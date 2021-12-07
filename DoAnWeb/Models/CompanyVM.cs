using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnWeb.Models
{
    public class CompanyVM
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public HttpPostedFileBase ImageLogo { get; set; }

        public string Web { get; set; }

        public int FieldID { get; set; }
    }
}