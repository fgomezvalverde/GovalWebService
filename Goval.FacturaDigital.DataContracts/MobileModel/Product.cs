using Goval.FacturaDigital.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.MobileModel
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public long ProductId { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string MeasurementUnit { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CurrencyType { get; set; }
        [DataMember]
        public string BarCode { get; set; }
        [DataMember]
        public string ProductType { get; set; }
        [DataMember]
        public string ProductCode { get; set; }
        [DataMember]
        public string MeasurementUnitType { get; set; }
        [DataMember]
        public long ProductByClientId { get; set; }
        [DataMember]
        public int ProductQuantity { get; set; }

        [DataMember]
        public decimal TotalCost { get; set; }
        [DataMember]
        public Boolean IsUsed { get; set; } = false;

    }
}
