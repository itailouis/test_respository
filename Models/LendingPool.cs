namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LendingPool")]
    public partial class LendingPool
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string TransactionID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string LenderID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string LenderCDSNo { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Sectype { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "numeric")]
        public decimal Quantity { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "numeric")]
        public decimal Value { get; set; }

        [StringLength(20)]
        public string FeeType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Fee { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string BorrowerID { get; set; }

        [StringLength(50)]
        public string BorrowerCDSNo { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "numeric")]
        public decimal LoanPeriod { get; set; }

        [Key]
        [Column(Order = 10, TypeName = "date")]
        public DateTime RepaymentDate { get; set; }

        public bool? CalculateInterest { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? InterestRate { get; set; }

        public bool? RecDiv { get; set; }

        [StringLength(50)]
        public string CollateralType { get; set; }

        [StringLength(250)]
        public string CollataralDetail { get; set; }

        public bool? Authorized { get; set; }

        public short? Repaid { get; set; }

        public bool? BorrowerAccept { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AuthDate { get; set; }

        [StringLength(30)]
        public string lender_broker { get; set; }

        [StringLength(30)]
        public string borrower_broker { get; set; }

        [StringLength(50)]
        public string collateral_type { get; set; }

        [StringLength(50)]
        public string collateral_name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? collateral_value { get; set; }
    }
}
