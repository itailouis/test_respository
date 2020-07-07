namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_holiday
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? holiday_date { get; set; }

        [StringLength(50)]
        public string comment { get; set; }
    }
}
