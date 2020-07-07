using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class CTRADELIMIT
    {
        public string LimitType { get; set; }
        public int Id { get; set; }
        public Nullable<decimal> Minimum { get; set; }
        public Nullable<decimal> Maximum { get; set; }
    }
}