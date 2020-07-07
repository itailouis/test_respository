using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class SubscriberProduct
    {
        public int Id { get; set; }
        public int SubscriberId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
    }
}