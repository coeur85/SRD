//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KokiDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderAudit
    {
        public int AuditID { get; set; }
        public int OrderID { get; set; }
        public int AdminID { get; set; }
        public System.DateTime AuditDate { get; set; }
        public int NewStatusID { get; set; }
        public string AdminNotes { get; set; }
    
        public virtual Administrator Administrator { get; set; }
        public virtual Order Order { get; set; }
        public virtual OrderStatu OrderStatu { get; set; }
    }
}
