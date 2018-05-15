using Goval.FacturaDigital.DataContracts.MobileModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.BusinessServiceModel
{
    [DataContract]
    public class BillRequest : BaseModel.BaseRequest
    {
        [DataMember]
        public Bill ClientBill { get; set; }

        [DataMember]
        public User User { get; set; }
    }
}
