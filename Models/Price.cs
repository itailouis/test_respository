using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class Price
    {
        public int Id { get; set; }
        public string Counter { get; set; }
        public decimal Pricey { get; set; }
        public decimal Change { get; set; }
        public DateTime Date { get; set; }
    }
    public class MYPriceGRAPH
    {
        public string Price { get; set; }
        public string Date { get; set; }
    }

}