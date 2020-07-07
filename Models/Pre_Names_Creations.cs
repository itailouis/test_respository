using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public partial class Pre_created
    {
        public int Id { get; set; }
        public Nullable<double> Shareholder { get; set; }
        public string Name { get; set; }
        public Nullable<double> Shares { get; set; }
        public Nullable<decimal> Gross { get; set; }
        public string Tax { get; set; }
        public Nullable<decimal> offer_shares { get; set; }
        public Nullable<decimal> Nett { get; set; }
        public string add_1 { get; set; }
        public string add_2 { get; set; }
        public string add_3 { get; set; }
        public string add_4 { get; set; }
        public string add_5 { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public string Tax_Code { get; set; }
        public Nullable<double> Tax_Rate { get; set; }
        public string Bank { get; set; }
        public string Bank_Branch { get; set; }
        public string Bank_Ac { get; set; }
        public bool ? For_Nominee { get; set; }
    }

    public class ForexTypes
    {
        public int id { get; set; }
        public string ForexType { get; set; }
        public string Type { get; set; }
    }
}