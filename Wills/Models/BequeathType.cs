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
    
    public partial class BequeathType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BequeathType()
        {
            this.Bequeaths = new HashSet<Bequeath>();
        }
    
        public int BequeathTypeID { get; set; }
        public string BequeathTypeDesc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bequeath> Bequeaths { get; set; }
    }
}
