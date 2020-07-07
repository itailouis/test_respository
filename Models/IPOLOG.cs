namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IPOLOG")]
    public partial class IPOLOG
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        public string LogText { get; set; }

        [StringLength(3000)]
        public string ISINSENTIN { get; set; }

        public DateTime? DATECREATED { get; set; }
    }
}
