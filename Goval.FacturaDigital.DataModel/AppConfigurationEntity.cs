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
    
    public partial class AppConfigurationEntity
    {
        public long AppConfigurationId { get; set; }
        public long StartBillNumber { get; set; }
        public long UserId_FK { get; set; }
        public string Base64Logotype { get; set; }
        public string EmailScheme { get; set; }
        public decimal Credits { get; set; }
        public bool IsPremiumAccount { get; set; }
        public long StartDebitCreditNoteNumber { get; set; }
    
        public virtual UserEntity User { get; set; }
    }
}
