using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.Core
{
    public class BillingConstants
    {
        public static string UrlhaciendaAuthApiDesarrollo = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/";
        public static string UrlhaciendaAuthApiProduccion = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut/protocol/openid-connect/";
        public static string UrlhaciendaApiProduccion = "https://api.comprobanteselectronicos.go.cr/recepcion/v1/";
        public static string UrlhaciendaApiDesarrollo = "https://api.comprobanteselectronicos.go.cr/recepcion-sandbox/v1/";
    }
}
