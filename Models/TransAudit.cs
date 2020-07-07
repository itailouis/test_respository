namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TransAudit")]
    public partial class TransAudit
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal TransKey { get; set; }

        [Required]
        [StringLength(50)]
        public string company { get; set; }

        [Column(TypeName = "numeric")]
        public decimal batch_ref { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Shares { get; set; }

        [Required]
        [StringLength(50)]
        public string cds_number { get; set; }

        public DateTime date_of_capture { get; set; }

        [Required]
        [StringLength(50)]
        public string transBroker { get; set; }

        [Required]
        [StringLength(50)]
        public string CapturedBy { get; set; }

        public bool Audit { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AuditDate { get; set; }

        [StringLength(50)]
        public string TransType { get; set; }
    }
}
