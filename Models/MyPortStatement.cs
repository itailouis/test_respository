using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class MyPortStatement
    {
        public string id { get; set; }
        public string counter { get; set; }
        public string date { get; set; }
        public string pricepershare { get; set; }
        public string volume { get; set; }
        public string purchasevalue { get; set; }
        public string currentmarketprice { get; set; }
        public string returns { get; set; }
    }

    public class market_cap_
    {
        public string id { get; set; }
        public string market_cap { get; set; }
        public string exchange { get; set; }
        public string turnover { get; set; }
        public string trades { get; set; }
    }
}