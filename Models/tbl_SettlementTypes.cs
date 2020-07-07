namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SettlementTypes
    {
        public int id { get; set; }

        [StringLength(50)]
        public string SettlementType { get; set; }
    }
}
