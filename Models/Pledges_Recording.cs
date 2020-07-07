namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pledges_Recording
    {
        public int id { get; set; }

        [StringLength(4000)]
        public string PledgeType { get; set; }

        [StringLength(4000)]
        public string PledgeReason { get; set; }

        [Column(TypeName = "image")]
        public byte[] IdentityDocuments { get; set; }

        [Column(TypeName = "image")]
        public byte[] CourtDocuments { get; set; }

        [Column(TypeName = "image")]
        public byte[] PledgeForms { get; set; }

        [Column(TypeName = "image")]
        public byte[] OtherDocuments { get; set; }

        [StringLength(4000)]
        public string Cds_Number { get; set; }

        [StringLength(4000)]
        public string Surname { get; set; }

        [StringLength(4000)]
        public string Forenames { get; set; }

        [StringLength(4000)]
        public string Company { get; set; }

        [StringLength(4000)]
        public string SecurityType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EffectiveDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiryDate { get; set; }

        [StringLength(4000)]
        public string Pledgee_Type { get; set; }

        [StringLength(4000)]
        public string Pledgee_Cds_number { get; set; }

        [StringLength(4000)]
        public string Pledgee_Surname { get; set; }

        [StringLength(4000)]
        public string Pledgee_Forenames { get; set; }

        [StringLength(4000)]
        public string Pledgeee_Add_1 { get; set; }

        [StringLength(4000)]
        public string Pledgee_Add_2 { get; set; }

        [StringLength(4000)]
        public string Pledgee_Add_3 { get; set; }

        [StringLength(4000)]
        public string Pledgee_Add_4 { get; set; }

        [StringLength(4000)]
        public string Pledgee_City { get; set; }

        [StringLength(4000)]
        public string Pledgee_Country { get; set; }

        [StringLength(4000)]
        public string Pledge_Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Pledge_Created_on { get; set; }

        [StringLength(4000)]
        public string Pledge_Created_By { get; set; }

        [StringLength(10)]
        public string Pledge_with_income { get; set; }

        [StringLength(10)]
        public string Pledge_capital_benefits { get; set; }

        [StringLength(50)]
        public string release_option { get; set; }

        [StringLength(10)]
        public string released { get; set; }

        [StringLength(10)]
        public string transferred { get; set; }

        [StringLength(10)]
        public string amendment { get; set; }
    }
}
