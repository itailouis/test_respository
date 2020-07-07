namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DematBatchheader")]
    public partial class DematBatchheader
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal Batch_ref { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? shareholder { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal TotalShares { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime CapturedDate { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string ClientCode { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string ClientUser { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool Status { get; set; }
    }
}
