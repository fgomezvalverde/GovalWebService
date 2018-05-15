using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.MobileModel
{
    [DataContract]
    public class AppConfiguration
    {
        [DataMember]
        public long StartBillNumber { get; set; }
        [DataMember]
        public string Base64Logotype { get; set; }
        [DataMember]
        public string EmailScheme { get; set; }
        [DataMember]
        public bool IsPremiumAccount { get; set; }
        [DataMember]
        public decimal Credits { get; set; }

    }
}
