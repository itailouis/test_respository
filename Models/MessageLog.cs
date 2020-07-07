namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MessageLog")]
    public partial class MessageLog
    {
        public int ID { get; set; }

        public DateTime? TimeStamp { get; set; }

        [StringLength(50)]
        public string SourceIP { get; set; }

        public string Message { get; set; }
    }
}
