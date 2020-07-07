using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class MarketWatch
    {
        public string Company { get; set; }
        public string Volume { get; set; }
        public string Bid { get; set; }
        public string VolumeSell { get; set; }
        public string Ask { get; set; }
        public string LastTradedPrice { get; set; }
        public string Lastmatched { get; set; }
        public string Lastvolume { get; set; }
        public string TotalVolume { get; set; }
        public string Turnover { get; set; }
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string AveragePrice { get; set; }
        public string Change { get; set; }
        public string Percchange { get; set; }
        public bidPrices BidDetail { get; set; }
        public offerPrices OfferDetail { get; set; }
    }


    public class MarketWatchNeww
    {
        public string market_company { get; set; }
        public string market_bbv { get; set; }
        public string market_bp { get; set; }
        public string market_va { get; set; }
        public string market_ap { get; set; }
        public string market_vwap { get; set; }
        public string market_lp { get; set; }
        public string market_lv { get; set; }
        public string market_tv { get; set; }
        public string market_to { get; set; }
        public string market_open { get; set; }
        public string market_high { get; set; }
        public string market_low { get; set; }
        public string market_change { get; set; }
        public string market_per_change { get; set; }
        public string details { get; set; }
        public string FullCompanyName { get; set; }
        public string Category { get; set; }
        public List<bidPrices_correct> bids { get; set; }
        public List<offerPrices> asks { get; set; }
    }
}