namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_maker_checker
    {
        public int id { get; set; }

        [StringLength(50)]
        public string control { get; set; }

        [StringLength(50)]
        public string on_off { get; set; }
    }
}
