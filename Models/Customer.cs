using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Customer
    {
        public Customer()
        {
            AccInvOutCoGs = new HashSet<AccInvOutCoG>();
            AdAfcids = new HashSet<AdAfcid>();
            AmzMfgCodes = new HashSet<AmzMfgCode>();
            ApisoStatuses = new HashSet<ApisoStatus>();
            CmTs = new HashSet<CmT>();
            CsInvtFeedTs = new HashSet<CsInvtFeedT>();
            CustAddrs = new HashSet<CustAddr>();
            CustBillAddrs = new HashSet<CustBillAddr>();
            CustLocCodes = new HashSet<CustLocCode>();
            CustRetuAddrs = new HashSet<CustRetuAddr>();
            GlimpactTs = new HashSet<GlimpactT>();
            InvAdjTs = new HashSet<InvAdjT>();
            InvFeedsMrktSpecificSkus = new HashSet<InvFeedsMrktSpecificSku>();
            InvFeedsRepItemDetails = new HashSet<InvFeedsRepItemDetail>();
            InvFeedsRules = new HashSet<InvFeedsRule>();
            InvFeedsShopifies = new HashSet<InvFeedsShopify>();
            InvFeedsSkuconflictReports = new HashSet<InvFeedsSkuconflictReport>();
            InvTs = new HashSet<InvT>();
            ItFeedRatioDs = new HashSet<ItFeedRatioD>();
            ItFeedRatioTLowQDfCusts = new HashSet<ItFeedRatioT>();
            ItFeedRatioTManualCusts = new HashSet<ItFeedRatioT>();
            ItemRegPrices = new HashSet<ItemRegPrice>();
            KoSoTs = new HashSet<KoSoT>();
            MkInvFeedTs = new HashSet<MkInvFeedT>();
            NsCreditMemoTs = new HashSet<NsCreditMemoT>();
            NsIcrs = new HashSet<NsIcr>();
            NsInvoiceTs = new HashSet<NsInvoiceT>();
            NsPayments = new HashSet<NsPayment>();
            PromoEts = new HashSet<PromoEt>();
            RemitCmTs = new HashSet<RemitCmT>();
            RemitInvTs = new HashSet<RemitInvT>();
            ShipAccts = new HashSet<ShipAcct>();
            SoCancels = new HashSet<SoCancel>();
            SoErrors = new HashSet<SoError>();
            SoTs = new HashSet<SoT>();
        }

        public int CustomerId { get; set; }
        public int NsIntId { get; set; }
        public string Category { get; set; }
        public string OrderType { get; set; }
        public string MarketPlace { get; set; }
        public string CustName { get; set; }
        public string NameSage { get; set; }
        public string NameZinus { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }
        public string Terms { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public int? MarketId { get; set; }
        public string VendorCode { get; set; }
        public int? BudgetMkId { get; set; }
        public int? BudgetCuId { get; set; }
        public bool IsActive { get; set; }
        public bool? IsDropship { get; set; }
        public int? EdipartnerId { get; set; }
        public bool? IsWayfCg { get; set; }
        public int? ZinusCustId { get; set; }
        public string SalesType { get; set; }
        public bool IsInvtFeed { get; set; }
        public int? FcstChannelId { get; set; }
        public int? SpRecpChId { get; set; }

        public virtual BudgetCust BudgetCu { get; set; }
        public virtual BudgetMk BudgetMk { get; set; }
        public virtual Edipartner Edipartner { get; set; }
        public virtual FcstChannel FcstChannel { get; set; }
        public virtual Market Market { get; set; }
        public virtual SpRecapChn SpRecpCh { get; set; }
        public virtual ZinusCust ZinusCust { get; set; }
        public virtual ICollection<AccInvOutCoG> AccInvOutCoGs { get; set; }
        public virtual ICollection<AdAfcid> AdAfcids { get; set; }
        public virtual ICollection<AmzMfgCode> AmzMfgCodes { get; set; }
        public virtual ICollection<ApisoStatus> ApisoStatuses { get; set; }
        public virtual ICollection<CmT> CmTs { get; set; }
        public virtual ICollection<CsInvtFeedT> CsInvtFeedTs { get; set; }
        public virtual ICollection<CustAddr> CustAddrs { get; set; }
        public virtual ICollection<CustBillAddr> CustBillAddrs { get; set; }
        public virtual ICollection<CustLocCode> CustLocCodes { get; set; }
        public virtual ICollection<CustRetuAddr> CustRetuAddrs { get; set; }
        public virtual ICollection<GlimpactT> GlimpactTs { get; set; }
        public virtual ICollection<InvAdjT> InvAdjTs { get; set; }
        public virtual ICollection<InvFeedsMrktSpecificSku> InvFeedsMrktSpecificSkus { get; set; }
        public virtual ICollection<InvFeedsRepItemDetail> InvFeedsRepItemDetails { get; set; }
        public virtual ICollection<InvFeedsRule> InvFeedsRules { get; set; }
        public virtual ICollection<InvFeedsShopify> InvFeedsShopifies { get; set; }
        public virtual ICollection<InvFeedsSkuconflictReport> InvFeedsSkuconflictReports { get; set; }
        public virtual ICollection<InvT> InvTs { get; set; }
        public virtual ICollection<ItFeedRatioD> ItFeedRatioDs { get; set; }
        public virtual ICollection<ItFeedRatioT> ItFeedRatioTLowQDfCusts { get; set; }
        public virtual ICollection<ItFeedRatioT> ItFeedRatioTManualCusts { get; set; }
        public virtual ICollection<ItemRegPrice> ItemRegPrices { get; set; }
        public virtual ICollection<KoSoT> KoSoTs { get; set; }
        public virtual ICollection<MkInvFeedT> MkInvFeedTs { get; set; }
        public virtual ICollection<NsCreditMemoT> NsCreditMemoTs { get; set; }
        public virtual ICollection<NsIcr> NsIcrs { get; set; }
        public virtual ICollection<NsInvoiceT> NsInvoiceTs { get; set; }
        public virtual ICollection<NsPayment> NsPayments { get; set; }
        public virtual ICollection<PromoEt> PromoEts { get; set; }
        public virtual ICollection<RemitCmT> RemitCmTs { get; set; }
        public virtual ICollection<RemitInvT> RemitInvTs { get; set; }
        public virtual ICollection<ShipAcct> ShipAccts { get; set; }
        public virtual ICollection<SoCancel> SoCancels { get; set; }
        public virtual ICollection<SoError> SoErrors { get; set; }
        public virtual ICollection<SoT> SoTs { get; set; }
    }
}
