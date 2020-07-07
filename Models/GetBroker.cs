using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class GetBroker
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class GetBrokers
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string BuyingPrice{ get; set; }
        public string SellingPrice{ get; set; }
    }

    public class GetBureau
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string BuyingVolume { get; set; }
        public string BuyingPrice{ get; set; }
        public string SellingVolume { get; set; }
        public string SellingPrice{ get; set; }
    }

    public class Forex
    {
        public string ID { get; set; }
        public string BUREAU { get; set; }
        public string BUYING { get; set; }
        public string SELLING { get; set; }
        public string DATE_UPDATED { get; set; }
        public string UPDATED_BY { get; set; }
        public string ACTIVE { get; set; }
        public string CURRENCY { get; set; }
        public string BUY_LIMIT { get; set; }
        public string SELL_LIMIT { get; set; }
    }
}