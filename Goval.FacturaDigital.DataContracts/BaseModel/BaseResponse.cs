using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.BaseModel
{
    [DataContract]
    public class BaseResponse
    {
        [DataMember]
        public Boolean IsSuccessful { get; set; } = false;
        [DataMember]
        public string UserMessage { get; set; }
        [DataMember]
        public string TechnicalMessage { get; set; }
        [DataMember]
        public int Code { get; set; }
        [DataMember]
        public string SSOT { get; set; }
        [DataMember]
        public Boolean NewSessionStarted { get; set; } = false;

    }
}
