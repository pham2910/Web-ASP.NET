namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        public int ReviewId { get; set; }

        public int? UserId { get; set; }

        public int? ComId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateCreated { get; set; }

        public int? Rating { get; set; }

        public string Content { get; set; }

        public bool? Incognito { get; set; }
    }
}
