using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class MarketWatcher
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string SharesInIssue { get; set; }
        public decimal ClosingPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal Change { get; set; }

        public string ChangeString { get; set; }

        public float ChangeFloat { get; set; }
        public string CompanyName { get; set; }
        public string Exchange { get; set; }
    }

    public class ShareAllocation
    {
          public string MyPercentage { get; set; }
          public string GroupTotal { get; set; }
          public string Mine { get; set; }
          public string Company { get; set; }
    

    }

    public class MarketWatcherZSE
    {
        public int id { get; set; }
        public string Ticker { get; set; }
        public string ISIN { get; set; }
        public string Best_Ask { get; set; }
        public string Best_bid { get; set; }
        public string Current_price { get; set; }
        public string Ask_Volume { get; set; }
        public string Bid_Volume { get; set; }
        public string FullCompanyName { get; set; }
        public string PrevPrice { get; set; }
        public string PrevPer { get; set; }
        public string PrevChange { get; set; }
    }

    public class Delivery
    {
        public int id { get; set; }
        public string Commodity { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Quantity { get; set; }
        public string Warehouse { get; set; }
        public string Expected_delivery_date { get; set; }
    }

    public class CommoType
    {
        public string Category { get; set; }
    }

    public class PSubCategory
    {
        public string Company { get; set; }
        public string InitialPrice { get; set; }
    }

    public class MarketData
    {
        public int PriceID { get; set; }
        public string company_name { get; set; }
        public string price_close { get; set; }
        public string price_open { get; set; }
        public string price_high { get; set; }
        public string price_low { get; set; }
        public string price_best { get; set; }
        public string price_volume { get; set; }
        public string price_date { get; set; }
        public string price_market_cap { get; set; }
        public string price_turnover { get; set; }
        public string price_vwap { get; set; }
        public string price_change { get; set; }
        public string price_change_per { get; set; }
    }
    public class Bureaus
    {
        public string Bureau { get; set; }
        public string date { get; set; }
        public string price { get; set; }
        public string price2 { get; set; }

    }
}