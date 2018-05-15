using BitOne.FE.BLL;
using BitOne.FE.EN;
using BitOne.FE.Resources;
using Goval.FacturaDigital.DataContracts.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.Core.BIlling
{
    public class UserValidation
    {
        public BaseResponse ValidateUserCredentials(DataContracts.MobileModel.User pNewUser, bool pIsProduction = false)
        {
            var vResponse = new BaseResponse();
            vResponse.IsSuccessful = false;

            // Validacion de Credenciales
            var vServicioBLL = new ServicioBLL();
            Reply vTokenReplyMessage = new Reply();
            var vUsuarioHacienda = new UsuarioHacienda();
            vUsuarioHacienda.modalidadProduccion = pIsProduction;
            vUsuarioHacienda.urlhaciendaAuthApiDesarrollo = BillingConstants.UrlhaciendaAuthApiDesarrollo;
            vUsuarioHacienda.urlhaciendaAuthApiProduccion = BillingConstants.UrlhaciendaAuthApiProduccion;
            vUsuarioHacienda.username = pNewUser.HaciendaUsername;
            vUsuarioHacienda.password = pNewUser.HaciendaPassword;

            vTokenReplyMessage = vServicioBLL.fGenerarToken(vUsuarioHacienda);
            if (vTokenReplyMessage != null && vTokenReplyMessage.ok &&
                vTokenReplyMessage.token != null && !string.IsNullOrEmpty(vTokenReplyMessage.token.access_token))
            {
                vTokenReplyMessage = new Reply();
                vUsuarioHacienda.Certificado = Convert.FromBase64String(pNewUser.HaciendaCryptographicFile);
                vUsuarioHacienda.Pin = Convert.ToString(pNewUser.HaciendaCryptographicPIN);

                vTokenReplyMessage = vServicioBLL.fValidarCertificado(vUsuarioHacienda);

                if (vTokenReplyMessage != null && vTokenReplyMessage.ok)
                {
                    vResponse.UserMessage = "Usuario Validado con éxito";
                    vResponse.IsSuccessful = true;
                }
                else
                {
                    vResponse.UserMessage = vTokenReplyMessage?.msg;
                    vResponse.IsSuccessful = false;
                }
                /*
                 Dim vUsuarioHacienda As New UsuarioHacienda()
        Dim vReply As New Reply

        ' Asigna datos
        vUsuarioHacienda.Certificado = IO.File.ReadAllBytes(txtCertificado.Text)
        vUsuarioHacienda.Pin = txtCertificadoPIN.Text

        ' Valida PIN y Certificado
        vReply = vServicioBLL.fValidarCertificado(vUsuarioHacienda)
                */

            }
            else
            {
                vResponse.UserMessage = vTokenReplyMessage?.msg;
                vResponse.IsSuccessful = false;
            }

            /*
            Dim vUsuarioHacienda As New UsuarioHacienda()

        ' Asigna datos
        vUsuarioHacienda.modalidadProduccion = False
        vUsuarioHacienda.urlhaciendaAuthApiDesarrollo = vUrlhaciendaAuthApiDesarrollo
        vUsuarioHacienda.urlhaciendaAuthApiProduccion = vUrlhaciendaAuthApiProduccion
        vUsuarioHacienda.username = txtUsuarioHacienda.Text
        vUsuarioHacienda.password = txtClaveHacienda.Text

        ' Genera Token 
        vReply = vServicioBLL.fGenerarToken(vUsuarioHacienda)

        If Not vReply.token Is Nothing Then
            MessageBox.Show("Mensaje: " & vReply.msg & Chr(13) & _
                            "Token: " & vReply.token.access_token)
        Else
            MessageBox.Show("Mensaje: " & vReply.msg & Chr(13) & "Token: NULL")
        End If
        */
            return vResponse;
        }
    }
}
