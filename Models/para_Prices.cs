namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_Prices
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string counter { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal price { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime PriceDate { get; set; }
    }
}
