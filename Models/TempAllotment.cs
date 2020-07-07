namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TempAllotment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal Batch_Ref { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string cds_number { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal shares { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string TranType { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime Date_Of_Capture { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string Status { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string Captured_By { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool Audit { get; set; }
    }
}
