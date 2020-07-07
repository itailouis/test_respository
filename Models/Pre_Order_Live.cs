namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pre_Order_Live
    {
        [Key]
        public long OrderNo { get; set; }

        [StringLength(50)]
        public string OrderType { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(10)]
        public string SecurityType { get; set; }

        [StringLength(50)]
        public string CDS_AC_No { get; set; }

        [StringLength(12)]
        public string Broker_Code { get; set; }

        [StringLength(50)]
        public string Client_Type { get; set; }

        public decimal? Tax { get; set; }

        [StringLength(50)]
        public string Shareholder { get; set; }

        [StringLength(50)]
        public string ClientName { get; set; }

        public int? TotalShareHolding { get; set; }

        [StringLength(50)]
        public string OrderStatus { get; set; }

        public DateTime? Create_date { get; set; }

        public DateTime? Deal_Begin_Date { get; set; }

        public DateTime? Expiry_Date { get; set; }

        public int? Quantity { get; set; }

        /*[Column(TypeName = "money")]
        public decimal? BasePrice { get; set; }*/

        public Double? BasePrice { get; set; }

        public int? AvailableShares { get; set; }

        [StringLength(50)]
        public string OrderPref { get; set; }

        [StringLength(255)]
        public string OrderAttribute { get; set; }

        [StringLength(255)]
        public string Marketboard { get; set; }

        [StringLength(255)]
        public string TimeInForce { get; set; }

        [StringLength(255)]
        public string OrderQualifier { get; set; }

        [StringLength(255)]
        public string BrokerRef { get; set; }

        [StringLength(255)]
        public string trading_platform { get; set; }

        [StringLength(255)]
        public string ContraBrokerId { get; set; }

        [Column(TypeName = "money")]
        public decimal? MaxPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? MiniPrice { get; set; }

        public bool? Flag_oldorder { get; set; }

        public bool? borrowStatus { get; set; }

        

        [StringLength(50)]
        public string OrderNumber { get; set; }

        [StringLength(30)]
        public string Currency { get; set; }

        public bool? FOK { get; set; }

        public bool? Affirmation { get; set; }

        [StringLength(30)]
        public string Source { get; set; }

        public string Custodian { get; set; }

        [Column(TypeName = "money")]
        public decimal? AmountValue { get; set; }
        


    }

    public class testb
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

    public class Pre_Order_Lives
    {
        public string id { get; set; }
        public string counter { get; set; }
        public string type { get; set; }
        public string volume { get; set; }
        public string price { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string desc { get; set; }
        public string fullname { get; set; }
        public string ordernumber { get; set; }
    }

    public class Pre_O_Lives
    {
        public int id { get; set; }
        public string counter { get; set; }
        public string type { get; set; }
        public string volume { get; set; }
        public string price { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string desc { get; set; }
        public string fullname { get; set; }
        public string ordernumber { get; set; }
        public string source { get; set; }
    }
    public class Forex_O_Lives
    {
        public int id { get; set; }
        public string counter { get; set; }
        public string type { get; set; }
        public string volume { get; set; }
        public string price { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string desc { get; set; }
        public string fullname { get; set; }
        public string ordernumber { get; set; }
        public string source { get; set; }
        public string Bureau { get; set; }
    }

    public class Pre_Order_Lives_new
    {
        public string id { get; set; }
        public string counter { get; set; }
        public string type { get; set; }
        public string volume { get; set; }
        public string price { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string desc { get; set; }
        public string fullname { get; set; }
        public string askprice { get; set; }
        public string bidprice { get; set; }
        public string askvolume { get; set; }
        public string current_price { get; set; }
        public string bidvolume { get; set; }
        public string security_type { get; set; }
        public string AmountValue { get; set; }
        
    }

    public class PreOrderLivess_new
    {
        public string id { get; set; }
        public string counter { get; set; }
        public string type { get; set; }
        public string volume { get; set; }
        public string price { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string desc { get; set; }
        public string fullname { get; set; }
    }

    public class Signup_qsn
    {
        public string id { get; set; }
        public string cds_number { get; set; }
        public string qsn_one { get; set; }
        public string qsn_two { get; set; }
        public string qsn_three { get; set; }

    }
}
