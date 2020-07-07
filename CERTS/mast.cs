namespace CDSC.CERTS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mast")]
    public partial class mast
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string company { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal shareholder { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal cert { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cdno { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte cd { get; set; }

        public DateTime? date_created { get; set; }

        public decimal? shares { get; set; }

        public bool? hfc { get; set; }

        public bool? locked { get; set; }

        public bool? part_ind { get; set; }

        [StringLength(500)]
        public string tran_type { get; set; }

        public bool? printed { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? xfer { get; set; }

        [StringLength(10)]
        public string cert_type { get; set; }

        [StringLength(10)]
        public string cert_origin { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cert_print_group { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? share1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? update_no { get; set; }

        [StringLength(3000)]
        public string lockreason { get; set; }

        [StringLength(50)]
        public string Post_Reg { get; set; }

        [StringLength(50)]
        public string Locked_By { get; set; }

        [StringLength(50)]
        public string Unlocked_By { get; set; }

        public DateTime? TransDate { get; set; }

        public int? batch_ref { get; set; }

        [StringLength(50)]
        public string CustodianFrom { get; set; }

        [StringLength(50)]
        public string CustodianTo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? VestingDate { get; set; }

        [StringLength(1000)]
        public string UserRef { get; set; }

        [StringLength(1000)]
        public string NameRef { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Issue_No { get; set; }

        [Column(TypeName = "date")]
        public DateTime? issue_date { get; set; }
    }
}
