namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounts_Attachments
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [StringLength(50)]
        public string CDSNumber { get; set; }

        [StringLength(50)]
        public string MIMEType { get; set; }

        [StringLength(50)]
        public string FileName { get; set; }

        [StringLength(5)]
        public string Extension { get; set; }

        [Column(TypeName = "image")]
        public byte[] FileContent { get; set; }

        [StringLength(50)]
        public string AttachmentType { get; set; }
    }
}
