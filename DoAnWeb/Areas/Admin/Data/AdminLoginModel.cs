using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnWeb.Areas.Admin.Data
{
    public class AdminLoginModel
    {
        [Required]
        public string adminName { get; set; }
        public string password { get; set;}
    }
}