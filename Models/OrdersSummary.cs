namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrdersSummary")]
    public partial class OrdersSummary
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal OrderRef { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [Required]
        [StringLength(50)]
        public string CDS_Number { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Order_Quantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OrderValue { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderType { get; set; }

        public DateTime? OrderDate { get; set; }

        [Required]
        [StringLength(50)]
        public string PurchasingBroker { get; set; }

        [Required]
        [StringLength(50)]
        public string CapturedBy { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public bool? Updated { get; set; }

        [StringLength(50)]
        public string Updated_By { get; set; }

        public DateTime? Updated_On { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BasePrice { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TargetDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiryDate { get; set; }

        [StringLength(50)]
        public string OrderAttribute { get; set; }

        [StringLength(3)]
        public string OrderPreference { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ApprovalFlag { get; set; }

        [StringLength(5000)]
        public string ActivationCode { get; set; }

        [StringLength(5)]
        public string ActivationCodeApp { get; set; }

        [StringLength(500)]
        public string MarketBoard { get; set; }

        [StringLength(500)]
        public string OrderQualifier { get; set; }

        [StringLength(50)]
        public string settlementref { get; set; }
    }
}
