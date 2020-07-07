namespace CDSC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class cdscDbContext : DbContext
    {
        public cdscDbContext()
            : base("name=cdscDbContext")
        {
        }

        public DbSet<Vatenkecis> Vatenkecis { get; set; }
        public DbSet<CashTrans> CashTrans { get; set; }
        public DbSet<CashTransGroup> CashTransGroup { get; set; }
        public DbSet<NotificationGroup> NotificationGroup { get; set; }
        public DbSet<CashTrans_forex> CashTrans_forex { get; set; }
        public DbSet<PreOrderLives> PreOrderLives { get; set; }
        public DbSet<CashTransTemp> CashTransTemps { get; set; }
        public DbSet<PreOrderLivesIPOes> PreOrderLivesIPOes { get; set; }
        public DbSet<PreOrderLivesIPOesV2> PreOrderLivesIPOesV2 { get; set; }
        public DbSet<Product> Products { get; set; }
        public virtual DbSet<club_members> club_members { get; set; }
        public virtual DbSet<investment_club> investment_club { get; set; }
        public virtual DbSet<investment_club_session> investment_club_session { get; set; }
        public DbSet<SubscriberProduct> SubscriberProducts { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<BuyOrderPayments> BuyOrderPayments { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<app_version> app_version { get; set; }
        public virtual DbSet<DPO> DPOes { get; set; }
        public virtual DbSet<DPOPaymentResult> DPOPaymentResults { get; set; }
        public virtual DbSet<DPOPayment> DPOPayments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<cdscDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<CDSC.Models.MarketNews> MarketNews { get; set; }
    }
}
