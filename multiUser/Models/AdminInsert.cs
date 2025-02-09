using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace multiUser.Models
{
    public class AdminInsert
    {
        [Required(ErrorMessage = "*enter name*")]
        public string name { set; get; }

        [Required(ErrorMessage = "*enter address*")]

        public string address { set; get; }

        [RegularExpression(@"^(\d{10})$",ErrorMessage = "*enter valid number*")]
        public string phone{ set; get; }


        [EmailAddress(ErrorMessage = "enter vaild email")]
        public string email { set; get; }

        public string username { set; get; }

        public string pass { set; get; }

        [Compare("pass", ErrorMessage = "password mismatch")]
        public string cpassword { set; get; }
        public string adminmsg { set; get; }
    }
}