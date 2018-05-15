using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.MobileModel
{
    [DataContract]
    public class User
    {
        [DataMember]
        public long UserId { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string UserLegalNumber { get; set; }
        [DataMember]
        public string HaciendaUsername { get; set; }
        [DataMember]
        public string HaciendaPassword { get; set; }
        [DataMember]
        public string HaciendaCryptographicPIN { get; set; }
        [DataMember]
        public string HaciendaCryptographicFile { get; set; }
        [DataMember]
        public string HaciendaCryptographicFileName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public Boolean HaciendaUserValidation { get; set; }
        [DataMember]
        public string IdentificationType { get; set; }
        [DataMember]
        public string ComercialName { get; set; }
        [DataMember]
        public string ProvinciaCode { get; set; }
        [DataMember]
        public string CantonCode { get; set; }
        [DataMember]
        public string DistritoCode { get; set; }
        [DataMember]
        public string BarrioCode { get; set; }
        [DataMember]
        public string LocationDescription { get; set; }
        [DataMember]
        public string PhoneNumberCountryCode { get; set; }
        [DataMember]
        public string FaxCountryCode { get; set; }
        [DataMember]
        public string Fax { get; set; }
    }
}
