
Imports BitOne.FE.BLL
Imports BitOne.FE.EN
Imports BitOne.FE.Resources
Imports System.Text
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime

Public Class SMTP

    Public Function fEnviarEmailPrueba(pUsername As String, pPassword As String, pServer As String, pPuerto As String,
                                       pSSL As Boolean) As Reply

        Dim vReply As New Reply

        Try

            Dim smtp As SmtpClient = New SmtpClient(pServer, pPuerto)
            smtp.EnableSsl = pSSL
            'smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            'smtp.UseDefaultCredentials = False
            smtp.Credentials = New System.Net.NetworkCredential(pUsername, pPassword)

            Dim mail As MailMessage = New MailMessage()
            mail.To.Add(pUsername)
            mail.From = New MailAddress(pUsername)
            mail.Subject = "FastBox - Correo de Prueba"
            mail.Body = "Se realiza prueba de funcionalidad de email."
            mail.IsBodyHtml = False

            smtp.Send(mail)

            vReply.ok = True
            vReply.msg = "Correo enviado"

        Catch ex As Exception
            vReply.ok = False
            vReply.msg = "Ocurrió un error al realizar el envió. Compruebe los datos del SMTP"
        End Try

        Return vReply

    End Function

End Class
