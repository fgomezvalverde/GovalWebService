using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.BusinessServiceModel
{
    [DataContract]
    public class ClientRequest : BaseModel.BaseRequest
    {
        [DataMember]
        public MobileModel.Client UserClient { get; set; }
        [DataMember]
        public long UserId { get; set; }
    }
}
