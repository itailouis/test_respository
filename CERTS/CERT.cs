namespace CDSC.CERTS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CERT : DbContext
    {
        public CERT()
            : base("name=CERT")
        {
        }

        public virtual DbSet<mast> masts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<mast>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.shareholder)
                .HasPrecision(25, 0);

            modelBuilder.Entity<mast>()
                .Property(e => e.cert)
                .HasPrecision(18, 0);

            modelBuilder.Entity<mast>()
                .Property(e => e.cdno)
                .HasPrecision(18, 0);

            modelBuilder.Entity<mast>()
                .Property(e => e.shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<mast>()
                .Property(e => e.tran_type)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.xfer)
                .HasPrecision(25, 0);

            modelBuilder.Entity<mast>()
                .Property(e => e.cert_type)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.cert_origin)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.cert_print_group)
                .HasPrecision(20, 0);

            modelBuilder.Entity<mast>()
                .Property(e => e.share1)
                .HasPrecision(25, 0);

            modelBuilder.Entity<mast>()
                .Property(e => e.update_no)
                .HasPrecision(25, 0);

            modelBuilder.Entity<mast>()
                .Property(e => e.lockreason)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.Post_Reg)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.Locked_By)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.Unlocked_By)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.CustodianFrom)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.CustodianTo)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.Issue_No)
                .HasPrecision(18, 0);
        }
    }
}
