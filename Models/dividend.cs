namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dividend")]
    public partial class dividend
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string company { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal div_no { get; set; }

        [StringLength(50)]
        public string shareholder { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string source { get; set; }

        [Column("short")]
        [StringLength(16)]
        public string _short { get; set; }

        [StringLength(500)]
        public string holder { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? shares_held { get; set; }

        [Column(TypeName = "money")]
        public decimal? offer_cash { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? offer_shares { get; set; }

        [Column(TypeName = "money")]
        public decimal? actual_gross { get; set; }

        [Column(TypeName = "money")]
        public decimal? actual_tax { get; set; }

        [Column(TypeName = "money")]
        public decimal? actual_nett { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? tax_rate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? actual_shares { get; set; }

        [StringLength(40)]
        public string add_1 { get; set; }

        [StringLength(40)]
        public string add_2 { get; set; }

        [StringLength(40)]
        public string add_3 { get; set; }

        [StringLength(40)]
        public string add_4 { get; set; }

        [StringLength(40)]
        public string add_5 { get; set; }

        public bool? mandate { get; set; }

        [StringLength(60)]
        public string man_add_1 { get; set; }

        [StringLength(60)]
        public string man_add_2 { get; set; }

        [StringLength(60)]
        public string man_add_3 { get; set; }

        [StringLength(60)]
        public string man_add_4 { get; set; }

        [StringLength(60)]
        public string man_add_5 { get; set; }

        [StringLength(3)]
        public string tax_code { get; set; }

        [StringLength(3)]
        public string country { get; set; }

        [StringLength(3)]
        public string industry { get; set; }

        [StringLength(10)]
        public string bank { get; set; }

        [StringLength(15)]
        public string bank_branch { get; set; }

        [StringLength(50)]
        public string bank_ac { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cheq_no { get; set; }

        public bool? hfc { get; set; }

        [StringLength(50)]
        public string origin { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? replace { get; set; }

        public DateTime? rdate { get; set; }

        [StringLength(1)]
        public string consold { get; set; }

        public bool? locked { get; set; }

        public bool? r_man { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? eft { get; set; }
    }
}
