namespace CDSC.CDS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CDS : DbContext
    {
        public CDS()
            : base("name=CDS")
        {
        }

        public virtual DbSet<SanctionedList> SanctionedLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanctionedList>()
                .Property(e => e.names)
                .IsFixedLength();

            modelBuilder.Entity<SanctionedList>()
                .Property(e => e.surname)
                .IsFixedLength();

            modelBuilder.Entity<SanctionedList>()
                .Property(e => e.address)
                .IsFixedLength();

            modelBuilder.Entity<SanctionedList>()
                .Property(e => e.birthdate)
                .IsFixedLength();

            modelBuilder.Entity<SanctionedList>()
                .Property(e => e.national_id)
                .IsFixedLength();

            modelBuilder.Entity<SanctionedList>()
                .Property(e => e.nationality)
                .IsFixedLength();

            modelBuilder.Entity<SanctionedList>()
                .Property(e => e.passport_number)
                .IsFixedLength();

            modelBuilder.Entity<SanctionedList>()
                .Property(e => e.account_type)
                .IsFixedLength();

            modelBuilder.Entity<SanctionedList>()
                .Property(e => e.id)
                .HasPrecision(18, 0);
        }
    }
}
