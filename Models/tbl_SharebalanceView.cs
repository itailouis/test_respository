namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SharebalanceView
    {
        public int id { get; set; }

        [StringLength(4000)]
        public string Holder { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Trade_Date { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Purchase { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Sale { get; set; }

        [StringLength(50)]
        public string DealNo { get; set; }

        [Column(TypeName = "money")]
        public decimal? Gross { get; set; }
    }
}
