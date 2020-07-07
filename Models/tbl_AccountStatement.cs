namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_AccountStatement
    {
        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(50)]
        public string cds_number { get; set; }

        [StringLength(50)]
        public string Account_Type { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Transdate { get; set; }

        [Column(TypeName = "money")]
        public decimal? DR { get; set; }

        [Column(TypeName = "money")]
        public decimal? CR { get; set; }

        [StringLength(500)]
        public string Reference { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
    }
}
