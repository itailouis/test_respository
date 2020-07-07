namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_Billing
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ChargeCode { get; set; }

        [StringLength(50)]
        public string ChargeName { get; set; }

        public double? PercentageOrValue { get; set; }

        [StringLength(50)]
        public string ApplyTo { get; set; }

        [StringLength(50)]
        public string Indicator { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }
    }
}
