Imports BitOne.FE.BLL
Imports BitOne.FE.EN
Imports BitOne.FE.Resources
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml

Public Class ServicioBLL

    Private vDocumentoBLL As DocumentoBLL
    Private vTributacionBLL As TributacionBLL

    Public Sub New()
        vDocumentoBLL = New DocumentoBLL
        vTributacionBLL = New TributacionBLL
    End Sub


    ''' <summary>
    ''' Esta función se utiliza para validar, enviar hacienda y al proveedor
    ''' la respuesta
    ''' </summary>
    ''' <param name="pXmlProveedor"></param>
    ''' <param name="pRespuesta"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fRegistraRecepcion(pDocumento As DocumentoEncabezado, pUsuarioHacienda As UsuarioHacienda,
                                       pXmlProveedor As XmlDocument, pRespuesta As String, pIntentosRecepcion As Integer) As Reply

        Dim vReply As New Reply
        Dim vReplyValidacion As New Reply
        Dim vReplyAcuse As New Reply
        Dim vReplyGeneraXML As New Reply
        Dim vReplyValidaCertificado As New Reply
        Dim vReplyGeneraToken As New Reply
        Dim vReplyFirmaXML As New Reply
        Dim vReplyEnvioHacienda As New Reply
        Dim vReplyObtieneRespuesta As New Reply
        Dim vClaveXMLProveedor As String = String.Empty
        Dim vDocCondicion As String = String.Empty
        Dim vCommon As New Common
        Dim vConsecutivoReceptor As String = String.Empty
        Dim vHaciendaDocumento As New EN.BitOne.FE.EN.Hacienda.HaciendaDocumento()

        Try


            ' Inicializa los datos
            vReply.contingencia = False
            vReply.ok = False
            vReply.msg = String.Empty
            vReply.xmlDocumento = Nothing
            vReply.xmlRespuesta = Nothing
            vReply.estado = "ERROR"
            vReply.reasonPhraseGETHacienda = String.Empty
            vReply.reasonPhrasePOSTHacienda = String.Empty

            ' Valida que el existe un XML
            If (pXmlProveedor Is Nothing) Then

                vReply.msg = "Ingrese un documento XML."
                vReply.ok = False
                vReply.estado = "ERROR"
                Return vReply

            End If

            ' Obtiene datos
            Dim VDocumento As XElement = XElement.Parse(pXmlProveedor.InnerXml)
            Dim vNameSpace As XNamespace = VDocumento.Attribute("xmlns").Value

            ' Si el elemento no existe
            If (vNameSpace Is Nothing) Then

                vReply.msg = "El XML recibido por el proveedor es invalido. Imposible de leer."
                vReply.estado = "ERROR"
                Return vReply

            End If

            ' Existe el nodo clave
            If VDocumento.Element(vNameSpace + "Clave") Is Nothing Then

                vReply.msg = "El XML recibido por el proveedor es invalido. Imposible de leer la clave."
                vReply.estado = "ERROR"
                Return vReply

            End If

            ' Asigna la clave
            vClaveXMLProveedor = VDocumento.Element(vNameSpace + "Clave")

            ' Si el detalle es mayor de 80 Caracteres
            If (pDocumento.Observacion.Length > 80) Then

                vReply.msg = "El detalle del documento respuesta es mayor de 80 caracteres."
                vReply.estado = "ERROR"
                Return vReply

            End If

            ' Obtiene la condición 
            vDocCondicion = pDocumento.Clave.Substring(41, 1)

            ' Valida documento emitido por el proveedor
            vReplyValidacion = vDocumentoBLL.fValidarDocumentoRecepcion(pDocumento, pXmlProveedor, vClaveXMLProveedor)

            ' Si el documento es invalido
            If vReplyValidacion.ok = False Then

                vReply.msg = vReplyValidacion.msg
                Return vReply

            End If

            ' Asigna datos del receptor
            ' Los datos del proveedor
            pDocumento.Receptor.Identificacion = VDocumento.Element(vNameSpace + "Emisor").Element(vNameSpace + "Identificacion").Element(vNameSpace + "Numero").Value
            pDocumento.Receptor.IdentificacionTipo = VDocumento.Element(vNameSpace + "Emisor").Element(vNameSpace + "Identificacion").Element(vNameSpace + "Tipo").Value

            ' Si CONDICION DOCUMENTO = NORMAL
            If vDocCondicion <> Diccionario.SituacionNormal Then

                vReply.contingencia = False
                vReply.msg = "Para la generación de la respuesta esté complemento solamente admite estado NORMAL"
                vReply.estado = "ERROR"
                Return vReply

            End If

            ' Genera token
            vReplyGeneraToken = vTributacionBLL.fGeneraToken(pUsuarioHacienda)

            ' Si el Token es invalido
            If vReplyGeneraToken.ok = False Then

                vReply.msg = vReplyGeneraToken.msg
                Return vReply

            End If

            ' Obtiene acuse de recibo de Hacienda
            vReplyAcuse = fHaciendaRespuestaDocumento(vClaveXMLProveedor, pUsuarioHacienda, vReplyGeneraToken)


            ' Si ocurrió un error al traer el acuse de recibo
            If vReplyAcuse.ok = False Then

                vReply.msg = "El Documento XML recibo de su proveedor no puede ser consultado en Hacienda"
                Return vReply

            End If

            If vReplyAcuse.ok And vReplyAcuse.estado = "ACEPTADO" Then

                ' Validar Certificado
                vReplyValidaCertificado = vTributacionBLL.fValidarCertificado(pUsuarioHacienda)

                ' Si el certificado es invalido
                If vReplyValidaCertificado.ok = False Then

                    vReply.msg = vReplyValidaCertificado.msg
                    Return vReply

                End If

                ' Genera XML de respuesta
                vReplyGeneraXML = vDocumentoBLL.fGenerarXMLMensajeReceptor(pDocumento, pRespuesta, pXmlProveedor)

                ' Si el archivo XML no se genero
                If vReplyGeneraXML.ok = False Then

                    vReply.msg = vReplyGeneraXML.msg
                    Return vReply

                Else
                    vReply.xmlDocumento = vReplyGeneraXML.xmlDocumento
                End If

                ' Firma el XML
                vReplyFirmaXML = vTributacionBLL.fFirmarDocumento(pUsuarioHacienda, vReplyGeneraXML.xmlDocumento)

                ' Si el archivo XML no se firmo
                If vReplyFirmaXML.ok = False Then

                    vReply.msg = vReplyFirmaXML.msg
                    Return vReply

                Else
                    vReply.xmlDocumento = vReplyFirmaXML.xmlDocumento
                End If


                ' Asigna datos del Objeto Hacienda Documento
                vHaciendaDocumento.clave = vClaveXMLProveedor
                vHaciendaDocumento.fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz")
                vHaciendaDocumento.emisor = New EN.BitOne.FE.EN.Hacienda.emisor With {.numeroIdentificacion = pDocumento.Emisor.Identificacion.PadLeft(12, "0"),
                                                                                      .tipoIdentificacion = pDocumento.Emisor.IdentificacionTipo}
                vHaciendaDocumento.receptor = New EN.BitOne.FE.EN.Hacienda.receptor With {.numeroIdentificacion = pDocumento.Receptor.Identificacion.PadLeft(12, "0"),
                                                                                          .tipoIdentificacion = pDocumento.Receptor.IdentificacionTipo}

                vHaciendaDocumento.comprobanteXml = vCommon.Encrypt(vReply.xmlDocumento)
                vHaciendaDocumento.consecutivoReceptor = pDocumento.Clave.Substring(21, 20) ' Clave generada para la respuesta


                ' 6- Envia documento a Hacienda
                vReplyEnvioHacienda = vTributacionBLL.fEnvioDocumento(vHaciendaDocumento, pUsuarioHacienda, vReplyGeneraToken.token)

                ' Asigna respuesta Hacienda
                vReply.reasonPhrasePOSTHacienda = vReplyEnvioHacienda.reasonPhrasePOSTHacienda
                vReply.statusCodePOSTHacienda = vReplyEnvioHacienda.statusCodePOSTHacienda

                ' Si no se envió el XML con éxito
                If vReplyEnvioHacienda.ok = False Then
                    vReply.msg = vReplyEnvioHacienda.msg
                    Return vReply
                End If

                ' Recorre la cantidad de intentos
                Dim vIntentos As Integer = 1
                While vIntentos <= pIntentosRecepcion

                    ' Obtiene la respuesta de Hacienda
                    vReplyObtieneRespuesta = vTributacionBLL.fObtenerDocumento(pUsuarioHacienda, vClaveXMLProveedor & "-" & pDocumento.Clave.Substring(21, 20), vReplyGeneraToken.token)

                    ' Asigna respuesta Hacienda
                    vReply.reasonPhraseGETHacienda = vReplyObtieneRespuesta.reasonPhraseGETHacienda
                    vReply.statusCodeGETHacienda = vReplyObtieneRespuesta.statusCodeGETHacienda

                    ' Si el documento se proceso
                    If vReplyObtieneRespuesta.ok Then

                        ' Asigna el Xml respuesta de Hacienda
                        vReply.xmlRespuesta = vReplyObtieneRespuesta.xmlRespuesta

                        ' Respuesta de Hacienda
                        Select Case vReplyObtieneRespuesta.msg
                            Case "ACEPTADO"

                                vReply.msg = "Documento: " & pDocumento.Clave & " | POST Hacienda: True |  GET Hacienda: True | Descripción: ACEPTADO"
                                vReply.ok = True
                                vReply.estado = "ACEPTADO"
                                Return vReply

                            Case "RECHAZADO"

                                vReply.msg = "Documento: " & pDocumento.Clave & " | POST Hacienda: True |  GET Hacienda: True | Descripción: RECHAZADO"
                                vReply.ok = True
                                vReply.estado = "RECHAZADO"
                                Return vReply

                            Case "PROCESANDO"

                                vReply.msg = "Documento: " & pDocumento.Clave & " | POST Hacienda: True |  GET Hacienda: True | Descripción: PROCESANDO"
                                vReply.estado = "PROCESANDO"
                                vReply.ok = True

                            Case Else

                                vReply.msg = "Documento: " & pDocumento.Clave & " | POST Hacienda: True |  GET Hacienda: True | Descripción: ERROR HACIENDA. CONTACTE A SOPORTE HACIENDA"
                                vReply.ok = False

                        End Select

                    Else
                        vReply.msg = "Documento: " & pDocumento.Clave & " | POST Hacienda: True | GET Hacienda: True | Descripción: " & vReplyObtieneRespuesta.msg
                        vReply.ok = False
                        Return vReply
                    End If

                    vIntentos = vIntentos + 1

                End While

            Else

                vReply.msg = "El XML recibido del proveedor es invalido. No se encuentra ACEPTADO por Hacienda. (" + vReplyAcuse.estado + ")"
                vReply.ok = False
                vReply.estado = "ERROR"
                Return vReply

            End If

            Return vReply

        Catch ex As Exception
            vReply.msg = "Ocurrió un error al procesar el documento "
            vReply.ok = False
        End Try

        Return vReply

    End Function

    ''' <summary>
    ''' Esta función se utiliza para procesar un documento 
    ''' (Factura, Tiquete, Nota de Crédito o Débito)
    ''' y ser enviado al Ministerio de Hacienda
    ''' </summary>
    ''' <param name="pDocumento">Objeto</param>
    ''' <returns>Objeto Reply(OK, MSG y OBJ(XML))</returns>
    ''' <remarks></remarks>
    Public Function fGenerarDocumento(pDocumento As DocumentoEncabezado,
                                       pUsuarioHacienda As UsuarioHacienda, pIntentosRecepcion As Integer) As Reply

        Dim vReply As New Reply
        Dim vReplyValidaDocumento As New Reply
        Dim vReplyValidaCertificado As New Reply
        Dim vReplyGeneraToken As New Reply
        Dim vReplyGeneraXML As New Reply
        Dim vReplyFirmaXML As New Reply
        Dim vReplyEnvioHacienda As New Reply
        Dim vReplyObtieneRespuesta As New Reply
        Dim vCommon As New Common
        Dim vHaciendaDocumento As New EN.BitOne.FE.EN.Hacienda.HaciendaDocumento()
        Dim vDocCondicion As String

        Try

            ' Inicializa los datos
            vReply.contingencia = False
            vReply.ok = False
            vReply.msg = String.Empty
            vReply.xmlDocumento = Nothing
            vReply.xmlRespuesta = Nothing
            vReply.estado = "ERROR"
            vReply.reasonPhraseGETHacienda = String.Empty
            vReply.reasonPhrasePOSTHacienda = String.Empty

            ' Obtiene la condición 
            vDocCondicion = pDocumento.Clave.Substring(41, 1)
            ' Obtiene el consecutivo
            pDocumento.DocumentoConsecutivo = pDocumento.Clave.Substring(31, 10)
            ' Obtiene el tipo 
            pDocumento.Tipo = pDocumento.Clave.Substring(29, 2)
            ' Obtiene la sucursal
            pDocumento.Sucursal = pDocumento.Clave.Substring(21, 3)
            ' Obtiene la terminal
            pDocumento.Terminal = pDocumento.Clave.Substring(24, 5)


            ' 1- Valida documento
            vReplyValidaDocumento = vDocumentoBLL.fValidarDocumento(pDocumento, vDocCondicion)

            ' Si el documento es invalido
            If vReplyValidaDocumento.ok = False Then

                vReply.msg = vReplyValidaDocumento.msg
                Return vReply

            End If


            ' 2- Validar Certificado
            vReplyValidaCertificado = vTributacionBLL.fValidarCertificado(pUsuarioHacienda)

            ' Si el certificado es invalido
            If vReplyValidaCertificado.ok = False Then

                vReply.msg = vReplyValidaCertificado.msg
                Return vReply

            End If

            ' Si CONDICION DOCUMENTO = SIN INTERNET no debe ingresar
            If vDocCondicion <> Diccionario.SituacionSinInternet Then

                ' 3- Genera token
                vReplyGeneraToken = vTributacionBLL.fGeneraToken(pUsuarioHacienda)

                ' Si la contingencia es True
                If vReplyGeneraToken.contingencia = True Then

                    vReply.contingencia = True
                    vReply.msg = vReplyGeneraToken.msg
                    vReply.estado = "CONTINGENCIA"
                    Return vReply

                End If

                ' Si el Token es invalido
                If vReplyGeneraToken.ok = False Then

                    vReply.msg = vReplyGeneraToken.msg
                    Return vReply

                End If

            End If

            ' 4- Genera el archivo XML
            vReplyGeneraXML = vDocumentoBLL.fGenerarXML(pDocumento, vDocCondicion)

            ' Si el archivo XML no se genero
            If vReplyGeneraXML.ok = False Then

                vReply.msg = vReplyGeneraXML.msg
                Return vReply

            Else
                vReply.xmlDocumento = vReplyGeneraXML.xmlDocumento
            End If


            ' 5- Firma el XML
            vReplyFirmaXML = vTributacionBLL.fFirmarDocumento(pUsuarioHacienda, vReplyGeneraXML.xmlDocumento)

            ' Si el archivo XML no se firmo
            If vReplyFirmaXML.ok = False Then

                vReply.msg = vReplyFirmaXML.msg
                Return vReply

            Else
                vReply.xmlDocumento = vReplyFirmaXML.xmlDocumento
            End If


            ' Si CONDICION DOCUMENTO = SIN INTERNET no debe ingresar
            If vDocCondicion <> Diccionario.SituacionSinInternet Then

                ' Asigna datos del Objeto Hacienda Documento
                vHaciendaDocumento.clave = pDocumento.Clave
                vHaciendaDocumento.fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz")
                vHaciendaDocumento.emisor = New EN.BitOne.FE.EN.Hacienda.emisor With {.numeroIdentificacion = pDocumento.Emisor.Identificacion.PadLeft(12, "0"),
                                                                                      .tipoIdentificacion = pDocumento.Emisor.IdentificacionTipo}
                ' Si el receptor existe
                If (Not pDocumento.Receptor Is Nothing) Then
                    vHaciendaDocumento.receptor = New EN.BitOne.FE.EN.Hacienda.receptor With {.numeroIdentificacion = pDocumento.Receptor.Identificacion.PadLeft(12, "0"),
                                                                                              .tipoIdentificacion = pDocumento.Receptor.IdentificacionTipo}
                End If

                vHaciendaDocumento.comprobanteXml = vCommon.Encrypt(vReply.xmlDocumento)
                vHaciendaDocumento.consecutivoReceptor = Nothing


                ' 6- Envia documento a Hacienda
                vReplyEnvioHacienda = vTributacionBLL.fEnvioDocumento(vHaciendaDocumento, pUsuarioHacienda, vReplyGeneraToken.token)

                ' Asigna respuesta Hacienda
                vReply.reasonPhrasePOSTHacienda = vReplyEnvioHacienda.reasonPhrasePOSTHacienda
                vReply.statusCodePOSTHacienda = vReplyEnvioHacienda.statusCodePOSTHacienda

                ' Si la contingencia es True
                If vReplyEnvioHacienda.contingencia = True Then

                    vReply.contingencia = True
                    vReply.msg = vReplyEnvioHacienda.msg
                    vReply.estado = "CONTINGENCIA"
                    Return vReply

                End If

                ' Si no se envió el XML con éxito
                If vReplyEnvioHacienda.ok = False Then
                    vReply.msg = vReplyEnvioHacienda.msg
                    Return vReply
                End If

                ' Recorre la cantidad de intentos
                Dim vIntentos As Integer = 1
                While vIntentos <= pIntentosRecepcion

                    ' 7- Obtiene la respuesta de Hacienda
                    vReplyObtieneRespuesta = vTributacionBLL.fObtenerDocumento(pUsuarioHacienda, pDocumento.Clave, vReplyGeneraToken.token)

                    ' Asigna respuesta Hacienda
                    vReply.reasonPhraseGETHacienda = vReplyObtieneRespuesta.reasonPhraseGETHacienda
                    vReply.statusCodeGETHacienda = vReplyObtieneRespuesta.statusCodeGETHacienda

                    ' Si el documento se proceso
                    If vReplyObtieneRespuesta.ok Then

                        ' Asigna el Xml respuesta de Hacienda
                        vReply.xmlRespuesta = vReplyObtieneRespuesta.xmlRespuesta

                        ' Respuesta de Hacienda
                        Select Case vReplyObtieneRespuesta.msg
                            Case "ACEPTADO"

                                vReply.msg = "Documento: " & pDocumento.Clave & " | POST Hacienda: True |  GET Hacienda: True | Descripción: ACEPTADO"
                                vReply.ok = True
                                vReply.estado = "ACEPTADO"
                                Return vReply

                            Case "RECHAZADO"
                                vReply.msg = "Documento: " & pDocumento.Clave & " | POST Hacienda: True |  GET Hacienda: True | Descripción: RECHAZADO"
                                vReply.ok = True
                                vReply.estado = "RECHAZADO"
                                Return vReply

                            Case "PROCESANDO"

                                vReply.msg = "Documento: " & pDocumento.Clave & " | POST Hacienda: True |  GET Hacienda: True | Descripción: PROCESANDO"
                                vReply.estado = "PROCESANDO"
                                vReply.ok = True

                            Case Else

                                vReply.msg = "Documento: " & pDocumento.Clave & " | POST Hacienda: True |  GET Hacienda: True | Descripción: ERROR HACIENDA. CONTACTE A SOPORTE HACIENDA"
                                vReply.ok = False

                        End Select

                    Else
                        vReply.msg = "Documento: " & pDocumento.Clave & " | POST Hacienda: True | GET Hacienda: True | Descripción: " & vReplyObtieneRespuesta.msg
                        vReply.ok = False
                        Return vReply
                    End If

                    vIntentos = vIntentos + 1

                End While

            Else

                ' Si es Condición = Sin Internet
                vReply.msg = "Documento: " & pDocumento.Clave & " | POST Hacienda: False |  GET Hacienda: False | Descripción: GENERADO :: CONTINGENCIA :: SIN INTERNET"
                vReply.ok = True
                vReply.estado = "SIN INTERNET"
                Return vReply

            End If

            Return vReply

        Catch ex As Exception
            vReply.msg = "Ocurrió un error al procesar el documento " & pDocumento.Clave
            vReply.ok = False
        End Try

        Return vReply

    End Function

    ''' <summary>
    ''' Brinda la posibilidad de enviar un documento a Hacienda para 
    ''' su aprobación
    ''' </summary>
    ''' <param name="pPath"></param>
    ''' <param name="pClave"></param>
    ''' <param name="pUsuarioHacienda"></param>
    ''' <param name="pEmisorIdentificacion"></param>
    ''' <param name="pEmisorIdentificacionTipo"></param>
    ''' <param name="pReceptorIdentificacion"></param>
    ''' <param name="pReceptorIdentificacionTipo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fHaciendaEnviaDocumento(pPath As String, pClave As String, pUsuarioHacienda As UsuarioHacienda,
                                            pEmisorIdentificacion As String, pEmisorIdentificacionTipo As String,
                                            Optional pReceptorIdentificacion As String = Nothing,
                                            Optional pReceptorIdentificacionTipo As String = Nothing) As Reply

        Dim vReply As New Reply
        Dim vReplyEnvio As New Reply
        Dim vReplyToken As New Reply
        Dim vHaciendaDocumento As New EN.BitOne.FE.EN.Hacienda.HaciendaDocumento()
        Dim vCommon As New Common

        Try

            ' Asigna datos del Objeto Hacienda Documento
            vHaciendaDocumento.clave = pClave
            vHaciendaDocumento.fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz")
            vHaciendaDocumento.emisor = New EN.BitOne.FE.EN.Hacienda.emisor With {.numeroIdentificacion = pEmisorIdentificacion.PadLeft(12, "0"),
                                                                                  .tipoIdentificacion = pEmisorIdentificacionTipo}

            ' Si el receptor existe
            If (Not pReceptorIdentificacion Is Nothing) Then
                vHaciendaDocumento.receptor = New EN.BitOne.FE.EN.Hacienda.receptor With {.numeroIdentificacion = pReceptorIdentificacion.PadLeft(12, "0"),
                                                                                          .tipoIdentificacion = pReceptorIdentificacionTipo}

            End If


            Dim xmldoc As New XmlDocument
            xmldoc.Load(pPath)
            Dim allText As String = xmldoc.InnerXml

            vHaciendaDocumento.comprobanteXml = vCommon.Encrypt(allText)
            vHaciendaDocumento.consecutivoReceptor = Nothing

            ' Genera el Token
            vReplyToken = vTributacionBLL.fGeneraToken(pUsuarioHacienda)

            If (vReplyToken.ok) Then

                vReplyEnvio = vTributacionBLL.fEnvioDocumento(vHaciendaDocumento, pUsuarioHacienda, vReplyToken.token)

                If vReplyEnvio.ok Then
                    vReply.ok = True
                    vReply.msg = "El Documento fue enviado exitosamente"
                Else
                    vReply.ok = False
                    vReply.msg = vReplyEnvio.msg
                End If
            Else
                vReply.msg = vReplyToken.msg
                vReply.ok = False
            End If


        Catch ex As Exception
            vReply.msg = "Ocurrió un error"
            vReply.ok = False
        End Try

        Return vReply

    End Function

    ''' <summary>
    ''' Brinda la posibilidad de consultar el estado de un documento
    ''' y la respuesta de hacienda
    ''' </summary>
    ''' <param name="pClave"></param>
    ''' <param name="pUsuarioHacienda"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fHaciendaRespuestaDocumento(pClave As String, pUsuarioHacienda As UsuarioHacienda, Optional pReplyToken As Reply = Nothing) As Reply

        Dim vReply As New Reply
        Dim vReplyToken As New Reply
        Dim vReplyObtieneRespuesta As New Reply

        Try

            If pReplyToken Is Nothing Then

                ' Genera el Token
                vReplyToken = vTributacionBLL.fGeneraToken(pUsuarioHacienda)

            Else

                ' Asigna el Token
                vReplyToken = pReplyToken

            End If

            If (vReplyToken.ok) Then

                vReplyObtieneRespuesta = vTributacionBLL.fObtenerDocumento(pUsuarioHacienda, pClave, vReplyToken.token)

                ' Si el documento se proceso
                If vReplyObtieneRespuesta.ok Then

                    ' Asigna el Xml respuesta de Hacienda
                    vReply.xmlRespuesta = vReplyObtieneRespuesta.xmlRespuesta

                    ' Respuesta de Hacienda
                    Select Case vReplyObtieneRespuesta.msg
                        Case "ACEPTADO"

                            vReply.msg = "Documento: " & pClave & " | GET Hacienda: True | Descripción: ACEPTADO"
                            vReply.ok = True
                            vReply.estado = "ACEPTADO"
                            Return vReply

                        Case "RECHAZADO"

                            vReply.msg = "Documento: " & pClave & " | GET Hacienda: True | Descripción: RECHAZADO"
                            vReply.ok = True
                            vReply.estado = "RECHAZADO"
                            Return vReply

                        Case "PROCESANDO"

                            vReply.msg = "Documento: " & pClave & " | GET Hacienda: True | Descripción: PROCESANDO"
                            vReply.estado = "PROCESANDO"
                            vReply.ok = True

                        Case Else

                            vReply.msg = "Documento: " & pClave & " | GET Hacienda: True | Descripción: ERROR HACIENDA. CONTACTE A SOPORTE HACIENDA"
                            vReply.ok = False

                    End Select

                Else
                    vReply.msg = "Documento: " & pClave & " |  GET Hacienda: True | Descripción: " & vReplyObtieneRespuesta.msg
                    vReply.ok = False
                    Return vReply
                End If

            Else
                vReply.msg = "Ocurrió un error al generar Token"
                vReply.ok = False
            End If

        Catch ex As Exception
            vReply.msg = "Ocurrió un error"
            vReply.ok = False
        End Try

        Return vReply

    End Function

    ''' <summary>
    ''' Se usa para traer la informacion de Token de Hacienda
    ''' </summary>
    ''' <param name="pUsuarioHacienda">Objeto</param>
    ''' <returns>Objeto Reply(OK, MSG y OBJ(Boolen))</returns>
    ''' <remarks></remarks>
    Public Function fGenerarToken(pUsuarioHacienda As UsuarioHacienda) As Reply

        ' Asigna los datos de la generación del Token
        Return vTributacionBLL.fGeneraToken(pUsuarioHacienda)

    End Function

    ''' <summary>
    ''' Se usa para verificar si el Certificado es valido
    ''' </summary>
    ''' <param name="pUsuarioHacienda">Objeto</param>
    ''' <returns>Objeto Reply(OK, MSG y OBJ(Boolen))</returns>
    ''' <remarks></remarks>
    Public Function fValidarCertificado(pUsuarioHacienda As UsuarioHacienda) As Reply

        Return vTributacionBLL.fValidarCertificado(pUsuarioHacienda)

    End Function


End Class


