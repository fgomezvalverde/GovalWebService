using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.BusinessServiceModel
{
    [DataContract]
    public class ProductRequest : BaseModel.BaseRequest
    {
        [DataMember]
        public MobileModel.Product UserProduct { get; set; }
        [DataMember]
        public long UserId { get; set; }
    }
}
