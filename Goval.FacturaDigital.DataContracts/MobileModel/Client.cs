using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.MobileModel
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public long ClientId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal DefaultDiscountPercentage { get; set; }
        [DataMember]
        public decimal DefaultTaxesPercentage { get; set; }
        [DataMember]
        public string DiscountNature { get; set; }
        [DataMember]
        public string TaxCode { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string ClientLegalNumber { get; set; }
        [DataMember]
        public string LocationDescription { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int DefaultPaymentTerm { get; set; }
        [DataMember]
        public string ComercialName { get; set; }
        [DataMember]
        public bool IsIndependentPerson { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string IdentificationType { get; set; }
        [DataMember]
        public string ForeignIdentification { get; set; }
        [DataMember]
        public string ProvinciaCode { get; set; }
        [DataMember]
        public string CantonCode { get; set; }
        [DataMember]
        public string DistritoCode { get; set; }
        [DataMember]
        public string BarrioCode { get; set; }
        [DataMember]
        public string PhoneNumberCountryCode { get; set; }
        [DataMember]
        public string FaxCountryCode { get; set; }
        [DataMember]
        public string Fax { get; set; }


        [DataMember]
        public List<Product> ClientProducts { get; set; } = new List<Product>();

    }
}
