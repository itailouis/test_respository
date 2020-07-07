namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_holding
    {
        [Key]
        public int ID_ { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [StringLength(50)]
        public string Issuer_Code { get; set; }

        [StringLength(50)]
        public string Debt_Type { get; set; }

        [StringLength(200)]
        public string Security_Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_Created { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GlobalLimit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IndividualLimit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DailyLimit { get; set; }

        [StringLength(50)]
        public string emailFrom { get; set; }

        [StringLength(50)]
        public string SMTPClient { get; set; }

        [StringLength(50)]
        public string NetworkCredUsername { get; set; }

        [StringLength(50)]
        public string NetworkCredPassword { get; set; }

        [StringLength(50)]
        public string SMTPport { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BidRatio { get; set; }

        [StringLength(100)]
        public string AirtelBidUsername { get; set; }

        [StringLength(100)]
        public string AirtelBidPassword { get; set; }

        [StringLength(100)]
        public string AirTelMarchantBillerCode { get; set; }

        public int? IPOSTATUS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? globLowerlimit { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? firstlimit { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? multiples { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? InterestRate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? IPOClosedDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Transaction_Limit { get; set; }

        [StringLength(500)]
        public string NewIssuerCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Listing_Date { get; set; }

        [StringLength(50)]
        public string Issuer { get; set; }
    }
}
