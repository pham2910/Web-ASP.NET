using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnWeb.Models
{
    public class LoginModel
    {
        public int ID { get; set; }

        public string email { get; set; }

        [Required(ErrorMessage = "Please enter your name or your email.")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        public string password { get; set; }
    }
}