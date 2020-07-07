namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mandate
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string shareholder { get; set; }

        [StringLength(50)]
        public string ManLname { get; set; }

        [StringLength(50)]
        public string ManFnames { get; set; }

        [StringLength(50)]
        public string ManTitle { get; set; }

        [StringLength(50)]
        public string ManIdpp { get; set; }

        [StringLength(60)]
        public string add_1 { get; set; }

        [StringLength(60)]
        public string add_2 { get; set; }

        [StringLength(60)]
        public string add_3 { get; set; }

        [StringLength(60)]
        public string add_4 { get; set; }

        [StringLength(60)]
        public string add_5 { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        public string telephone { get; set; }

        [StringLength(50)]
        public string cellphone { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fax { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string man_bank { get; set; }

        [StringLength(50)]
        public string man_bankCode { get; set; }

        [StringLength(50)]
        public string man_branch { get; set; }

        [StringLength(50)]
        public string man_branchCode { get; set; }

        [StringLength(50)]
        public string man_acc { get; set; }

        [StringLength(20)]
        public string postcode { get; set; }

        [StringLength(50)]
        public string eft { get; set; }
    }
}
