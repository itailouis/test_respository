namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class borrowers_valuation
    {
        public int id { get; set; }

        [StringLength(50)]
        public string client_number { get; set; }

        [StringLength(50)]
        public string BalanceSheetItems { get; set; }

        [StringLength(50)]
        public string Class { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateCreated { get; set; }

        [Column(TypeName = "money")]
        public decimal? Value { get; set; }

        [StringLength(50)]
        public string Capturedby { get; set; }
    }
}
