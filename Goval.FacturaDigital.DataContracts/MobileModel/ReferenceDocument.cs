using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.MobileModel
{
    [DataContract]
    public class ReferenceDocument
    {
        [DataMember]
        public string ReferenceCode { get; set; }
        [DataMember]
        public string ReferenceDescription { get; set; }
        [DataMember]
        public string ReferenceDocumentType { get; set; }
    }
}
