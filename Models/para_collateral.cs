namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_collateral
    {
        [Key]
        public int collateral_id { get; set; }

        [StringLength(50)]
        public string collateral_name { get; set; }
    }
}
