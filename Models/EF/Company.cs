namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Company")]
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [DataType(DataType.Upload)]
        public string Logo { get; set; }
        /*public HttpPostedFileBase ImageLogo { get; set; }*/

        [StringLength(100)]
        public string Web { get; set; }

        public double? Rating { get; set; }

        public int? UserRequest { get; set; }

        public bool? Confirm { get; set; }

        public int? FieldID { get; set; }

        public virtual Field Field { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
