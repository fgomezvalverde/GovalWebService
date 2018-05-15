Imports System.Threading.Tasks
Imports System.Security.Cryptography.X509Certificates
Imports System.Configuration
Imports System.Text
Imports System.IO
Imports BitOne.FE.EN
Imports BitOne.FE.Resources
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json
Imports FirmaXadesNet.Signature.Parameters
Imports FirmaXadesNet.Crypto
Imports FirmaXadesNet
Imports FirmaXadesNet.Signature
Imports BitOne.FE.EN.BitOne.FE.EN.Hacienda
Imports System.Xml
Imports System.Xml.Serialization

Public Class TributacionBLL


    ''' <summary>
    ''' Valida que la llave criptografica se encuentre
    ''' vigente y que el PIN funcione correctamente con 
    ''' la misma
    ''' </summary>
    ''' <param name="pUsuarioHacienda"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fValidarCertificado(pUsuarioHacienda As UsuarioHacienda) As Reply

        Dim vReply As New Reply
        Dim vLlave As X509Certificate2 = Nothing
        Dim vFechaAct As DateTime = DateTime.Now

        Try

            ' Utiliza el PIN con la llave criptografica
            vLlave = New X509Certificate2(pUsuarioHacienda.Certificado, pUsuarioHacienda.Pin)

            ' Si la fecha actual esta fuera de la vigencia de la llave
            If (vFechaAct < Convert.ToDateTime(vLlave.NotBefore.ToString) Or
                vFechaAct > Convert.ToDateTime(vLlave.NotAfter.ToString)) Then

                vReply.msg = "El Certificado expiró"
                vReply.ok = False

            Else

                ' Datos validos
                vReply.msg = "Los datos son validos"
                vReply.ok = True

            End If

        Catch ex As Exception

            vReply.msg = "El PIN y la llave criptografica son incompatibles"
            vReply.ok = False

        End Try

        Return vReply

    End Function

    ''' <summary>
    ''' Genera un Token contra el servicio
    ''' del Ministerio de Hacienda
    ''' </summary>
    ''' <param name="pUsuarioHacienda"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fGeneraToken(pUsuarioHacienda As UsuarioHacienda) As Reply

        Dim vReply As New Reply
        Dim vRes As New Token
        Dim vCliente_id As String

        Using vClient = New HttpClient()

            Try
                'Si es produccion 
                If pUsuarioHacienda.modalidadProduccion Then
                    vCliente_id = "api-prod"
                    vClient.BaseAddress = New Uri(pUsuarioHacienda.urlhaciendaAuthApiProduccion)
                Else
                    vCliente_id = "api-stag"
                    vClient.BaseAddress = New Uri(pUsuarioHacienda.urlhaciendaAuthApiDesarrollo)
                End If

                vClient.DefaultRequestHeaders.Accept.Clear()
                vClient.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"))

                Dim response As HttpResponseMessage = Nothing
                Dim param As New List(Of KeyValuePair(Of String, String))
                param.Add(New KeyValuePair(Of String, String)("grant_type", "password"))
                param.Add(New KeyValuePair(Of String, String)("client_id", vCliente_id))
                param.Add(New KeyValuePair(Of String, String)("username", pUsuarioHacienda.username))
                param.Add(New KeyValuePair(Of String, String)("password", pUsuarioHacienda.password))
                Dim content As HttpContent = New FormUrlEncodedContent(param)

                Try

                    ' Solicita Token 
                    response = vClient.PostAsync("token", content).Result

                Catch ex As Exception

                    ' Si ocurrió un error de conexión
                    vReply.msg = "Contingencia :: GET Token :: No se pudo establecer conexión entre las partes"
                    vReply.contingencia = True
                    vReply.ok = False

                    Return vReply

                End Try

                ' Si se genera el Token éxitosamente
                If response.IsSuccessStatusCode And response.StatusCode = "200" Then

                    vReply.contingencia = False
                    vReply.ok = True
                    vReply.token = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Token)(response.Content.ReadAsStringAsync.Result)
                    vReply.msg = "Datos generados Correctamente"

                Else

                    ' Credenciales invalidas
                    vReply.contingencia = False
                    vReply.ok = False
                    vReply.msg = "El usuario o la contraseña son invalidos"
                    ' Mensaje especifico de hacienda
                    'response.Content.ReadAsStringAsync.Result

                End If

            Catch ex As Exception

                ' Ocurrió un error 
                vReply.contingencia = False
                vReply.ok = False
                vReply.msg = "Ocurrió un error al generar token"

            End Try

        End Using

        Return vReply

    End Function

    ''' <summary>
    ''' Esta funcción se utiliza para enviar los documentos XML
    ''' al API de recepción del Ministerio de Hacienda
    ''' </summary>
    ''' <param name="pHaciendaDocumento"></param>
    ''' <param name="pUsuarioHacienda"></param>
    ''' <param name="pToken"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fEnvioDocumento(pHaciendaDocumento As EN.BitOne.FE.EN.Hacienda.HaciendaDocumento, pUsuarioHacienda As UsuarioHacienda,
                                    pToken As Token) As Reply

        Dim vReply As New Reply
        Dim DocValida As String = JsonConvert.SerializeObject(pHaciendaDocumento, New JsonSerializerSettings With {.NullValueHandling = NullValueHandling.Ignore})
        DocValida = DocValida.Replace("\\", "")
        Dim vRes As Boolean = False
        Dim vMsg As ResponseMessage = Nothing
        Dim vCliente_id As String
        Using vClient = New HttpClient()

            'Si es produccion 
            If pUsuarioHacienda.modalidadProduccion Then
                vCliente_id = "api-prod"
                vClient.BaseAddress = New Uri(pUsuarioHacienda.urlhaciendaApiProduccion)
            Else
                vCliente_id = "api-stag"
                vClient.BaseAddress = New Uri(pUsuarioHacienda.urlhaciendaApiDesarrollo)
            End If

            vClient.DefaultRequestHeaders.Accept.Clear()
            vClient.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            vClient.DefaultRequestHeaders.Add("Authorization", "bearer " + pToken.access_token)

            ' HTTP POST
            Dim vResponse As HttpResponseMessage = Nothing

            Try

                Dim vStr As String = ""
                Dim vContent As StringContent = New StringContent(DocValida, Encoding.UTF8, "application/json")

                ' Envia los datos
                vResponse = vClient.PostAsync("recepcion", vContent).Result

                If Not vResponse.ReasonPhrase Is Nothing Then
                    vReply.reasonPhrasePOSTHacienda = vResponse.ReasonPhrase
                End If

                If (vResponse.IsSuccessStatusCode) Then
                    vReply.statusCodePOSTHacienda = vResponse.StatusCode
                End If

                ' Si hacienda responde
                If (vResponse.IsSuccessStatusCode) Then
                    vReply.ok = True
                Else
                    If vResponse.Headers.Contains("X-Error-Cause") Then
                        Dim header As [String]() = vResponse.Headers.GetValues("X-Error-Cause")
                        vReply.msg = header(0)
                    Else
                        vReply.msg = "Ocurrió un error"
                    End If
                    vReply.ok = False
                End If

            Catch ex As Exception

                ' Si ocurrió un error de conexión
                vReply.msg = "Contingencia :: POST Hacienda :: No se pudo establecer conexión entre las partes"
                vReply.contingencia = True
                vReply.ok = False

            End Try

        End Using

        Return vReply

    End Function

    ''' <summary>
    ''' Obtiene de hacienda la respuesta del POST
    ''' </summary>
    ''' <param name="pUsuarioHacienda"></param>
    ''' <param name="pClave"></param>
    ''' <param name="pToken"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fObtenerDocumento(pUsuarioHacienda As UsuarioHacienda, pClave As String,
                                      pToken As Token) As Reply

        Dim vRes As Integer = -1
        Dim vReply As New Reply
        Dim vCliente_id As String
        Dim vCommon As New Common

        Using vClient = New HttpClient()

            'Si es produccion 
            If pUsuarioHacienda.modalidadProduccion Then
                vCliente_id = "api-prod"
                vClient.BaseAddress = New Uri(pUsuarioHacienda.urlhaciendaApiProduccion)
            Else
                vCliente_id = "api-stag"
                vClient.BaseAddress = New Uri(pUsuarioHacienda.urlhaciendaApiDesarrollo)
            End If

            vClient.DefaultRequestHeaders.Accept.Clear()
            vClient.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            vClient.DefaultRequestHeaders.Add("Authorization", "bearer " + pToken.access_token)

            '' HTTP POST
            Dim vResponse As HttpResponseMessage = Nothing
            Dim vMsg As ResponseMessage = Nothing

            Try

                Dim vIntentosMax = 0

                ' Recorrer mientras sea respuesta sea nothing o intentos menor a 3
                While vReply.xmlRespuesta = Nothing Or vIntentosMax < 3

                    Dim vStr As String = " "

                    ' Consulta por la clave del documento
                    vResponse = vClient.GetAsync("recepcion/" + pClave).Result

                    If Not vResponse.ReasonPhrase Is Nothing Then
                        vReply.reasonPhraseGETHacienda = vResponse.ReasonPhrase
                    End If

                    If (vResponse.StatusCode) Then
                        vReply.statusCodeGETHacienda = vResponse.StatusCode
                    End If

                    'Si se realizo correctamente
                    If (vResponse.IsSuccessStatusCode) Then

                        vStr = vResponse.Content.ReadAsStringAsync().Result
                        vMsg = JsonConvert.DeserializeObject(Of ResponseMessage)(vStr)

                        ' Asigna respuesta de hacienda
                        vReply.msg = vMsg.indEstado.ToUpper
                        vReply.ok = True

                        ' Si el mensaje no es nulo o vació
                        If Not String.IsNullOrEmpty(vMsg.respuestaXml) Then
                            vReply.xmlRespuesta = vCommon.Decrypt(vMsg.respuestaXml)
                            vIntentosMax = 3
                        Else
                            vReply.xmlRespuesta = Nothing
                        End If

                    Else
                        Dim header As [String]() = vResponse.Headers.GetValues("X-Error-Cause")
                        vReply.msg = header(0)
                        vReply.ok = False
                        vIntentosMax = 3
                    End If

                    vIntentosMax = vIntentosMax + 1

                End While

            Catch ex As Exception

                vReply.msg = "Ocurrió un error"
                vReply.ok = False

            End Try

        End Using

        Return vReply

    End Function


    ''' <summary>
    ''' Esta función se utiliza para firmar un XML utilizando la 
    ''' llave criptografica y el PIN
    ''' </summary>
    ''' <param name="pUsuarioHacienda"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fFirmarDocumento(pUsuarioHacienda As UsuarioHacienda, pDocumentoXml As String) As Reply

        Dim vSignatureDocument = New SignatureDocument
        Dim _firmaXades As New XadesService
        Dim vReply As New Reply
        Dim vCommon As New Common


        'Crea la lista de propiedades
        'Policy Info
        Dim parametros As SignatureParameters = New SignatureParameters()
        Dim spi As SignaturePolicyInfo = New SignaturePolicyInfo()
        Dim vCertificado As New X509Certificate2

        spi.PolicyIdentifier = "https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/Resolucion%20Comprobantes%20Electronicos%20%20DGT-R-48-2016.pdf"
        spi.PolicyUri = ""
        spi.PolicyHash = "NmI5Njk1ZThkNzI0MmIzMGJmZDAyNDc4YjUwNzkzODM2NTBiOWUxNTBkMmI2YjgzYzZjM2I5NTZlNDQ4OWQzMQ=="
        spi.PolicyDigestAlgorithm = FirmaXadesNet.Crypto.DigestMethod.SHA256
        parametros.SignaturePolicyInfo = spi
        'Otros parametros
        parametros.SignaturePackaging = SignaturePackaging.ENVELOPED
        parametros.SigningDate = DateTime.Now
        parametros.SignatureMethod = SignatureMethod.RSAwithSHA256
        parametros.InputMimeType = "application/octet-stream"

        ' Asigna el Certificado
        vCertificado = fObtenerCertificado(pUsuarioHacienda)
        parametros.Signer = New Signer(vCertificado)

        Try

            Dim strAsBytes() As Byte = New System.Text.UTF8Encoding().GetBytes(pDocumentoXml)
            Dim ms As New System.IO.MemoryStream(strAsBytes)

            vSignatureDocument = _firmaXades.Sign(ms, parametros)

            ' Firma 
            vReply.xmlDocumento = vSignatureDocument.Document.InnerXml
            vReply.ok = True
            vReply.msg = "XML firmado"

        Catch ex As Exception
            vReply.ok = False
            vReply.msg = "Ocurrió un error al firmar el documento XML"
        End Try

        Return vReply

    End Function


    ''' <summary>
    ''' Obtiene el certificado para firmar
    ''' </summary>
    ''' <param name="pUsuarioHacienda"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function fObtenerCertificado(pUsuarioHacienda As UsuarioHacienda) As X509Certificate2

        Dim vReply As New X509Certificate2

        Try

            vReply = New X509Certificate2(pUsuarioHacienda.Certificado, pUsuarioHacienda.Pin)

        Catch ex As Exception
            vReply = Nothing
        End Try

        Return vReply

    End Function

End Class
