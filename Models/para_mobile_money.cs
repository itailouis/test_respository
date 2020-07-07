namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_mobile_money
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Mobile_money_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_added { get; set; }
    }
}
