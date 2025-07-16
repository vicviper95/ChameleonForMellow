using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AccInvInOutTs = new HashSet<AccInvInOutT>();
            AnnouncementCreatedByNavigations = new HashSet<Announcement>();
            AnnouncementLastModifiedByNavigations = new HashSet<Announcement>();
            BinInvtAdjs = new HashSet<BinInvtAdj>();
            BinItemScans = new HashSet<BinItemScan>();
            CsInvtFeedTEmpAddeds = new HashSet<CsInvtFeedT>();
            CsInvtFeedTEmpReviewds = new HashSet<CsInvtFeedT>();
            CsInvtFeedTEmpSents = new HashSet<CsInvtFeedT>();
            DeptManagers = new HashSet<DeptManager>();
            EmpChameleonConfigs = new HashSet<EmpChameleonConfig>();
            ExwCosts = new HashSet<ExwCost>();
            FcstWkTs = new HashSet<FcstWkT>();
            InvCountEntries = new HashSet<InvCountEntry>();
            InvFeedsMrktSpecificSkus = new HashSet<InvFeedsMrktSpecificSku>();
            InvFeedsRemarks = new HashSet<InvFeedsRemark>();
            InvFeedsReportApprovedByNavigations = new HashSet<InvFeedsReport>();
            InvFeedsReportCreatedByNavigations = new HashSet<InvFeedsReport>();
            InvFeedsReportItems = new HashSet<InvFeedsReportItem>();
            InvFeedsRmrkCtgries = new HashSet<InvFeedsRmrkCtgry>();
            InvFeedsRules = new HashSet<InvFeedsRule>();
            InvFeedsShopifies = new HashSet<InvFeedsShopify>();
            InvFeedsSkuconflictReports = new HashSet<InvFeedsSkuconflictReport>();
            ItemCurrFobs = new HashSet<ItemCurrFob>();
            ItemFobHists = new HashSet<ItemFobHist>();
            ItemFvcps = new HashSet<ItemFvcp>();
            ItemMdFobs = new HashSet<ItemMdFob>();
            ItemStatLogs = new HashSet<ItemStatLog>();
            MkInvFeedTEmpChecks = new HashSet<MkInvFeedT>();
            MkInvFeedTEmpSents = new HashSet<MkInvFeedT>();
            MsBinScans = new HashSet<MsBinScan>();
            MsInvAdjEntries = new HashSet<MsInvAdjEntry>();
            NotesAndRuleCreatedByNavigations = new HashSet<NotesAndRule>();
            NotesAndRuleLastModifiedByNavigations = new HashSet<NotesAndRule>();
            NotesRulesRmrkCatCreatedByNavigations = new HashSet<NotesRulesRmrkCat>();
            NotesRulesRmrkCatModifiedByNavigations = new HashSet<NotesRulesRmrkCat>();
            NsIcrs = new HashSet<NsIcr>();
            PickTaskEmpAsgneds = new HashSet<PickTask>();
            PickTaskEmpPickeds = new HashSet<PickTask>();
            PoChanges = new HashSet<PoChange>();
            RealTimeInvUpdates = new HashSet<RealTimeInvUpdate>();
            Rmas = new HashSet<Rma>();
            SalesRemitAddedEmps = new HashSet<SalesRemit>();
            SalesRemitLastModeEmps = new HashSet<SalesRemit>();
            ScanGuns = new HashSet<ScanGun>();
            ToDoListOweners = new HashSet<ToDoList>();
            ToDoListRequesters = new HashSet<ToDoList>();
            VendorBillTs = new HashSet<VendorBillT>();
            WmsAdjustAdjusters = new HashSet<WmsAdjust>();
            WmsAdjustApprovers = new HashSet<WmsAdjust>();
            WmsCycleCounts = new HashSet<WmsCycleCount>();
            WmsTransferReceivers = new HashSet<WmsTransfer>();
            WmsTransferRequesters = new HashSet<WmsTransfer>();
        }

        public int EmployeeId { get; set; }
        public string LoginId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? DateHired { get; set; }
        public DateTime? DateTerminated { get; set; }
        public DateTime? DateBirth { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? AddedTime { get; set; }
        public int? EmpTypeId { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DatePwChange { get; set; }
        public int LoginFailCount { get; set; }
        public int LoginFailTotal { get; set; }
        public string PasswordSalt { get; set; }
        public int? DepartmentId { get; set; }
        public int? NsIntId { get; set; }
        public string LegalName { get; set; }
        public string EmployeeNo { get; set; }
        public int? EmpStatusId { get; set; }
        public DateTime? LastLogOnTime { get; set; }
        public bool IsEdiadmin { get; set; }
        public int? PrePoauthorizationLevel { get; set; }
        public bool? IsInventoryFeeder { get; set; }
        public int? KoalaRoleId { get; set; }
        public int? ApiauthLvlId { get; set; }
        public bool? IsUserOnFstMvngSkus { get; set; }
        public bool? IsUserOnPrePoNotif { get; set; }

        public virtual ApiauthorityLevel ApiauthLvl { get; set; }
        public virtual Department Department { get; set; }
        public virtual EmployeeStatus EmpStatus { get; set; }
        public virtual EmployeeType EmpType { get; set; }
        public virtual KoalaRole KoalaRole { get; set; }
        public virtual ICollection<AccInvInOutT> AccInvInOutTs { get; set; }
        public virtual ICollection<Announcement> AnnouncementCreatedByNavigations { get; set; }
        public virtual ICollection<Announcement> AnnouncementLastModifiedByNavigations { get; set; }
        public virtual ICollection<BinInvtAdj> BinInvtAdjs { get; set; }
        public virtual ICollection<BinItemScan> BinItemScans { get; set; }
        public virtual ICollection<CsInvtFeedT> CsInvtFeedTEmpAddeds { get; set; }
        public virtual ICollection<CsInvtFeedT> CsInvtFeedTEmpReviewds { get; set; }
        public virtual ICollection<CsInvtFeedT> CsInvtFeedTEmpSents { get; set; }
        public virtual ICollection<DeptManager> DeptManagers { get; set; }
        public virtual ICollection<EmpChameleonConfig> EmpChameleonConfigs { get; set; }
        public virtual ICollection<ExwCost> ExwCosts { get; set; }
        public virtual ICollection<FcstWkT> FcstWkTs { get; set; }
        public virtual ICollection<InvCountEntry> InvCountEntries { get; set; }
        public virtual ICollection<InvFeedsMrktSpecificSku> InvFeedsMrktSpecificSkus { get; set; }
        public virtual ICollection<InvFeedsRemark> InvFeedsRemarks { get; set; }
        public virtual ICollection<InvFeedsReport> InvFeedsReportApprovedByNavigations { get; set; }
        public virtual ICollection<InvFeedsReport> InvFeedsReportCreatedByNavigations { get; set; }
        public virtual ICollection<InvFeedsReportItem> InvFeedsReportItems { get; set; }
        public virtual ICollection<InvFeedsRmrkCtgry> InvFeedsRmrkCtgries { get; set; }
        public virtual ICollection<InvFeedsRule> InvFeedsRules { get; set; }
        public virtual ICollection<InvFeedsShopify> InvFeedsShopifies { get; set; }
        public virtual ICollection<InvFeedsSkuconflictReport> InvFeedsSkuconflictReports { get; set; }
        public virtual ICollection<ItemCurrFob> ItemCurrFobs { get; set; }
        public virtual ICollection<ItemFobHist> ItemFobHists { get; set; }
        public virtual ICollection<ItemFvcp> ItemFvcps { get; set; }
        public virtual ICollection<ItemMdFob> ItemMdFobs { get; set; }
        public virtual ICollection<ItemStatLog> ItemStatLogs { get; set; }
        public virtual ICollection<MkInvFeedT> MkInvFeedTEmpChecks { get; set; }
        public virtual ICollection<MkInvFeedT> MkInvFeedTEmpSents { get; set; }
        public virtual ICollection<MsBinScan> MsBinScans { get; set; }
        public virtual ICollection<MsInvAdjEntry> MsInvAdjEntries { get; set; }
        public virtual ICollection<NotesAndRule> NotesAndRuleCreatedByNavigations { get; set; }
        public virtual ICollection<NotesAndRule> NotesAndRuleLastModifiedByNavigations { get; set; }
        public virtual ICollection<NotesRulesRmrkCat> NotesRulesRmrkCatCreatedByNavigations { get; set; }
        public virtual ICollection<NotesRulesRmrkCat> NotesRulesRmrkCatModifiedByNavigations { get; set; }
        public virtual ICollection<NsIcr> NsIcrs { get; set; }
        public virtual ICollection<PickTask> PickTaskEmpAsgneds { get; set; }
        public virtual ICollection<PickTask> PickTaskEmpPickeds { get; set; }
        public virtual ICollection<PoChange> PoChanges { get; set; }
        public virtual ICollection<RealTimeInvUpdate> RealTimeInvUpdates { get; set; }
        public virtual ICollection<Rma> Rmas { get; set; }
        public virtual ICollection<SalesRemit> SalesRemitAddedEmps { get; set; }
        public virtual ICollection<SalesRemit> SalesRemitLastModeEmps { get; set; }
        public virtual ICollection<ScanGun> ScanGuns { get; set; }
        public virtual ICollection<ToDoList> ToDoListOweners { get; set; }
        public virtual ICollection<ToDoList> ToDoListRequesters { get; set; }
        public virtual ICollection<VendorBillT> VendorBillTs { get; set; }
        public virtual ICollection<WmsAdjust> WmsAdjustAdjusters { get; set; }
        public virtual ICollection<WmsAdjust> WmsAdjustApprovers { get; set; }
        public virtual ICollection<WmsCycleCount> WmsCycleCounts { get; set; }
        public virtual ICollection<WmsTransfer> WmsTransferReceivers { get; set; }
        public virtual ICollection<WmsTransfer> WmsTransferRequesters { get; set; }
    }
}
