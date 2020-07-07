using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class Balances
    {
        public string ISIN { get; set; }
        public string Name { get; set; }
        public long Shares { get; set; }
    }
}