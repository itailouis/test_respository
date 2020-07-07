namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Para_Fees
    {
        [Column(TypeName = "numeric")]
        public decimal BasicFee { get; set; }

        [Column(TypeName = "numeric")]
        public decimal StampDuty { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PurchaseRegistration { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MinimumBrokerage { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TransferFees { get; set; }

        [Column(TypeName = "numeric")]
        public decimal WithholdingTax { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SecLevy { get; set; }

        public DateTime DateUpdate { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Trans_ID { get; set; }
    }
}
