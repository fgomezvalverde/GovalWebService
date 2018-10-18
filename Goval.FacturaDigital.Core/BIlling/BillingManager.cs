using BitOne.FE.BLL;
using BitOne.FE.EN;
using Goval.FacturaDigital.DataContracts.BaseModel;
using Goval.FacturaDigital.DataContracts.MobileModel;
using Goval.FacturaDigital.DataContracts.Utils;
using Goval.FacturaDigital.DataModel;
using Newtonsoft.Json;
using Syncfusion.ExcelToPdfConverter;
using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Goval.FacturaDigital.Core.BIlling
{
    public static class BillingManager
    {
        private const string UrlhaciendaAuthApiDesarrollo = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/";
        private const string UrlhaciendaAuthApiProduccion = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut/protocol/openid-connect/";
        private const string UrlhaciendaApiProduccion = "https://api.comprobanteselectronicos.go.cr/recepcion/v1/";
        private const string UrlhaciendaApiDesarrollo = "https://api.comprobanteselectronicos.go.cr/recepcion-sandbox/v1/";

        private static int MaxRetryCount = 100;

        private const string AcceptedHTTPCode = "202";

        private const string BillingMailSubjectFormat = "Nueva Factura Electronica - {0} - Factura N° {1}";
        private const string XMLNameSendedToHaciendaFormat = "XMLEnviadoHaciendaNumero{0}.xml";
        private const string XMLNameReceivedToHaciendaFormat = "XMLRecibidoHaciendaNumero{0}.xml";
        private const string PDFBillNameFormat = "Factura{0}.pdf";

        static Dictionary<string, string> SellConditions = new Dictionary<string, string>()
                {
                    {"01","Contado"},
                    {"02","Crédito"},
                    {"03","Consignación"},
                    {"04","Apartado"},
                    {"05","Arrendamiento con opción de compra"},
                    {"06","Arrendamiento en función financiera"},
                    {"99","Otros"}
                };
        public static BaseResponse TryToRefreshBillStatus(ref BillEntity pBill)
        {
            BaseResponse vResponse = new BaseResponse { IsSuccessful = false };
            try
            {
                var vServicioBLL = new ServicioBLL();
                var vTributacionBLL = new TributacionBLL();
                var vUsuarioHacienda = new UsuarioHacienda();

                // Datos de Hacienda
                vUsuarioHacienda.username = pBill.Client.User.HaciendaUsername;
                vUsuarioHacienda.password = pBill.Client.User.HaciendaPassword;
                vUsuarioHacienda.Pin = pBill.Client.User.HaciendaCryptographicPIN;
                vUsuarioHacienda.Certificado = pBill.Client.User.HaciendaCryptographicFile;
                vUsuarioHacienda.modalidadProduccion = false;
                vUsuarioHacienda.urlhaciendaAuthApiDesarrollo = UrlhaciendaAuthApiDesarrollo;
                vUsuarioHacienda.urlhaciendaAuthApiProduccion = UrlhaciendaAuthApiProduccion;
                vUsuarioHacienda.urlhaciendaApiDesarrollo = UrlhaciendaApiDesarrollo;
                vUsuarioHacienda.urlhaciendaApiProduccion = UrlhaciendaApiProduccion;


                var vReplyValidaCertificado = vServicioBLL.fValidarCertificado(vUsuarioHacienda);
                if (vReplyValidaCertificado.ok)
                {
                    var vReplyGeneraToken = vTributacionBLL.fGeneraToken(vUsuarioHacienda);
                    if (vReplyGeneraToken.ok && vReplyGeneraToken.contingencia == false)
                    {
                        Boolean vValidAnswer = false;
                        for (int vCounter = 0; vCounter < MaxRetryCount && !vValidAnswer; vCounter++)
                        {
                            var vReplyObtieneRespuesta = vTributacionBLL.fObtenerDocumento(vUsuarioHacienda, pBill.DocumentKey, vReplyGeneraToken.token);

                            pBill.ReasonPhraseGETHacienda = vReplyObtieneRespuesta.reasonPhraseGETHacienda;
                            pBill.StatusCodeGETHacienda = vReplyObtieneRespuesta.statusCodeGETHacienda;

                            if (vReplyObtieneRespuesta.ok)
                            {
                                pBill.XMLReceivedFromHacienda = vReplyObtieneRespuesta.xmlRespuesta;

                                switch (vReplyObtieneRespuesta.msg)
                                {
                                    case "ACEPTADO":

                                        pBill.SystemMesagges = "Documento: " + pBill.DocumentKey + " | POST Hacienda: True |  GET Hacienda: True | Descripción: ACEPTADO";
                                        vResponse.UserMessage = pBill.SystemMesagges;
                                        pBill.Status = BillStatus.Done.ToString();
                                        vResponse.IsSuccessful = true;
                                        vValidAnswer = true;
                                        break;

                                    case "RECHAZADO":
                                        pBill.SystemMesagges = "Documento: " + pBill.DocumentKey + " | POST Hacienda: True |  GET Hacienda: True | Descripción: RECHAZADO";
                                        vResponse.UserMessage = pBill.SystemMesagges;
                                        pBill.Status = BillStatus.Rejected.ToString();
                                        vResponse.IsSuccessful = false;
                                        vValidAnswer = true;
                                        break;


                                    case "PROCESANDO":

                                        pBill.SystemMesagges = "Documento: " + pBill.DocumentKey + " | POST Hacienda: True |  GET Hacienda: True | Descripción: PROCESANDO";
                                        pBill.Status = BillStatus.Processing.ToString();
                                        break;


                                    default:

                                        pBill.SystemMesagges = "Documento: " + pBill.DocumentKey + " | POST Hacienda: True |  GET Hacienda: True | Descripción: ERROR HACIENDA. CONTACTE A SOPORTE HACIENDA";
                                        pBill.Status = BillStatus.Error.ToString();
                                        break;

                                }
                            }
                            else
                            {
                                pBill.SystemMesagges = "Documento: " + pBill.DocumentKey + " | POST Hacienda: True | GET Hacienda: True | Descripción: " + vReplyObtieneRespuesta.msg;
                                pBill.Status = BillStatus.Error.ToString();
                            }
                            pBill.SystemMesagges = vReplyObtieneRespuesta.estado + "-" + pBill.SystemMesagges + string.Format("| REASON GET: {0} | REASON POST: {1}", pBill.ReasonPhraseGETHacienda, pBill.ReasonPhrasePOSTHacienda);
                        }
                    }
                    else
                    {
                        vResponse.UserMessage = vReplyGeneraToken.msg;
                        vResponse.TechnicalMessage = vReplyGeneraToken.msg;
                    }
                }
                else
                {
                    vResponse.UserMessage = vReplyValidaCertificado.msg;
                    vResponse.TechnicalMessage = vReplyValidaCertificado.msg;
                }
            }
            catch (Exception vEx)
            {
                vResponse.UserMessage = vEx.Message;
                vResponse.TechnicalMessage = vEx.ToString();
                vResponse.IsSuccessful = false;
            }
            return vResponse;
        }
        public static BaseResponse ProcessBill(ref BillEntity pBill, CreditOrDebitNoteEntity pDocumentReference)
        {
            BaseResponse vResponse = new BaseResponse {IsSuccessful= false };
            pBill.Status = BillStatus.Error.ToString();
            try
            {
                var vServicioBLL = new ServicioBLL();
                var vDocumentoEncabezado = new DocumentoEncabezado();
                var vUsuarioHacienda = new UsuarioHacienda();
                var vListaMedioPago = new List<DocumentoMedioPago>();
                var vDetalleDocumento = new List<DocumentoDetalle>();

                //Encabezado
                vDocumentoEncabezado.Clave = pBill.DocumentKey;
                vDocumentoEncabezado.TipoCambio = 1.00;
                vDocumentoEncabezado.Fecha = DateTime.Now;
                vDocumentoEncabezado.Moneda = "CRC";
                vDocumentoEncabezado.CondicionVenta = pBill.SellCondition ;
                vDocumentoEncabezado.PlazoCredito = string.IsNullOrEmpty(pBill.CreditTerm)?"0": pBill.CreditTerm;
                vDocumentoEncabezado.NormativaFechaResolucion = "20-02-2017 13:22:22";
                vDocumentoEncabezado.NormativaNumeroResolucion = "DGT-R-48-2016";
                vDocumentoEncabezado.Observacion = string.IsNullOrEmpty(pBill.Observation) ? string.Empty: pBill.Observation;
                vDocumentoEncabezado.SubTotal = Convert.ToDouble(pBill.SubTotalProducts);
                vDocumentoEncabezado.Descuento = Convert.ToDouble(pBill.DiscountAmount);
                vDocumentoEncabezado.Impuesto = Convert.ToDouble(pBill.TaxesToPay);
                vDocumentoEncabezado.DocumentoConsecutivo = pBill.ConsecutiveNumber+"";

                //Emisor
                vDocumentoEncabezado.Emisor.Identificacion = pBill.User.UserLegalNumber;
                vDocumentoEncabezado.Emisor.IdentificacionTipo = pBill.User.IdentificationType;
                vDocumentoEncabezado.Emisor.Direccion = pBill.User.LocationDescription;
                vDocumentoEncabezado.Emisor.CodigoPais = "506";
                vDocumentoEncabezado.Emisor.Provincia = pBill.User.ProvinciaCode;
                vDocumentoEncabezado.Emisor.Canton = pBill.User.CantonCode;
                vDocumentoEncabezado.Emisor.Distrito = pBill.User.DistritoCode;
                vDocumentoEncabezado.Emisor.Barrio = pBill.User.BarrioCode;
                vDocumentoEncabezado.Emisor.Nombre = pBill.User.Name;
                vDocumentoEncabezado.Emisor.NombreComercial =  string.IsNullOrEmpty(pBill.User.ComercialName)? string.Empty: pBill.User.ComercialName;
                vDocumentoEncabezado.Emisor.Telefono = pBill.User.PhoneNumber;
                vDocumentoEncabezado.Emisor.Fax = "00000000";
                vDocumentoEncabezado.Emisor.Email = pBill.User.Email;

                //Receptor
                vDocumentoEncabezado.Receptor.IdentificacionExtranjero = pBill.Client.ForeignIdentification;
                vDocumentoEncabezado.Receptor.Identificacion = pBill.Client.ClientLegalNumber;
                vDocumentoEncabezado.Receptor.IdentificacionTipo = pBill.Client.IdentificationType;
                vDocumentoEncabezado.Receptor.Direccion = pBill.Client.LocationDescription;
                vDocumentoEncabezado.Receptor.CodigoPais = "506";
                vDocumentoEncabezado.Receptor.Provincia = pBill.Client.ProvinciaCode;
                vDocumentoEncabezado.Receptor.Canton = pBill.Client.CantonCode;
                vDocumentoEncabezado.Receptor.Distrito = pBill.Client.DistritoCode;
                vDocumentoEncabezado.Receptor.Barrio = pBill.Client.BarrioCode;
                vDocumentoEncabezado.Receptor.Nombre = pBill.Client.Name;
                vDocumentoEncabezado.Receptor.NombreComercial = pBill.Client.ComercialName;
                vDocumentoEncabezado.Receptor.Telefono = pBill.Client.PhoneNumber;
                vDocumentoEncabezado.Receptor.Fax = "00000000";
                vDocumentoEncabezado.Receptor.Email = pBill.Client.Email;

                //Medio de Pago
                var vMedioDePago = new DocumentoMedioPago();
                vMedioDePago.Codigo = pBill.PaymentMethod;
                vListaMedioPago.Add(vMedioDePago);
                vDocumentoEncabezado.MedioPago = vListaMedioPago;

                var vListaProductos = JsonConvert.DeserializeObject<Client>(pBill.SoldProductsJSON);
                foreach (var vProducto in vListaProductos.ClientProducts)
                {
                    if (vProducto.ProductQuantity > 0)
                    {
                        //Detalle del Producto
                        decimal vProductTotal = vProducto.Price * vProducto.ProductQuantity;
                        var vLinea = new DocumentoDetalle();
                        vLinea.Cantidad = vProducto.ProductQuantity;
                        vLinea.Nombre = vProducto.Name;
                        vLinea.Descripcion = vProducto.Description;
                        vLinea.Codigo = vProducto.ProductCode;
                        vLinea.Tipo = vProducto.ProductType;
                        vLinea.Unidad = vProducto.MeasurementUnit;
                        vLinea.UnidadMedidaComercial = string.IsNullOrEmpty(vProducto.MeasurementUnitType)?string.Empty: vProducto.MeasurementUnitType;
                        vLinea.EsProducto = true;
                        vLinea.Precio = Convert.ToDouble(vProducto.Price);
                        vLinea.Descuento = Convert.ToDouble((vProductTotal / 100) *pBill.Client.DefaultDiscountPercentage);
                        vLinea.DescuentoDescripcion = string.IsNullOrEmpty(pBill.DiscountNature) ? string.Empty : pBill.DiscountNature;
                        if (pBill.Client.DefaultTaxesPercentage > 0)
                        {
                            

                            // Impuestos
                            var vLineaListaImpuesto = new List<DocumentoDetalleImpuesto>();
                            var vLineaImpuesto = new DocumentoDetalleImpuesto();
                            vLineaImpuesto.Tipo = pBill.TaxCode;
                            vLineaImpuesto.Tarifa = Convert.ToDouble(pBill.Client.DefaultTaxesPercentage);
                            vLineaImpuesto.Monto = 
                                Convert.ToDouble(((vProductTotal - Convert.ToDecimal(vLinea.Descuento)) / 100) * pBill.Client.DefaultTaxesPercentage);
                            vLineaListaImpuesto.Add(vLineaImpuesto);
                            // Se agrega el impuesto a Lista
                            vLinea.DocumentoDetalleImpuesto = vLineaListaImpuesto;
                        }

                        // Se agrega el Producto completo a todos los demas
                        vDetalleDocumento.Add(vLinea);
                    }
                    else
                    {
                        // El producto no tiene ninguna cantidad a facturar
                    }
                }

                //Se agrega referencia si es que existe
                if (pDocumentReference != null)
                {
                    var vReferenceList = new List<DocumentoReferencia>();
                    var vReferenceDoc = new DocumentoReferencia();

                    vReferenceDoc.Codigo = pDocumentReference.ReferenceCode;
                    vReferenceDoc.FechaEmision = pDocumentReference.EmissionDate;
                    vReferenceDoc.Numero = pDocumentReference.DocuementKey;
                    vReferenceDoc.Razon = pDocumentReference.ReasonDescription;
                    vReferenceDoc.TipoDoc = HaciendaTransactionType.Factura_Electronica;

                    vReferenceList.Add(vReferenceDoc);
                    vDocumentoEncabezado.Referencia = vReferenceList;
                }

                // Se agrega el Segmento de todos los productos
                vDocumentoEncabezado.DocumentoDetalle = vDetalleDocumento;

                // Datos de Hacienda
                vUsuarioHacienda.username = pBill.Client.User.HaciendaUsername;
                vUsuarioHacienda.password = pBill.Client.User.HaciendaPassword;
                vUsuarioHacienda.Pin = pBill.Client.User.HaciendaCryptographicPIN;
                vUsuarioHacienda.Certificado = pBill.Client.User.HaciendaCryptographicFile;
                vUsuarioHacienda.modalidadProduccion = false;
                vUsuarioHacienda.urlhaciendaAuthApiDesarrollo = UrlhaciendaAuthApiDesarrollo;
                vUsuarioHacienda.urlhaciendaAuthApiProduccion = UrlhaciendaAuthApiProduccion;
                vUsuarioHacienda.urlhaciendaApiDesarrollo = UrlhaciendaApiDesarrollo;
                vUsuarioHacienda.urlhaciendaApiProduccion = UrlhaciendaApiProduccion;

                var vReply = vServicioBLL.fGenerarDocumento(vDocumentoEncabezado, vUsuarioHacienda, MaxRetryCount);
                if (vReply != null)
                {
                    // try to save the Sended XML always
                    if (!string.IsNullOrEmpty(vReply.xmlDocumento))
                    {
                        pBill.XMLSendedToHacienda = vReply.xmlDocumento;
                    }

                    if (!string.IsNullOrEmpty(vReply.xmlRespuesta))
                    {
                        Regex vRegex = new Regex("<DetalleMensaje>(.+)</DetalleMensaje>");
                        string msgWithoutChangeLines = Regex.Replace(vReply.xmlRespuesta, "\r\n?|\n", "");
                        var vMatch = vRegex.Match(msgWithoutChangeLines);
                        if (vMatch.Success)
                        {
                            pBill.SystemMesagges = vReply.estado + "-" + vReply.msg + vMatch.Value;
                        }
                        else
                        {
                            pBill.SystemMesagges = vReply.estado + "-" + vReply.msg;
                        }
                        
                    }
                    else
                    {
                        pBill.SystemMesagges = vReply.estado + "-" + vReply.msg + 
                            string.Format("| REASON GET: {0} | REASON POST: {1}",vReply.reasonPhraseGETHacienda,vReply.reasonPhrasePOSTHacienda);
                    }
                    
                    
                    if (vReply.ok)
                    {
                        
                        if (!string.IsNullOrEmpty(vReply.xmlRespuesta))
                        {
                            pBill.XMLReceivedFromHacienda = vReply.xmlRespuesta;
                        }
                        switch (vReply.estado)
                        {
                            case BillStatusHacienda.Aceptada:
                                pBill.Status = BillStatus.Done.ToString();
                                vResponse.IsSuccessful = true;
                                break;
                            case BillStatusHacienda.Rechazada:
                                pBill.Status = BillStatus.Rejected.ToString();
                                vResponse.IsSuccessful = false;
                                break;
                            case BillStatusHacienda.Procesando:
                                pBill.Status = BillStatus.Processing.ToString();
                                vResponse.IsSuccessful = false;
                                break;
                            default:
                                pBill.Status = BillStatus.Error.ToString();
                                vResponse.IsSuccessful = false;
                                break;
                        }

                        if (string.IsNullOrEmpty(pBill.SystemMesagges))
                        {
                            pBill.SystemMesagges = pBill.Status + vReply.msg;
                        }
                        vResponse.UserMessage = pBill.SystemMesagges;
                        
                    }
                    else {
                        if (string.IsNullOrEmpty(pBill.Status))
                        {
                            pBill.Status = BillStatus.Error.ToString();
                        }
                        if(string.IsNullOrEmpty(pBill.SystemMesagges))
                        {
                            pBill.SystemMesagges = "Error." + "La respuesta no fue positiva:" + vReply.msg;
                        }


                        if (string.IsNullOrEmpty(vReply.statusCodePOSTHacienda) || !vReply.statusCodePOSTHacienda.Equals(AcceptedHTTPCode))
                        {
                            if (!string.IsNullOrEmpty(vReply.msg) && vReply.msg.Contains("ya fue recibido anteriormente"))
                            {
                                pBill.Status = BillStatus.Processing.ToString();
                            }
                            else
                            {
                                pBill.Status = BillStatus.Error.ToString();
                            }
                            
                        }
                        else
                        {
                                pBill.Status = BillStatus.Processing.ToString();
                        }
                        pBill.ReasonPhraseGETHacienda = vReply.reasonPhraseGETHacienda;
                        pBill.ReasonPhrasePOSTHacienda = vReply.reasonPhrasePOSTHacienda;

                        pBill.StatusCodeGETHacienda = vReply.statusCodeGETHacienda;
                        pBill.StatusCodePOSTHacienda = vReply.statusCodePOSTHacienda;

                        vResponse.IsSuccessful = false;
                        vResponse.UserMessage = pBill.SystemMesagges;
                    }

                }
                else
                {
                    pBill.SystemMesagges = "No se recibio respuesta de hacienda";
                    vResponse.UserMessage = "Error." + "No se recibio respuesta de hacienda";
                    pBill.Status = BillStatus.Error.ToString();
                }

                pBill.HaciendaFailCounter++;
            }
            catch (Exception ex)
            {
                vResponse.UserMessage = ex.Message;
                vResponse.TechnicalMessage = ex.ToString();
                vResponse.IsSuccessful = false;
            }

            return vResponse;
        }

        public static byte[] GenerateBillPDF(Bill pBill, User pUser)
        {
            var values = new Dictionary<string, string>();

            //Products Values
            for (int cont = 0; cont < pBill.SoldProductsJSON?.ClientProducts?.Count; cont++)
            {
                if (pBill.SoldProductsJSON.ClientProducts[cont].ProductQuantity > 0)
                {
                    values.Add("productAmount" + cont,
                        pBill.SoldProductsJSON.ClientProducts[cont].ProductQuantity + "");

                    values.Add("productBarCode" + cont,
                        pBill.SoldProductsJSON.ClientProducts[cont].ProductCode);

                    values.Add("productType" + cont,
                        pBill.SoldProductsJSON.ClientProducts[cont].ProductType);

                    values.Add("productDescription" + cont,
                        pBill.SoldProductsJSON.ClientProducts[cont].Description);

                    values.Add("productPrice" + cont, "¢" +
                        FormatNumericToString(pBill.SoldProductsJSON.ClientProducts[cont].Price));

                    values.Add("productTotalCost" + cont, "¢" +
                        FormatNumericToString(pBill.SoldProductsJSON.ClientProducts[cont].ProductQuantity *
                          pBill.SoldProductsJSON.ClientProducts[cont].Price));

                }




            }
            //User Info
            values.Add("userName",
                    pUser.Name);
            values.Add("userPhone",
                    pUser.PhoneNumber);
            values.Add("userEmail",
                    pUser.Email);
            values.Add("userLegalNumber",
                    pUser.UserLegalNumber);
            values.Add("userDirection",
                    pUser.LocationDescription);


            //Client Info
            values.Add("clientName",
                    pBill.SoldProductsJSON.Name);
            values.Add("clientDirection",
                    pBill.SoldProductsJSON.LocationDescription);
            values.Add("clientTelephone",
                    pBill.SoldProductsJSON.PhoneNumber);
            values.Add("clientEmail",
                    pBill.SoldProductsJSON.Email);
            values.Add("clientLegalId",
                    pBill.SoldProductsJSON.ClientLegalNumber);
            values.Add("clientDiscount",
                string.Format("DESCUENTO({0}%)", pBill.SoldProductsJSON.DefaultDiscountPercentage));
            values.Add("clientTaxes",
                string.Format("IMPUESTO VENTAS({0}%)", pBill.SoldProductsJSON.DefaultTaxesPercentage));


            if (pBill.SellCondition.Equals("02")) //{"02","Crédito"}
            {
                int daysTerm = Convert.ToInt32(pBill.CreditTerm);
                values.Add("clientTerm",
                   daysTerm + " dias");

                values.Add("billExpiration",
                    pBill.EmissionDate?.AddDays(daysTerm).ToString("d", new CultureInfo("pt-BR")));
            }
            else
            {
                values.Add("clientTerm",
                   SellConditions[pBill.SellCondition]);
            }



            //Bill Info
            values.Add("billDate",
                    pBill.EmissionDate?.ToString("d", new CultureInfo("pt-BR")));
            values.Add("billPurchaseOrder",
                    pBill.PurchaseOrderCode);
            values.Add("billId",
                    "N° " + pBill.ConsecutiveNumber);
            values.Add("billTotalProducts",
                    "¢" + FormatNumericToString(pBill.SubTotalProducts));
            values.Add("billDescountAmount",
                    "¢" + FormatNumericToString(pBill.DiscountAmount));
            values.Add("billTotalAfterDescount",
                    "¢" + FormatNumericToString(pBill.TotalAfterDiscount));
            values.Add("billTaxesAmount",
                    "¢" + FormatNumericToString(pBill.TaxesToPay));
            values.Add("billTotal",
                    "¢" + FormatNumericToString(pBill.TotalToPay));

            values.Add("documentKey", pBill.DocumentKey);

            Utils util = new Utils();
            
            values.Add("billTotalInText",
                   util.IntegerToWritten((FormatNumericToString(pBill.TotalToPay))));

            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            var path = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            var finalPath = Path.Combine(path, @"Files/DefaultInvoices/FacturaGovalFormatoOriginal.xlsx");
            IWorkbook workbook = application.Workbooks.Open(finalPath);
            IWorksheet sheet = workbook.Worksheets[0];

            foreach (Syncfusion.XlsIO.Implementation.NameImpl namedVariable in workbook.Names)
            {
                string value = "";
                if (values.TryGetValue(namedVariable.Address, out value))
                {
                    sheet.Range[namedVariable.AddressLocal].Text = value;
                }
                else
                {
                    Console.WriteLine("ERROR", "ESTO NO PUEDE PASAR");
                }
            }

            ExcelToPdfConverter converter = new ExcelToPdfConverter(workbook);

            //Initialize PDF Document

            PdfDocument pdfDocument = new PdfDocument();

            pdfDocument = converter.Convert();
            byte[] vResult = null;
            using (MemoryStream vTemporalPDFStream = new MemoryStream())
            {
                pdfDocument.Save(vTemporalPDFStream);
                vResult = vTemporalPDFStream.ToArray();
            }
            
            workbook.Close();
            pdfDocument.Dispose();
            return vResult;
        }

        public static BaseResponse SendMailFromSuccessfulyBillTransaction(BillEntity pBill, User pUser, byte[] pBillPdf)
        {
            BaseResponse vResponse = new BaseResponse();
            try
            {
                string uUserOficialName = pUser.Name;
                string vUserMail = pUser.Email;
                string vClientMail = pBill.Client.Email;
                string vSubject = string.Format(BillingMailSubjectFormat, uUserOficialName, pBill.ConsecutiveNumber+"");
                List<string> vClientsList = new List<string>() { vClientMail };

                var path = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
                var finalPath = Path.Combine(path, @"Files/DefaultHTMLEmail/MailTemplate.html");

                var vBody = System.IO.File.ReadAllText(finalPath);

                vBody = vBody.Replace("$NOMBRE_CLIENTE$", uUserOficialName);
                vBody = vBody.Replace("$NUMERO_FACTURA$", pBill.ConsecutiveNumber + "");
                vBody = vBody.Replace("$MONTO_TOTAL$", pBill.TotalToPay+"");
                vBody = vBody.Replace("$FECHA$", DateTime.Now.ToString());
                vBody = vBody.Replace("$TELEFONO$", pUser.PhoneNumber);

                XmlDocument vXMLSendedToHacienda = new XmlDocument();
                vXMLSendedToHacienda.LoadXml(pBill.XMLSendedToHacienda);

                Stream vStreamSendedToHacienda = new MemoryStream();
                vXMLSendedToHacienda.Save(vStreamSendedToHacienda);
                vStreamSendedToHacienda.Flush();
                vStreamSendedToHacienda.Position = 0;


                XmlDocument vXMLReceivedFromHacienda = new XmlDocument();
                vXMLReceivedFromHacienda.LoadXml(pBill.XMLReceivedFromHacienda);
                Stream vStreamReceivedFromHacienda = new MemoryStream();
                vXMLReceivedFromHacienda.Save(vStreamReceivedFromHacienda);
                vStreamReceivedFromHacienda.Flush();
                vStreamReceivedFromHacienda.Position = 0;

                Stream vStreamBillPDF = new MemoryStream(pBillPdf);

                List<AttachmentMail> vAttachments = new List<AttachmentMail>()
                {
                    new AttachmentMail{
                        FileName = string.Format(XMLNameSendedToHaciendaFormat,pBill.ConsecutiveNumber + ""),
                        FileData = vStreamSendedToHacienda
                    },
                    new AttachmentMail{
                        FileName = string.Format(XMLNameReceivedToHaciendaFormat,pBill.ConsecutiveNumber + ""),
                        FileData = vStreamReceivedFromHacienda
                    },
                    new AttachmentMail{
                        FileName = string.Format(PDFBillNameFormat,pBill.ConsecutiveNumber + ""),
                        FileData = vStreamBillPDF
                    }
                };

                var vResponseFromEmail = Utils.SendMail(vSubject, vBody, vClientsList, vAttachments, true);
                if (vResponseFromEmail.IsSuccessful)
                {
                    vResponse.IsSuccessful = true;
                }
                else
                {
                    vResponse.TechnicalMessage = vResponseFromEmail.TechnicalMessage;
                    vResponse.UserMessage = vResponseFromEmail.UserMessage;
                    vResponse.IsSuccessful = false;
                }

                vStreamSendedToHacienda.Dispose();
                vStreamReceivedFromHacienda.Dispose();
                vStreamBillPDF.Dispose();
                vAttachments = null;

               
            }
            catch (Exception vEx)
            {
                vResponse.IsSuccessful = false;
                vResponse.UserMessage = vEx.Message;
                vResponse.TechnicalMessage = vEx.ToString();
            }
            return vResponse;
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static string FormatNumericToString(decimal pNumber)
        {
            string result = pNumber.ToString("0,0.00", CultureInfo.InvariantCulture);


            return result;
        }
        public static string FormatNumericToString(double pNumber)
        {
            string result = pNumber.ToString("0,0.00", CultureInfo.InvariantCulture);


            return result;
        }
    }
}
