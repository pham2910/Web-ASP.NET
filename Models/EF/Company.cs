namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string Address { get; set; }

        public byte[] Logo { get; set; }

        [StringLength(50)]
        public string Web { get; set; }

        public double? Rating { get; set; }

        public int? Request { get; set; }

        public bool? Confirm { get; set; }

        public int? FieldID { get; set; }
    }
}
