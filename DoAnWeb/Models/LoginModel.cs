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
        [Required ]
        public string userName { get; set; }
        public string password { get; set; }
    }
}