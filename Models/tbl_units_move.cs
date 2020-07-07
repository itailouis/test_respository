namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_units_move
    {
        public int id { get; set; }

        [StringLength(50)]
        public string fromcdsnumber { get; set; }

        [StringLength(50)]
        public string tocdsnumber { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? quantity { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        [StringLength(50)]
        public string company { get; set; }

        public int? deal { get; set; }

        [Column(TypeName = "money")]
        public decimal? total_charge { get; set; }

        [StringLength(100)]
        public string charge_name { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? amount { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? buy_amount { get; set; }

        public decimal? Dealprice { get; set; }

        [StringLength(50)]
        public string Language { get; set; }
    }
}
