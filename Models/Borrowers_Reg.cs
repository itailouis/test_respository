namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Borrowers_Reg
    {
        public int id { get; set; }

        [StringLength(50)]
        public string client_type { get; set; }

        [StringLength(400)]
        public string client_name { get; set; }

        [StringLength(400)]
        public string client_number { get; set; }

        [StringLength(50)]
        public string company { get; set; }

        [StringLength(50)]
        public string securities { get; set; }

        [Column(TypeName = "money")]
        public decimal? unit_price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datecreated { get; set; }

        [StringLength(50)]
        public string capturedby { get; set; }

        [StringLength(50)]
        public string status { get; set; }
    }
}
