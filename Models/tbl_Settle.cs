namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Settle
    {
        public int id { get; set; }

        [StringLength(50)]
        public string BrokerID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? netposition { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TradeDate { get; set; }
    }
}
