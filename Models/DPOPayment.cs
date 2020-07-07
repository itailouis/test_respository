using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class DPOPayment
    {
        [Key]
        public int Id { get; set; }
        public string Result { get; set; }
        public string ResultExplanation { get; set; }
        public string TransToken { get; set; }
        public string TransRef { get; set; }
        public string TransID { get; set; }
        public string CCDapproval { get; set; }
        public string PnrID { get; set; }
        public string CompanyRef { get; set; }
        public string TransactionToken { get; set; }
        public string CDSNumber { get; set; }
        public decimal? Amount { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
    }
}