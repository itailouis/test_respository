namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounts_Documents
    {
        public int id { get; set; }
        public string doc_generated { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
    }
}
