using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public decimal Charge { get; set; }
        public DateTime Date { get; set; }
    }
}