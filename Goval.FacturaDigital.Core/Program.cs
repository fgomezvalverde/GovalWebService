using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.Core
{
    class Program
    {
        static string testBill = @"{
  ""Status"": null,
  ""PurchaseOrderCode"": null,
  ""TotalAfterDiscount"": 950,
  ""TaxesToPay"": 0,
  ""SubTotalProducts"": 1000,
  ""DiscountAmount"": 50,
  ""TotalToPay"": 950,
  ""ClientId"": 2,
  ""XMLReceivedFromHacienda"": null,
  ""SoldProductsJSON"": {
    ""ClientId"": 2,
    ""Name"": ""cliente1"",
    ""DefaultDiscountPercentage"": 5,
    ""DefaultTaxesPercentage"": 0,
    ""PhoneNumber"": ""70183877"",
    ""ClientLegalNumber"": ""304530463"",
    ""LocationDescription"": ""prueba"",
    ""Email"": ""fabiangomezvalverde@gmail.com"",
    ""DefaultPaymentTerm"": 2,
    ""ComercialName"": ""prueba"",
    ""IsIndependentPerson"": false,
    ""LastName"": null,
    ""SecondName"": null,
    ""IdentificationType"": ""01"",
    ""ForeignIdentification"": null,
    ""ProvinciaCode"": ""1"",
    ""CantonCode"": ""01"",
    ""DistritoCode"": ""01"",
    ""BarrioCode"": ""01"",
    ""PhoneNumberCountryCode"": ""506"",
    ""FaxCountryCode"": ""506"",
    ""Fax"": ""123456"",
    ""ClientProducts"": [
      {
        ""ProductId"": 12,
        ""Price"": 1000,
        ""MeasurementUnit"": ""ninguna"",
        ""Description"": ""descrippro1"",
        ""Name"": ""pro1"",
        ""CurrencyType"": ""CRC"",
        ""BarCode"": ""0123"",
        ""ProductType"": ""01"",
        ""ProductCode"": ""codProd"",
        ""MeasurementUnitType"": ""m"",
        ""ProductByClientId"": 21,
        ""ProductQuantity"": 1,
        ""TotalCost"": 1000,
        ""IsUsed"": false
      },
      {
        ""ProductId"": 13,
        ""Price"": 1500,
        ""MeasurementUnit"": ""ninguno"",
        ""Description"": ""descrip pro2"",
        ""Name"": ""pro2"",
        ""CurrencyType"": ""CRC"",
        ""BarCode"": ""012245"",
        ""ProductType"": ""01"",
        ""ProductCode"": ""pcodro2"",
        ""MeasurementUnitType"": ""Sp"",
        ""ProductByClientId"": 22,
        ""ProductQuantity"": 0,
        ""TotalCost"": 0,
        ""IsUsed"": false
      }
    ]
  },
  ""BillId"": 0,
  ""HaciendaFailCounter"": 0,
  ""LastSendDate"": null,
  ""EmissionDate"": null,
  ""DocumentKey"": null,
  ""ConsecutiveNumber"": 0,
  ""SellCondition"": ""02"",
  ""CreditTerm"": ""25"",
  ""PaymentMethod"": ""01"",
  ""DiscountNature"": null,
  ""TaxCode"": null,
  ""HaveExoneration"": false,
  ""ExonerationAmount"": 0,
  ""ExonerationData"": null
}";
        static string base64File = "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";
        static void Main(string[] args)
        {
            //BIlling.BillingManager.CreateBill();
            var vUserValiation = new BIlling.UserValidation();
            /*vUserValiation.ValidateUserCredentials(new DataContracts.MobileModel.User
            {
                HaciendaUsername = """"cpf-03-0453-0463@stag.comprobanteselectronicos.go.cr"""",
                HaciendaPassword = """"}&eV*t;oJ({0$a|2No?!"""",
                HaciendaCryptographicPIN = """"1234"""",
                HaciendaCryptographicFile = base64File
            }, false);*/
            var obj = JsonConvert.DeserializeObject<DataContracts.MobileModel.Bill>(testBill);
            obj.ConsecutiveNumber = 1231243435;
            obj.EmissionDate = DateTime.Now;
            /*var bytesResult = BIlling.BillingManager.GenerateBillPDF(
                obj,null
                );*/
            //File.WriteAllBytes("C:\\DV\\Goval.FacturaDigital.BusinessService\\Goval.FacturaDigital.Core\\Foo.pdf", bytesResult);

            string test = DateTime.Now.ToString("ddMMyy");
            Console.WriteLine(test);
            Console.ReadLine();
        }
    }
}
