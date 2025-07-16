using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BpmItem
    {
        public BpmItem()
        {
            AccInvInOutDs = new HashSet<AccInvInOutD>();
            AccInvOutCoGs = new HashSet<AccInvOutCoG>();
            AcctHqCogsRpts = new HashSet<AcctHqCogsRpt>();
            AcctHqSaleRpts = new HashSet<AcctHqSaleRpt>();
            Ad20222hs = new HashSet<Ad20222h>();
            AdInvValuations = new HashSet<AdInvValuation>();
            AmzObInvManufacturings = new HashSet<AmzObInvManufacturing>();
            AmzObSalesManuFacturings = new HashSet<AmzObSalesManuFacturing>();
            AmzObTracffics = new HashSet<AmzObTracffic>();
            BinInvtCurs = new HashSet<BinInvtCur>();
            BomChildItems = new HashSet<Bom>();
            BomParentItems = new HashSet<Bom>();
            BpmBegInventories = new HashSet<BpmBegInventory>();
            CatBudgets = new HashSet<CatBudget>();
            CmDs = new HashSet<CmD>();
            CmOrigins = new HashSet<CmOrigin>();
            CompetingItems = new HashSet<CompetingItem>();
            ConsolidationInventoryDs = new HashSet<ConsolidationInventoryD>();
            CrdDs = new HashSet<CrdD>();
            CsFeeClaimDs = new HashSet<CsFeeClaimD>();
            CsFeeInvDs = new HashSet<CsFeeInvD>();
            EdiTs = new HashSet<EdiT>();
            FcstAvgSos = new HashSet<FcstAvgSo>();
            FcstAvgSqas = new HashSet<FcstAvgSqa>();
            FcstBpmSos = new HashSet<FcstBpmSo>();
            FcstWkDs = new HashSet<FcstWkD>();
            FcstWkHts = new HashSet<FcstWkHt>();
            FcstWkInvts = new HashSet<FcstWkInvt>();
            FcstWkPos = new HashSet<FcstWkPo>();
            FcstWkSos = new HashSet<FcstWkSo>();
            FobCostTracks = new HashSet<FobCostTrack>();
            GlAccounts = new HashSet<GlAccount>();
            GlimpactDs = new HashSet<GlimpactD>();
            InvAdjDs = new HashSet<InvAdjD>();
            InvDs = new HashSet<InvD>();
            InvFeedsItems = new HashSet<InvFeedsItem>();
            InvFeedsMrktSpecificSkus = new HashSet<InvFeedsMrktSpecificSku>();
            InvFeedsRemarks = new HashSet<InvFeedsRemark>();
            InvFeedsReportItems = new HashSet<InvFeedsReportItem>();
            InvFeedsRuleSkus = new HashSet<InvFeedsRuleSku>();
            InvFeedsShopifies = new HashSet<InvFeedsShopify>();
            InvFeedsSkucnflctRepItems = new HashSet<InvFeedsSkucnflctRepItem>();
            InvNsMends = new HashSet<InvNsMend>();
            InvRealTimes = new HashSet<InvRealTime>();
            InvTrDs = new HashSet<InvTrD>();
            InvWorksheetDs = new HashSet<InvWorksheetD>();
            InventoryAgingTs = new HashSet<InventoryAgingT>();
            InvtDailyTrxDs = new HashSet<InvtDailyTrxD>();
            ItFeedRatioTs = new HashSet<ItFeedRatioT>();
            ItemAbcAms = new HashSet<ItemAbcAm>();
            ItemAbcCms = new HashSet<ItemAbcCm>();
            ItemAbcPcs = new HashSet<ItemAbcPc>();
            ItemAbcPms = new HashSet<ItemAbcPm>();
            ItemAcctFobs = new HashSet<ItemAcctFob>();
            ItemAvgCostByLocs = new HashSet<ItemAvgCostByLoc>();
            ItemAvgCosts = new HashSet<ItemAvgCost>();
            ItemBoxDims = new HashSet<ItemBoxDim>();
            ItemCurrFobs = new HashSet<ItemCurrFob>();
            ItemDimMfgs = new HashSet<ItemDimMfg>();
            ItemDutyTarifs = new HashSet<ItemDutyTarif>();
            ItemFobCcs = new HashSet<ItemFobCc>();
            ItemFobHists = new HashSet<ItemFobHist>();
            ItemFobPcs = new HashSet<ItemFobPc>();
            ItemFobVcs = new HashSet<ItemFobVc>();
            ItemFvcps = new HashSet<ItemFvcp>();
            ItemMdFobs = new HashSet<ItemMdFob>();
            ItemProductTypes = new HashSet<ItemProductType>();
            ItemRegPrices = new HashSet<ItemRegPrice>();
            ItemStatLogs = new HashSet<ItemStatLog>();
            ItemTrkCoOCoItemNos = new HashSet<ItemTrkCoO>();
            ItemTrkCoOItemNos = new HashSet<ItemTrkCoO>();
            KoSoDs = new HashSet<KoSoD>();
            MarketMasterItems = new HashSet<MarketMasterItem>();
            MkIcrs = new HashSet<MkIcr>();
            MsInvAtBins = new HashSet<MsInvAtBin>();
            NsCreditMemoDs = new HashSet<NsCreditMemoD>();
            NsCustPns = new HashSet<NsCustPn>();
            NsIcrs = new HashSet<NsIcr>();
            NsInvoiceDs = new HashSet<NsInvoiceD>();
            PoCmDs = new HashSet<PoCmD>();
            PoDs = new HashSet<PoD>();
            PromoEds = new HashSet<PromoEd>();
            QpPalByLocs = new HashSet<QpPalByLoc>();
            RealTimeInvUpdDetails = new HashSet<RealTimeInvUpdDetail>();
            RemitCmDItemNos = new HashSet<RemitCmD>();
            RemitCmDRemitItems = new HashSet<RemitCmD>();
            RemitInvDItemNos = new HashSet<RemitInvD>();
            RemitInvDRemitItems = new HashSet<RemitInvD>();
            RetailPriceHistories = new HashSet<RetailPriceHistory>();
            SoDItemNoOrigs = new HashSet<SoD>();
            SoDItemNos = new HashSet<SoD>();
            SodBols = new HashSet<SodBol>();
            SodPts = new HashSet<SodPt>();
            ToDs = new HashSet<ToD>();
            TplInvRptDs = new HashSet<TplInvRptD>();
            TplinvoiceDs = new HashSet<TplinvoiceD>();
            TplinvoiceRates = new HashSet<TplinvoiceRate>();
            VendorReturnDs = new HashSet<VendorReturnD>();
            WyfrPricCstStckRepDetails = new HashSet<WyfrPricCstStckRepDetail>();
            ZinusSkus = new HashSet<ZinusSku>();
        }

        public int ItemNoId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int? NsIntId { get; set; }
        public int ItemTypeId { get; set; }
        public string BpmUpc { get; set; }
        public string HtsCode { get; set; }
        public int? Cat1Id { get; set; }
        public int? Cat2Id { get; set; }
        public int? Cat3Id { get; set; }
        public int? Cat4Id { get; set; }
        public int? Cat5Id { get; set; }
        public int? Cat6Id { get; set; }
        public string CatSage { get; set; }
        public int? CatZinusId { get; set; }
        public int? MasterSkuId { get; set; }
        public int? VendorId { get; set; }
        public decimal? CartonLength { get; set; }
        public decimal? CartonWidth { get; set; }
        public decimal? CartonHeight { get; set; }
        public decimal? CartonWeight { get; set; }
        public decimal? ProductLength { get; set; }
        public decimal? ProductWidth { get; set; }
        public decimal? ProductHeight { get; set; }
        public decimal? ProductWeight { get; set; }
        public string Size { get; set; }
        public decimal? Thickness { get; set; }
        public string Color { get; set; }
        public int? SortOrder { get; set; }
        public int? ItemStatusId { get; set; }
        public int? IsObsolete { get; set; }
        public DateTime? DateObsolete { get; set; }
        public int? PalletTypeId { get; set; }
        public int? QtyPerPallet { get; set; }
        public int? MrcQty { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? LastModKoT { get; set; }
        public int? LastModKoE { get; set; }
        public string Category { get; set; }
        public string CategoryAd { get; set; }
        public int? CatZinOldId { get; set; }
        public DateTime? LaunchDate { get; set; }
        public int? MatTypeId { get; set; }
        public int? MatInfusid { get; set; }
        public int? ItemCollId { get; set; }
        public byte? IsAmzDisku { get; set; }
        public byte? IsWaySlpSku { get; set; }
        public byte? IsWayExsSku { get; set; }
        public int? MatrialTypeId { get; set; }
        public bool? IsFeedable { get; set; }
        public int? InvFeedsCheckBackOrderLeadTimeId { get; set; }
        public int? CheckBackOrderLeadTimeMainSlid { get; set; }
        public int? CheckBackOrderLeadTimeSwcaftid { get; set; }
        public int? CheckBackOrderLeadTimeBancid { get; set; }
        public int? CheckBackOrderLeadTimeBascid { get; set; }
        public int? LeftOverMainSlassgndMktId { get; set; }
        public int? LeftOverSwcaftassgndMktId { get; set; }
        public int? LeftOverBancassgndMktId { get; set; }
        public int? LeftOverBascassgndMktId { get; set; }
        public bool? IsCoOmasterSku { get; set; }
        public int? CoOmasterSkuId { get; set; }
        public bool? IsNewExtended { get; set; }
        public int? CheckBackOrderLeadTimePrsmLthrpId { get; set; }
        public int? CheckBackOrderLeadTimePrsmStcktnId { get; set; }
        public int? LeftOverPrsmStcktnAssgndMktId { get; set; }
        public int? LeftOverPrsmLthrpAssgndMktId { get; set; }
        public int? CatGlobalZId { get; set; }
        public string UserManualLink { get; set; }
        public decimal? CartonMfgCm { get; set; }
        public bool? IsAllowDupUpc { get; set; }
        public decimal? CartonMfgCcm { get; set; }
        public string ZinusSku { get; set; }
        public int? CheckBackOrderLeadTimeZnsTracyId { get; set; }
        public int? CheckBackOrderLeadTimeZnsChsId { get; set; }
        public int? LeftOverZnsTracyAssgndMktId { get; set; }
        public int? LeftOverZnsChsAssgndMktId { get; set; }
        public bool IsLageSmallBox { get; set; }
        public int? ChanExclusiveId { get; set; }

        public virtual Category1 Cat1 { get; set; }
        public virtual Category2 Cat2 { get; set; }
        public virtual Category3 Cat3 { get; set; }
        public virtual Category4 Cat4 { get; set; }
        public virtual Category5 Cat5 { get; set; }
        public virtual Category6 Cat6 { get; set; }
        public virtual CatGlobalZ CatGlobalZ { get; set; }
        public virtual CategoryZinu CatZinOld { get; set; }
        public virtual CategoryZinu CatZinus { get; set; }
        public virtual ChanExclusive ChanExclusive { get; set; }
        public virtual ItemColl ItemColl { get; set; }
        public virtual ItemStatus ItemStatus { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual MasterSku MasterSku { get; set; }
        public virtual MatInfu MatInfus { get; set; }
        public virtual MatType MatType { get; set; }
        public virtual MatreialType MatrialType { get; set; }
        public virtual PalletType PalletType { get; set; }
        public virtual AdBolPickWh AdBolPickWh { get; set; }
        public virtual ICollection<AccInvInOutD> AccInvInOutDs { get; set; }
        public virtual ICollection<AccInvOutCoG> AccInvOutCoGs { get; set; }
        public virtual ICollection<AcctHqCogsRpt> AcctHqCogsRpts { get; set; }
        public virtual ICollection<AcctHqSaleRpt> AcctHqSaleRpts { get; set; }
        public virtual ICollection<Ad20222h> Ad20222hs { get; set; }
        public virtual ICollection<AdInvValuation> AdInvValuations { get; set; }
        public virtual ICollection<AmzObInvManufacturing> AmzObInvManufacturings { get; set; }
        public virtual ICollection<AmzObSalesManuFacturing> AmzObSalesManuFacturings { get; set; }
        public virtual ICollection<AmzObTracffic> AmzObTracffics { get; set; }
        public virtual ICollection<BinInvtCur> BinInvtCurs { get; set; }
        public virtual ICollection<Bom> BomChildItems { get; set; }
        public virtual ICollection<Bom> BomParentItems { get; set; }
        public virtual ICollection<BpmBegInventory> BpmBegInventories { get; set; }
        public virtual ICollection<CatBudget> CatBudgets { get; set; }
        public virtual ICollection<CmD> CmDs { get; set; }
        public virtual ICollection<CmOrigin> CmOrigins { get; set; }
        public virtual ICollection<CompetingItem> CompetingItems { get; set; }
        public virtual ICollection<ConsolidationInventoryD> ConsolidationInventoryDs { get; set; }
        public virtual ICollection<CrdD> CrdDs { get; set; }
        public virtual ICollection<CsFeeClaimD> CsFeeClaimDs { get; set; }
        public virtual ICollection<CsFeeInvD> CsFeeInvDs { get; set; }
        public virtual ICollection<EdiT> EdiTs { get; set; }
        public virtual ICollection<FcstAvgSo> FcstAvgSos { get; set; }
        public virtual ICollection<FcstAvgSqa> FcstAvgSqas { get; set; }
        public virtual ICollection<FcstBpmSo> FcstBpmSos { get; set; }
        public virtual ICollection<FcstWkD> FcstWkDs { get; set; }
        public virtual ICollection<FcstWkHt> FcstWkHts { get; set; }
        public virtual ICollection<FcstWkInvt> FcstWkInvts { get; set; }
        public virtual ICollection<FcstWkPo> FcstWkPos { get; set; }
        public virtual ICollection<FcstWkSo> FcstWkSos { get; set; }
        public virtual ICollection<FobCostTrack> FobCostTracks { get; set; }
        public virtual ICollection<GlAccount> GlAccounts { get; set; }
        public virtual ICollection<GlimpactD> GlimpactDs { get; set; }
        public virtual ICollection<InvAdjD> InvAdjDs { get; set; }
        public virtual ICollection<InvD> InvDs { get; set; }
        public virtual ICollection<InvFeedsItem> InvFeedsItems { get; set; }
        public virtual ICollection<InvFeedsMrktSpecificSku> InvFeedsMrktSpecificSkus { get; set; }
        public virtual ICollection<InvFeedsRemark> InvFeedsRemarks { get; set; }
        public virtual ICollection<InvFeedsReportItem> InvFeedsReportItems { get; set; }
        public virtual ICollection<InvFeedsRuleSku> InvFeedsRuleSkus { get; set; }
        public virtual ICollection<InvFeedsShopify> InvFeedsShopifies { get; set; }
        public virtual ICollection<InvFeedsSkucnflctRepItem> InvFeedsSkucnflctRepItems { get; set; }
        public virtual ICollection<InvNsMend> InvNsMends { get; set; }
        public virtual ICollection<InvRealTime> InvRealTimes { get; set; }
        public virtual ICollection<InvTrD> InvTrDs { get; set; }
        public virtual ICollection<InvWorksheetD> InvWorksheetDs { get; set; }
        public virtual ICollection<InventoryAgingT> InventoryAgingTs { get; set; }
        public virtual ICollection<InvtDailyTrxD> InvtDailyTrxDs { get; set; }
        public virtual ICollection<ItFeedRatioT> ItFeedRatioTs { get; set; }
        public virtual ICollection<ItemAbcAm> ItemAbcAms { get; set; }
        public virtual ICollection<ItemAbcCm> ItemAbcCms { get; set; }
        public virtual ICollection<ItemAbcPc> ItemAbcPcs { get; set; }
        public virtual ICollection<ItemAbcPm> ItemAbcPms { get; set; }
        public virtual ICollection<ItemAcctFob> ItemAcctFobs { get; set; }
        public virtual ICollection<ItemAvgCostByLoc> ItemAvgCostByLocs { get; set; }
        public virtual ICollection<ItemAvgCost> ItemAvgCosts { get; set; }
        public virtual ICollection<ItemBoxDim> ItemBoxDims { get; set; }
        public virtual ICollection<ItemCurrFob> ItemCurrFobs { get; set; }
        public virtual ICollection<ItemDimMfg> ItemDimMfgs { get; set; }
        public virtual ICollection<ItemDutyTarif> ItemDutyTarifs { get; set; }
        public virtual ICollection<ItemFobCc> ItemFobCcs { get; set; }
        public virtual ICollection<ItemFobHist> ItemFobHists { get; set; }
        public virtual ICollection<ItemFobPc> ItemFobPcs { get; set; }
        public virtual ICollection<ItemFobVc> ItemFobVcs { get; set; }
        public virtual ICollection<ItemFvcp> ItemFvcps { get; set; }
        public virtual ICollection<ItemMdFob> ItemMdFobs { get; set; }
        public virtual ICollection<ItemProductType> ItemProductTypes { get; set; }
        public virtual ICollection<ItemRegPrice> ItemRegPrices { get; set; }
        public virtual ICollection<ItemStatLog> ItemStatLogs { get; set; }
        public virtual ICollection<ItemTrkCoO> ItemTrkCoOCoItemNos { get; set; }
        public virtual ICollection<ItemTrkCoO> ItemTrkCoOItemNos { get; set; }
        public virtual ICollection<KoSoD> KoSoDs { get; set; }
        public virtual ICollection<MarketMasterItem> MarketMasterItems { get; set; }
        public virtual ICollection<MkIcr> MkIcrs { get; set; }
        public virtual ICollection<MsInvAtBin> MsInvAtBins { get; set; }
        public virtual ICollection<NsCreditMemoD> NsCreditMemoDs { get; set; }
        public virtual ICollection<NsCustPn> NsCustPns { get; set; }
        public virtual ICollection<NsIcr> NsIcrs { get; set; }
        public virtual ICollection<NsInvoiceD> NsInvoiceDs { get; set; }
        public virtual ICollection<PoCmD> PoCmDs { get; set; }
        public virtual ICollection<PoD> PoDs { get; set; }
        public virtual ICollection<PromoEd> PromoEds { get; set; }
        public virtual ICollection<QpPalByLoc> QpPalByLocs { get; set; }
        public virtual ICollection<RealTimeInvUpdDetail> RealTimeInvUpdDetails { get; set; }
        public virtual ICollection<RemitCmD> RemitCmDItemNos { get; set; }
        public virtual ICollection<RemitCmD> RemitCmDRemitItems { get; set; }
        public virtual ICollection<RemitInvD> RemitInvDItemNos { get; set; }
        public virtual ICollection<RemitInvD> RemitInvDRemitItems { get; set; }
        public virtual ICollection<RetailPriceHistory> RetailPriceHistories { get; set; }
        public virtual ICollection<SoD> SoDItemNoOrigs { get; set; }
        public virtual ICollection<SoD> SoDItemNos { get; set; }
        public virtual ICollection<SodBol> SodBols { get; set; }
        public virtual ICollection<SodPt> SodPts { get; set; }
        public virtual ICollection<ToD> ToDs { get; set; }
        public virtual ICollection<TplInvRptD> TplInvRptDs { get; set; }
        public virtual ICollection<TplinvoiceD> TplinvoiceDs { get; set; }
        public virtual ICollection<TplinvoiceRate> TplinvoiceRates { get; set; }
        public virtual ICollection<VendorReturnD> VendorReturnDs { get; set; }
        public virtual ICollection<WyfrPricCstStckRepDetail> WyfrPricCstStckRepDetails { get; set; }
        public virtual ICollection<ZinusSku> ZinusSkus { get; set; }
    }
}
