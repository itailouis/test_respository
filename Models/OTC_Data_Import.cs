namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OTC_Data_Import
    {
        public int id { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(50)]
        public string BuyOrderNum { get; set; }

        public int? Quantity { get; set; }

        [StringLength(50)]
        public string SellOrderNum { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TradeDate { get; set; }

        public int? SettlementStatus { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? importid { get; set; }
    }
}
