using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class PreOrderLives
    {
        public long ID { get; set; }
        public string OrderType { get; set; }
        public string Company { get; set; }
        public string SecurityType { get; set; }
        public string CDS_AC_No { get; set; }
        public string Broker_Code { get; set; }
        public string OrderStatus { get; set; }
        public DateTime Create_date { get; set; }
        public long Quantity { get; set; }
        //[Column(TypeName = "money")]
        //public Nullable<decimal> BasePrice { get; set; }
        public Double? BasePrice { get; set; }
        public string TimeInForce { get; set; }
        public string OrderQualifier { get; set; }
        public string BrokerRef { get; set; }
        public string OrderNumber { get; set; }
        public string Source { get; set; }
    }
    public class PreOrderLivess
    {
        public string id { get; set; }
        public string counter { get; set; }
        public string type { get; set; }
        public string volume { get; set; }
        public string price { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string desc { get; set; }
    }
}