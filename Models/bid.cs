namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bid
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal deal_number { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal bid_number { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal broker_code { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal client_Acc { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal company { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime bid_date { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] bid_time { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "money")]
        public decimal bid_price { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "numeric")]
        public decimal status { get; set; }
    }
}
