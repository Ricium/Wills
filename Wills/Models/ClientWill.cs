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
    
    public partial class ClientWill
    {
        public int ClientWillID { get; set; }
        public Nullable<int> LanguagesID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<int> WillID { get; set; }
        public Nullable<int> BequeathID { get; set; }
        public Nullable<int> ApointmentOfHeirsID { get; set; }
    
        public virtual AppointmentOFHeir AppointmentOFHeir { get; set; }
        public virtual Bequeath Bequeath { get; set; }
        public virtual Client Client { get; set; }
        public virtual Language Language { get; set; }
        public virtual Will Will { get; set; }
    }
}
