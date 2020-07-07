namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_DebtCompany
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [StringLength(50)]
        public string Issuer { get; set; }

        [StringLength(50)]
        public string DebtType { get; set; }

        [StringLength(150)]
        public string DebtName { get; set; }

        [StringLength(50)]
        public string ShortCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ParValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FaceValue { get; set; }

        [Column(TypeName = "date")]
        public DateTime? IssueDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MaturityDate { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DaysToMature { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NoCerts { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? InitialShareCap { get; set; }
    }
}
