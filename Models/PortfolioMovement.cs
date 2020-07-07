using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class PortfolioMovement
    {
        //        Shares Date    Company CompanyName
        public string CompanyName { get; set; }
        public string Shares { get; set; }
        public string Date { get; set; }
        public string Instrument { get; set; }
        
    }
}