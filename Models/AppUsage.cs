using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class AppUsage
    {
        public int Id { get; set; }
        public string Activity { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
    }
}