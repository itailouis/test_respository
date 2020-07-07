namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Interdepository")]
    public partial class Interdepository
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string ISIN { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Quantity { get; set; }

        [StringLength(50)]
        public string CDS_number { get; set; }

        [StringLength(50)]
        public string Stockexchange { get; set; }

        public short? Updated { get; set; }

        public string Full_Name { get; set; }

        [StringLength(50)]
        public string Bank_name { get; set; }

        [StringLength(50)]
        public string Swift_code { get; set; }

        [StringLength(50)]
        public string Bank_Account { get; set; }

        public short? locked { get; set; }
    }
}
