namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_settlementBankType
    {
        [Key]
        [Column("int")]
        public int _int { get; set; }

        [StringLength(500)]
        public string para_SettlementBank { get; set; }

        [StringLength(50)]
        public string status { get; set; }
    }
}
