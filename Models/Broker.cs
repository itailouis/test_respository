using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class Broker
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public string threshold { get; set; }
    }

    public class MyCompanyLists
    {
        public string CompanyCode { get; set; }
        public string AccountNumber { get; set; }
        public string CompanyName { get; set; }

    }

}