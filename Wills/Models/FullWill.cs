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
    
    public partial class FullWill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FullWill()
        {
            this.HeirBequests = new HashSet<HeirBequest>();
        }
    
        public int WillID { get; set; }
        public string UserID { get; set; }
        public string PrimaryClientName { get; set; }
        public string PrimaryClientSurname { get; set; }
        public string PrimaryClientIDNumber { get; set; }
        public string SecandaryClientName { get; set; }
        public string SecanderyClientSurname { get; set; }
        public string SecandaryClientIDNumber { get; set; }
        public int WillTypeID { get; set; }
        public int MaritalStatusID { get; set; }
        public string GardianName { get; set; }
        public string GardianSurname { get; set; }
        public string GardianIDNumber { get; set; }
        public string CoExecutorName { get; set; }
        public string CoExecutorSurname { get; set; }
        public string CoExecutorIDNumber { get; set; }
        public string CoTrusteeName { get; set; }
        public string CoTrusteeSurname { get; set; }
        public string CoTrusteeIDNumber { get; set; }
        public bool DoCremation { get; set; }
        public bool IsLivingWill { get; set; }
        public bool IsOrganDoner { get; set; }
        public bool HasSpecialRequest { get; set; }
        public string SpecialRequest { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HeirBequest> HeirBequests { get; set; }
    }
}