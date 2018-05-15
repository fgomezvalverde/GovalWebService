using Goval.FacturaDigital.DataContracts.BaseModel;
using Goval.FacturaDigital.DataContracts.BusinessServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.BusinessService
{
    [ServiceContract]
    public interface IBusinessService
    {
        [OperationContract]
        LoginResponse ValidateUser(LoginRequest pUser);


        [OperationContract]
        ProductResponse AddUserProduct(ProductRequest pNewProduct);

        [OperationContract]
        ProductResponse GetUserProducts(ProductRequest pUserRequest);

        [OperationContract]
        ProductResponse SetUserProduct(ProductRequest pChangedProduct);

        [OperationContract]
        ProductResponse DeleteUserProduct(ProductRequest pDeleteProduct);


        [OperationContract]
        ClientResponse AddUserClient(ClientRequest pNewClient);

        [OperationContract]
        ClientResponse GetUserClients(ClientRequest pUserRequest);

        [OperationContract]
        ClientResponse SetUserClient(ClientRequest pChangedClient);

        [OperationContract]
        ClientResponse DeleteUserClient(ClientRequest pDeleteClient);

        [OperationContract]
        BillResponse CreateBill(BillRequest pBillRequest);

        [OperationContract]
        BillResponse GetUserBills(BillRequest pBillRequest);

        [OperationContract]
        LoginResponse RegisterUser(SignupRequest pNewUser);

        [OperationContract]
        BaseResponse ValidateUserWithHacienda(UserValidationRequest pRequestValidationUser);
    }
}
