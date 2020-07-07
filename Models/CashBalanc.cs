using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class CashBalanc
    {
        public string id { get; set; }
        public string MyPotValue { get; set; }
        public string MyProfitLoss { get; set; }
        public string CashBal { get; set; }
        public string VirtCashBal { get; set; }
        public string totalAccount { get; set; }
    }

    public class CashBalancV2
    {
        public string id { get; set; }
        public string MyPotValue { get; set; }
        public string MyPrevPotValue { get; set; }
        public string MyProfitLoss { get; set; }
        public string CashBal { get; set; }
        public string VirtCashBal { get; set; }
        public string ActualCashBal { get; set; }
        public string totalAccount { get; set; }
    }
    public class CashBalancV22
    {

        public string ActualCashBal { get; set; }

    }
}