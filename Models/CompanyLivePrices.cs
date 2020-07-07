using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class CompanyLivePrices
    {
        public int id { get; set; }
        public double BID { get; set; }
        public double OFFER { get; set; }
        public string COMPANY { get; set; }
        public double CurrentPrice { get; set; }
        public double ShareVOL { get; set; }
        public double LastUpdated { get; set; }
    }

    public class CompanyLivePricess
    {
        public string currentVolume { get; set; }
        public string CurrentPrice { get; set; }
    }
}