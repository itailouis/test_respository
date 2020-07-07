namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment_SellOrder
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Quantity { get; set; }

        [StringLength(1)]
        public string Payment_Status { get; set; }
    }
}
