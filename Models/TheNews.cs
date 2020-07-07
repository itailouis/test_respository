using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class TheNews
    {
        public long id { get; set; }
        public bool isImportant { get; set; }
        public string picture { get; set; }
        public string from { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public string timestamp { get; set; }
        public bool isRead { get; set; }

    }
}