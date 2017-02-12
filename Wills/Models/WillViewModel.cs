using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wills.Models
{
    public class WillViewModel
    {
        [Required]
        [DisplayName("Will ID")]
        public int WillID { get; set; }
        [Required]
        [DisplayName("User ID")]
        public string UserID { get; set; }
        [Required]
        [DisplayName("Name")]
        [StringLength(50)]
        public string PrimaryClientName { get; set; }
        [Required]
        [DisplayName("Surname")]
        [StringLength(50)]
        public string PrimaryClientSurname { get; set; }
        [Required]
        [DisplayName("ID Number")]
        [StringLength(13)]
        public string PrimaryClientIDNumber { get; set; }

        [DisplayName("Name")]
        [StringLength(50)]
        public string SecandaryClientName { get; set; }

        [DisplayName("Surname")]
        [StringLength(50)]
        public string SecanderyClientSurname { get; set; }
        [DisplayName("ID Number")]
        [StringLength(13)]
        public string SecandaryClientIDNumber { get; set; }
        [DisplayName("Will Type")]
        public int WillTypeID { get; set; }
        [DisplayName("Marital Status")]
        public int MaritalStatusID { get; set; }
        [DisplayName("Name")]
        [StringLength(50)]
        public string GardianName { get; set; }
        [DisplayName("Surname")]
        [StringLength(50)]
        public string GardianSurname { get; set; }
        [DisplayName("ID Number")]
        [StringLength(13)]
        public string GardianIDNumber { get; set; }
        [DisplayName("Name")]
        [StringLength(50)]
        public string CoExecutorName { get; set; }
        [DisplayName("Surname")]
        [StringLength(50)]
        public string CoExecutorSurname { get; set; }
        [DisplayName("ID Number")]
        [StringLength(50)]
        public string CoExecutorIDNumber { get; set; }
        [DisplayName("Name")]
        [StringLength(50)]
        public string CoTrusteeName { get; set; }
        [DisplayName("Surname")]
        [StringLength(50)]
        public string CoTrusteeSurname { get; set; }
        [DisplayName("ID Number")]
        [StringLength(13)]
        public string CoTrusteeIDNumber { get; set; }
        [DisplayName("Would you like your remains to be cremated?")]
        public bool DoCremation { get; set; }
        [DisplayName("Would you like to provide for a living will?")]
        public bool IsLivingWill { get; set; }
        [DisplayName("Would you like your organs donated for medical research and/or transplantpurposes?")]
        public bool IsOrganDoner { get; set; }
        [DisplayName("Specify your own request.")]
        public bool HasSpecialRequest { get; set; }
        [DisplayName("Special Request")]
        [StringLength(50)]
        public string SpecialRequest { get; set; }

        public List<HeirViewModel> Heirs { get; set; }

        public List<HeirViewModel> Bequest { get; set; }
    }
}