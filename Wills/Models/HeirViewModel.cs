using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wills.Models
{
    public class HeirViewModel
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
        public bool IsDeleted { get; set; }
    }
}