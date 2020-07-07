namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Para_lendingRules
    {
        public int id { get; set; }

        [StringLength(50)]
        public string Security { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? InterestRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ServiceCharges { get; set; }

        public int? LendingPeriod { get; set; }

        [Column(TypeName = "money")]
        public decimal? MiniAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? MaxiAmount { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateCreated { get; set; }
    }
}
