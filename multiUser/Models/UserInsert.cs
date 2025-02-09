using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace multiUser.Models
{
    public class UserInsert
    {
        public int uid { set; get; }

        [Required(ErrorMessage = "*enter name*")]
        public string name { set; get; }

        

        [Range(18,50, ErrorMessage = "*enter age*")]
        public int age  { set; get; }
        [Required(ErrorMessage = "*enter address*")]
        public string address { set; get; }

     
     

        [EmailAddress(ErrorMessage = "enter vaild email")]
        public string email { set; get; }
        public string photo { set; get; }

        public string username { set; get; }

        public string pass { set; get; }

        [Compare("pass", ErrorMessage = "password mismatch")]
        public string cpassword { set; get; }
        public string usermsg { set; get; }
    }
}