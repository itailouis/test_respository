namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class account_documents
    {
        public int id { get; set; }

        [StringLength(50)]
        public string cds_number { get; set; }

        [Column(TypeName = "image")]
        public byte[] image_data { get; set; }

        [StringLength(50)]
        public string imagetype { get; set; }

        [StringLength(50)]
        public string imagelength { get; set; }

        [StringLength(50)]
        public string document_Type { get; set; }
    }
}
