using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.BusinessServiceModel
{
    [DataContract]
    public class SignupRequest
    {
        [DataMember]
        public MobileModel.User User { get; set; }

        [DataMember]
        public MobileModel.AppConfiguration UserAppConfiguration { get; set; }

    }
}
