namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_MatchedOrders
    {
        public long ID { get; set; }

        public long? Deal { get; set; }

        [StringLength(50)]
        public string BuyCompany { get; set; }

        [StringLength(50)]
        public string SellCompany { get; set; }

        [StringLength(100)]
        public string Buyercdsno { get; set; }

        [StringLength(100)]
        public string Sellercdsno { get; set; }

        public decimal? Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Trade { get; set; }

        public decimal? DealPrice { get; set; }

        [StringLength(50)]
        public string DealFlag { get; set; }

        [StringLength(50)]
        public string instrument { get; set; }
    }
}
