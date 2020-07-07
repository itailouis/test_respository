namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BrokerTran
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string company { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Broker_Code { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal TransID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string TransType { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal DealPrice { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal Quantity { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime DealDate { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "numeric")]
        public decimal Dealnum { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "numeric")]
        public decimal Dealsufix { get; set; }
    }
}
