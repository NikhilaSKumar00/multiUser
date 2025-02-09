using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace multiUser.Models
{
    public class Logincls
    {
        [Required(ErrorMessage = "*enter username*")]
        public string Uname { set; get; }
        [Required(ErrorMessage = "*enter password*")]
        public string password { set; get; }

        public string msg { set; get; }
    }
}