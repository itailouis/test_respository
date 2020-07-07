namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pledge
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal pledge_no { get; set; }

        [Required]
        [StringLength(50)]
        public string cds_number { get; set; }

        [Required]
        [StringLength(50)]
        public string company { get; set; }

        [Column(TypeName = "numeric")]
        public decimal shares { get; set; }

        [Required]
        [StringLength(50)]
        public string pledgee { get; set; }

        [Required]
        [StringLength(250)]
        public string pledged_reason { get; set; }

        [Required]
        [StringLength(50)]
        public string updated_by { get; set; }

        public DateTime Date_created { get; set; }

        public bool pledgeState { get; set; }

        [StringLength(50)]
        public string Pledger { get; set; }

        [StringLength(50)]
        public string Pledgee_num { get; set; }

        [StringLength(5000)]
        public string Rejection { get; set; }
    }
}
