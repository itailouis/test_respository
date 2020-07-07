namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AccountsStatementEmail
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_ { get; set; }

        public string CDS_Number { get; set; }

        public string EmailAddress { get; set; }

        public string EmailMessage { get; set; }

        public string StatementName { get; set; }

        public DateTime? EnquiryDate { get; set; }

        public int? SentFlag { get; set; }
    }
}
