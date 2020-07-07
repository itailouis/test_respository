namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class orders_trans
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal DealNo { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal SuffixNo { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal Quantity { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal BasePrice { get; set; }
    }
}
