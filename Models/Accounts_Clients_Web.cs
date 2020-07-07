namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounts_Clients_Web
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
      
        public string CDS_Number { get; set; }
   
        public string BrokerCode { get; set; }
        public string AccountType { get; set; }

        public string Surname { get; set; }

        public string Middlename { get; set; }

        public string Forenames { get; set; }

        public string Initials { get; set; }

        public string Title { get; set; }

        public string IDNoPP { get; set; }

        public string IDtype { get; set; }

        public string Nationality { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        public string Gender { get; set; }

        public string Add_1 { get; set; }

        public string Add_2 { get; set; }


        public string Add_3 { get; set; }

        public string Add_4 { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Tel { get; set; }
  
        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Category { get; set; }

        public string Custodian { get; set; }

        public string TradingStatus { get; set; }


        public string Industry { get; set; }

   
        public string Tax { get; set; }


        public string Div_Bank { get; set; }


        public string Div_Branch { get; set; }

   
        public string Div_AccountNo { get; set; }


        public string Cash_Bank { get; set; }


        public string Cash_Branch { get; set; }


        public string Cash_AccountNo { get; set; }

        [Column(TypeName = "image")]
        public byte[] Client_Image { get; set; }

        [Column(TypeName = "image")]
        public byte[] Documents { get; set; }

        [Column(TypeName = "image")]
        public byte[] BioMatrix { get; set; }

   
        public string Attached_Documents { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_Created { get; set; }

  
        public string Update_Type { get; set; }


        public string Created_By { get; set; }

    
        public string AccountState { get; set; }

  
        public string Comments { get; set; }

  
        public string DivPayee { get; set; }

        public string SettlementPayee { get; set; }

  
        public string Account_class { get; set; }

 
        public string idnopp2 { get; set; }

      
        public string idtype2 { get; set; }


        public string client_image2 { get; set; }

  
        public string documents2 { get; set; }

  
        public string isin { get; set; }

        public string company_code { get; set; }

        public string mobile_money { get; set; }

        public string mobile_number { get; set; }

        public bool? sttupdate { get; set; }

        public string currency { get; set; }
        public string trading_platform { get; set; }
        public string SourceName { get; set; }
        public string CDC_Number { get; set; }
        public string Finsec_Number { get; set; }
        public string UT_Number { get; set; }
        public string BIC { get; set; }
        public string shareholder { get; set; }
    }
}
