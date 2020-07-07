namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_company_crosslisted
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Fnam { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Date_created { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Issued_shares { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CDS_Ac_No { get; set; }

        [StringLength(50)]
        public string registrar { get; set; }

        [StringLength(50)]
        public string Add_1 { get; set; }

        [StringLength(50)]
        public string Add_2 { get; set; }

        [StringLength(50)]
        public string Add_3 { get; set; }

        [StringLength(50)]
        public string Add_4 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string Contact_Person { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        [StringLength(50)]
        public string Cellphone { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Comments { get; set; }

        [StringLength(50)]
        public string sec_type { get; set; }

        [StringLength(50)]
        public string board { get; set; }

        [StringLength(50)]
        public string index_type { get; set; }

        [StringLength(50)]
        public string ticker { get; set; }

        [StringLength(50)]
        public string ISIN { get; set; }

        [StringLength(50)]
        public string year_listed { get; set; }

        [StringLength(50)]
        public string comp_secretary { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string website { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? issued_capital { get; set; }

        [Column(TypeName = "money")]
        public decimal? nominal_value { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? company_id { get; set; }

        [StringLength(50)]
        public string stockexchange { get; set; }
    }
}
