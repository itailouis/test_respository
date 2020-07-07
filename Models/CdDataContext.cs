namespace CDSC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CdDataContext : DbContext
    {
        public CdDataContext()
            : base("name=CdDataContext")
        {
        }

        public virtual DbSet<batch_header> batch_header { get; set; }
        public virtual DbSet<Broker_Batch_Ref> Broker_Batch_Ref { get; set; }
        public virtual DbSet<cds_certs> cds_certs { get; set; }
        public virtual DbSet<dematerialization> dematerializations { get; set; }
        public virtual DbSet<div_instr> div_instr { get; set; }
        public virtual DbSet<immobilization> immobilizations { get; set; }
        public virtual DbSet<LendingRelease> LendingReleases { get; set; }
        public virtual DbSet<mast> masts { get; set; }
        public virtual DbSet<MASTER_PERMISSIONS> MASTER_PERMISSIONS { get; set; }
        public virtual DbSet<masttemp> masttemps { get; set; }
        public virtual DbSet<MNOOrder_Live> MNOOrder_Live { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<ModuleSub> ModuleSubs { get; set; }
        public virtual DbSet<name> names { get; set; }
        public virtual DbSet<names_audit> names_audit { get; set; }
        public virtual DbSet<NamesUpdateAuth> NamesUpdateAuths { get; set; }
        public virtual DbSet<order_placement> order_placement { get; set; }
        public virtual DbSet<Order_Posted> Order_Posted { get; set; }
        public virtual DbSet<OrdersSummary> OrdersSummaries { get; set; }
        public virtual DbSet<OrdersSummaryApproval> OrdersSummaryApprovals { get; set; }
        public virtual DbSet<para_bank> para_bank { get; set; }
        public virtual DbSet<Para_Fees> Para_Fees { get; set; }
        public virtual DbSet<pledge> pledges { get; set; }
        public virtual DbSet<Pledges_Trans> Pledges_Trans { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<SaleOrder> SaleOrders { get; set; }
        public virtual DbSet<SystemUsersProfile> SystemUsersProfiles { get; set; }
        public virtual DbSet<tbl_IdentityDocuments> tbl_IdentityDocuments { get; set; }
        public virtual DbSet<Tbl_MatchedOrders> Tbl_MatchedOrders { get; set; }
        public virtual DbSet<tbl_Settle> tbl_Settle { get; set; }
        public virtual DbSet<tran> trans { get; set; }
        public virtual DbSet<TransAudit> TransAudits { get; set; }
        public virtual DbSet<TSec_Batch_Ref> TSec_Batch_Ref { get; set; }
        public virtual DbSet<User_Management> User_Management { get; set; }
        public virtual DbSet<Account_Creation> Account_Creation { get; set; }
        public virtual DbSet<account_documents> account_documents { get; set; }
        public virtual DbSet<account_transfer> account_transfer { get; set; }
        public virtual DbSet<AccountC_FailedReg> AccountC_FailedReg { get; set; }
        public virtual DbSet<AccountC_ReconErrors> AccountC_ReconErrors { get; set; }
        public virtual DbSet<Accounts_Attachments> Accounts_Attachments { get; set; }
        public virtual DbSet<Accounts_Audit> Accounts_Audit { get; set; }
        public virtual DbSet<accounts_classes> accounts_classes { get; set; }
        public virtual DbSet<Accounts_Clients> Accounts_Clients { get; set; }
        public virtual DbSet<Accounts_Clients_Web> Accounts_Clients_Web { get; set; }
        public virtual DbSet<Accounts_Documents> Accounts_Documents { get; set; }
        public virtual DbSet<Accounts_Joint> Accounts_Joint { get; set; }
        public virtual DbSet<Accounts_Mobiles> Accounts_Mobiles { get; set; }
        public virtual DbSet<AccountsStatementEmail> AccountsStatementEmails { get; set; }
        public virtual DbSet<ATS_Orders_Imports> ATS_Orders_Imports { get; set; }
        public virtual DbSet<audit_comments> audit_comments { get; set; }
        public virtual DbSet<BankOutbox> BankOutboxes { get; set; }
        public virtual DbSet<BankRespons> BankResponses { get; set; }
        public virtual DbSet<BankTransfer> BankTransfers { get; set; }
        public virtual DbSet<batch_certs> batch_certs { get; set; }
        public virtual DbSet<Batch_receipt> Batch_receipt { get; set; }
        public virtual DbSet<batch_ref> batch_ref { get; set; }
        public virtual DbSet<bid> bids { get; set; }
        public virtual DbSet<Bond_Payment_Audit> Bond_Payment_Audit { get; set; }
        public virtual DbSet<Bond_Payment_ReconErrors> Bond_Payment_ReconErrors { get; set; }
        public virtual DbSet<Bonu> Bonus { get; set; }
        public virtual DbSet<Borrowers_Reg> Borrowers_Reg { get; set; }
        public virtual DbSet<borrowers_valuation> borrowers_valuation { get; set; }
        public virtual DbSet<BorrowersRegister> BorrowersRegisters { get; set; }
        public virtual DbSet<brok_activity> brok_activity { get; set; }
        public virtual DbSet<Broker_Batch_Header> Broker_Batch_Header { get; set; }
        public virtual DbSet<broker_transfers> broker_transfers { get; set; }
        public virtual DbSet<BrokerTran> BrokerTrans { get; set; }
        public virtual DbSet<CDSAccountsUpload> CDSAccountsUploads { get; set; }
        public virtual DbSet<CertificatesRegister> CertificatesRegisters { get; set; }
        public virtual DbSet<cheq_dets> cheq_dets { get; set; }
        public virtual DbSet<Client_Companies> Client_Companies { get; set; }
        public virtual DbSet<CompanyAccount> CompanyAccounts { get; set; }
        public virtual DbSet<confirmationsOutbox> confirmationsOutboxes { get; set; }
        public virtual DbSet<ConsMast> ConsMasts { get; set; }
        public virtual DbSet<Consolodation> Consolodations { get; set; }
        public virtual DbSet<DematBatchheader> DematBatchheaders { get; set; }
        public virtual DbSet<DematBatchref> DematBatchrefs { get; set; }
        public virtual DbSet<Deposits_Reg> Deposits_Reg { get; set; }
        public virtual DbSet<Deposits_Reg_BROKER> Deposits_Reg_BROKER { get; set; }
        public virtual DbSet<div_reprint> div_reprint { get; set; }
        public virtual DbSet<div_types> div_types { get; set; }
        public virtual DbSet<dividend> dividends { get; set; }
        public virtual DbSet<EnrolMNO> EnrolMNOs { get; set; }
        public virtual DbSet<extension> extensions { get; set; }
        public virtual DbSet<holdersLog> holdersLogs { get; set; }
        public virtual DbSet<industry_code> industry_code { get; set; }
        public virtual DbSet<inter_depository_trans> inter_depository_trans { get; set; }
        public virtual DbSet<Interdepository> Interdepositories { get; set; }
        public virtual DbSet<IPOLOG> IPOLOGs { get; set; }
        public virtual DbSet<LendersRegister> LendersRegisters { get; set; }
        public virtual DbSet<LendingPool> LendingPools { get; set; }
        public virtual DbSet<LockAudit> LockAudits { get; set; }
        public virtual DbSet<LoginAudit> LoginAudits { get; set; }
        public virtual DbSet<mandate> mandates { get; set; }
        public virtual DbSet<marketcap> marketcaps { get; set; }
        public virtual DbSet<MASTER_MODULE_CATEGORIES> MASTER_MODULE_CATEGORIES { get; set; }
        public virtual DbSet<MASTER_ROLES> MASTER_ROLES { get; set; }
        public virtual DbSet<MessageLog> MessageLogs { get; set; }
        public virtual DbSet<MobileWallet> MobileWallets { get; set; }
        public virtual DbSet<module_permissions> module_permissions { get; set; }
        public virtual DbSet<module_permissions_users> module_permissions_users { get; set; }
        public virtual DbSet<Modules_Roles> Modules_Roles { get; set; }
        public virtual DbSet<MonitorService> MonitorServices { get; set; }
        public virtual DbSet<NewzBoard> NewzBoards { get; set; }
        public virtual DbSet<nominee> nominees { get; set; }
        public virtual DbSet<orders_executed> orders_executed { get; set; }
        public virtual DbSet<orders_trans> orders_trans { get; set; }
        public virtual DbSet<OTC_Data_Import> OTC_Data_Import { get; set; }
        public virtual DbSet<Para_Batch_Type> Para_Batch_Type { get; set; }
        public virtual DbSet<Para_Batch_Type_Tsec> Para_Batch_Type_Tsec { get; set; }
        public virtual DbSet<para_Billing> para_Billing { get; set; }
        public virtual DbSet<para_branch> para_branch { get; set; }
        public virtual DbSet<para_broker> para_broker { get; set; }
        public virtual DbSet<para_brokerclasses> para_brokerclasses { get; set; }
        public virtual DbSet<para_city> para_city { get; set; }
        public virtual DbSet<para_clientCompanyTypes> para_clientCompanyTypes { get; set; }
        public virtual DbSet<para_collateral> para_collateral { get; set; }
        public virtual DbSet<paraCompanyCds> para_company { get; set; }
        public virtual DbSet<para_company_crosslisted> para_company_crosslisted { get; set; }
        public virtual DbSet<para_country> para_country { get; set; }
        public virtual DbSet<para_Criteria> para_Criteria { get; set; }
        public virtual DbSet<para_DebtCompany> para_DebtCompany { get; set; }
        public virtual DbSet<Para_Dept> Para_Dept { get; set; }
        public virtual DbSet<para_holding> para_holding { get; set; }
        public virtual DbSet<para_holiday> para_holiday { get; set; }
        public virtual DbSet<para_industry> para_industry { get; set; }
        public virtual DbSet<para_lenders> para_lenders { get; set; }
        public virtual DbSet<Para_lendingRules> Para_lendingRules { get; set; }
        public virtual DbSet<para_mailing_list> para_mailing_list { get; set; }
        public virtual DbSet<para_maker_checker> para_maker_checker { get; set; }
        public virtual DbSet<para_mobile_money> para_mobile_money { get; set; }
        public virtual DbSet<para_Prices> para_Prices { get; set; }
        public virtual DbSet<para_sectors> para_sectors { get; set; }
        public virtual DbSet<para_settlementBankType> para_settlementBankType { get; set; }
        public virtual DbSet<para_stock_exchange> para_stock_exchange { get; set; }
        public virtual DbSet<para_tax> para_tax { get; set; }
        public virtual DbSet<para_tax1> para_tax1 { get; set; }
        public virtual DbSet<para_Tplus> para_Tplus { get; set; }
        public virtual DbSet<para_transverse> para_transverse { get; set; }
        public virtual DbSet<para_txid> para_txid { get; set; }
        public virtual DbSet<para_VerificationCriterias> para_VerificationCriterias { get; set; }
        public virtual DbSet<Payment_SellOrder> Payment_SellOrder { get; set; }
        public virtual DbSet<permission> permissions { get; set; }
        public virtual DbSet<pledgee_amendment> pledgee_amendment { get; set; }
        public virtual DbSet<Pledges_Recording> Pledges_Recording { get; set; }
        public virtual DbSet<Pledges_release> Pledges_release { get; set; }
        public virtual DbSet<Pledges_transfer> Pledges_transfer { get; set; }
        public virtual DbSet<Pre_Names_Creation> Pre_Names_Creation { get; set; }
        public virtual DbSet<Pre_created> Pre_created { get; set; }
        public virtual DbSet<ReceiveUSSDEnquire> ReceiveUSSDEnquires { get; set; }
        public virtual DbSet<registrar_type> registrar_type { get; set; }
        public virtual DbSet<rights_dets> rights_dets { get; set; }
        public virtual DbSet<rights_instr> rights_instr { get; set; }
        public virtual DbSet<rights_mast> rights_mast { get; set; }
        public virtual DbSet<Role_permissions> Role_permissions { get; set; }
        public virtual DbSet<security_type> security_type { get; set; }
        public virtual DbSet<settlement_movement> settlement_movement { get; set; }
        public virtual DbSet<SettlementPool> SettlementPools { get; set; }
        public virtual DbSet<Settlement> Settlements { get; set; }
        public virtual DbSet<share_transfer> share_transfer { get; set; }
        public virtual DbSet<SystemTimeAccess> SystemTimeAccesses { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<tbl_AccountStatement> tbl_AccountStatement { get; set; }
        public virtual DbSet<tbl_AccountsUploadID> tbl_AccountsUploadID { get; set; }
        public virtual DbSet<tbl_airtelmoney> tbl_airtelmoney { get; set; }
        public virtual DbSet<tbl_character_rating> tbl_character_rating { get; set; }
        public virtual DbSet<tbl_charges> tbl_charges { get; set; }
        public virtual DbSet<tbl_ClientStatementsView> tbl_ClientStatementsView { get; set; }
        public virtual DbSet<tbl_EventsDiary> tbl_EventsDiary { get; set; }
        public virtual DbSet<tbl_MessagingProtocols> tbl_MessagingProtocols { get; set; }
        public virtual DbSet<tbl_ParticipantsType> tbl_ParticipantsType { get; set; }
        public virtual DbSet<tbl_people_rating> tbl_people_rating { get; set; }
        public virtual DbSet<tbl_PermissionsList> tbl_PermissionsList { get; set; }
        public virtual DbSet<tbl_RatioAnalysis> tbl_RatioAnalysis { get; set; }
        public virtual DbSet<tbl_savedMsages> tbl_savedMsages { get; set; }
        public virtual DbSet<tbl_SettlementCycle> tbl_SettlementCycle { get; set; }
        public virtual DbSet<tbl_SettlementSummary> tbl_SettlementSummary { get; set; }
        public virtual DbSet<tbl_SettlementTypes> tbl_SettlementTypes { get; set; }
        public virtual DbSet<tbl_SharebalanceView> tbl_SharebalanceView { get; set; }
        public virtual DbSet<tbl_uncommitted> tbl_uncommitted { get; set; }
        public virtual DbSet<tbl_units_move> tbl_units_move { get; set; }
        public virtual DbSet<tbl_unmatchedorders> tbl_unmatchedorders { get; set; }
        public virtual DbSet<TempAllotment> TempAllotments { get; set; }
        public virtual DbSet<temptran> temptrans { get; set; }
        public virtual DbSet<TempTransFrom> TempTransFroms { get; set; }
        public virtual DbSet<TempTransTo> TempTransToes { get; set; }
        public virtual DbSet<TSec_Batch_Header> TSec_Batch_Header { get; set; }
        public virtual DbSet<UploadKeyReg> UploadKeyRegs { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserManagement> UserManagements { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<CTRADELIMIT> CTRADELIMITS { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<batch_header>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<batch_header>()
                .Property(e => e.Batch_ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<batch_header>()
                .Property(e => e.Traded_Shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<batch_header>()
                .Property(e => e.Traded_amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<batch_header>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<batch_header>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Broker_Batch_Ref>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Broker_Batch_Ref>()
                .Property(e => e.Batch_Ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Broker_Batch_Ref>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Broker_Batch_Ref>()
                .Property(e => e.Batch_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Broker_Batch_Ref>()
                .Property(e => e.Shareholder)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Broker_Batch_Ref>()
                .Property(e => e.Shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Broker_Batch_Ref>()
                .Property(e => e.Certificate)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Broker_Batch_Ref>()
                .Property(e => e.CD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Broker_Batch_Ref>()
                .Property(e => e.CDS_Number)
                .IsUnicode(false);

            modelBuilder.Entity<Broker_Batch_Ref>()
                .Property(e => e.HolderNames)
                .IsUnicode(false);

            modelBuilder.Entity<Broker_Batch_Ref>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Broker_Batch_Ref>()
                .Property(e => e.CertVerification)
                .IsUnicode(false);

            modelBuilder.Entity<cds_certs>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cds_certs>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<cds_certs>()
                .Property(e => e.shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cds_certs>()
                .Property(e => e.certificate_number)
                .IsUnicode(false);

            modelBuilder.Entity<cds_certs>()
                .Property(e => e.agent)
                .IsUnicode(false);

            modelBuilder.Entity<cds_certs>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<dematerialization>()
                .Property(e => e.batch_ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<dematerialization>()
                .Property(e => e.broker_code)
                .IsUnicode(false);

            modelBuilder.Entity<dematerialization>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<dematerialization>()
                .Property(e => e.Shareholder)
                .HasPrecision(18, 0);

            modelBuilder.Entity<dematerialization>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<dematerialization>()
                .Property(e => e.Forenames)
                .IsUnicode(false);

            modelBuilder.Entity<dematerialization>()
                .Property(e => e.Client_type)
                .IsUnicode(false);

            modelBuilder.Entity<dematerialization>()
                .Property(e => e.Oldholder)
                .IsUnicode(false);

            modelBuilder.Entity<dematerialization>()
                .Property(e => e.Cert)
                .IsUnicode(false);

            modelBuilder.Entity<dematerialization>()
                .Property(e => e.Shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<dematerialization>()
                .Property(e => e.Status)
                .HasPrecision(18, 0);

            modelBuilder.Entity<div_instr>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<div_instr>()
                .Property(e => e.div_no)
                .HasPrecision(5, 0);

            modelBuilder.Entity<div_instr>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<div_instr>()
                .Property(e => e.div_type)
                .IsUnicode(false);

            modelBuilder.Entity<div_instr>()
                .Property(e => e.rate)
                .HasPrecision(12, 6);

            modelBuilder.Entity<div_instr>()
                .Property(e => e.mess_1)
                .IsUnicode(false);

            modelBuilder.Entity<div_instr>()
                .Property(e => e.mess_2)
                .IsUnicode(false);

            modelBuilder.Entity<div_instr>()
                .Property(e => e.scrip_price)
                .HasPrecision(12, 6);

            modelBuilder.Entity<div_instr>()
                .Property(e => e.scrip_round)
                .IsUnicode(false);

            modelBuilder.Entity<div_instr>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<div_instr>()
                .Property(e => e.entered_by)
                .IsUnicode(false);

            modelBuilder.Entity<div_instr>()
                .Property(e => e.bank_accNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<immobilization>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<immobilization>()
                .Property(e => e.Shareholder)
                .HasPrecision(18, 0);

            modelBuilder.Entity<immobilization>()
                .Property(e => e.cdsnumber)
                .IsUnicode(false);

            modelBuilder.Entity<immobilization>()
                .Property(e => e.Broker_Code)
                .IsUnicode(false);

            modelBuilder.Entity<immobilization>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<immobilization>()
                .Property(e => e.ForeNames)
                .IsUnicode(false);

            modelBuilder.Entity<immobilization>()
                .Property(e => e.Batch_Number)
                .HasPrecision(18, 0);

            modelBuilder.Entity<immobilization>()
                .Property(e => e.Batch_Total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LendingRelease>()
                .Property(e => e.initialloan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LendingRelease>()
                .Property(e => e.outstanding)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LendingRelease>()
                .Property(e => e.Returned)
                .HasPrecision(18, 0);

            modelBuilder.Entity<mast>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.CDS_Number)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.Trans_Time)
                .IsFixedLength();

            modelBuilder.Entity<mast>()
                .Property(e => e.Shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<mast>()
                .Property(e => e.Update_Type)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.Pledge_Shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<mast>()
                .Property(e => e.Created_By)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.Updated_By)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.Lock_Reason)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.Batch_Ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<mast>()
                .Property(e => e.Trans_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<mast>()
                .Property(e => e.PledgeReason)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.SecType)
                .IsUnicode(false);

            modelBuilder.Entity<mast>()
                .Property(e => e.lockQuantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<mast>()
                .Property(e => e.cert)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MASTER_PERMISSIONS>()
                .Property(e => e.ORDERING)
                .IsUnicode(false);

            modelBuilder.Entity<masttemp>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<masttemp>()
                .Property(e => e.CDS_Number)
                .IsUnicode(false);

            modelBuilder.Entity<masttemp>()
                .Property(e => e.Shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<masttemp>()
                .Property(e => e.Update_Type)
                .IsUnicode(false);

            modelBuilder.Entity<masttemp>()
                .Property(e => e.Created_By)
                .IsUnicode(false);

            modelBuilder.Entity<masttemp>()
                .Property(e => e.Batch_Ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<masttemp>()
                .Property(e => e.Source)
                .IsUnicode(false);

            modelBuilder.Entity<masttemp>()
                .Property(e => e.Trans_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.OrderType)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.SecurityType)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.CDS_AC_No)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.Broker_Code)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.Client_Type)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.Tax)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.Shareholder)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.ClientName)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.OrderStatus)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.BasePrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.OrderPref)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.OrderAttribute)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.Marketboard)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.TimeInForce)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.OrderQualifier)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.BrokerRef)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.ContraBrokerId)
                .IsUnicode(false);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.MaxPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.MiniPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MNOOrder_Live>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .HasMany(e => e.ModuleSubs)
                .WithRequired(e => e.Module)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ModuleSub>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Shareholder)
                .HasPrecision(18, 0);

            modelBuilder.Entity<name>()
                .Property(e => e.Broker_Code)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.CDS_Number)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Forenames)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Idpp)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.nominee_code)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Add_1)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Add_2)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Add_3)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Add_4)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Cellphone)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Bank_Name)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Bank_Code)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Branch_Name)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Branch_Code)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Account_Type)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Tax)
                .HasPrecision(18, 0);

            modelBuilder.Entity<name>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Industry)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Approved_by)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Holder_type)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.ImageID)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.accountstate)
                .HasPrecision(3, 0);

            modelBuilder.Entity<name>()
                .Property(e => e.JSurname)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.JForenames)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.JEmail)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.JCell)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Nationality)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.Old_Shareholder)
                .IsUnicode(false);

            modelBuilder.Entity<name>()
                .Property(e => e.dormantState)
                .HasPrecision(13, 0);

            modelBuilder.Entity<names_audit>()
                .Property(e => e.Shareholder)
                .HasPrecision(18, 0);

            modelBuilder.Entity<names_audit>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<names_audit>()
                .Property(e => e.Forenames)
                .IsUnicode(false);

            modelBuilder.Entity<names_audit>()
                .Property(e => e.Idpp)
                .IsUnicode(false);

            modelBuilder.Entity<names_audit>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<names_audit>()
                .Property(e => e.Updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<names_audit>()
                .Property(e => e.Add_1)
                .IsUnicode(false);

            modelBuilder.Entity<names_audit>()
                .Property(e => e.Add_2)
                .IsUnicode(false);

            modelBuilder.Entity<names_audit>()
                .Property(e => e.Add_3)
                .IsUnicode(false);

            modelBuilder.Entity<names_audit>()
                .Property(e => e.Add_4)
                .IsUnicode(false);

            modelBuilder.Entity<names_audit>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<names_audit>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<names_audit>()
                .Property(e => e.Tax)
                .IsUnicode(false);

            modelBuilder.Entity<names_audit>()
                .Property(e => e.holder_type)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.UpdatingBroker)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.CDS_Number)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Forenames)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.idpp)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Add_1)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Add_2)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Add_3)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Add_4)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Bank_Code)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Bank_Name)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Branch_Code)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Branch_name)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Tax)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Updated_By)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.Auditor)
                .IsUnicode(false);

            modelBuilder.Entity<NamesUpdateAuth>()
                .Property(e => e.FKey)
                .HasPrecision(18, 0);

            modelBuilder.Entity<order_placement>()
                .Property(e => e.Broker_Code)
                .IsUnicode(false);

            modelBuilder.Entity<order_placement>()
                .Property(e => e.Deal_Number)
                .HasPrecision(18, 0);

            modelBuilder.Entity<order_placement>()
                .Property(e => e.Deal_Suffix)
                .HasPrecision(18, 0);

            modelBuilder.Entity<order_placement>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<order_placement>()
                .Property(e => e.Order_Type)
                .IsUnicode(false);

            modelBuilder.Entity<order_placement>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<order_placement>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<order_placement>()
                .Property(e => e.Client_Acc)
                .HasPrecision(18, 0);

            modelBuilder.Entity<order_placement>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<order_placement>()
                .Property(e => e.Forenames)
                .IsUnicode(false);

            modelBuilder.Entity<order_placement>()
                .Property(e => e.Client_Type)
                .IsUnicode(false);

            modelBuilder.Entity<order_placement>()
                .Property(e => e.Update_by)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Posted>()
                .Property(e => e.DealType)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Posted>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Posted>()
                .Property(e => e.SecurityType)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Posted>()
                .Property(e => e.CDS_AC_No)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Posted>()
                .Property(e => e.Broker_Code)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Posted>()
                .Property(e => e.Client_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Posted>()
                .Property(e => e.Tax)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order_Posted>()
                .Property(e => e.Shareholder)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Order_Posted>()
                .Property(e => e.ClientName)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Posted>()
                .Property(e => e.TotalShareHolding)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Order_Posted>()
                .Property(e => e.DealStatus)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order_Posted>()
                .Property(e => e.Quantity)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Order_Posted>()
                .Property(e => e.BasePrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order_Posted>()
                .Property(e => e.AvailableShares)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Order_Posted>()
                .Property(e => e.OrderPref)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.OrderRef)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.CDS_Number)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.Order_Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.OrderType)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.PurchasingBroker)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.CapturedBy)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.Updated_By)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.OrderAttribute)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.OrderPreference)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.ApprovalFlag)
                .HasPrecision(2, 0);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.ActivationCode)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.ActivationCodeApp)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.MarketBoard)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummary>()
                .Property(e => e.OrderQualifier)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.OrderRef)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.CDS_Number)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.Order_Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.OrderType)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.PurchasingBroker)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.CapturedBy)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.Updated_By)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.OrderAttribute)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.OrderPreference)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.ApprovalFlag)
                .HasPrecision(2, 0);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.ApprovedOn)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.ApprovedBy)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersSummaryApproval>()
                .Property(e => e.RejectionReason)
                .IsUnicode(false);

            modelBuilder.Entity<para_bank>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_bank>()
                .Property(e => e.bank)
                .IsUnicode(false);

            modelBuilder.Entity<para_bank>()
                .Property(e => e.bank_name)
                .IsUnicode(false);

            modelBuilder.Entity<para_bank>()
                .Property(e => e.Bank_Code)
                .IsUnicode(false);

            modelBuilder.Entity<Para_Fees>()
                .Property(e => e.BasicFee)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Para_Fees>()
                .Property(e => e.StampDuty)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Para_Fees>()
                .Property(e => e.WithholdingTax)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Para_Fees>()
                .Property(e => e.SecLevy)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Para_Fees>()
                .Property(e => e.Trans_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<pledge>()
                .Property(e => e.pledge_no)
                .HasPrecision(18, 0);

            modelBuilder.Entity<pledge>()
                .Property(e => e.cds_number)
                .IsUnicode(false);

            modelBuilder.Entity<pledge>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<pledge>()
                .Property(e => e.shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<pledge>()
                .Property(e => e.pledgee)
                .IsUnicode(false);

            modelBuilder.Entity<pledge>()
                .Property(e => e.pledged_reason)
                .IsUnicode(false);

            modelBuilder.Entity<pledge>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<pledge>()
                .Property(e => e.Pledger)
                .IsUnicode(false);

            modelBuilder.Entity<pledge>()
                .Property(e => e.Pledgee_num)
                .IsUnicode(false);

            modelBuilder.Entity<pledge>()
                .Property(e => e.Rejection)
                .IsUnicode(false);

            modelBuilder.Entity<Pledges_Trans>()
                .Property(e => e.Shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.CDS_Number)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.Order_Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.Stamp_Duty)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.WithHoldingtax)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.Order_By)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.OrderAttribute)
                .IsUnicode(false);

            modelBuilder.Entity<SaleOrder>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SaleOrder>()
                .Property(e => e.CDS_Number)
                .IsUnicode(false);

            modelBuilder.Entity<SaleOrder>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<SaleOrder>()
                .Property(e => e.Order_Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SaleOrder>()
                .Property(e => e.Basic_Fee)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SaleOrder>()
                .Property(e => e.Stamp_Duty)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SaleOrder>()
                .Property(e => e.MinimumBrokerage)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SaleOrder>()
                .Property(e => e.TransferFees)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SaleOrder>()
                .Property(e => e.SecLevy)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SaleOrder>()
                .Property(e => e.ValueBeforeTax)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SaleOrder>()
                .Property(e => e.TotalCharges)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SaleOrder>()
                .Property(e => e.OrderValue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SaleOrder>()
                .Property(e => e.Order_By)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.IDKEY)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.Forenames)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.IDPP)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.EmpID)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.BROKERCODE)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.COMPANY)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.DEPARTMENT)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.WPOSITION)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.TEL)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.CEL)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.HOD)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUsersProfile>()
                .Property(e => e.USERROLE)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_MatchedOrders>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_Settle>()
                .Property(e => e.DR)
                .HasPrecision(23, 2);

            modelBuilder.Entity<tbl_Settle>()
                .Property(e => e.CR)
                .HasPrecision(23, 2);

            modelBuilder.Entity<tbl_Settle>()
                .Property(e => e.netposition)
                .HasPrecision(23, 2);

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

            modelBuilder.Entity<TransAudit>()
                .Property(e => e.TransKey)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TransAudit>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<TransAudit>()
                .Property(e => e.batch_ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TransAudit>()
                .Property(e => e.Shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TransAudit>()
                .Property(e => e.cds_number)
                .IsUnicode(false);

            modelBuilder.Entity<TransAudit>()
                .Property(e => e.transBroker)
                .IsUnicode(false);

            modelBuilder.Entity<TransAudit>()
                .Property(e => e.CapturedBy)
                .IsUnicode(false);

            modelBuilder.Entity<TSec_Batch_Ref>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<TSec_Batch_Ref>()
                .Property(e => e.CDS_Number)
                .IsUnicode(false);

            modelBuilder.Entity<TSec_Batch_Ref>()
                .Property(e => e.Shareholder)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TSec_Batch_Ref>()
                .Property(e => e.HolderNames)
                .IsUnicode(false);

            modelBuilder.Entity<TSec_Batch_Ref>()
                .Property(e => e.Batch_Type)
                .IsUnicode(false);

            modelBuilder.Entity<TSec_Batch_Ref>()
                .Property(e => e.Batch_ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TSec_Batch_Ref>()
                .Property(e => e.Certificate)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TSec_Batch_Ref>()
                .Property(e => e.CD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TSec_Batch_Ref>()
                .Property(e => e.Shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TSec_Batch_Ref>()
                .Property(e => e.Forwarded_By)
                .IsUnicode(false);

            modelBuilder.Entity<TSec_Batch_Ref>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<User_Management>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User_Management>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<User_Management>()
                .Property(e => e.User_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User_Management>()
                .Property(e => e.Pass_Word)
                .IsUnicode(false);

            modelBuilder.Entity<User_Management>()
                .Property(e => e.ContactEmail)
                .IsUnicode(false);

            modelBuilder.Entity<User_Management>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User_Management>()
                .Property(e => e.Active_Session)
                .IsUnicode(false);

            modelBuilder.Entity<User_Management>()
                .Property(e => e.Fullname)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.ClientSuffix)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.JointAcc)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Identification)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Initials)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.OtherNames)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Surname_CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Address3)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Town)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.PostCode)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.FaxNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Emailaddress)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Nationality)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Resident)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.TelephoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Bank)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Branch)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Accountnumber)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.No_of_Notes_Applied)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.AmountPaid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.PaymentRefNo)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.ClientType)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.BrokerReference)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.CDSC_Number)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Callback_Endpoint)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.MNO_)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.PIN_No)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.Middlename)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.RNum)
                .IsUnicode(false);

            modelBuilder.Entity<Account_Creation>()
                .Property(e => e.MNOCustodian)
                .IsUnicode(false);

            modelBuilder.Entity<account_documents>()
                .Property(e => e.cds_number)
                .IsUnicode(false);

            modelBuilder.Entity<account_documents>()
                .Property(e => e.imagetype)
                .IsUnicode(false);

            modelBuilder.Entity<account_transfer>()
                .Property(e => e.part_portfolio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.ClientSuffix)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.JointAcc)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Identification)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Initials)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.OtherNames)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Surname_CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Address3)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Town)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.PostCode)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.FaxNumber)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Emailaddress)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Nationality)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Resident)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.TelephoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Bank)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Branch)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Accountnumber)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.No_of_Notes_Applied)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.AmountPaid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.PaymentRefNo)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.ClientType)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.BrokerReference)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.DividendDisposalPreference)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.CDSC_Number)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Callback_Endpoint)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.MNO_)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.PIN_No)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Middlename)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.RNum)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_FailedReg>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.ClientSuffix)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.JointAcc)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Identification)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Initials)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.OtherNames)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Surname_CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Address3)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Town)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.PostCode)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.FaxNumber)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Emailaddress)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Nationality)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Resident)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.TelephoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Bank)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Branch)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Accountnumber)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.No_of_Notes_Applied)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.AmountPaid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.PaymentRefNo)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.ClientType)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.BrokerReference)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.CDSC_Number)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Callback_Endpoint)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.MNO_)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.PIN_No)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Middlename)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.RNum)
                .IsUnicode(false);

            modelBuilder.Entity<AccountC_ReconErrors>()
                .Property(e => e.Reasons)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts_Attachments>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Accounts_Audit>()
                .Property(e => e.VerificationCode)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Accounts_Audit>()
                .Property(e => e.DivPayee)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts_Audit>()
                .Property(e => e.SettlementPayee)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts_Audit>()
                .Property(e => e.client_image2)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts_Audit>()
                .Property(e => e.documents2)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts_Clients>()
                .Property(e => e.DivPayee)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts_Clients>()
                .Property(e => e.SettlementPayee)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts_Clients>()
                .Property(e => e.Account_class)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts_Clients>()
                .Property(e => e.client_image2)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts_Clients>()
                .Property(e => e.documents2)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts_Documents>()
                .Property(e => e.doc_generated)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts_Documents>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts_Documents>()
                .Property(e => e.ContentType)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts_Mobiles>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Accounts_Mobiles>()
                .Property(e => e.CDS_Number)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts_Mobiles>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<AccountsStatementEmail>()
                .Property(e => e.ID_)
                .HasPrecision(25, 0);

            modelBuilder.Entity<AccountsStatementEmail>()
                .Property(e => e.CDS_Number)
                .IsUnicode(false);

            modelBuilder.Entity<AccountsStatementEmail>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<AccountsStatementEmail>()
                .Property(e => e.EmailMessage)
                .IsUnicode(false);

            modelBuilder.Entity<AccountsStatementEmail>()
                .Property(e => e.StatementName)
                .IsUnicode(false);

            modelBuilder.Entity<ATS_Orders_Imports>()
                .Property(e => e.DealPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ATS_Orders_Imports>()
                .Property(e => e.Broker_Init)
                .IsUnicode(false);

            modelBuilder.Entity<ATS_Orders_Imports>()
                .Property(e => e.Broker_Target)
                .IsUnicode(false);

            modelBuilder.Entity<ATS_Orders_Imports>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<audit_comments>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<audit_comments>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<BankRespons>()
                .Property(e => e.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BankTransfer>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<batch_certs>()
                .Property(e => e.cds_number)
                .IsUnicode(false);

            modelBuilder.Entity<batch_certs>()
                .Property(e => e.shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<batch_certs>()
                .Property(e => e.certificate_no)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Batch_receipt>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Batch_receipt>()
                .Property(e => e.Batch_Shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Batch_receipt>()
                .Property(e => e.Shareprice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Batch_receipt>()
                .Property(e => e.Batch_value)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Batch_receipt>()
                .Property(e => e.Lodger)
                .IsUnicode(false);

            modelBuilder.Entity<Batch_receipt>()
                .Property(e => e.broker_code)
                .IsUnicode(false);

            modelBuilder.Entity<Batch_receipt>()
                .Property(e => e.batch_type)
                .IsUnicode(false);

            modelBuilder.Entity<batch_ref>()
                .Property(e => e.batch_ref1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<batch_ref>()
                .Property(e => e.MatcheDealNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<batch_ref>()
                .Property(e => e.DrBroker)
                .IsUnicode(false);

            modelBuilder.Entity<batch_ref>()
                .Property(e => e.Shareholder)
                .HasPrecision(18, 0);

            modelBuilder.Entity<batch_ref>()
                .Property(e => e.CrBroker)
                .IsUnicode(false);

            modelBuilder.Entity<batch_ref>()
                .Property(e => e.TradedShares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<batch_ref>()
                .Property(e => e.TradedAmount)
                .IsUnicode(false);

            modelBuilder.Entity<batch_ref>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<bid>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<bid>()
                .Property(e => e.deal_number)
                .HasPrecision(18, 0);

            modelBuilder.Entity<bid>()
                .Property(e => e.bid_number)
                .HasPrecision(18, 0);

            modelBuilder.Entity<bid>()
                .Property(e => e.broker_code)
                .HasPrecision(18, 0);

            modelBuilder.Entity<bid>()
                .Property(e => e.client_Acc)
                .HasPrecision(18, 0);

            modelBuilder.Entity<bid>()
                .Property(e => e.company)
                .HasPrecision(18, 0);

            modelBuilder.Entity<bid>()
                .Property(e => e.bid_time)
                .IsFixedLength();

            modelBuilder.Entity<bid>()
                .Property(e => e.bid_price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<bid>()
                .Property(e => e.status)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.Bank)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.Branch)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.Accountnumber)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.No_of_Notes_Applied)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.AmountPaid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.PaymentRefNo)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.ClientType)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.BrokerReference)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.MNO_)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.Identification)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.TelephoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.CDSC_Number)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.ReceiptNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.Custodian)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.TransNum)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.PledgeIndicator)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_Audit>()
                .Property(e => e.PledgeeBPID)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_ReconErrors>()
                .Property(e => e.No_of_Notes_Applied)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Bond_Payment_ReconErrors>()
                .Property(e => e.AmountPaid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bond_Payment_ReconErrors>()
                .Property(e => e.PaymentRefNo)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_ReconErrors>()
                .Property(e => e.ClientType)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_ReconErrors>()
                .Property(e => e.BrokerReference)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_ReconErrors>()
                .Property(e => e.MNO_)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_ReconErrors>()
                .Property(e => e.Identification)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_ReconErrors>()
                .Property(e => e.TelephoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_ReconErrors>()
                .Property(e => e.CDSC_Number)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_ReconErrors>()
                .Property(e => e.ReceiptNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Bond_Payment_ReconErrors>()
                .Property(e => e.Reasons)
                .IsUnicode(false);

            modelBuilder.Entity<Bonu>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Bonu>()
                .Property(e => e.BType)
                .IsUnicode(false);

            modelBuilder.Entity<Bonu>()
                .Property(e => e.Allot)
                .HasPrecision(12, 0);

            modelBuilder.Entity<Bonu>()
                .Property(e => e.Every)
                .HasPrecision(12, 0);

            modelBuilder.Entity<Bonu>()
                .Property(e => e.BRound)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bonu>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Borrowers_Reg>()
                .Property(e => e.unit_price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<borrowers_valuation>()
                .Property(e => e.Value)
                .HasPrecision(19, 4);

            modelBuilder.Entity<brok_activity>()
                .Property(e => e.ordertype)
                .IsUnicode(false);

            modelBuilder.Entity<brok_activity>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<brok_activity>()
                .Property(e => e.broker_code)
                .IsUnicode(false);

            modelBuilder.Entity<brok_activity>()
                .Property(e => e.cds_number)
                .IsUnicode(false);

            modelBuilder.Entity<brok_activity>()
                .Property(e => e.clientname)
                .IsUnicode(false);

            modelBuilder.Entity<Broker_Batch_Header>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Broker_Batch_Header>()
                .Property(e => e.Batch_Ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Broker_Batch_Header>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Broker_Batch_Header>()
                .Property(e => e.Batch_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Broker_Batch_Header>()
                .Property(e => e.Shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Broker_Batch_Header>()
                .Property(e => e.Lodger)
                .IsUnicode(false);

            modelBuilder.Entity<Broker_Batch_Header>()
                .Property(e => e.Created_by)
                .IsUnicode(false);

            modelBuilder.Entity<Broker_Batch_Header>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Broker_Batch_Header>()
                .Property(e => e.RejectionReason)
                .IsUnicode(false);

            modelBuilder.Entity<broker_transfers>()
                .Property(e => e.part_portfolio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BrokerTran>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<BrokerTran>()
                .Property(e => e.Broker_Code)
                .IsUnicode(false);

            modelBuilder.Entity<BrokerTran>()
                .Property(e => e.TransID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BrokerTran>()
                .Property(e => e.TransType)
                .IsUnicode(false);

            modelBuilder.Entity<BrokerTran>()
                .Property(e => e.DealPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BrokerTran>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BrokerTran>()
                .Property(e => e.Dealnum)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BrokerTran>()
                .Property(e => e.Dealsufix)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CDSAccountsUpload>()
                .Property(e => e.Identification)
                .IsUnicode(false);

            modelBuilder.Entity<CDSAccountsUpload>()
                .Property(e => e.TelephoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CDSAccountsUpload>()
                .Property(e => e.CDSC_Number)
                .IsUnicode(false);

            modelBuilder.Entity<CDSAccountsUpload>()
                .Property(e => e.UploadBy)
                .IsUnicode(false);

            modelBuilder.Entity<CDSAccountsUpload>()
                .Property(e => e.Client_Type)
                .IsUnicode(false);

            modelBuilder.Entity<CertificatesRegister>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CertificatesRegister>()
                .Property(e => e.Certificate)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CertificatesRegister>()
                .Property(e => e.shareholder)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CertificatesRegister>()
                .Property(e => e.Status)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CertificatesRegister>()
                .Property(e => e.SubmittingEntity)
                .IsUnicode(false);

            modelBuilder.Entity<CertificatesRegister>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<CertificatesRegister>()
                .Property(e => e.UploadKey)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CertificatesRegister>()
                .Property(e => e.shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.cheq_no)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.seq)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.payee)
                .IsUnicode(false);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.fnam)
                .IsUnicode(false);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.bank)
                .IsUnicode(false);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.branch)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.account)
                .IsUnicode(false);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.changed_by)
                .IsUnicode(false);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.Shareholder)
                .HasPrecision(27, 0);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.Div_no)
                .HasPrecision(27, 0);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.reson)
                .IsUnicode(false);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.replace)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.bank_ac)
                .IsUnicode(false);

            modelBuilder.Entity<cheq_dets>()
                .Property(e => e.consold)
                .IsUnicode(false);

            modelBuilder.Entity<Client_Companies>()
                .Property(e => e.Company_name)
                .IsUnicode(false);

            modelBuilder.Entity<Client_Companies>()
                .Property(e => e.Company_Code)
                .IsUnicode(false);

            modelBuilder.Entity<Client_Companies>()
                .Property(e => e.Company_type)
                .IsUnicode(false);

            modelBuilder.Entity<Client_Companies>()
                .Property(e => e.AccountManager)
                .IsUnicode(false);

            modelBuilder.Entity<Client_Companies>()
                .Property(e => e.Account_Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Client_Companies>()
                .Property(e => e.Adress_1)
                .IsUnicode(false);

            modelBuilder.Entity<Client_Companies>()
                .Property(e => e.Adress_2)
                .IsUnicode(false);

            modelBuilder.Entity<Client_Companies>()
                .Property(e => e.Adress_3)
                .IsUnicode(false);

            modelBuilder.Entity<Client_Companies>()
                .Property(e => e.Adress_4)
                .IsUnicode(false);

            modelBuilder.Entity<Client_Companies>()
                .Property(e => e.adress_5)
                .IsUnicode(false);

            modelBuilder.Entity<Client_Companies>()
                .Property(e => e.contact_email)
                .IsUnicode(false);

            modelBuilder.Entity<Client_Companies>()
                .Property(e => e.contact_person)
                .IsUnicode(false);

            modelBuilder.Entity<Client_Companies>()
                .Property(e => e.Job)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyAccount>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyAccount>()
                .Property(e => e.CompanyType)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyAccount>()
                .Property(e => e.Company_Code)
                .IsUnicode(false);

            modelBuilder.Entity<ConsMast>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ConsMast>()
                .Property(e => e.IssueNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ConsMast>()
                .Property(e => e.OldShares)
                .HasPrecision(32, 0);

            modelBuilder.Entity<ConsMast>()
                .Property(e => e.NewShares)
                .HasPrecision(32, 0);

            modelBuilder.Entity<Consolodation>()
                .Property(e => e.issue_no)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Consolodation>()
                .Property(e => e.offer)
                .HasPrecision(12, 6);

            modelBuilder.Entity<Consolodation>()
                .Property(e => e.every)
                .HasPrecision(12, 6);

            modelBuilder.Entity<DematBatchheader>()
                .Property(e => e.Batch_ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DematBatchheader>()
                .Property(e => e.shareholder)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DematBatchheader>()
                .Property(e => e.TotalShares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DematBatchheader>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<DematBatchheader>()
                .Property(e => e.ClientCode)
                .IsUnicode(false);

            modelBuilder.Entity<DematBatchheader>()
                .Property(e => e.ClientUser)
                .IsUnicode(false);

            modelBuilder.Entity<DematBatchref>()
                .Property(e => e.Batch_ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DematBatchref>()
                .Property(e => e.Shareholder)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DematBatchref>()
                .Property(e => e.Cert)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DematBatchref>()
                .Property(e => e.Shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DematBatchref>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<DematBatchref>()
                .Property(e => e.oldshareholder)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DematBatchref>()
                .Property(e => e.ClientCode)
                .IsUnicode(false);

            modelBuilder.Entity<DematBatchref>()
                .Property(e => e.ClientUser)
                .IsUnicode(false);

            modelBuilder.Entity<DematBatchref>()
                .Property(e => e.Status)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Deposits_Reg>()
                .Property(e => e.Deposit_Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Deposits_Reg_BROKER>()
                .Property(e => e.Deposit_Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e._short)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.holder)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.shares_held)
                .HasPrecision(12, 0);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.offer_cash)
                .HasPrecision(19, 4);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.offer_shares)
                .HasPrecision(12, 0);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.actual_gross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.actual_tax)
                .HasPrecision(19, 4);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.actual_nett)
                .HasPrecision(19, 4);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.tax_rate)
                .HasPrecision(8, 4);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.actual_shares)
                .HasPrecision(12, 0);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.add_1)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.add_2)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.add_3)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.add_4)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.add_5)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.man_add_1)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.man_add_2)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.man_add_3)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.man_add_4)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.man_add_5)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.tax_code)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.industry)
                .IsUnicode(false);

            modelBuilder.Entity<div_reprint>()
                .Property(e => e.bank_ac)
                .IsUnicode(false);

            modelBuilder.Entity<div_types>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<div_types>()
                .Property(e => e.fnam)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.div_no)
                .HasPrecision(5, 0);

            modelBuilder.Entity<dividend>()
                .Property(e => e.shareholder)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.source)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e._short)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.holder)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.shares_held)
                .HasPrecision(12, 0);

            modelBuilder.Entity<dividend>()
                .Property(e => e.offer_cash)
                .HasPrecision(19, 4);

            modelBuilder.Entity<dividend>()
                .Property(e => e.offer_shares)
                .HasPrecision(12, 0);

            modelBuilder.Entity<dividend>()
                .Property(e => e.actual_gross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<dividend>()
                .Property(e => e.actual_tax)
                .HasPrecision(19, 4);

            modelBuilder.Entity<dividend>()
                .Property(e => e.actual_nett)
                .HasPrecision(19, 4);

            modelBuilder.Entity<dividend>()
                .Property(e => e.tax_rate)
                .HasPrecision(8, 4);

            modelBuilder.Entity<dividend>()
                .Property(e => e.actual_shares)
                .HasPrecision(12, 0);

            modelBuilder.Entity<dividend>()
                .Property(e => e.add_1)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.add_2)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.add_3)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.add_4)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.add_5)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.man_add_1)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.man_add_2)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.man_add_3)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.man_add_4)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.man_add_5)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.tax_code)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.industry)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.bank)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.bank_branch)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.bank_ac)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.cheq_no)
                .HasPrecision(10, 0);

            modelBuilder.Entity<dividend>()
                .Property(e => e.origin)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.replace)
                .HasPrecision(18, 0);

            modelBuilder.Entity<dividend>()
                .Property(e => e.consold)
                .IsUnicode(false);

            modelBuilder.Entity<dividend>()
                .Property(e => e.eft)
                .HasPrecision(18, 0);

            modelBuilder.Entity<EnrolMNO>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<EnrolMNO>()
                .Property(e => e.WalletName)
                .IsUnicode(false);

            modelBuilder.Entity<EnrolMNO>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<EnrolMNO>()
                .Property(e => e.Active_Session)
                .IsUnicode(false);

            modelBuilder.Entity<EnrolMNO>()
                .Property(e => e.Fullname)
                .IsUnicode(false);

            modelBuilder.Entity<holdersLog>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<holdersLog>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<holdersLog>()
                .Property(e => e.Shareholder)
                .IsUnicode(false);

            modelBuilder.Entity<holdersLog>()
                .Property(e => e.Broker_code)
                .IsUnicode(false);

            modelBuilder.Entity<holdersLog>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<industry_code>()
                .Property(e => e.sector_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<industry_code>()
                .Property(e => e.sector_name)
                .IsUnicode(false);

            modelBuilder.Entity<inter_depository_trans>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Interdepository>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<IPOLOG>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LendersRegister>()
                .Property(e => e.quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LendersRegister>()
                .Property(e => e.security_type)
                .IsUnicode(false);

            modelBuilder.Entity<LendingPool>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LendingPool>()
                .Property(e => e.Quantity)
                .HasPrecision(21, 0);

            modelBuilder.Entity<LendingPool>()
                .Property(e => e.Value)
                .HasPrecision(21, 2);

            modelBuilder.Entity<LendingPool>()
                .Property(e => e.LoanPeriod)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LendingPool>()
                .Property(e => e.collateral_value)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LockAudit>()
                .Property(e => e.cds_Number)
                .IsUnicode(false);

            modelBuilder.Entity<LockAudit>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<LockAudit>()
                .Property(e => e.LockDate)
                .IsUnicode(false);

            modelBuilder.Entity<LockAudit>()
                .Property(e => e.LockState)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LockAudit>()
                .Property(e => e.LockReason)
                .IsUnicode(false);

            modelBuilder.Entity<LockAudit>()
                .Property(e => e.LockDoc)
                .IsUnicode(false);

            modelBuilder.Entity<LockAudit>()
                .Property(e => e.LockedBy)
                .IsUnicode(false);

            modelBuilder.Entity<LockAudit>()
                .Property(e => e.LockType)
                .IsUnicode(false);

            modelBuilder.Entity<LockAudit>()
                .Property(e => e.Approved)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LockAudit>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LockAudit>()
                .Property(e => e.RejectionReason)
                .IsUnicode(false);

            modelBuilder.Entity<LoginAudit>()
                .Property(e => e.idkey)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LoginAudit>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<LoginAudit>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<LoginAudit>()
                .Property(e => e.LoginTime)
                .IsFixedLength();

            modelBuilder.Entity<mandate>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<mandate>()
                .Property(e => e.shareholder)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.ManLname)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.ManFnames)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.ManTitle)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.ManIdpp)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.add_1)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.add_2)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.add_3)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.add_4)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.add_5)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.telephone)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.cellphone)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.fax)
                .HasPrecision(18, 0);

            modelBuilder.Entity<mandate>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.man_bank)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.man_bankCode)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.man_branch)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.man_branchCode)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.man_acc)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.postcode)
                .IsUnicode(false);

            modelBuilder.Entity<mandate>()
                .Property(e => e.eft)
                .IsUnicode(false);

            modelBuilder.Entity<marketcap>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<marketcap>()
                .Property(e => e.shares)
                .HasPrecision(38, 0);

            modelBuilder.Entity<marketcap>()
                .Property(e => e.Market_cap)
                .HasPrecision(38, 2);

            modelBuilder.Entity<MASTER_MODULE_CATEGORIES>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MASTER_MODULE_CATEGORIES>()
                .Property(e => e.CATEGORY)
                .IsUnicode(false);

            modelBuilder.Entity<MASTER_ROLES>()
                .Property(e => e.ROLE_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<MobileWallet>()
                .Property(e => e.Identification)
                .IsUnicode(false);

            modelBuilder.Entity<MobileWallet>()
                .Property(e => e.TelephoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<MobileWallet>()
                .Property(e => e.ReferenceNumber)
                .IsUnicode(false);

            modelBuilder.Entity<MobileWallet>()
                .Property(e => e.MobileWallet1)
                .IsUnicode(false);

            modelBuilder.Entity<MonitorService>()
                .Property(e => e.Service_Description)
                .IsUnicode(false);

            modelBuilder.Entity<MonitorService>()
                .Property(e => e.Service_Name)
                .IsUnicode(false);

            modelBuilder.Entity<NewzBoard>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<NewzBoard>()
                .Property(e => e.audience)
                .IsUnicode(false);

            modelBuilder.Entity<NewzBoard>()
                .Property(e => e.Newz)
                .IsUnicode(false);

            modelBuilder.Entity<NewzBoard>()
                .Property(e => e.Post_By)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.Nominee_Name)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.Nominee_Manager)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.Shareholder)
                .HasPrecision(18, 0);

            modelBuilder.Entity<nominee>()
                .Property(e => e.CDSnumber)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.Brokercode)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.add1)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.add2)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.add3)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.add4)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.cell)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.tell)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.fax)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.bank)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.branch)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.account_type)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.account)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.industry)
                .IsUnicode(false);

            modelBuilder.Entity<nominee>()
                .Property(e => e.tax)
                .HasPrecision(18, 0);

            modelBuilder.Entity<nominee>()
                .Property(e => e.Updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<orders_executed>()
                .Property(e => e.TransId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<orders_executed>()
                .Property(e => e.InitDealNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<orders_executed>()
                .Property(e => e.InitSuffixNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<orders_executed>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<orders_executed>()
                .Property(e => e.DealPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<orders_executed>()
                .Property(e => e.Broker_init)
                .IsUnicode(false);

            modelBuilder.Entity<orders_executed>()
                .Property(e => e.Broker_target)
                .IsUnicode(false);

            modelBuilder.Entity<orders_executed>()
                .Property(e => e.Company)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<orders_executed>()
                .Property(e => e.InitDealType)
                .IsUnicode(false);

            modelBuilder.Entity<orders_executed>()
                .Property(e => e.TargetDealType)
                .IsUnicode(false);

            modelBuilder.Entity<orders_executed>()
                .Property(e => e.TargetDealNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<orders_executed>()
                .Property(e => e.TargetSuffixNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<orders_trans>()
                .Property(e => e.DealNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<orders_trans>()
                .Property(e => e.SuffixNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<orders_trans>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<orders_trans>()
                .Property(e => e.BasePrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OTC_Data_Import>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OTC_Data_Import>()
                .Property(e => e.importid)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Para_Batch_Type>()
                .Property(e => e.Batch_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Para_Batch_Type>()
                .Property(e => e.BatchName)
                .IsUnicode(false);

            modelBuilder.Entity<Para_Batch_Type_Tsec>()
                .Property(e => e.Batch_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Para_Batch_Type_Tsec>()
                .Property(e => e.BatchName)
                .IsUnicode(false);

            modelBuilder.Entity<para_branch>()
                .Property(e => e.bank)
                .IsUnicode(false);

            modelBuilder.Entity<para_branch>()
                .Property(e => e.branch)
                .IsUnicode(false);

            modelBuilder.Entity<para_branch>()
                .Property(e => e.branch_name)
                .IsUnicode(false);

            modelBuilder.Entity<para_branch>()
                .Property(e => e.branch_code)
                .IsUnicode(false);

            modelBuilder.Entity<para_broker>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_broker>()
                .Property(e => e.broker_code)
                .IsUnicode(false);

            modelBuilder.Entity<para_broker>()
                .Property(e => e.fnam)
                .IsUnicode(false);

            modelBuilder.Entity<para_broker>()
                .Property(e => e.CompanyType)
                .IsUnicode(false);

            modelBuilder.Entity<para_broker>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<para_broker>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<para_broker>()
                .Property(e => e.reason)
                .IsUnicode(false);

            modelBuilder.Entity<para_broker>()
                .Property(e => e.clearing_account)
                .IsUnicode(false);

            modelBuilder.Entity<para_broker>()
                .Property(e => e.comments)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<para_city>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_city>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<para_city>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.Id);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.Fnam)
                .IsUnicode(false);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.Issued_shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.CDS_Ac_No)
                .HasPrecision(18, 0);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.registrar)
                .IsUnicode(false);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.Add_1)
                .IsUnicode(false);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.Add_2)
                .IsUnicode(false);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.Add_3)
                .IsUnicode(false);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.Add_4)
                .IsUnicode(false);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.Contact_Person)
                .IsUnicode(false);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.Cellphone)
                .IsUnicode(false);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.Comments)
                .IsUnicode(false);

   
            modelBuilder.Entity<paraCompanyCds>()
                .Property(e => e.board)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.Fnam)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.Issued_shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.CDS_Ac_No)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.registrar)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.Add_1)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.Add_2)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.Add_3)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.Add_4)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.Contact_Person)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.Cellphone)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.sec_type)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.board)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.index_type)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.ticker)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.ISIN)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.year_listed)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.comp_secretary)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.issued_capital)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.nominal_value)
                .HasPrecision(19, 4);

            modelBuilder.Entity<para_company_crosslisted>()
                .Property(e => e.company_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_country>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_country>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<para_country>()
                .Property(e => e.fnam)
                .IsUnicode(false);

            modelBuilder.Entity<para_country>()
                .Property(e => e.Nationality)
                .IsUnicode(false);

            modelBuilder.Entity<para_DebtCompany>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_DebtCompany>()
                .Property(e => e.DaysToMature)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_DebtCompany>()
                .Property(e => e.NoCerts)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_DebtCompany>()
                .Property(e => e.InitialShareCap)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Para_Dept>()
                .Property(e => e.DeptID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Para_Dept>()
                .Property(e => e.DeptName)
                .IsUnicode(false);

            modelBuilder.Entity<Para_Dept>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.Issuer_Code)
                .IsUnicode(false);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.Debt_Type)
                .IsUnicode(false);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.Security_Description)
                .IsUnicode(false);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.GlobalLimit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.IndividualLimit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.DailyLimit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.emailFrom)
                .IsUnicode(false);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.SMTPClient)
                .IsUnicode(false);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.NetworkCredUsername)
                .IsUnicode(false);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.NetworkCredPassword)
                .IsUnicode(false);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.SMTPport)
                .IsUnicode(false);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.AirtelBidUsername)
                .IsUnicode(false);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.AirtelBidPassword)
                .IsUnicode(false);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.AirTelMarchantBillerCode)
                .IsUnicode(false);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.globLowerlimit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.Transaction_Limit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_holding>()
                .Property(e => e.NewIssuerCode)
                .IsUnicode(false);

            modelBuilder.Entity<para_industry>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_industry>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<para_industry>()
                .Property(e => e.fnam)
                .IsUnicode(false);

            modelBuilder.Entity<para_lenders>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_lenders>()
                .Property(e => e.BorrowingLimit)
                .HasPrecision(32, 2);

            modelBuilder.Entity<para_lenders>()
                .Property(e => e.LendingLimit)
                .HasPrecision(32, 2);

            modelBuilder.Entity<Para_lendingRules>()
                .Property(e => e.InterestRate)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Para_lendingRules>()
                .Property(e => e.ServiceCharges)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Para_lendingRules>()
                .Property(e => e.MiniAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Para_lendingRules>()
                .Property(e => e.MaxiAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<para_Prices>()
                .Property(e => e.counter)
                .IsUnicode(false);

            modelBuilder.Entity<para_sectors>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_sectors>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<para_sectors>()
                .Property(e => e.fnam)
                .IsUnicode(false);

            modelBuilder.Entity<para_tax>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_tax>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<para_tax>()
                .Property(e => e.fnam)
                .IsUnicode(false);

            modelBuilder.Entity<para_tax>()
                .Property(e => e.rate)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_tax>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<para_tax1>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_tax1>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<para_tax1>()
                .Property(e => e.fnam)
                .IsUnicode(false);

            modelBuilder.Entity<para_tax1>()
                .Property(e => e.rate)
                .HasPrecision(18, 0);

            modelBuilder.Entity<para_tax1>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Payment_SellOrder>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Payment_SellOrder>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Payment_SellOrder>()
                .Property(e => e.Payment_Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<permission>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<permission>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<permission>()
                .Property(e => e.Forenames)
                .IsUnicode(false);

            modelBuilder.Entity<permission>()
                .Property(e => e.EmployeeCode)
                .IsUnicode(false);

            modelBuilder.Entity<permission>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<permission>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<pledgee_amendment>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<pledgee_amendment>()
                .Property(e => e.command_query)
                .IsUnicode(false);

            modelBuilder.Entity<pledgee_amendment>()
                .Property(e => e.code_pledgor)
                .IsUnicode(false);

            modelBuilder.Entity<pledgee_amendment>()
                .Property(e => e.code_pledgee)
                .IsUnicode(false);

            modelBuilder.Entity<pledgee_amendment>()
                .Property(e => e.updated)
                .IsUnicode(false);

            modelBuilder.Entity<Pledges_Recording>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Pledges_Recording>()
                .Property(e => e.Pledge_with_income)
                .IsUnicode(false);

            modelBuilder.Entity<Pledges_Recording>()
                .Property(e => e.Pledge_capital_benefits)
                .IsUnicode(false);

            modelBuilder.Entity<Pledges_Recording>()
                .Property(e => e.release_option)
                .IsUnicode(false);

            modelBuilder.Entity<Pledges_Recording>()
                .Property(e => e.released)
                .IsUnicode(false);

            modelBuilder.Entity<Pledges_Recording>()
                .Property(e => e.transferred)
                .IsUnicode(false);

            modelBuilder.Entity<Pledges_Recording>()
                .Property(e => e.amendment)
                .IsUnicode(false);

            modelBuilder.Entity<Pledges_release>()
                .Property(e => e.Released_by)
                .IsUnicode(false);

            modelBuilder.Entity<Pledges_release>()
                .Property(e => e.Release_reseason)
                .IsUnicode(false);

            modelBuilder.Entity<Pledges_release>()
                .Property(e => e.Release_Approval)
                .IsUnicode(false);

            modelBuilder.Entity<Pledges_release>()
                .Property(e => e.codes)
                .IsUnicode(false);

            modelBuilder.Entity<Pledges_transfer>()
                .Property(e => e.transferred_by)
                .IsUnicode(false);

            modelBuilder.Entity<Pledges_transfer>()
                .Property(e => e.transfer_reason)
                .IsUnicode(false);

            modelBuilder.Entity<Pledges_transfer>()
                .Property(e => e.transfer_Approval)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.shareholder)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.BrokerCode)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.CDS_number)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Forenames)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.IDpp)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Add_1)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Add_2)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Add_3)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Add_4)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Cellphone)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Bank_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Bank_Code)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Branch_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Branch_Code)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Tax)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Updated_By)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Industry)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Approved)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Approved_By)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Holder_type)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.RecType)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Initials)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.ImageID)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.nominee_code)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.JSurname)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.JForenames)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.JEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.JCell)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Nationality)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.RejectionReason)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.Old_Shareholder)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.idimage)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.sigimage)
                .IsUnicode(false);

            modelBuilder.Entity<Pre_Names_Creation>()
                .Property(e => e.ActivationCode)
                .IsUnicode(false);

            modelBuilder.Entity<ReceiveUSSDEnquire>()
                .Property(e => e.Reference_No)
                .IsUnicode(false);

            modelBuilder.Entity<ReceiveUSSDEnquire>()
                .Property(e => e.PerformFxn)
                .IsUnicode(false);

            modelBuilder.Entity<ReceiveUSSDEnquire>()
                .Property(e => e.CDS_Number)
                .IsUnicode(false);

            modelBuilder.Entity<registrar_type>()
                .Property(e => e.type_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<registrar_type>()
                .Property(e => e.fnam)
                .IsUnicode(false);

            modelBuilder.Entity<rights_dets>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<rights_dets>()
                .Property(e => e.Issue_no)
                .HasPrecision(10, 0);

            modelBuilder.Entity<rights_dets>()
                .Property(e => e.Origin)
                .HasPrecision(10, 0);

            modelBuilder.Entity<rights_dets>()
                .Property(e => e.RightsID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<rights_dets>()
                .Property(e => e.CDSBroker)
                .IsUnicode(false);

            modelBuilder.Entity<rights_dets>()
                .Property(e => e.Source)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<rights_dets>()
                .Property(e => e.La_No)
                .HasPrecision(10, 0);

            modelBuilder.Entity<rights_dets>()
                .Property(e => e.Rights)
                .HasPrecision(12, 0);

            modelBuilder.Entity<rights_dets>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<rights_dets>()
                .Property(e => e.Accepted_By)
                .HasPrecision(10, 0);

            modelBuilder.Entity<rights_dets>()
                .Property(e => e.Accepted_By_Source)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<rights_dets>()
                .Property(e => e.Accepted_By_ID)
                .IsUnicode(false);

            modelBuilder.Entity<rights_dets>()
                .Property(e => e.Origin_ID)
                .IsUnicode(false);

            modelBuilder.Entity<rights_instr>()
                .Property(e => e.issue_no)
                .HasPrecision(10, 0);

            modelBuilder.Entity<rights_instr>()
                .Property(e => e.offer)
                .HasPrecision(12, 6);

            modelBuilder.Entity<rights_instr>()
                .Property(e => e.every)
                .HasPrecision(12, 6);

            modelBuilder.Entity<rights_instr>()
                .Property(e => e.price_per_share)
                .HasPrecision(12, 6);

            modelBuilder.Entity<rights_mast>()
                .Property(e => e.CDSBroker)
                .IsUnicode(false);

            modelBuilder.Entity<rights_mast>()
                .Property(e => e.Source)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<rights_mast>()
                .Property(e => e.Shares_held)
                .HasPrecision(12, 0);

            modelBuilder.Entity<rights_mast>()
                .Property(e => e.Rights)
                .HasPrecision(12, 0);

            modelBuilder.Entity<Role_permissions>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<security_type>()
                .Property(e => e.security_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<security_type>()
                .Property(e => e.security_name)
                .IsUnicode(false);

            modelBuilder.Entity<settlement_movement>()
                .Property(e => e.quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<settlement_movement>()
                .Property(e => e.uploadId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<settlement_movement>()
                .Property(e => e.UpdateState)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SettlementPool>()
                .Property(e => e.NumberofShares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Settlement>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Settlement>()
                .Property(e => e.MatchDeal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Settlement>()
                .Property(e => e.DealerA)
                .IsUnicode(false);

            modelBuilder.Entity<Settlement>()
                .Property(e => e.sharesA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Settlement>()
                .Property(e => e.TranTypeA)
                .IsUnicode(false);

            modelBuilder.Entity<Settlement>()
                .Property(e => e.ConfirmA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Settlement>()
                .Property(e => e.DealerB)
                .IsUnicode(false);

            modelBuilder.Entity<Settlement>()
                .Property(e => e.SharesB)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Settlement>()
                .Property(e => e.TranTypeB)
                .IsUnicode(false);

            modelBuilder.Entity<Settlement>()
                .Property(e => e.ConfirmB)
                .HasPrecision(18, 0);

            modelBuilder.Entity<share_transfer>()
                .Property(e => e.amount_to_transfer)
                .HasPrecision(18, 0);

            modelBuilder.Entity<share_transfer>()
                .Property(e => e.status)
                .IsFixedLength();

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.companyCode)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.CompanyType)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.Trail)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.Password1)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.Password2)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.AuthorizePerm)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.AllocatePermLevel)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.AccountType)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.Forenames)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.Mobile1)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.Mobile2)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.Idnopp)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                .Property(e => e.ContractType)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_AccountStatement>()
                .Property(e => e.DR)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_AccountStatement>()
                .Property(e => e.CR)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_AccountStatement>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_AccountsUploadID>()
                .Property(e => e.UploadID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_AccountsUploadID>()
                .Property(e => e.BrokerCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_AccountsUploadID>()
                .Property(e => e.UploadedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_airtelmoney>()
                .Property(e => e.amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_character_rating>()
                .Property(e => e.QuestionNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_character_rating>()
                .Property(e => e.TotalSection)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tbl_character_rating>()
                .Property(e => e.IndividualWeight)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tbl_charges>()
                .Property(e => e.Charge)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tbl_ClientStatementsView>()
                .Property(e => e.Debit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_ClientStatementsView>()
                .Property(e => e.Credit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_EventsDiary>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_EventsDiary>()
                .Property(e => e.EventFlag)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_people_rating>()
                .Property(e => e.QuestionNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_people_rating>()
                .Property(e => e.TotalSection)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tbl_people_rating>()
                .Property(e => e.IndividualWeight)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tbl_RatioAnalysis>()
                .Property(e => e.QuestionNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_RatioAnalysis>()
                .Property(e => e.TotalSection)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tbl_RatioAnalysis>()
                .Property(e => e.StandardRation)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tbl_RatioAnalysis>()
                .Property(e => e.IndividualWeight)
                .HasPrecision(18, 4);

            modelBuilder.Entity<tbl_SettlementSummary>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_SettlementSummary>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_SharebalanceView>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_SharebalanceView>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_SharebalanceView>()
                .Property(e => e.Purchase)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_SharebalanceView>()
                .Property(e => e.Sale)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_SharebalanceView>()
                .Property(e => e.Gross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_units_move>()
                .Property(e => e.quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_units_move>()
                .Property(e => e.total_charge)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_units_move>()
                .Property(e => e.amount)
                .HasPrecision(38, 5);

            modelBuilder.Entity<tbl_units_move>()
                .Property(e => e.buy_amount)
                .HasPrecision(38, 5);

            modelBuilder.Entity<tbl_units_move>()
                .Property(e => e.Dealprice)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tbl_unmatchedorders>()
                .Property(e => e.quantity_unmatched)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_unmatchedorders>()
                .Property(e => e.order_status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TempAllotment>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<TempAllotment>()
                .Property(e => e.Batch_Ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TempAllotment>()
                .Property(e => e.cds_number)
                .IsUnicode(false);

            modelBuilder.Entity<TempAllotment>()
                .Property(e => e.shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TempAllotment>()
                .Property(e => e.TranType)
                .IsUnicode(false);

            modelBuilder.Entity<TempAllotment>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<TempAllotment>()
                .Property(e => e.Captured_By)
                .IsUnicode(false);

            modelBuilder.Entity<temptran>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<temptran>()
                .Property(e => e.batch_ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<temptran>()
                .Property(e => e.matchedDeal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<temptran>()
                .Property(e => e.shareholder)
                .IsUnicode(false);

            modelBuilder.Entity<temptran>()
                .Property(e => e.shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TempTransFrom>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<TempTransFrom>()
                .Property(e => e.cds_number)
                .IsUnicode(false);

            modelBuilder.Entity<TempTransFrom>()
                .Property(e => e.shares)
                .IsUnicode(false);

            modelBuilder.Entity<TempTransFrom>()
                .Property(e => e.batch_ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TempTransFrom>()
                .Property(e => e.capturedBy)
                .IsUnicode(false);

            modelBuilder.Entity<TempTransFrom>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<TempTransTo>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<TempTransTo>()
                .Property(e => e.cds_number)
                .IsUnicode(false);

            modelBuilder.Entity<TempTransTo>()
                .Property(e => e.shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TempTransTo>()
                .Property(e => e.batch_Ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TempTransTo>()
                .Property(e => e.CapturedBy)
                .IsUnicode(false);

            modelBuilder.Entity<TempTransTo>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<TSec_Batch_Header>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<TSec_Batch_Header>()
                .Property(e => e.Batch_Ref)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TSec_Batch_Header>()
                .Property(e => e.batch_type)
                .IsUnicode(false);

            modelBuilder.Entity<TSec_Batch_Header>()
                .Property(e => e.Batch_Total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TSec_Batch_Header>()
                .Property(e => e.Batch_Broker)
                .IsUnicode(false);

            modelBuilder.Entity<TSec_Batch_Header>()
                .Property(e => e.Batch_Forwarded_By)
                .IsUnicode(false);

            modelBuilder.Entity<TSec_Batch_Header>()
                .Property(e => e.Accepted_By)
                .IsUnicode(false);

            modelBuilder.Entity<TSec_Batch_Header>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<TSec_Batch_Header>()
                .Property(e => e.rejection)
                .IsUnicode(false);

            modelBuilder.Entity<UploadKeyReg>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<UploadKeyReg>()
                .Property(e => e.UploadKey)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UploadKeyReg>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.client_code)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.User_Id)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.User_pass)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.UserLastName)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.UserNames)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Idno)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.SSN)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Client_Class)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Job_Title)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.createdby)
                .IsUnicode(false);

            modelBuilder.Entity<UserManagement>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserManagement>()
                .Property(e => e.Client_Code)
                .IsUnicode(false);

            modelBuilder.Entity<UserManagement>()
                .Property(e => e.Client_Pass)
                .IsUnicode(false);

            modelBuilder.Entity<UserManagement>()
                .Property(e => e.User_Id)
                .IsUnicode(false);

            modelBuilder.Entity<UserManagement>()
                .Property(e => e.User_Pass)
                .IsUnicode(false);

            modelBuilder.Entity<UserManagement>()
                .Property(e => e.Client_Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserManagement>()
                .Property(e => e.User_Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserManagement>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<UserManagement>()
                .Property(e => e.User_Role)
                .IsUnicode(false);

            modelBuilder.Entity<UserManagement>()
                .Property(e => e.Date_Created)
                .IsUnicode(false);

            modelBuilder.Entity<UserManagement>()
                .Property(e => e.Created_By)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
