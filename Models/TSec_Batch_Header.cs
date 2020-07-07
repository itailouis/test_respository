namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TSec_Batch_Header
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal Batch_Ref { get; set; }

        [StringLength(50)]
        public string batch_type { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime Batch_Date { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal Batch_Total { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Batch_Broker { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Batch_Forwarded_By { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime Batch_Forwarded_On { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string Accepted_By { get; set; }

        [Key]
        [Column(Order = 8)]
        public DateTime Accepted_On { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(50)]
        public string Status { get; set; }

        public bool? DebtSecurity { get; set; }

        [StringLength(5000)]
        public string rejection { get; set; }
    }
}
