namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Deposits_Reg
    {
        public int id { get; set; }

        [StringLength(500)]
        public string ORDER_Number { get; set; }

        [StringLength(50)]
        public string CDS_Number { get; set; }

        [Column(TypeName = "money")]
        public decimal? Deposit_Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_of_Deposit { get; set; }

        [StringLength(50)]
        public string Flag_Status { get; set; }
    }
}
