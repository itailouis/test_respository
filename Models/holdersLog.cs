namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("holdersLog")]
    public partial class holdersLog
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Shareholder { get; set; }

        [StringLength(50)]
        public string Broker_code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Password { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Created { get; set; }
    }
}
