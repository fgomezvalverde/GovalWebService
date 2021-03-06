//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Goval.FacturaDigital.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientEntity()
        {
            this.Bill = new HashSet<BillEntity>();
            this.ProductsByClient = new HashSet<ProductsByClientEntity>();
        }
    
        public long ClientId { get; set; }
        public string Name { get; set; }
        public decimal DefaultDiscountPercentage { get; set; }
        public decimal DefaultTaxesPercentage { get; set; }
        public string PhoneNumber { get; set; }
        public string ClientLegalNumber { get; set; }
        public string LocationDescription { get; set; }
        public string Email { get; set; }
        public int DefaultPaymentTerm { get; set; }
        public string ComercialName { get; set; }
        public bool IsIndependentPerson { get; set; }
        public long UserId_FK { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string IdentificationType { get; set; }
        public string ForeignIdentification { get; set; }
        public string ProvinciaCode { get; set; }
        public string CantonCode { get; set; }
        public string DistritoCode { get; set; }
        public string BarrioCode { get; set; }
        public string PhoneNumberCountryCode { get; set; }
        public string FaxCountryCode { get; set; }
        public string Fax { get; set; }
        public string DiscountNature { get; set; }
        public string TaxCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillEntity> Bill { get; set; }
        public virtual IdentificationTypeEntity IdentificationType1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductsByClientEntity> ProductsByClient { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
