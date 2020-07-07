namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SettlementCycle
    {
        [Key]
        [Column("int")]
        public int _int { get; set; }

        public int? TplusDays { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Updated_On { get; set; }
    }
}
