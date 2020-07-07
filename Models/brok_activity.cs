namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class brok_activity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long orderno { get; set; }

        [StringLength(50)]
        public string ordertype { get; set; }

        [StringLength(50)]
        public string company { get; set; }

        [StringLength(12)]
        public string broker_code { get; set; }

        [StringLength(50)]
        public string cds_number { get; set; }

        [StringLength(50)]
        public string clientname { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime inserted_datetime { get; set; }

        public int? quantity { get; set; }

        [StringLength(15)]
        public string status { get; set; }
    }
}
