namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class permission
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Surname { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Forenames { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string EmployeeCode { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Department { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool CreateSystemAccounts { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool UpdateSystemAccounts { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool AllotPermissions { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool CreateMemberAcc { get; set; }

        [Key]
        [Column(Order = 10)]
        public bool UpdateMemberAcc { get; set; }

        [Key]
        [Column(Order = 11)]
        public bool EnqSystUserAcc { get; set; }

        [Key]
        [Column(Order = 12)]
        public bool EnqSystUserAudit { get; set; }

        [Key]
        [Column(Order = 13)]
        public bool EnqMemberAccDe { get; set; }

        [Key]
        [Column(Order = 14)]
        public bool EnqMemberAccPo { get; set; }

        [Key]
        [Column(Order = 15)]
        public bool EnqTransHist { get; set; }

        [Key]
        [Column(Order = 16)]
        public bool EnqBatchHist { get; set; }

        [Key]
        [Column(Order = 17)]
        public bool EnqTradesSett { get; set; }

        [Key]
        [Column(Order = 18)]
        public bool EnqDivHist { get; set; }

        [Key]
        [Column(Order = 19)]
        public bool EnqRightsAllot { get; set; }

        [Key]
        [Column(Order = 20)]
        public bool EnqBonusAllot { get; set; }

        [Key]
        [Column(Order = 21)]
        public bool TransBatchCre { get; set; }

        [Key]
        [Column(Order = 22)]
        public bool TransBatchProc { get; set; }

        [Key]
        [Column(Order = 23)]
        public bool TransBatchUpdate { get; set; }

        [Key]
        [Column(Order = 24)]
        public bool TransBatchRev { get; set; }

        [Key]
        [Column(Order = 25)]
        public bool OrdSalePos { get; set; }

        [Key]
        [Column(Order = 26)]
        public bool OrdPurchPos { get; set; }

        [Key]
        [Column(Order = 27)]
        public bool OrdUpdate { get; set; }

        [Key]
        [Column(Order = 28)]
        public bool OrdRev { get; set; }

        [Key]
        [Column(Order = 29)]
        public bool AudSystUserCre { get; set; }

        [Key]
        [Column(Order = 30)]
        public bool AudSystUserPerm { get; set; }

        [Key]
        [Column(Order = 31)]
        public bool AudSystUserAcces { get; set; }

        [Key]
        [Column(Order = 32)]
        public bool AudSystUserProfMan { get; set; }

        [Key]
        [Column(Order = 33)]
        public bool AudMemberAccCre { get; set; }

        [Key]
        [Column(Order = 34)]
        public bool AudMemberAccUp { get; set; }

        [Key]
        [Column(Order = 35)]
        public bool AudBatchCre { get; set; }

        [Key]
        [Column(Order = 36)]
        public bool AudBatchProc { get; set; }

        [Key]
        [Column(Order = 37)]
        public bool AudOrderCre { get; set; }

        [Key]
        [Column(Order = 38)]
        public bool AudOrdUp { get; set; }

        [Key]
        [Column(Order = 39)]
        public bool FileOrdSumDown { get; set; }

        [Key]
        [Column(Order = 40)]
        public bool FileATSettUp { get; set; }

        [Key]
        [Column(Order = 41)]
        public bool FileSettEFTDown { get; set; }

        [Key]
        [Column(Order = 42)]
        public bool FileSettEFTCon { get; set; }

        [Key]
        [Column(Order = 43)]
        public bool FileMemberAccUp { get; set; }

        [Key]
        [Column(Order = 44)]
        public bool FileMemberAccDown { get; set; }

        [Key]
        [Column(Order = 45)]
        public bool FileDivEFTDown { get; set; }

        [Key]
        [Column(Order = 46)]
        public bool CorpDivCreate { get; set; }

        [Key]
        [Column(Order = 47)]
        public bool CorpDivProc { get; set; }

        [Key]
        [Column(Order = 48)]
        public bool CorpCheqNumAllot { get; set; }

        [Key]
        [Column(Order = 49)]
        public bool CorpCheqPrint { get; set; }

        [Key]
        [Column(Order = 50)]
        public bool CorpDivRecon { get; set; }

        [Key]
        [Column(Order = 51)]
        public bool CorpCheqRepl { get; set; }

        [Key]
        [Column(Order = 52)]
        public bool CorpRightsCre { get; set; }

        [Key]
        [Column(Order = 53)]
        public bool CorpRightsSplit { get; set; }

        [Key]
        [Column(Order = 54)]
        public bool CorpRightsAccCap { get; set; }

        [Key]
        [Column(Order = 55)]
        public bool CorpRightsLaPrint { get; set; }

        [Key]
        [Column(Order = 56)]
        public bool CorpBonusCre { get; set; }

        [Key]
        [Column(Order = 57)]
        public bool CorpBonusProc { get; set; }

        [Key]
        [Column(Order = 58)]
        public bool CorpBonusNotePrint { get; set; }

        [Key]
        [Column(Order = 59)]
        public bool CorpAnnRepUpload { get; set; }

        [Key]
        [Column(Order = 60)]
        public bool CorpAGMNote { get; set; }

        [Key]
        [Column(Order = 61)]
        public bool CorpOtherEvents { get; set; }

        [Key]
        [Column(Order = 62)]
        public bool RptMemberAccSchd { get; set; }

        [Key]
        [Column(Order = 63)]
        public bool RptCompPortSchd { get; set; }

        [Key]
        [Column(Order = 64)]
        public bool RptMemberAccAud { get; set; }

        [Key]
        [Column(Order = 65)]
        public bool RptTransBatchSum { get; set; }

        [Key]
        [Column(Order = 66)]
        public bool RptOrdSumSch { get; set; }

        [Key]
        [Column(Order = 67)]
        public bool RptSattSumSch { get; set; }

        [Key]
        [Column(Order = 68)]
        public bool RptCorpActSch { get; set; }

        [Key]
        [Column(Order = 69)]
        public bool RptMemberTransMovSch { get; set; }
    }
}
