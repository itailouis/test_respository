namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CertificatesRegister")]
    public partial class CertificatesRegister
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Certificate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? shareholder { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal Status { get; set; }

        [StringLength(50)]
        public string SubmittingEntity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SubmittedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ImmobilizedDate { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UploadKey { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? shares { get; set; }
    }
}
