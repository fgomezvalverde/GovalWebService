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
    public class CodesDirectionListRequest : BaseRequest
    {
        [DataMember]
        public int ProvinciaCode { get; set; }
        [DataMember]
        public int DistritoCode { get; set; }
        [DataMember]
        public int CantonCode { get; set; }

    }
}
