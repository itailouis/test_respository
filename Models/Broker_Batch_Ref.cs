namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Broker_Batch_Ref
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Batch_Ref { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Company { get; set; }

        [Required]
        [StringLength(50)]
        public string Batch_Type { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Shareholder { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Shares { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal Certificate { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal CD { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string CDS_Number { get; set; }

        [StringLength(150)]
        public string HolderNames { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(1)]
        public string CertVerification { get; set; }
    }
}
