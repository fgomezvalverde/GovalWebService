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
    
    public partial class CreditOrDebitNoteEntity
    {
        public long CreditOrDebitNoteId { get; set; }
        public Nullable<long> BillId_FK { get; set; }
        public string DocuementKey { get; set; }
        public System.DateTime EmissionDate { get; set; }
        public string ReferenceCode { get; set; }
        public string ReasonDescription { get; set; }
        public Nullable<long> BillId_CreditDebitNote_FK { get; set; }
    
        public virtual BillEntity Bill { get; set; }
        public virtual ReferencesCodeTypeEntity ReferencesCodeType { get; set; }
        public virtual BillEntity Bill1 { get; set; }
    }
}
