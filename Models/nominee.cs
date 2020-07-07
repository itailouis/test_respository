namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class nominee
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Nominee_Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Nominee_Manager { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal Shareholder { get; set; }

        [StringLength(50)]
        public string CDSnumber { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Brokercode { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string add1 { get; set; }

        [StringLength(50)]
        public string add2 { get; set; }

        [StringLength(50)]
        public string add3 { get; set; }

        [StringLength(50)]
        public string add4 { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        public string cell { get; set; }

        [StringLength(50)]
        public string tell { get; set; }

        [StringLength(50)]
        public string fax { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string bank { get; set; }

        [StringLength(50)]
        public string branch { get; set; }

        [StringLength(50)]
        public string account_type { get; set; }

        [StringLength(50)]
        public string account { get; set; }

        [StringLength(50)]
        public string industry { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? tax { get; set; }

        [StringLength(50)]
        public string Updated_by { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime updated_on { get; set; }
    }
}
