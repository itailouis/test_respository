namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class div_reprint
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string company { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short div_no { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int shareholder { get; set; }

        [Key]
        [Column("short", Order = 3)]
        [StringLength(16)]
        public string _short { get; set; }

        [StringLength(60)]
        public string holder { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal shares_held { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "money")]
        public decimal offer_cash { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "numeric")]
        public decimal offer_shares { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "money")]
        public decimal actual_gross { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "money")]
        public decimal actual_tax { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "money")]
        public decimal actual_nett { get; set; }

        [Key]
        [Column(Order = 10, TypeName = "numeric")]
        public decimal tax_rate { get; set; }

        [Key]
        [Column(Order = 11, TypeName = "numeric")]
        public decimal actual_shares { get; set; }

        [Key]
        [Column(Order = 12)]
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

        [Key]
        [Column(Order = 13)]
        public bool mandate { get; set; }

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

        [Key]
        [Column(Order = 14)]
        [StringLength(3)]
        public string tax_code { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(3)]
        public string country { get; set; }

        [StringLength(3)]
        public string industry { get; set; }

        public int? bank_branch { get; set; }

        [StringLength(20)]
        public string bank_ac { get; set; }

        [Key]
        [Column(Order = 16)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cheq_no { get; set; }

        public bool? printed { get; set; }

        public int? cheq_no_old { get; set; }

        public bool? recon { get; set; }
    }
}
