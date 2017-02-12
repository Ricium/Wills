using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wills.Models
{
    public class HeirViewModel
    {
        [Required]
        [DisplayName("Heir ID")]
        public int HeirID { get; set; }
        [Required]
        [DisplayName("Full Will ID")]
        public int FullWillID { get; set; }
        [Required]
        [DisplayName("Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Surname")]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required]
        [DisplayName("ID Number")]
        [StringLength(13)]
        public string IDNumber { get; set; }
        [Required]
        [DisplayName("Relationship ID")]
        public int RelationshipID { get; set; }
        [Required]
        [DisplayName("Is Heirs")]
        public bool IsHeir { get; set; }
      
        [DisplayName("Heir Percentage")]
        public Nullable<decimal> HeirPercentage { get; set; }
        [DisplayName("Bequest Amount")]
     
        public Nullable<decimal> BequestAmount { get; set; }
        [DisplayName("Bequest Item")]
        [StringLength(250)]
        public string BequestItem { get; set; }
    }
}