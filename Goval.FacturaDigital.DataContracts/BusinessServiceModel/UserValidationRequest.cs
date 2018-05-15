using Goval.FacturaDigital.DataContracts.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.BusinessServiceModel
{
    [DataContract]
    public class UserValidationRequest : BaseRequest
    {
        [DataMember]
        public MobileModel.User User { get; set; }
    }
}
