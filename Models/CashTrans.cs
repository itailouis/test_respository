using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class CashTrans
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public string TransType { get; set; }
        [Column(TypeName = "money")]
        public Nullable<decimal> Amount { get; set; }
        public DateTime DateCreated { get; set; }
        public string TransStatus { get; set; }
        public string CDS_Number { get; set; }
    }

    public class CashTransGroup
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public string TransType { get; set; }
        [Column(TypeName = "money")]
        public Nullable<decimal> Amount { get; set; }
        public DateTime DateCreated { get; set; }
        public string TransStatus { get; set; }
        public string CDS_Number { get; set; }
        public string CDS_NumberGroup { get; set; }
    }

    public partial class ClubMembers
    {
        public int id { get; set; }
        public string club_phone { get; set; }
        public Nullable<bool> confirmed { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string member_cds_number { get; set; }
        public string member_phone { get; set; }
        public string member_email { get; set; }
        public Nullable<bool> rejected { get; set; }
        public string confirmation_date { get; set; }
        public int club_id { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string FullName { get; set; }
        public string cdsnumber { get; set; }
    }


    public class CashListTransGroup
    {
      
        public string Email { get; set; }
        public string FullName { get; set; }
        public string CdsNumber { get; set; }
        public string Amount { get; set; }
        public string TransType { get; set; }
        public string DateCreated { get; set; }
        
        
    }








    public class NotificationGroupReturn
    {
        public long ID { get; set; }
        public string Notification { get; set; }
        public string DateCreated { get; set; }
        public string CDS_NumberGroup { get; set; }
    }
    public class NotificationGroup
    {
        public long ID { get; set; }
        public string Notification { get; set; }
        public DateTime DateCreated { get; set; }
        public string CDS_NumberGroup { get; set; }
    }

    public partial class CashTransTemp
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public string TransType { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string TransStatus { get; set; }
        public string CDS_Number { get; set; }
        public Nullable<bool> Paid { get; set; }
        public string Reference { get; set; }
    }
    //cash trans forex
    public class CashTrans_forex
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public string TransType { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string TransStatus { get; set; }
        public string CDS_Number { get; set; }
        public Nullable<bool> Paid { get; set; }
        public string Reference { get; set; }
        public string Currency { get; set; }
        public Nullable<bool> Processed { get; set; }
        public string Type_ { get; set; }
        public string Bureau { get; set; }
        public Nullable<bool> PickUp{ get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string Source { get; set; }
        public Nullable<bool> BuyForPickUp { get; set; }
        public Nullable<bool> BuyForWallet { get; set; }
        public Nullable<bool> SellForBureau { get; set; }
        public Nullable<bool> SellForWallet { get; set; }
    }
    public class CashTranss
    {
        public string id { get; set; }
        public string desc { get; set; }
        public string type { get; set; }
        [Column(TypeName = "money")]
        public Nullable<decimal> ammount { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        //public string CDS_Number { get; set; }
    }
}