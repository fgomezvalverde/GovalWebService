using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.BaseModel
{
    [DataContract]
    public class BaseRequest
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string ApplicationId { get; set; }
        [DataMember]
        public string DeviceId { get; set; }
        [DataMember]
        public string SSOT { get; set; }

        [DataMember]
        public Boolean IsProductionStage { get; set; } = false;
    }
}
