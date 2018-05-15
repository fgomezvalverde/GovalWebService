using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.BusinessServiceModel
{
    [DataContract]
    public class ProductResponse : BaseModel.BaseResponse
    {
        [DataMember]
        public List<MobileModel.Product> UserProducts { get; set; } = new List<MobileModel.Product>();

    }
}
