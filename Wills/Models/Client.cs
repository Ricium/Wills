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
    
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.ClientWills = new HashSet<ClientWill>();
        }
    
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IDNumDOB { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public Nullable<int> LanguagesID { get; set; }
        public Nullable<int> MariedType { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual MariedType MariedType1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientWill> ClientWills { get; set; }
    }
}
