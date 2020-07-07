using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class MarketNews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Story { get; set; }
        public string Source { get; set; }
        public DateTime DatePosted { get; set; }
    }
}