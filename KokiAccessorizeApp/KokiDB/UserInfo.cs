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
    
    public partial class UserInfo
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
    
        public virtual Administrator Administrator { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
