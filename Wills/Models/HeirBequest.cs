//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wills.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HeirBequest
    {
        public int HeirID { get; set; }
        public int FullWillID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; }
        public int RelationshipID { get; set; }
        public bool IsHeir { get; set; }
        public Nullable<decimal> HeirPercentage { get; set; }
        public Nullable<decimal> BequestAmount { get; set; }
        public string BequestItem { get; set; }
    
        public virtual FullWill FullWill { get; set; }
    }
}