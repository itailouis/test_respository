namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_company
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Company { get; set; }

        [StringLength(255)]
        public string Sector { get; set; }

        public decimal? SharePrice { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? YearEnd { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Issued_shares { get; set; }

        public decimal? Earnings { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Date_created { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CDS_Ac_No { get; set; }

        [StringLength(100)]
        public string registrar { get; set; }

        [StringLength(100)]
        public string Add_1 { get; set; }

        [StringLength(100)]
        public string Add_2 { get; set; }

        [StringLength(100)]
        public string Add_3 { get; set; }

        [StringLength(100)]
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

        [StringLength(255)]
        public string Comments { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(50)]
        public string ISIN_No { get; set; }

        [StringLength(100)]
        public string comp_Sector { get; set; }

        [StringLength(100)]
        public string Market_Segment { get; set; }

        [StringLength(50)]
        public string Instrument { get; set; }

        [StringLength(200)]
        public string Index_Type { get; set; }

        public decimal? FHL { get; set; }

        public decimal? FEL { get; set; }

        public decimal? SWL { get; set; }

        public decimal? InitialPrice { get; set; }

        [StringLength(200)]
        public string fnam { get; set; }

        [StringLength(200)]
        public string exchange { get; set; }

        [StringLength(50)]
        public string board { get; set; }

        [StringLength(50)]
        public string Symbol { get; set; }
    }

    public partial class Trust
    {
        public int ID { get; set; }

        public string Company { get; set; }

        public decimal? Issued_shares { get; set; }

        public decimal? InitialPrice { get; set; }

        public string fnam { get; set; }

    }

    public partial class Commodity
    {
        public string Id { get; set; }
        public string Product { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Multiples { get; set; }

    }

    public partial class ZipitBankCodes
    {
        public int id { get; set; }

        public string bank_name { get; set; }

        public string zipit_code { get; set; }

    }

    public partial class Deriv_Contract
    {
        public string ContractNo { get; set; }
        public string Assetname { get; set; }
        public string AssetDescription { get; set; }
        public string AssetQuantity { get; set; }
        public string Created_On { get; set; }

    }

    public partial class TrustCharges
    {
        public int ID { get; set; }

        public string Company { get; set; }

        public decimal? Issued_shares { get; set; }

        public decimal? InitialPrice { get; set; }

        public string fnam { get; set; }

        public string ChargesBuy { get; set; }

        public string ChargesSell { get; set; }

    }

    public partial class CommoPort
    {
        public string Company { get; set; }

        public string LastAcDate { get; set; }

        public string totAllShares { get; set; }

        public string prevdayQuantity { get; set; }

        public string currePrice { get; set; }

        public string PrevPrice { get; set; }
        public string Uncleared { get; set; }

        public string Net { get; set; }

    }

    public partial class ForexMarketWatch
    {
        public int ID { get; set; }
        public string BUREAU { get; set; }
        public string BUYING { get; set; }
        public string SELLING { get; set; }
        public string DATE_UPDATED { get; set; }
        public string CURRENCY { get; set; }
        public string BUY_LIMIT { get; set; }
        public string SELL_LIMIT { get; set; }

    }

    public partial class TrustBalance
    {
        public string Company { get; set; }

        public string Balance { get; set; }

    }

    public partial class NewsFeed
    {
        public string Heading { get; set; }

        public string Message { get; set; }

    }
}
