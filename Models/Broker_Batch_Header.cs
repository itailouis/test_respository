namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Broker_Batch_Header
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal Batch_Ref { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1000)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Batch_Type { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal Shares { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(1000)]
        public string Lodger { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(1000)]
        public string Created_by { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime Created_on { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string Status { get; set; }

        public bool? DebtSecurity { get; set; }

        [StringLength(50)]
        public string RejectionReason { get; set; }
    }
}
