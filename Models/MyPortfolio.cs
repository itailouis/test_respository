using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class MyPortfolio
    {
        public string id { get; set; }
        public string counter { get; set; }
        public string numbershares { get; set; }
        public string lastactivitydate { get; set; }
        public string currentprice { get; set; }
        public string prevprice { get; set; }
        public string totalportvalue { get; set; }
        public string uncleared { get; set; }
        public string net { get; set; }
        public string totalPrevPortValue { get; set; }
        public string returns { get; set; }
        public string companyFullName { get; set; }
        public List<BuysByme> BuyDetail { get; set; }
        public List<SellsByme> SellDetail { get; set; }
    }

    public class MyPortfolioNew
    {
        public string id { get; set; }
        public string counter { get; set; }
        public string numbershares { get; set; }
        public string prev_numbershares { get; set; }
        public string lastactivitydate { get; set; }
        public string currentprice { get; set; }
        public string prevprice { get; set; }
        public string totalportvalue { get; set; }
        public string uncleared { get; set; }
        public string net { get; set; }
        public string totalPrevPortValue { get; set; }
        public string returns { get; set; }
        public string companyFullName { get; set; }
        public List<BuysByme> BuyDetail { get; set; }
        public List<SellsByme> SellDetail { get; set; }
    }

    public class PortfolioAll
    {
        public string id { get; set; }
        public string counter { get; set; }
        public string numbershares { get; set; }
        public string prev_numbershares { get; set; }
        public string lastactivitydate { get; set; }
        public string currentprice { get; set; }
        public string prevprice { get; set; }
        public string totalportvalue { get; set; }
        public string uncleared { get; set; }
        public string net { get; set; }
        public string totalPrevPortValue { get; set; }
        public string returns { get; set; }
        public string companyFullName { get; set; }
        public string Instrument { get; set; }
        public List<BuysByme> BuyDetail { get; set; }
        public List<SellsByme> SellDetail { get; set; }
    }
}