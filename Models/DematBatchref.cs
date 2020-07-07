namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DematBatchref")]
    public partial class DematBatchref
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal Batch_ref { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal Shareholder { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal Cert { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal Shares { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal oldshareholder { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime CapturedDate { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string ClientCode { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string ClientUser { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "numeric")]
        public decimal Status { get; set; }
    }
}
