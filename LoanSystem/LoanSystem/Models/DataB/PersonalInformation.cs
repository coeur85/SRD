//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoanSystem.Models.DataB
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonalInformation
    {
        public int PersonID { get; set; }
        public string PersonfName { get; set; }
        public string PersonlName { get; set; }
        public System.DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    
        public virtual Agent Agent { get; set; }
    }
}