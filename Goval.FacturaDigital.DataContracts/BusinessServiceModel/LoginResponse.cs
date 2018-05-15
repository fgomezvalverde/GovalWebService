using Goval.FacturaDigital.DataContracts.MobileModel;
using System.Runtime.Serialization;


namespace Goval.FacturaDigital.DataContracts.BusinessServiceModel
{
    [DataContract]
    public class LoginResponse : BaseModel.BaseResponse
    {
        [DataMember]
        public AppConfiguration UserConfiguration { get; set; }
        [DataMember]
        public User UserInformation { get; set; }
    }
}
