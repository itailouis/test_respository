namespace CDSC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AtsDbContext : DbContext
    {
        public AtsDbContext()
            : base("name=AtsDbContext")
        {
        }

        public virtual DbSet<LiveTradingMaster> LiveTradingMasters { get; set; }
        public virtual DbSet<Order_Live> Order_Live { get; set; }
        //public virtual DbSet<LiveTradingMaster> LiveTradingMaster { get; set; }
        public virtual DbSet<Tbl_MatchedDeals> Tbl_MatchedDeals { get; set; }
        public virtual DbSet<Tbl_MatchedOrders> Tbl_MatchedOrders { get; set; }
        public virtual DbSet<MobileSession> MobileSessions { get; set; }
        public virtual DbSet<para_company> para_company { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<CompanyLivePrices> CompanyLivePrices { get; set; }
        public virtual DbSet<Pre_Order_Live> Pre_Order_Live { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.OrderType)
                .IsUnicode(false);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.SecurityType)
                .IsUnicode(false);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.CDS_AC_No)
                .IsUnicode(false);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.Broker_Code)
                .IsUnicode(false);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.Client_Type)
                .IsUnicode(false);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.Tax)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.Shareholder)
                .IsUnicode(false);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.ClientName)
                .IsUnicode(false);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.DealStatus)
                .IsUnicode(false);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.BasePrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.OrderPref)
                .IsUnicode(false);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.OrderTransPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.OrderAttribute)
                .IsUnicode(false);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.TimeInForce)
                .IsUnicode(false);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.Marketboard)
                .IsUnicode(false);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.MaxPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.MiniPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<LiveTradingMaster>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.OrderType)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.SecurityType)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.CDS_AC_No)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.Broker_Code)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.Client_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.Tax)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.Shareholder)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.ClientName)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.OrderStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.BasePrice)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.OrderPref)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.OrderAttribute)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.Marketboard)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.TimeInForce)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.OrderQualifier)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.BrokerRef)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.ContraBrokerId)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.MaxPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.MiniPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order_Live>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_MatchedDeals>()
                .Property(e => e.BuyCompany)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_MatchedDeals>()
                .Property(e => e.SellCompany)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_MatchedDeals>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tbl_MatchedOrders>()
                .Property(e => e.BuyCompany)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_MatchedOrders>()
                .Property(e => e.SellCompany)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_MatchedOrders>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_company>()
                .Property(e => e.Issued_shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_company>()
                .Property(e => e.CDS_Ac_No)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_company>()
                .Property(e => e.registrar)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.Add_1)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.Add_2)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.Add_3)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.Add_4)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.Contact_Person)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.Cellphone)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.ISIN_No)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.comp_Sector)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.Market_Segment)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.Instrument)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.Index_Type)
                .IsUnicode(false);

            modelBuilder.Entity<para_company>()
                .Property(e => e.FHL)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_company>()
                .Property(e => e.FEL)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_company>()
                .Property(e => e.SWL)
                .HasPrecision(18, 0);
        }
    }
}
