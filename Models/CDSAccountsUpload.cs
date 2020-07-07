namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CDSAccountsUpload")]
    public partial class CDSAccountsUpload
    {
        [Key]
        public int ID_ { get; set; }

        [StringLength(50)]
        public string Identification { get; set; }

        [StringLength(50)]
        public string TelephoneNumber { get; set; }

        [StringLength(50)]
        public string CDSC_Number { get; set; }

        public DateTime? Import_Date { get; set; }

        public int? Updated_Accounts { get; set; }

        [StringLength(50)]
        public string UploadBy { get; set; }

        [StringLength(50)]
        public string Client_Type { get; set; }

        public int? ID_Created { get; set; }
    }
}
