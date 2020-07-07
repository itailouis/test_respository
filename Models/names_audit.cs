namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class names_audit
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal Shareholder { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string Forenames { get; set; }

        [Required]
        [StringLength(50)]
        public string Idpp { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public DateTime? Date_created { get; set; }

        [StringLength(50)]
        public string Updated_by { get; set; }

        [StringLength(50)]
        public string Add_1 { get; set; }

        [StringLength(50)]
        public string Add_2 { get; set; }

        [StringLength(50)]
        public string Add_3 { get; set; }

        [StringLength(50)]
        public string Add_4 { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string Tax { get; set; }

        [StringLength(50)]
        public string holder_type { get; set; }
    }
}
