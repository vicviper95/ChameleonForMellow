using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BpmLocation
    {
        public BpmLocation()
        {
            AccInvInOutDs = new HashSet<AccInvInOutD>();
            AdArns = new HashSet<AdArn>();
            AdBolPickWhP1s = new HashSet<AdBolPickWh>();
            AdBolPickWhP2s = new HashSet<AdBolPickWh>();
            AdBolPickWhP3s = new HashSet<AdBolPickWh>();
            AdBolPickWhP4s = new HashSet<AdBolPickWh>();
            AdBolPickWhP5s = new HashSet<AdBolPickWh>();
            AdBols = new HashSet<AdBol>();
            AdInvValuations = new HashSet<AdInvValuation>();
            BpmBegInventories = new HashSet<BpmBegInventory>();
            ConsolidationInventoryDs = new HashSet<ConsolidationInventoryD>();
            Containers = new HashSet<Container>();
            CsInvtFeedDs = new HashSet<CsInvtFeedD>();
            CustAddrs = new HashSet<CustAddr>();
            CustBillAddrs = new HashSet<CustBillAddr>();
            CustLocCodes = new HashSet<CustLocCode>();
            CustRetuAddrs = new HashSet<CustRetuAddr>();
            EdiAutoTpls = new HashSet<EdiAutoTpl>();
            EdiTs = new HashSet<EdiT>();
            GlimpactDs = new HashSet<GlimpactD>();
            InLandTrDays = new HashSet<InLandTrDay>();
            InvAdjDs = new HashSet<InvAdjD>();
            InvFeedsItemLocQties = new HashSet<InvFeedsItemLocQty>();
            InvNsMends = new HashSet<InvNsMend>();
            InvRealTimes = new HashSet<InvRealTime>();
            InvTrDFrLocs = new HashSet<InvTrD>();
            InvTrDToLocs = new HashSet<InvTrD>();
            InvWorksheetDs = new HashSet<InvWorksheetD>();
            InventoryAgingTs = new HashSet<InventoryAgingT>();
            InverseMasterLoc = new HashSet<BpmLocation>();
            InvtCntTs = new HashSet<InvtCntT>();
            InvtDailyTrxDs = new HashSet<InvtDailyTrxD>();
            ItemAvgCostByLocs = new HashSet<ItemAvgCostByLoc>();
            KoSoDs = new HashSet<KoSoD>();
            MkInvFeedTs = new HashSet<MkInvFeedT>();
            MslBinNos = new HashSet<MslBinNo>();
            PoBillDs = new HashSet<PoBillD>();
            PoDs = new HashSet<PoD>();
            PoRcvDs = new HashSet<PoRcvD>();
            PoTs = new HashSet<PoT>();
            QpPalByLocs = new HashSet<QpPalByLoc>();
            RealTimeInvUpdDetails = new HashSet<RealTimeInvUpdDetail>();
            ShipAccts = new HashSet<ShipAcct>();
            SoDShipFromOrigs = new HashSet<SoD>();
            SoDShipFromWhs = new HashSet<SoD>();
            ToTShipFrs = new HashSet<ToT>();
            ToTShipTos = new HashSet<ToT>();
            TplInvRptTs = new HashSet<TplInvRptT>();
            TplinvoiceRates = new HashSet<TplinvoiceRate>();
            TplinvoiceTs = new HashSet<TplinvoiceT>();
            TplinvoiceTypes = new HashSet<TplinvoiceType>();
            Vend2WhLts = new HashSet<Vend2WhLt>();
            VendorReturnDs = new HashSet<VendorReturnD>();
            WfsInvtHists = new HashSet<WfsInvtHist>();
            WhTotes = new HashSet<WhTote>();
        }

        public int LocationId { get; set; }
        public int? NsIntId { get; set; }
        public string LocName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string LocIdAmazon { get; set; }
        public string LocIdOverstock { get; set; }
        public string LocIdWayfair { get; set; }
        public string LocIdWalmart { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }
        public string LocType { get; set; }
        public short? FcstLocId { get; set; }
        public string LocIdWay846 { get; set; }
        public string LocIdWay945 { get; set; }
        public int IsActive { get; set; }
        public string LocIdAinSan { get; set; }
        public string LocIdAdds { get; set; }
        public string LocIdHomeDp { get; set; }
        public int? DfPortDestId { get; set; }
        public string LocIdTarget { get; set; }
        public bool IsDropShip { get; set; }
        public bool Is3Pl { get; set; }
        public bool IsWayfCg { get; set; }
        public int? EdipartnerId { get; set; }
        public int? TimeOffset { get; set; }
        public int? ZinusLocId { get; set; }
        public bool IsBulkFf { get; set; }
        public int? MasterLocId { get; set; }
        public bool IsFbaCa { get; set; }
        public bool IsWfs { get; set; }
        public int? LocationTypeId { get; set; }
        public int? BudgetLocId { get; set; }
        public bool IsUsingNs { get; set; }
        public bool IsFeedDsInvt { get; set; }

        public virtual BudgetLoc BudgetLoc { get; set; }
        public virtual PortDest DfPortDest { get; set; }
        public virtual Edipartner Edipartner { get; set; }
        public virtual FcstLocation FcstLoc { get; set; }
        public virtual LocationType LocationType { get; set; }
        public virtual BpmLocation MasterLoc { get; set; }
        public virtual ZinusLoc ZinusLoc { get; set; }
        public virtual ICollection<AccInvInOutD> AccInvInOutDs { get; set; }
        public virtual ICollection<AdArn> AdArns { get; set; }
        public virtual ICollection<AdBolPickWh> AdBolPickWhP1s { get; set; }
        public virtual ICollection<AdBolPickWh> AdBolPickWhP2s { get; set; }
        public virtual ICollection<AdBolPickWh> AdBolPickWhP3s { get; set; }
        public virtual ICollection<AdBolPickWh> AdBolPickWhP4s { get; set; }
        public virtual ICollection<AdBolPickWh> AdBolPickWhP5s { get; set; }
        public virtual ICollection<AdBol> AdBols { get; set; }
        public virtual ICollection<AdInvValuation> AdInvValuations { get; set; }
        public virtual ICollection<BpmBegInventory> BpmBegInventories { get; set; }
        public virtual ICollection<ConsolidationInventoryD> ConsolidationInventoryDs { get; set; }
        public virtual ICollection<Container> Containers { get; set; }
        public virtual ICollection<CsInvtFeedD> CsInvtFeedDs { get; set; }
        public virtual ICollection<CustAddr> CustAddrs { get; set; }
        public virtual ICollection<CustBillAddr> CustBillAddrs { get; set; }
        public virtual ICollection<CustLocCode> CustLocCodes { get; set; }
        public virtual ICollection<CustRetuAddr> CustRetuAddrs { get; set; }
        public virtual ICollection<EdiAutoTpl> EdiAutoTpls { get; set; }
        public virtual ICollection<EdiT> EdiTs { get; set; }
        public virtual ICollection<GlimpactD> GlimpactDs { get; set; }
        public virtual ICollection<InLandTrDay> InLandTrDays { get; set; }
        public virtual ICollection<InvAdjD> InvAdjDs { get; set; }
        public virtual ICollection<InvFeedsItemLocQty> InvFeedsItemLocQties { get; set; }
        public virtual ICollection<InvNsMend> InvNsMends { get; set; }
        public virtual ICollection<InvRealTime> InvRealTimes { get; set; }
        public virtual ICollection<InvTrD> InvTrDFrLocs { get; set; }
        public virtual ICollection<InvTrD> InvTrDToLocs { get; set; }
        public virtual ICollection<InvWorksheetD> InvWorksheetDs { get; set; }
        public virtual ICollection<InventoryAgingT> InventoryAgingTs { get; set; }
        public virtual ICollection<BpmLocation> InverseMasterLoc { get; set; }
        public virtual ICollection<InvtCntT> InvtCntTs { get; set; }
        public virtual ICollection<InvtDailyTrxD> InvtDailyTrxDs { get; set; }
        public virtual ICollection<ItemAvgCostByLoc> ItemAvgCostByLocs { get; set; }
        public virtual ICollection<KoSoD> KoSoDs { get; set; }
        public virtual ICollection<MkInvFeedT> MkInvFeedTs { get; set; }
        public virtual ICollection<MslBinNo> MslBinNos { get; set; }
        public virtual ICollection<PoBillD> PoBillDs { get; set; }
        public virtual ICollection<PoD> PoDs { get; set; }
        public virtual ICollection<PoRcvD> PoRcvDs { get; set; }
        public virtual ICollection<PoT> PoTs { get; set; }
        public virtual ICollection<QpPalByLoc> QpPalByLocs { get; set; }
        public virtual ICollection<RealTimeInvUpdDetail> RealTimeInvUpdDetails { get; set; }
        public virtual ICollection<ShipAcct> ShipAccts { get; set; }
        public virtual ICollection<SoD> SoDShipFromOrigs { get; set; }
        public virtual ICollection<SoD> SoDShipFromWhs { get; set; }
        public virtual ICollection<ToT> ToTShipFrs { get; set; }
        public virtual ICollection<ToT> ToTShipTos { get; set; }
        public virtual ICollection<TplInvRptT> TplInvRptTs { get; set; }
        public virtual ICollection<TplinvoiceRate> TplinvoiceRates { get; set; }
        public virtual ICollection<TplinvoiceT> TplinvoiceTs { get; set; }
        public virtual ICollection<TplinvoiceType> TplinvoiceTypes { get; set; }
        public virtual ICollection<Vend2WhLt> Vend2WhLts { get; set; }
        public virtual ICollection<VendorReturnD> VendorReturnDs { get; set; }
        public virtual ICollection<WfsInvtHist> WfsInvtHists { get; set; }
        public virtual ICollection<WhTote> WhTotes { get; set; }
    }
}
