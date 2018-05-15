using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.MobileModel
{
    [DataContract]
    public class Exoneration
    {
        [DataMember]
        public long ExonerationId { get; set; }
        [DataMember]
        public string DocumentType { get; set; }
        [DataMember]
        public string DocumentNumber { get; set; }
        [DataMember]
        public string InstitutionName { get; set; }
        [DataMember]
        public System.DateTime EmissionDate { get; set; }
        [DataMember]
        public decimal TaxAmount { get; set; }
        [DataMember]
        public int PurchasePercentaje { get; set; }
    }
}
