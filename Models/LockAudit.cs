namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LockAudit")]
    public partial class LockAudit
    {
        [StringLength(50)]
        public string cds_Number { get; set; }

        [StringLength(50)]
        public string company { get; set; }

        [StringLength(50)]
        public string LockDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LockState { get; set; }

        [StringLength(6000)]
        public string LockReason { get; set; }

        [StringLength(50)]
        public string LockDoc { get; set; }

        [StringLength(50)]
        public string LockedBy { get; set; }

        [StringLength(50)]
        public string LockType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Approved { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [StringLength(5000)]
        public string RejectionReason { get; set; }
    }
}
