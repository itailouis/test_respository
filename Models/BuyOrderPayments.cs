using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class BuyOrderPayments
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string CdsNumber { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(50)]
        public string Security { get; set; }

        [StringLength(50)]
        public string Quantity { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(50)]
        public string Price { get; set; }

        [StringLength(50)]
        public string PaymentStatus { get; set; }

        [StringLength(50)]
        public string PostedStatus { get; set; }

        [StringLength(50)]
        public string PaynowRef { get; set; }

        [StringLength(500)]
        public string Broker { get; set; }
        

        [StringLength(500)]
        public string PollUrl { get; set; }

        [StringLength(50)]
        public string Total { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(500)]
        public string Currency { get; set; }

    }
}