﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BusinessDataModelEntities : DbContext
    {
        public BusinessDataModelEntities()
            : base("name=BusinessDataModelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AppConfigurationEntity> AppConfiguration { get; set; }
        public virtual DbSet<BarrioTypeEntity> BarrioType { get; set; }
        public virtual DbSet<BillEntity> Bill { get; set; }
        public virtual DbSet<BillingHistoryEntity> BillingHistory { get; set; }
        public virtual DbSet<CantonTypeEntity> CantonType { get; set; }
        public virtual DbSet<ClientEntity> Client { get; set; }
        public virtual DbSet<CreditOrDebitNoteEntity> CreditOrDebitNote { get; set; }
        public virtual DbSet<CurrencyTypeEntity> CurrencyType { get; set; }
        public virtual DbSet<DistritoTypeEntity> DistritoType { get; set; }
        public virtual DbSet<ExceptionsTypeEntity> ExceptionsType { get; set; }
        public virtual DbSet<ExonerationEntity> Exoneration { get; set; }
        public virtual DbSet<ExonerationAuthorizationDocumentTypeEntity> ExonerationAuthorizationDocumentType { get; set; }
        public virtual DbSet<IdentificationTypeEntity> IdentificationType { get; set; }
        public virtual DbSet<PaymentMethodTypeEntity> PaymentMethodType { get; set; }
        public virtual DbSet<ProductEntity> Product { get; set; }
        public virtual DbSet<ProductsByClientEntity> ProductsByClient { get; set; }
        public virtual DbSet<ProductServiceTypeEntity> ProductServiceType { get; set; }
        public virtual DbSet<ProvinciaTypeEntity> ProvinciaType { get; set; }
        public virtual DbSet<ReferenceDocumentTypeEntity> ReferenceDocumentType { get; set; }
        public virtual DbSet<ReferencesCodeTypeEntity> ReferencesCodeType { get; set; }
        public virtual DbSet<SellConditionsTypeEntity> SellConditionsType { get; set; }
        public virtual DbSet<TaxesTypeEntity> TaxesType { get; set; }
        public virtual DbSet<UserEntity> User { get; set; }
        public virtual DbSet<cfg_barrio> cfg_barrio { get; set; }
        public virtual DbSet<cfg_canton> cfg_canton { get; set; }
        public virtual DbSet<cfg_distrito> cfg_distrito { get; set; }
        public virtual DbSet<cfg_pais> cfg_pais { get; set; }
        public virtual DbSet<cfg_provincia> cfg_provincia { get; set; }
    }
}
