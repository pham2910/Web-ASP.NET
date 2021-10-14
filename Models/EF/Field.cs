namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Field")]
    public partial class Field
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string FieldName { get; set; }
    }
}
