using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Goval.FacturaDigital.DataContracts.Utils;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Goval.FacturaDigital.DataContracts.BaseModel;

namespace Goval.FacturaDigital.Core
{
    public class Utils
    {
        static MailAddress FromAddress = new MailAddress("goval.automatic@gmail.com", "Factura Goval APP");
        static string UserName = "goval.automatic";
        static string Password = "gomezvalverde5";

        #region NumberToName

        private String[] UNIDADES = { "", "un ", "dos ", "tres ", "cuatro ", "cinco ", "seis ", "siete ", "ocho ", "nueve " };
        private String[] DECENAS = {"diez ", "once ", "doce ", "trece ", "catorce ", "quince ", "dieciseis ",
        "diecisiete ", "dieciocho ", "diecinueve", "veinte ", "treinta ", "cuarenta ",
        "cincuenta ", "sesenta ", "setenta ", "ochenta ", "noventa "};
        private String[] CENTENAS = {"", "ciento ", "doscientos ", "trecientos ", "cuatrocientos ", "quinientos ", "seiscientos ",
        "setecientos ", "ochocientos ", "novecientos "};

        private Regex r;

        public String IntegerToWritten(String numero)
        {

            String literal = "";
            String parte_decimal;
            //si el numero utiliza (.) en lugar de (,) -> se reemplaza
            numero = numero.Replace(",", "");
            numero = numero.Replace(".", ",");
            //si el numero no tiene parte decimal, se le agrega ,00
            if (numero.IndexOf(",") == -1)
            {
                numero = numero + ",00";
            }
            //se valida formato de entrada -> 0,00 y 999 999 999,00
            r = new Regex(@"\d{1,9},\d{1,2}");
            MatchCollection mc = r.Matches(numero);
            if (mc.Count > 0)
            {
                //se divide el numero 0000000,00 -> entero y decimal
                String[] Num = numero.Split(',');

                //de da formato al numero decimal
                parte_decimal = Num[1] + "/100";

                //se convierte el numero a literal
                if (int.Parse(Num[0]) == 0)
                {//si el valor es cero                
                    literal = "cero ";
                }
                else if (int.Parse(Num[0]) > 999999)
                {//si es millon
                    literal = getMillones(Num[0]);
                }
                else if (int.Parse(Num[0]) > 999)
                {//si es miles
                    literal = getMiles(Num[0]);
                }
                else if (int.Parse(Num[0]) > 99)
                {//si es centena
                    literal = getCentenas(Num[0]);
                }
                else if (int.Parse(Num[0]) > 9)
                {//si es decena
                    literal = getDecenas(Num[0]);
                }
                else
                {//sino unidades -> 9
                    literal = getUnidades(Num[0]);
                }
                //devuelve el resultado en mayusculas o minusculas
                if (false)
                {
                    return (literal + " " + parte_decimal).ToUpper();
                }
                else
                {
                    return (literal + " " + parte_decimal);
                }
            }
            else
            {//error, no se puede convertir
                return literal = "";
            }
        }

        /* funciones para convertir los numeros a literales */

        private String getUnidades(String numero)
        {   // 1 - 9            
            //si tuviera algun 0 antes se lo quita -> 09 = 9 o 009=9
            String num = numero.Substring(numero.Length - 1);
            return UNIDADES[int.Parse(num)];
        }

        private String getDecenas(String num)
        {// 99                        
            int n = int.Parse(num);
            if (n < 10)
            {//para casos como -> 01 - 09
                return getUnidades(num);
            }
            else if (n > 19)
            {//para 20...99
                String u = getUnidades(num);
                if (u.Equals(""))
                { //para 20,30,40,50,60,70,80,90
                    return DECENAS[int.Parse(num.Substring(0, 1)) + 8];
                }
                else
                {
                    return DECENAS[int.Parse(num.Substring(0, 1)) + 8] + "y " + u;
                }
            }
            else
            {//numeros entre 11 y 19
                return DECENAS[n - 10];
            }
        }

