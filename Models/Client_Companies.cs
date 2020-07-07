namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Client_Companies
    {
        [StringLength(50)]
        public string Company_name { get; set; }

        [StringLength(50)]
        public string Company_Code { get; set; }

        [StringLength(50)]
        public string Company_type { get; set; }

        [StringLength(50)]
        public string AccountManager { get; set; }

        [StringLength(50)]
        public string Account_Pass { get; set; }

        [StringLength(50)]
        public string Adress_1 { get; set; }

        [StringLength(50)]
        public string Adress_2 { get; set; }

        [StringLength(50)]
        public string Adress_3 { get; set; }

        [StringLength(50)]
        public string Adress_4 { get; set; }

        [StringLength(50)]
        public string adress_5 { get; set; }

        [StringLength(50)]
        public string contact_email { get; set; }

        [StringLength(50)]
        public string contact_phone { get; set; }

        [StringLength(50)]
        public string contact_person { get; set; }

        [StringLength(50)]
        public string Job { get; set; }

        public bool? status { get; set; }

        public int ID { get; set; }

        [StringLength(100)]
        public string main_branch { get; set; }

        [StringLength(100)]
        public string main_account { get; set; }

        [StringLength(100)]
        public string trading_branch { get; set; }

        [StringLength(100)]
        public string trading_account { get; set; }

        [StringLength(100)]
        public string main_account_name { get; set; }

        [StringLength(100)]
        public string trading_account_name { get; set; }

        [StringLength(50)]
        public string trading_bank { get; set; }

        [StringLength(50)]
        public string main_bank { get; set; }
    }
}
