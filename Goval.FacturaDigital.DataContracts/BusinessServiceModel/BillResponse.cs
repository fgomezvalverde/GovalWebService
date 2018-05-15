using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.BusinessServiceModel
{
    [DataContract]
    public class BillResponse : BaseModel.BaseResponse
    {
        [DataMember]
        public byte[] PdfInvoice { get; set; }

        [DataMember]
        public List<MobileModel.Bill> UserBills { get; set; } = new List<MobileModel.Bill>();

        [DataMember]
        public long BillNumber { get; set; } 
    }
}
