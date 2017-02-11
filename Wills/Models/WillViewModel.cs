using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wills.Models
{
    public class WillViewModel
    {
        public WillViewModel() { }

        public WillViewModel(Client Details)
        {
            if (Details != null)
            {
                this.UserId = Details.UserId;
                this.ClientID = Details.ClientID;
                this.Name = Details.Name;
                this.Surname = Details.Surname;
                this.ContactNo = Details.ContactNo;
                this.Email = Details.Email;
                this.IDNumDOB = Details.IDNumDOB;
                this.LanguagesID = Details.LanguagesID;
                this.MariedType = Details.MariedType;
            }
        }

        [UIHint("Willtype")]
        [DisplayName("Will Type")]
        public int WillType { get; set; }

        public string UserId { get; set; }
        public int ClientID { get; set; }   
             
        [UIHint("Text")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [UIHint("Text")]
        [DisplayName("Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage ="ID Number is Required")]
        [UIHint("Text")]
        [DisplayName("ID Number")]
        [AdditionalMetadata("Max", "13")]        
        public string IDNumDOB { get; set; }

        [UIHint("Email")]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        [UIHint("Text")]
        [DisplayName("Contact Number")]
        [AdditionalMetadata("Max", "10")]
        public string ContactNo { get; set; }


        public int? LanguagesID { get; set; }
        public int? MariedType { get; set; }      
    }
}