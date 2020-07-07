namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cheq_dets
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal cheq_no { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal seq { get; set; }

        [Column(TypeName = "money")]
        public decimal? amount { get; set; }

        [StringLength(500)]
        public string payee { get; set; }

        [StringLength(40)]
        public string fnam { get; set; }

        [StringLength(1)]
        public string type { get; set; }

        [StringLength(1)]
        public string status { get; set; }

        [StringLength(10)]
        public string bank { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? branch { get; set; }

        [StringLength(20)]
        public string account { get; set; }

        [StringLength(60)]
        public string changed_by { get; set; }

        public DateTime? changed_on { get; set; }

        public DateTime? ActionDate { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Shareholder { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Div_no { get; set; }

        public bool? flag { get; set; }

        public DateTime? impdate { get; set; }

        [StringLength(500)]
        public string reson { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? replace { get; set; }

        [StringLength(50)]
        public string bank_ac { get; set; }

        [StringLength(1)]
        public string consold { get; set; }

        public DateTime? rdate { get; set; }

        public bool? r_man { get; set; }
    }
}