        private String getCentenas(String num)
        {// 999 o 099
            if (int.Parse(num) > 99)
            {//es centena
                if (int.Parse(num) == 100)
                {//caso especial
                    return " cien ";
                }
                else
                {
                    return CENTENAS[int.Parse(num.Substring(0, 1))] + getDecenas(num.Substring(1));
                }
            }
            else
            {//por Ej. 099 
                //se quita el 0 antes de convertir a decenas
                return getDecenas(int.Parse(num) + "");
            }
        }

        private String getMiles(String numero)
        {// 999 999
            //obtiene las centenas
            String c = numero.Substring(numero.Length - 3);
            //obtiene los miles
            String m = numero.Substring(0, numero.Length - 3);
            String n = "";
            //se comprueba que miles tenga valor entero
            if (int.Parse(m) > 0)
            {
                n = getCentenas(m);
                return n + "mil " + getCentenas(c);
            }
            else
            {
                return "" + getCentenas(c);
            }

        }

        private String getMillones(String numero)
        { //000 000 000        
            //se obtiene los miles
            String miles = numero.Substring(numero.Length - 6);
            //se obtiene los millones
            String millon = numero.Substring(0, numero.Length - 6);
            String n = "";
            if (Convert.ToInt32(millon) > 1)
            {
                n = getCentenas(millon) + "millones ";
            }
            else
            {
                n = getUnidades(millon) + "millon ";
            }
            return n + getMiles(miles);
        }

        #endregion


        public static string GenerateDocumentKey(DataContracts.MobileModel.Bill pBill, DataContracts.MobileModel.User pUser, string pDocumentType)
        {
            string vCountryCode = "506";

            //Date Set
            string vDateString = DateTime.Now.ToString("ddMMyy");

            // Identification
            string vIdentification = pUser.UserLegalNumber.PadLeft(12,'0');

            // BIll ConsecutiveNumber
            // https://tribunet.hacienda.go.cr/tribunet/docs/esquemas/2016/v4.2/ResolucionComprobantesElectronicosDGT-R-48-2016_4.2.pdf
            string vConsecutiveNumber = "001"+"00001"+ pDocumentType + pBill.ConsecutiveNumber.ToString().PadLeft(10, '0');

            //Situacion del Comprobante Electronico
            string vElectronicVoucher = "1";  

            //Security Code
            string vSecurityCode = "1".PadLeft(8,'0');  // Es un codigo de seguridad interno


            string vResultKey = vCountryCode+ vDateString+ vIdentification+ vConsecutiveNumber+ vElectronicVoucher+ vSecurityCode;

            return vResultKey;
        }

        public static BaseResponse SendMail(String pSubject, String pBody, List<string> pCopyEmails, List<AttachmentMail> pAttachments = null, Boolean pIsHtmlBody = false)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            BaseResponse vResponse = new BaseResponse();

            try
            {
                mail.From = FromAddress;
                if (pCopyEmails != null && pCopyEmails.Any())
                {
                    foreach (var address in pCopyEmails)
                    {
                        mail.To.Add(address);
                    }
                }


                if (pAttachments != null && pAttachments.Any())
                {
                    foreach (var attachment in pAttachments)
                    {
                        Attachment newAttachment = new Attachment(attachment.FileData, attachment.FileName);
                        mail.Attachments.Add(newAttachment);
                    }
                }

                mail.Subject = pSubject;
                mail.Body = pBody;
                mail.IsBodyHtml = pIsHtmlBody;
                SmtpServer.Port = 587;  //gmail default port
                SmtpServer.Credentials = new System.Net.NetworkCredential(UserName, Password);
                SmtpServer.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
                SmtpServer.Send(mail);
                vResponse.IsSuccessful = true;
            }

            catch (Exception vEx)
            {
                vResponse.IsSuccessful = false;
                vResponse.UserMessage = vEx.Message;
                vResponse.TechnicalMessage = vEx.ToString();

            }
            return vResponse;
        }
    }
}
