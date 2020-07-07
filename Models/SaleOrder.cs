namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SaleOrder
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string OrderNumber { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string CDS_Number { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Order_Quantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Basic_Fee { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Stamp_Duty { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MinimumBrokerage { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TransferFees { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SecLevy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueBeforeTax { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TotalCharges { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OrderValue { get; set; }

        [Required]
        [StringLength(50)]
        public string Order_By { get; set; }
    }
}
