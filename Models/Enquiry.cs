using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class Enquiry
    {
        [Key]
        public int ID { get; set; }
        public string Request { get; set; }
        public DateTime? RequestDate { get; set; }
        public bool? Sent { get; set; }
    }
}