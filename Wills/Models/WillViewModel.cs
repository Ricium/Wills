using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wills.Models
{
    public class WillViewModel
    {
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

        public List<HeirViewModel> Heirs { get; set; }

        public List<HeirViewModel> Bequest { get; set; }
    }
}