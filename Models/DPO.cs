using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class DPO
    {
        [Key]
        public int Id { get; set; }
        public string CompanyToken { get; set; }
        public string CreateToken { get; set; }
        public string VerifyToken { get; set; }
        public string PaymentUrl { get; set; }
        public string RedirectUrl { get; set; }
        public string ServiceTypeProduct { get; set; }
        public string ServiceTypeService { get; set; }
        public string ErrorUrl { get; set; }
        public string SuccessUrl { get; set; }
    }
}