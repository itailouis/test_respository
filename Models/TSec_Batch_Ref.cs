namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TSec_Batch_Ref
    {
        [Required]
        [StringLength(1000)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string CDS_Number { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Shareholder { get; set; }

        [Required]
        [StringLength(1000)]
        public string HolderNames { get; set; }

        [Required]
        [StringLength(50)]
        public string Batch_Type { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal Batch_ref { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal Certificate { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal CD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Shares { get; set; }

        [Column(TypeName = "date")]
        public DateTime Forwarded_On { get; set; }

        [Required]
        [StringLength(50)]
        public string Forwarded_By { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
