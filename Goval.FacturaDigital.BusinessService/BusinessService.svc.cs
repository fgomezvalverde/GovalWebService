using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Goval.FacturaDigital.Core.BIlling;
using Goval.FacturaDigital.DataContracts.BaseModel;
using Goval.FacturaDigital.DataContracts.BusinessServiceModel;
using Goval.FacturaDigital.DataContracts.MobileModel;
using Goval.FacturaDigital.DataModel;
using Newtonsoft.Json;

namespace Goval.FacturaDigital.BusinessService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class BusinessService : IBusinessService
    {
        private string TEMPORAL_VALIDATION_TOKEN = "0ed4b262-9fe5-4ad2-ad07-49cad10c7262";
        private Boolean ValidateToken(string pToken)
        {
            if (!string.IsNullOrEmpty(pToken) && 
                pToken.Contains(TEMPORAL_VALIDATION_TOKEN))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Authentication
        public LoginResponse ValidateUser(LoginRequest pUser)
        {
            LoginResponse vLoginResult = new LoginResponse();
            try
            {
                using (BusinessDataModelEntities vContext = new BusinessDataModelEntities())
                {
                    vContext.Database.Connection.Open();
                    var vUsersConfiguration = vContext.AppConfiguration.AsQueryable();

                    if (vUsersConfiguration != null)
                    {
                        var vUserConfigurationFilter = vUsersConfiguration.Where<AppConfigurationEntity>(x => x.User.UserName.Equals(pUser.UserName));
                        if (vUserConfigurationFilter != null && vUserConfigurationFilter.Any())
                        {
                            var vUserConfiguration = vUserConfigurationFilter.First();

                            if (vUserConfiguration != null)
                            {
                                if (vUserConfiguration.User.Password.Equals(pUser.Password))
                                {
                                    vLoginResult.UserConfiguration = new AppConfiguration();
                                    vLoginResult.UserConfiguration.Base64Logotype = vUserConfiguration.Base64Logotype;
                                    vLoginResult.UserConfiguration.IsPremiumAccount = vUserConfiguration.IsPremiumAccount;
                                    vLoginResult.UserConfiguration.Credits = vUserConfiguration.Credits;
                                    vLoginResult.UserConfiguration.StartBillNumber = vUserConfiguration.StartBillNumber;

                                    vLoginResult.UserInformation = new User();
                                    vLoginResult.UserInformation.UserId = vUserConfiguration.User.UserId;
                                    vLoginResult.UserInformation.Email = vUserConfiguration.User.Email;
                                    vLoginResult.UserInformation.LastName = vUserConfiguration.User.LastName;
                                    vLoginResult.UserInformation.Name = vUserConfiguration.User.Name;
                                    vLoginResult.UserInformation.SecondName = vUserConfiguration.User.SecondName;
                                    vLoginResult.UserInformation.UserLegalNumber = vUserConfiguration.User.UserLegalNumber;
                                    vLoginResult.UserInformation.UserName = vUserConfiguration.User.UserName;
                                    vLoginResult.UserInformation.HaciendaUsername = vUserConfiguration.User.Password;
                                    vLoginResult.UserInformation.HaciendaPassword = vUserConfiguration.User.HaciendaPassword;

                                    vLoginResult.UserInformation.HaciendaCryptographicPIN = vUserConfiguration.User.HaciendaCryptographicPIN;
                                    //vLoginResult.UserInformation.HaciendaCryptographicFile = vUserConfiguration.User.HaciendaCryptographicFile;
                                    //vLoginResult.UserInformation.Password = vUserConfiguration.User.Password;
                                    vLoginResult.UserInformation.PhoneNumber = vUserConfiguration.User.PhoneNumber;
                                    vLoginResult.UserInformation.HaciendaUserValidation = vUserConfiguration.User.HaciendaUserValidation;
                                    vLoginResult.UserInformation.IdentificationType = vUserConfiguration.User.IdentificationType;
                                    vLoginResult.UserInformation.ComercialName = vUserConfiguration.User.ComercialName;
                                    vLoginResult.UserInformation.ProvinciaCode = vUserConfiguration.User.ProvinciaCode;
                                    vLoginResult.UserInformation.CantonCode = vUserConfiguration.User.CantonCode;
                                    vLoginResult.UserInformation.DistritoCode = vUserConfiguration.User.DistritoCode;
                                    vLoginResult.UserInformation.BarrioCode = vUserConfiguration.User.BarrioCode;
                                    vLoginResult.UserInformation.LocationDescription = vUserConfiguration.User.LocationDescription;
                                    vLoginResult.UserInformation.PhoneNumberCountryCode = vUserConfiguration.User.PhoneNumberCountryCode;
                                    vLoginResult.UserInformation.FaxCountryCode = vUserConfiguration.User.FaxCountryCode;
                                    vLoginResult.UserInformation.Fax = vUserConfiguration.User.Fax;
                                    vLoginResult.SSOT = TEMPORAL_VALIDATION_TOKEN;
                                    vLoginResult.NewSessionStarted = true;

                                    vLoginResult.IsSuccessful = true;
                                }
                                else
                                {
                                    vLoginResult.UserMessage = "La contraseña es incorrecta";
                                    vLoginResult.IsSuccessful = false;
                                }
                            }
                            else
                            {
                                vLoginResult.UserMessage = "No existe el usuario";
                                vLoginResult.IsSuccessful = false;
                            }
                        }
                        else
                        {
                            vLoginResult.UserMessage = "No existe el usuario";
                            vLoginResult.IsSuccessful = false;
                        }
                        
                    }
                    else
                    {
                        vLoginResult.UserMessage = "No existen usuarios en la base de datos";
                        vLoginResult.IsSuccessful = false;
                    }
                    vContext.Database.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                vLoginResult.TechnicalMessage = ex.ToString();
                vLoginResult.UserMessage = ex.Message;
                vLoginResult.IsSuccessful = false;
            }
            return vLoginResult;


        }
        #endregion

        #region Products CRUD
        public ProductResponse GetUserProducts(ProductRequest pUserRequest)
        {
            ProductResponse vResponse = new ProductResponse();
            try
            {
                if (!ValidateToken(pUserRequest.SSOT))
                {
                    vResponse.UserMessage = "Sesión Caducada";
                    vResponse.IsSuccessful = false;
                    return vResponse;
                }
                using (BusinessDataModelEntities vContext = new BusinessDataModelEntities())
                {
                    vContext.Database.Connection.Open();
                    var vProductList = vContext.Product.AsQueryable();
                    if (vProductList != null)
                    {
                        var vUserProductsList = vProductList.Where<ProductEntity>(x => x.User.UserId.Equals(pUserRequest.UserId));
                        if (vUserProductsList != null && vUserProductsList.Any())
                        {
                            foreach (var vUserProduct in vUserProductsList)
                            {
                                vResponse.UserProducts.Add(new Product {
                                    ProductId = vUserProduct.ProductId,
                                    Price = vUserProduct.Price,
                                    MeasurementUnit = vUserProduct.MeasurementUnit,
                                    MeasurementUnitType = vUserProduct.MeasurementUnitType,
                                    Description = vUserProduct.Description,
                                    Name = vUserProduct.Name,
                                    CurrencyType = vUserProduct.CurrencyType,
                                    BarCode = vUserProduct.BarCode,
                                    ProductType = vUserProduct.ProductType,
                                    ProductCode = vUserProduct.ProductCode});
                            }
                            vResponse.IsSuccessful = true;
                        }
                        else
                        {
                            // El usuario no tiene productos asociados
                            vResponse.IsSuccessful = true;
                            vResponse.UserMessage = "El usuario no tiene productos asociados";
                        }
                    }
                    else
                    {
                        vResponse.IsSuccessful = true;
                        vResponse.UserMessage = "No existen Productos en la base de datos";
                    }


                    vContext.Database.Connection.Close();
                };
            }
            catch (Exception ex)
            {
                vResponse.IsSuccessful = false;
                vResponse.TechnicalMessage = ex.ToString();
                vResponse.UserMessage = ex.Message;
            }
            return vResponse;

        }

        public ProductResponse AddUserProduct(ProductRequest pNewProduct)
        {
            ProductResponse vResponse = new ProductResponse();
            try
            {
                if (!ValidateToken(pNewProduct.SSOT))
                {
                    vResponse.UserMessage = "Sesión Caducada";
                    vResponse.IsSuccessful = false;
                    return vResponse;
                }
                using (BusinessDataModelEntities vContext = new BusinessDataModelEntities())
                {
                    vContext.Database.Connection.Open();
                    vContext.Product.Add(new ProductEntity {
                        //ProductId = pNewProduct.UserProduct.ProductId,  auto increment
                        UserId_FK = pNewProduct.UserId,
                        Price = pNewProduct.UserProduct.Price,
                        MeasurementUnit = pNewProduct.UserProduct.MeasurementUnit,
                        MeasurementUnitType = pNewProduct.UserProduct.MeasurementUnitType,
                        Description = pNewProduct.UserProduct.Description,
                        Name = pNewProduct.UserProduct.Name,
                        CurrencyType = pNewProduct.UserProduct.CurrencyType,
                        BarCode = pNewProduct.UserProduct.BarCode,
                        ProductType = pNewProduct.UserProduct.ProductType,
                        ProductCode = pNewProduct.UserProduct.ProductCode
                    });
                    vContext.SaveChanges();

                    vContext.Database.Connection.Close();
                    vResponse.IsSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                vResponse.IsSuccessful = false;
                vResponse.TechnicalMessage = ex.ToString();
                vResponse.UserMessage = ex.Message;
            }
            return vResponse;
        }

        public ProductResponse SetUserProduct(ProductRequest pChangedProduct)
        {
            ProductResponse vResponse = new ProductResponse();
            try
            {
                if (!ValidateToken(pChangedProduct.SSOT))
                {
                    vResponse.UserMessage = "Sesión Caducada";
                    vResponse.IsSuccessful = false;
                    return vResponse;
                }
                using (BusinessDataModelEntities vContext = new BusinessDataModelEntities())
                {
                    vContext.Database.Connection.Open();
                    var vChangedProductEntity = new ProductEntity
                    {
                        ProductId = pChangedProduct.UserProduct.ProductId,
                        UserId_FK = pChangedProduct.UserId,
                        Price = pChangedProduct.UserProduct.Price,
                        MeasurementUnit = pChangedProduct.UserProduct.MeasurementUnit,
                        MeasurementUnitType = pChangedProduct.UserProduct.MeasurementUnitType,
                        Description = pChangedProduct.UserProduct.Description,
                        Name = pChangedProduct.UserProduct.Name,
                        CurrencyType = pChangedProduct.UserProduct.CurrencyType,
                        BarCode = pChangedProduct.UserProduct.BarCode,
                        ProductType = pChangedProduct.UserProduct.ProductType,
                        ProductCode = pChangedProduct.UserProduct.ProductCode
                    };
                    vContext.Product.Attach(vChangedProductEntity);
                    vContext.Entry(vChangedProductEntity).State = System.Data.Entity.EntityState.Modified;
                    vContext.SaveChanges();
                    vContext.Database.Connection.Close();
                    vResponse.IsSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                vResponse.IsSuccessful = false;
                vResponse.TechnicalMessage = ex.ToString();
                vResponse.UserMessage = ex.Message;
            }

            return vResponse;
        }


        public ProductResponse DeleteUserProduct(ProductRequest pDeleteProduct)
        {
            ProductResponse vResponse = new ProductResponse();
            try
            {
                if (!ValidateToken(pDeleteProduct.SSOT))
                {
                    vResponse.UserMessage = "Sesión Caducada";
                    vResponse.IsSuccessful = false;
                    return vResponse;
                }
                using (BusinessDataModelEntities vContext = new BusinessDataModelEntities())
                {
                    vContext.Database.Connection.Open();
                    var vChangedProductEntity = new ProductEntity
                    {
                        ProductId = pDeleteProduct.UserProduct.ProductId
                    };
                    vContext.Entry(vChangedProductEntity).State = System.Data.Entity.EntityState.Deleted;
                    vContext.SaveChanges();
                    vContext.Database.Connection.Close();
                    vResponse.IsSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                vResponse.IsSuccessful = false;
                vResponse.TechnicalMessage = ex.ToString();
                vResponse.UserMessage = ex.Message;
            }

            return vResponse;
        }
        #endregion

        #region Clients CRUD
        public ClientResponse AddUserClient(ClientRequest pNewClient)
        {
            ClientResponse vResponse = new ClientResponse();
            try
            {
                if (!ValidateToken(pNewClient.SSOT))
                {
                    vResponse.UserMessage = "Sesión Caducada";
                    vResponse.IsSuccessful = false;
                    return vResponse;
                }
                using (BusinessDataModelEntities vContext = new BusinessDataModelEntities())
                {
                    vContext.Database.Connection.Open();
                    var vListProduct = new List<ProductsByClientEntity>();
                    foreach (var vProduct in pNewClient.UserClient.ClientProducts)
                    {
                        vListProduct.Add(
                            new ProductsByClientEntity
                            {
                                ProductId_FK = vProduct.ProductId
                            }
                        );
                    }
                    ClientEntity vNewClient = new ClientEntity
                    {
                        UserId_FK = pNewClient.UserId,
                        Name = pNewClient.UserClient.Name,
                        ClientLegalNumber = pNewClient.UserClient.ClientLegalNumber,
                        Email = pNewClient.UserClient.Email,
                        IsIndependentPerson = pNewClient.UserClient.IsIndependentPerson,
                        DefaultDiscountPercentage = pNewClient.UserClient.DefaultDiscountPercentage,
                        DefaultTaxesPercentage = pNewClient.UserClient.DefaultTaxesPercentage,
                        PhoneNumber = pNewClient.UserClient.PhoneNumber,
                        LocationDescription = pNewClient.UserClient.LocationDescription,
                        DefaultPaymentTerm = pNewClient.UserClient.DefaultPaymentTerm,
                        ComercialName = pNewClient.UserClient.ComercialName,
                        LastName = pNewClient.UserClient.LastName,
                        SecondName = pNewClient.UserClient.SecondName,
                        IdentificationType = pNewClient.UserClient.IdentificationType,
                        ForeignIdentification = pNewClient.UserClient.ForeignIdentification,
                        ProvinciaCode = pNewClient.UserClient.ProvinciaCode,
                        CantonCode = pNewClient.UserClient.CantonCode,
                        DistritoCode = pNewClient.UserClient.DistritoCode,
                        BarrioCode = pNewClient.UserClient.BarrioCode,
                        PhoneNumberCountryCode = pNewClient.UserClient.PhoneNumberCountryCode,
                        FaxCountryCode = pNewClient.UserClient.FaxCountryCode,
                        Fax = pNewClient.UserClient.Fax,
                        ProductsByClient = vListProduct
                    };
                    vContext.Client.Add(vNewClient);
                    vContext.SaveChanges();

                    vContext.Database.Connection.Close();
                    vResponse.IsSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                vResponse.IsSuccessful = false;
                vResponse.TechnicalMessage = ex.ToString();
                vResponse.UserMessage = ex.Message;
            }
            return vResponse;
        }
        public ClientResponse GetUserClients(ClientRequest pUserRequest)
        {
            ClientResponse vResponse = new ClientResponse();
            try
            {
                if (!ValidateToken(pUserRequest.SSOT))
                {
                    vResponse.UserMessage = "Sesión Caducada";
                    vResponse.IsSuccessful = false;
                    return vResponse;
                }
                using (BusinessDataModelEntities vContext = new BusinessDataModelEntities())
                {
                    vContext.Database.Connection.Open();
                    var vClientsList = vContext.Client.AsQueryable();
                    if (vClientsList != null)
                    {
                        var vUserClients = vClientsList.Where(x => x.User.UserId.Equals(pUserRequest.UserId));
                        if (vUserClients != null && vUserClients.Any())
                        {
                            foreach (var vClient in vUserClients)
                            {
                                var vClientProducts = new List<Product>();
                                var vProductsByClient = vContext.ProductsByClient.AsQueryable();
                                if (vProductsByClient != null && vProductsByClient.Any())
                                {
                                    var vThisClientProducts = vProductsByClient.Where(x => x.ClientId_FK.Equals(vClient.ClientId));
                                    if (vThisClientProducts != null && vThisClientProducts.Any())
                                    {
                                        foreach (var vProduct in vThisClientProducts)
                                        {
                                            vClientProducts.Add(
                                                new Product {
                                                    ProductId = vProduct.Product.ProductId,
                                                    Price = vProduct.Product.Price,
                                                    MeasurementUnit = vProduct.Product.MeasurementUnit,
                                                    MeasurementUnitType = vProduct.Product.MeasurementUnitType,
                                                    Description = vProduct.Product.Description,
                                                    Name = vProduct.Product.Name,
                                                    CurrencyType = vProduct.Product.CurrencyType,
                                                    BarCode = vProduct.Product.BarCode,
                                                    ProductType = vProduct.Product.ProductType,
                                                    ProductCode = vProduct.Product.ProductCode,
                                                    ProductByClientId = vProduct.ProductsByClientId
                                                }
                                            );
                                        }
                                    }
                                }

                                vResponse.UserClients.Add(
                                    new Client {
                                        ClientId = vClient.ClientId,
                                        Name = vClient.Name,
                                        ClientLegalNumber = vClient.ClientLegalNumber,
                                        Email = vClient.Email,
                                        IsIndependentPerson = vClient.IsIndependentPerson,
                                        DefaultDiscountPercentage = vClient.DefaultDiscountPercentage,
                                        DefaultTaxesPercentage = vClient.DefaultTaxesPercentage,
                                        PhoneNumber = vClient.PhoneNumber,
                                        LocationDescription = vClient.LocationDescription,
                                        DefaultPaymentTerm = vClient.DefaultPaymentTerm,
                                        ComercialName = vClient.ComercialName,
                                        LastName = vClient.LastName,
                                        SecondName = vClient.SecondName,
                                        IdentificationType = vClient.IdentificationType,
                                        ForeignIdentification = vClient.ForeignIdentification,
                                        ProvinciaCode = vClient.ProvinciaCode,
                                        CantonCode = vClient.CantonCode,
                                        DistritoCode = vClient.DistritoCode,
                                        BarrioCode = vClient.BarrioCode,
                                        PhoneNumberCountryCode = vClient.PhoneNumberCountryCode,
                                        FaxCountryCode = vClient.FaxCountryCode,
                                        Fax = vClient.Fax,
                                        ClientProducts = vClientProducts
                                    }
                                );
                            }
                        }
                        else
                        {
                            vResponse.UserMessage = "No hay clientes para este usuario";
                        }
                    }
                    else {
                        vResponse.UserMessage = "No hay clientes en la base de datos";
                    }
                    vContext.Database.Connection.Close();
                    vResponse.IsSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                vResponse.IsSuccessful = false;
                vResponse.TechnicalMessage = ex.ToString();
                vResponse.UserMessage = ex.Message;
            }
            return vResponse;
        }

        public ClientResponse SetUserClient(ClientRequest pChangedClient)
        {
            ClientResponse vResponse = new ClientResponse();
            try
            {
                if (!ValidateToken(pChangedClient.SSOT))
                {
                    vResponse.UserMessage = "Sesión Caducada";
                    vResponse.IsSuccessful = false;
                    return vResponse;
                }
                using (BusinessDataModelEntities vContext = new BusinessDataModelEntities())
                {
                    vContext.Database.Connection.Open();

                    // ESTO NO SE PUEDE QUEDAR ASi, TIENE QUE SER POR UN QUERIABLE O POR SP
                    vContext.ProductsByClient.Where(w => w.ClientId_FK == pChangedClient.UserClient.ClientId)
                        .ToList().ForEach(x=>{
                            vContext.Entry(x).State = System.Data.Entity.EntityState.Deleted;
                        });

                    vContext.SaveChanges();

                    foreach (var vProduct in pChangedClient.UserClient.ClientProducts)
                    {
                        var vNewProductsByClient = new ProductsByClientEntity
                        {
                            ClientId_FK = pChangedClient.UserClient.ClientId,
                            ProductId_FK = vProduct.ProductId,
                            ProductsByClientId = vProduct.ProductByClientId
                        };
                        vContext.ProductsByClient.Add(vNewProductsByClient);
                    }
                    vContext.SaveChanges();
                    ClientEntity vChangedClient = new ClientEntity
                    {
                        UserId_FK = pChangedClient.UserId,
                        ClientId = pChangedClient.UserClient.ClientId,
                        Name = pChangedClient.UserClient.Name,
                        ClientLegalNumber = pChangedClient.UserClient.ClientLegalNumber,
                        Email = pChangedClient.UserClient.Email,
                        IsIndependentPerson = pChangedClient.UserClient.IsIndependentPerson,
                        DefaultDiscountPercentage = pChangedClient.UserClient.DefaultDiscountPercentage,
                        DefaultTaxesPercentage = pChangedClient.UserClient.DefaultTaxesPercentage,
                        PhoneNumber = pChangedClient.UserClient.PhoneNumber,
                        LocationDescription = pChangedClient.UserClient.LocationDescription,
                        DefaultPaymentTerm = pChangedClient.UserClient.DefaultPaymentTerm,
                        ComercialName = pChangedClient.UserClient.ComercialName,
                        LastName = pChangedClient.UserClient.LastName,
                        SecondName = pChangedClient.UserClient.SecondName,
                        IdentificationType = pChangedClient.UserClient.IdentificationType,
                        ForeignIdentification = pChangedClient.UserClient.ForeignIdentification,
                        ProvinciaCode = pChangedClient.UserClient.ProvinciaCode,
                        CantonCode = pChangedClient.UserClient.CantonCode,
                        DistritoCode = pChangedClient.UserClient.DistritoCode,
                        BarrioCode = pChangedClient.UserClient.BarrioCode,
                        PhoneNumberCountryCode = pChangedClient.UserClient.PhoneNumberCountryCode,
                        FaxCountryCode = pChangedClient.UserClient.FaxCountryCode,
                        Fax = pChangedClient.UserClient.Fax,
                    };
                    vContext.Client.Attach(vChangedClient);
                    vContext.Entry(vChangedClient).State = System.Data.Entity.EntityState.Modified;
                    vContext.SaveChanges();


                    vContext.Database.Connection.Close();
                    vResponse.IsSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                vResponse.IsSuccessful = false;
                vResponse.TechnicalMessage = ex.ToString();
                vResponse.UserMessage = ex.Message;
            }
            return vResponse;
        }

        public ClientResponse DeleteUserClient(ClientRequest pDeleteClient)
        {
            ClientResponse vResponse = new ClientResponse();
            try
            {
                if (!ValidateToken(pDeleteClient.SSOT))
                {
                    vResponse.UserMessage = "Sesión Caducada";
                    vResponse.IsSuccessful = false;
                    return vResponse;
                }
                using (BusinessDataModelEntities vContext = new BusinessDataModelEntities())
                {
                    vContext.Database.Connection.Open();

                    //Si hay una factura ya con este cliente, el cliente no puede ser eliminado
                    if (vContext.Bill.Any(x => x.ClientId_FK == pDeleteClient.UserClient.ClientId))
                    {
                        vResponse.UserMessage = "El cliente no puede ser eliminado porque ya posee Facturas";
                        vResponse.IsSuccessful = true;
                    }
                    else
                    {
                        // ESTO NO SE PUEDE QUEDAR ASi, TIENE QUE SER POR UN QUERIABLE O POR SP
                        vContext.ProductsByClient.Where(w => w.ClientId_FK == pDeleteClient.UserClient.ClientId)
                            .ToList().ForEach(x => {
                                vContext.Entry(x).State = System.Data.Entity.EntityState.Deleted;
                            });

                        var vDeleteClientEntity = new ClientEntity
                        {
                            ClientId = pDeleteClient.UserClient.ClientId
                        };
                        vContext.Entry(vDeleteClientEntity).State = System.Data.Entity.EntityState.Deleted;
                        vContext.SaveChanges();
                        vContext.Database.Connection.Close();
                        vResponse.IsSuccessful = true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                vResponse.IsSuccessful = false;
                vResponse.TechnicalMessage = ex.ToString();
                vResponse.UserMessage = ex.Message;
            }
            return vResponse;
        }
        #endregion


        #region Billing
        public BillResponse GetUserBills(BillRequest pBillRequest)
        {
            BillResponse vResponse = new BillResponse();
            try
            {
                if (!ValidateToken(pBillRequest.SSOT))
                {
                    vResponse.UserMessage = "Sesión Caducada";
                    vResponse.IsSuccessful = false;
                    return vResponse;
                }
                using (BusinessDataModelEntities vContext = new BusinessDataModelEntities())
                {
                    vContext.Database.Connection.Open();
                    var vBillList = vContext.Bill.AsQueryable();
                    if (vBillList != null)
                    {
                        var vUserBillsList = vBillList.Where<BillEntity>(x => x.User.UserId.Equals(pBillRequest.User.UserId));
                        if (vUserBillsList != null && vUserBillsList.Any())
                        {
                            foreach (var vUserBill in vUserBillsList)
                            {
                                vResponse.UserBills.Add(
                                    new Bill
                                    {
                                        BillId  = vUserBill.BillId,
                                        Status = vUserBill.Status,
                                        PurchaseOrderCode = vUserBill.PurchaseOrderCode,
                                        TotalAfterDiscount = vUserBill.TotalAfterDiscount,
                                        TaxesToPay = vUserBill.TaxesToPay,
                                        SubTotalProducts = vUserBill.SubTotalProducts,
                                        DiscountAmount = vUserBill.DiscountAmount,
                                        TotalToPay = vUserBill.TotalToPay,
                                        XMLSendedToHacienda = vUserBill.XMLSendedToHacienda,
                                        XMLReceivedFromHacienda = vUserBill.XMLReceivedFromHacienda,
                                        SoldProductsJSON = string.IsNullOrEmpty(vUserBill.SoldProductsJSON)? 
                                            null: JsonConvert.DeserializeObject<Client>(vUserBill.SoldProductsJSON),
                                        LastSendDate = vUserBill.LastSendDate,
                                        HaciendaFailCounter = vUserBill.HaciendaFailCounter,
                                        EmissionDate = vUserBill.EmissionDate,
                                        DocumentKey = vUserBill.DocumentKey,
                                        ConsecutiveNumber = vUserBill.ConsecutiveNumber,
                                        SellCondition = vUserBill.SellCondition,
                                        CreditTerm = vUserBill.CreditTerm,
                                        PaymentMethod = vUserBill.PaymentMethod,
                                        DiscountNature = vUserBill.DiscountNature,
                                        TaxCode = vUserBill.TaxCode,
                                        HaveExoneration = vUserBill.HaveExoneration,
                                        ExonerationAmount = vUserBill.ExonerationAmount,
                                        Observation = vUserBill.Observation,
                                        SystemMesagges = vUserBill.SystemMesagges
                                    }
                                    );
                            }
                        }
                    }
                    else
                    {
                        vResponse.IsSuccessful = true;
                        vResponse.UserMessage = "No existen Productos en la base de datos";
                    }

                    vContext.Database.Connection.Close();
                    vResponse.IsSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                vResponse.IsSuccessful = false;
                vResponse.TechnicalMessage = ex.ToString();
                vResponse.UserMessage = ex.Message;
            }
            return vResponse;
        }

        public BillResponse CreateBill(BillRequest pBillRequest)
        {
            BillResponse vResponse = new BillResponse();
            try
            {
                if (!ValidateToken(pBillRequest.SSOT))
                {
                    vResponse.UserMessage = "Sesión Caducada";
                    vResponse.IsSuccessful = false;
                    return vResponse;
                }
                using (BusinessDataModelEntities vContext = new BusinessDataModelEntities())
                {
                    vContext.Database.Connection.Open();
                    var vBillList = vContext.Bill.AsQueryable();
                    long vBillNumber = -1;
                    if (vBillList != null)
                    {
                        var vUserBillsList = vBillList.Where<BillEntity>(x => x.User.UserId.Equals(pBillRequest.User.UserId));
                        if (vUserBillsList != null && vUserBillsList.Any())
                        {
                            vBillNumber = vUserBillsList.Max(x => x.ConsecutiveNumber) + 1;
                        }
                        else
                        {
                            var vClientConfigurationQuery = vContext.AppConfiguration.AsQueryable();
                            var vClientConfiguration = vClientConfigurationQuery.Where<AppConfigurationEntity>(x => x.User.UserId.Equals(pBillRequest.User.UserId)).FirstOrDefault();
                            vBillNumber = vClientConfiguration.StartBillNumber;
                        }

                    }
                    if (vBillNumber != -1)
                    {

                        pBillRequest.ClientBill.EmissionDate = DateTime.Now;
                        pBillRequest.ClientBill.LastSendDate = DateTime.Now;
                        pBillRequest.ClientBill.Status = BillStatus.Processing.ToString();
                        vResponse.BillNumber = vBillNumber;
                        pBillRequest.ClientBill.ConsecutiveNumber = vBillNumber;
                        vResponse.PdfInvoice = BillingManager.GenerateBillPDF(pBillRequest.ClientBill, pBillRequest.User);
                        pBillRequest.ClientBill.DocumentKey = Core.Utils.GenerateDocumentKey(pBillRequest.ClientBill, pBillRequest.User);

                        BillEntity vBillToCreate = new BillEntity
                        {
                            //BillId  AutoIncrement
                            Status = pBillRequest.ClientBill.Status,
                            UserId_FK = pBillRequest.User.UserId,
                            PurchaseOrderCode = pBillRequest.ClientBill.PurchaseOrderCode,
                            TotalAfterDiscount = pBillRequest.ClientBill.TotalAfterDiscount,
                            TaxesToPay = pBillRequest.ClientBill.TaxesToPay,
                            SubTotalProducts = pBillRequest.ClientBill.SubTotalProducts,
                            DiscountAmount = pBillRequest.ClientBill.DiscountAmount,
                            TotalToPay = pBillRequest.ClientBill.TotalToPay,
                            ClientId_FK = pBillRequest.ClientBill.ClientId,
                            XMLSendedToHacienda = string.Empty,
                            XMLReceivedFromHacienda = string.Empty,
                            SoldProductsJSON = JsonConvert.SerializeObject(pBillRequest.ClientBill.SoldProductsJSON),
                            LastSendDate = pBillRequest.ClientBill.LastSendDate ?? DateTime.Now,
                            HaciendaFailCounter = 0,
                            EmissionDate = pBillRequest.ClientBill.EmissionDate ?? DateTime.Now,
                            DocumentKey = pBillRequest.ClientBill.DocumentKey,
                            ConsecutiveNumber = vBillNumber,
                            SellCondition = pBillRequest.ClientBill.SellCondition,
                            CreditTerm = pBillRequest.ClientBill.CreditTerm,
                            PaymentMethod = pBillRequest.ClientBill.PaymentMethod,
                            DiscountNature = pBillRequest.ClientBill.DiscountNature,
                            TaxCode = pBillRequest.ClientBill.TaxCode,
                            HaveExoneration = false, // still no manage Exonerations
                            ExonerationId_FK = null,
                            ExonerationAmount = 0,
                            Observation = pBillRequest.ClientBill.Observation
                        };
                        vContext.Bill.Add(vBillToCreate);
                        vContext.SaveChanges();
                        vContext.Database.Connection.Close();
                        vResponse.IsSuccessful = true;
                        
                    }
                    
                }
            }
            catch (Exception ex)
            {
                vResponse.IsSuccessful = false;
                vResponse.TechnicalMessage = ex.ToString();
                vResponse.UserMessage = ex.Message;
            }
            return vResponse;
        }
        #endregion


        public LoginResponse RegisterUser(SignupRequest pNewUser)
        {
            var vResponse = new LoginResponse();
            try
            {
                using (BusinessDataModelEntities vContext = new BusinessDataModelEntities())
                {
                    vContext.Database.Connection.Open();
                    var vUserList = vContext.User.AsQueryable();
                    if (vUserList != null)
                    {
                        var vUserLegalNumberValidation = vUserList.Where(x => x.UserLegalNumber.Equals(pNewUser.User.UserLegalNumber));
                        var vUserUsernameValidation = vUserList.Where(x => x.UserName.Equals(pNewUser.User.UserName));

                        // El numero de cedula ya existe
                        if (vUserLegalNumberValidation.Any())
                        {
                            vResponse.IsSuccessful = false;
                            vResponse.UserMessage = "La identificación ya ha sido usada, porfavor intente iniciar sesión";
                        }
                        else
                        {
                            // El correo ya ha sidoo usado por otro usuario
                            if (vUserUsernameValidation.Any())
                            {
                                vResponse.IsSuccessful = false;
                                vResponse.UserMessage = "Ya existe un usuario con este correo, porfavor intente iniciar sesión";
                            }
                            else
                            {
                                //Todas las validaciones han sido correctas
                                var vAddedUser = vContext.User.Add(new UserEntity
                                {

                                    UserName = pNewUser.User.UserName,
                                    Name = pNewUser.User.Name,
                                    LastName = pNewUser.User.LastName,
                                    SecondName = pNewUser.User.SecondName,
                                    Email = pNewUser.User.Email,
                                    UserLegalNumber = pNewUser.User.UserLegalNumber,
                                    /*HaciendaUsername = pNewUser.User.HaciendaUsername,
                                    HaciendaPassword = pNewUser.User.HaciendaPassword,
                                    HaciendaCryptographicPIN = pNewUser.User.HaciendaCryptographicPIN,
                                    HaciendaCryptographicFile = pNewUser.User.HaciendaCryptographicFile,
                                    HaciendaCryptographicFileName = pNewUser.User.HaciendaCryptographicFileName,*/
                                    Password = pNewUser.User.Password,
                                    PhoneNumber = pNewUser.User.PhoneNumber,
                                    HaciendaUserValidation = pNewUser.User.HaciendaUserValidation,
                                    IdentificationType = pNewUser.User.IdentificationType,
                                    ComercialName = pNewUser.User.ComercialName,
                                    ProvinciaCode = pNewUser.User.ProvinciaCode,
                                    CantonCode = pNewUser.User.CantonCode,
                                    DistritoCode = pNewUser.User.DistritoCode,
                                    BarrioCode = pNewUser.User.BarrioCode,
                                    LocationDescription = pNewUser.User.LocationDescription,
                                    PhoneNumberCountryCode = pNewUser.User.PhoneNumberCountryCode,
                                    FaxCountryCode = pNewUser.User.FaxCountryCode,
                                    Fax = pNewUser.User.Fax,

                                });
                                vContext.SaveChanges();


                                var vAppConfigurationResponse = vContext.AppConfiguration.Add(new AppConfigurationEntity
                                {
                                    StartBillNumber = pNewUser.UserAppConfiguration.StartBillNumber,
                                    UserId_FK = vAddedUser.UserId,
                                    Base64Logotype = pNewUser.UserAppConfiguration.Base64Logotype,
                                    EmailScheme = pNewUser.UserAppConfiguration.EmailScheme,
                                    Credits = pNewUser.UserAppConfiguration.Credits,
                                    IsPremiumAccount = pNewUser.UserAppConfiguration.IsPremiumAccount

                                });
                                vContext.SaveChanges();

                                vResponse.UserConfiguration = pNewUser.UserAppConfiguration;
                                vResponse.UserInformation = pNewUser.User;
                                vResponse.UserInformation.UserId = vAddedUser.UserId;
                                vResponse.SSOT = TEMPORAL_VALIDATION_TOKEN;

                                vResponse.IsSuccessful = true;
                            }
                        }

                    }

                    vContext.Database.Connection.Close();
                }
                
            }
            catch (Exception ex)
            {
                vResponse.IsSuccessful = false;
                vResponse.UserMessage = ex.Message;
                vResponse.TechnicalMessage = ex.ToString();
            }
            



            return vResponse;
        }

        public BaseResponse ValidateUserWithHacienda(UserValidationRequest pRequestValidationUser)
        {
            var vResponse = new BaseResponse();
            if (!ValidateToken(pRequestValidationUser.SSOT))
            {
                vResponse.UserMessage = "Sesión Caducada";
                vResponse.IsSuccessful = false;
                return vResponse;
            }
            try
            {
                var vUserValidationProxy = new Core.BIlling.UserValidation();
                var vValidationResponse = vUserValidationProxy.ValidateUserCredentials(pRequestValidationUser.User, false);
                if (vValidationResponse.IsSuccessful)
                {
                    using (BusinessDataModelEntities vContext = new BusinessDataModelEntities())
                    {
                        vContext.Database.Connection.Open();

                        var vUserList = vContext.User.AsQueryable();
                        var vActualUser = vUserList.Where(x => x.UserId.Equals(pRequestValidationUser.User.UserId)).First();

                        /*var vChangedUser = new UserEntity
                        {
                            UserId = pRequestValidationUser.User.UserId,
                            UserName = pRequestValidationUser.User.UserName,
                            Name = pRequestValidationUser.User.Name,
                            LastName = pRequestValidationUser.User.LastName,
                            SecondName = pRequestValidationUser.User.SecondName,
                            Email = pRequestValidationUser.User.Email,
                            UserLegalNumber = pRequestValidationUser.User.UserLegalNumber,
                            HaciendaUsername = pRequestValidationUser.User.HaciendaUsername,
                            HaciendaPassword = pRequestValidationUser.User.HaciendaPassword,
                            Password = pRequestValidationUser.User.Password,
                            HaciendaCryptographicPIN = pRequestValidationUser.User.HaciendaCryptographicPIN,
                            //HaciendaCryptographicFile = Convert.FromBase64String(pRequestValidationUser.User.HaciendaCryptographicFile),
                            HaciendaCryptographicFileName = pRequestValidationUser.User.HaciendaCryptographicFileName,
                            PhoneNumber = pRequestValidationUser.User.PhoneNumber,
                            HaciendaUserValidation = true,
                            IdentificationType = pRequestValidationUser.User.IdentificationType,
                            ComercialName = pRequestValidationUser.User.ComercialName,
                            ProvinciaCode = pRequestValidationUser.User.ProvinciaCode,
                            CantonCode = pRequestValidationUser.User.CantonCode,
                            DistritoCode = pRequestValidationUser.User.DistritoCode,
                            BarrioCode = pRequestValidationUser.User.BarrioCode,
                            LocationDescription = pRequestValidationUser.User.LocationDescription,
                            PhoneNumberCountryCode = pRequestValidationUser.User.PhoneNumberCountryCode,
                            FaxCountryCode = pRequestValidationUser.User.FaxCountryCode,
                            Fax = pRequestValidationUser.User.Fax,

                        };*/
                        vActualUser.HaciendaUsername = pRequestValidationUser.User.HaciendaUsername;
                        vActualUser.HaciendaPassword = pRequestValidationUser.User.HaciendaPassword;
                        vActualUser.HaciendaCryptographicPIN = pRequestValidationUser.User.HaciendaCryptographicPIN;
                        vActualUser.HaciendaCryptographicFile = Convert.FromBase64String(pRequestValidationUser.User.HaciendaCryptographicFile);
                        vActualUser.HaciendaUserValidation = true;


                        vContext.User.Attach(vActualUser);
                        vContext.Entry(vActualUser).State = System.Data.Entity.EntityState.Modified;
                        vContext.SaveChanges();
                        vContext.Database.Connection.Close();
                        vResponse.IsSuccessful = true;

                        vContext.Database.Connection.Close();
                    }
                }
                else
                {
                    vResponse.IsSuccessful = false;
                    vResponse.UserMessage = vValidationResponse.UserMessage;
                    vResponse.TechnicalMessage = vValidationResponse.TechnicalMessage;
                }
            }
            catch (Exception ex)
            {
                vResponse.IsSuccessful = false;
                vResponse.UserMessage = ex.Message;
                vResponse.TechnicalMessage = ex.ToString();
            }
            return vResponse;
        }
    }
}
