using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wills.Models
{
    public class WillViewModel
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IDNumDOB { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public Nullable<int> LanguagesID { get; set; }
        public Nullable<int> MariedType { get; set; }
        public string UserId { get; set; }

    }
}