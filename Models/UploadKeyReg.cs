namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UploadKeyReg")]
    public partial class UploadKeyReg
    {
        [StringLength(50)]
        public string id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal UploadKey { get; set; }

        [StringLength(50)]
        public string Company { get; set; }
    }
}
