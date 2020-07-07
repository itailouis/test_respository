namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pledgee_amendment
    {
        [Key]
        public int Amend_id { get; set; }

        public int? pledge_id { get; set; }

        [StringLength(20)]
        public string updated_by { get; set; }

        public DateTime? date_updated { get; set; }

        public string command_query { get; set; }

        [StringLength(50)]
        public string code_pledgor { get; set; }

        [StringLength(50)]
        public string code_pledgee { get; set; }

        [StringLength(50)]
        public string updated { get; set; }
    }
}
