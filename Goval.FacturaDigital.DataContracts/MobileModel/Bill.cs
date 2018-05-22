using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.MobileModel
{
    [DataContract]
    public class Bill
    {
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string PurchaseOrderCode { get; set; }
        [DataMember]
        public decimal TotalAfterDiscount { get; set; }
        [DataMember]
        public decimal TaxesToPay { get; set; }
        [DataMember]
        public decimal SubTotalProducts { get; set; }
        [DataMember]
        public decimal DiscountAmount { get; set; }
        [DataMember]
        public decimal TotalToPay { get; set; }
        [DataMember]
        public long ClientId { get; set; }
        [DataMember]
        public string XMLReceivedFromHacienda { get; set; }
        [DataMember]
        public string XMLSendedToHacienda { get; set; }
        
        [DataMember]
        public Client SoldProductsJSON { get; set; }
        [DataMember]
        public long BillId { get; set; }
        [DataMember]
        public int HaciendaFailCounter { get; set; }
        [DataMember]
        public System.DateTime? LastSendDate { get; set; }
        [DataMember]
        public System.DateTime? EmissionDate { get; set; }
        [DataMember]
        public string DocumentKey { get; set; }
        [DataMember]
        public long ConsecutiveNumber { get; set; }
        [DataMember]
        public string SellCondition { get; set; }
        [DataMember]
        public string CreditTerm { get; set; }
        [DataMember]
        public string PaymentMethod { get; set; }
        [DataMember]
        public string DiscountNature { get; set; }
        [DataMember]
        public string TaxCode { get; set; }
        [DataMember]
        public string Observation { get; set; }

        [DataMember]
        public string SystemMesagges { get; set; }

        [DataMember]
        public bool HaveExoneration { get; set; }
        [DataMember]
        public decimal ExonerationAmount { get; set; }
        [DataMember]
        public Exoneration ExonerationData { get; set; }
        
    }
}
