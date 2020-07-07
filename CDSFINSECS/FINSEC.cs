namespace CDSC.CDSFINSECS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FINSEC : DbContext
    {
        public FINSEC()
            : base("name=FINSEC")
        {
        }

        public virtual DbSet<tran> trans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tran>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<tran>()
                .Property(e => e.CDS_Number)
                .IsUnicode(false);

            modelBuilder.Entity<tran>()
                .Property(e => e.Shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tran>()
                .Property(e => e.Update_Type)
                .IsUnicode(false);

            modelBuilder.Entity<tran>()
                .Property(e => e.Created_By)
                .IsUnicode(false);

            modelBuilder.Entity<tran>()
                .Property(e => e.Batch_Ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tran>()
                .Property(e => e.Source)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tran>()
                .Property(e => e.Trans_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tran>()
                .Property(e => e.Pledge_shares)
                .HasPrecision(18, 0);
        }
    }
}
