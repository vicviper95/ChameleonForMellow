using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SoD
    {
        public SoD()
        {
            AdSsccs = new HashSet<AdSscc>();
            FedexInvoices = new HashSet<FedexInvoice>();
            InvDs = new HashSet<InvD>();
            InverseParentSoD = new HashSet<SoD>();
            ItemFfds = new HashSet<ItemFfd>();
            KoCoDs = new HashSet<KoCoD>();
            PoDs = new HashSet<PoD>();
            RemitCmDs = new HashSet<RemitCmD>();
            RemitInvDs = new HashSet<RemitInvD>();
            SoCoos = new HashSet<SoCoo>();
            SodBols = new HashSet<SodBol>();
            SodPts = new HashSet<SodPt>();
            SpcInvDs = new HashSet<SpcInvD>();
            TakeBacks = new HashSet<TakeBack>();
            Upsinvoices = new HashSet<Upsinvoice>();
        }

        public int SoDId { get; set; }
        public int? NsIntId { get; set; }
        public int SoTId { get; set; }
        public int SodLineNo { get; set; }
        public DateTime SoDate { get; set; }
        public DateTime? ShipWindowStart { get; set; }
        public DateTime? ShipWindowEnd { get; set; }
        public DateTime? BackOrderDate { get; set; }
        public DateTime? ExpShipDate { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? ActShipDate { get; set; }
        public int ShipFromWhId { get; set; }
        public int? ShipToAfcId { get; set; }
        public int? ShipViaId { get; set; }
        public string ShipScac { get; set; }
        public string AmzBolNo { get; set; }
        public byte? AutoBol { get; set; }
        public string CustSku { get; set; }
        public int ItemNoId { get; set; }
        public int? PriceLevelId { get; set; }
        public int QtyOrdered { get; set; }
        public int? QtyRejected { get; set; }
        public int? QtyCancelled { get; set; }
        public int? QtyBackOrdered { get; set; }
        public int? QtyCommitted { get; set; }
        public int? QtyPicked { get; set; }
        public int? QtyShipped { get; set; }
        public int? QtyInvoiced { get; set; }
        public int? ApplyDbst { get; set; }
        public decimal UnitPrice { get; set; }
        public string DiscCode { get; set; }
        public decimal? DiscAmt { get; set; }
        public decimal? VatAmt { get; set; }
        public decimal? FeeAmt { get; set; }
        public decimal? ShipCost { get; set; }
        public decimal? LineTotal { get; set; }
        public int? IsRejectAcpt { get; set; }
        public byte? CommitInv { get; set; }
        public int? AcptStatusId { get; set; }
        public int? SoStatusNsId { get; set; }
        public int? SoStatusKoId { get; set; }
        public string MemoLine { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? LastModKoT { get; set; }
        public int? LastModKoE { get; set; }
        public bool? IsLabelPrinted { get; set; }
        public decimal? RegPrice { get; set; }
        public int? NsLineId { get; set; }
        public int? QtyShipped3Pl { get; set; }
        public int? ShipFromOrigId { get; set; }
        public int? QtyCancelReq { get; set; }
        public bool? IsMissing3Pl { get; set; }
        public string CustItemId { get; set; }
        public int? ItemNoOrigId { get; set; }
        public string WmtRouteNo { get; set; }
        public int? ParentSoDId { get; set; }

        public virtual StatusItemAcpt AcptStatus { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmItem ItemNoOrig { get; set; }
        public virtual SoD ParentSoD { get; set; }
        public virtual ItemPriceLevel PriceLevel { get; set; }
        public virtual BpmLocation ShipFromOrig { get; set; }
        public virtual BpmLocation ShipFromWh { get; set; }
        public virtual AdAfcid ShipToAfc { get; set; }
        public virtual ShipVium ShipVia { get; set; }
        public virtual SoStatusKo SoStatusKo { get; set; }
        public virtual SoStatusN SoStatusNs { get; set; }
        public virtual SoT SoT { get; set; }
        public virtual ICollection<AdSscc> AdSsccs { get; set; }
        public virtual ICollection<FedexInvoice> FedexInvoices { get; set; }
        public virtual ICollection<InvD> InvDs { get; set; }
        public virtual ICollection<SoD> InverseParentSoD { get; set; }
        public virtual ICollection<ItemFfd> ItemFfds { get; set; }
        public virtual ICollection<KoCoD> KoCoDs { get; set; }
        public virtual ICollection<PoD> PoDs { get; set; }
        public virtual ICollection<RemitCmD> RemitCmDs { get; set; }
        public virtual ICollection<RemitInvD> RemitInvDs { get; set; }
        public virtual ICollection<SoCoo> SoCoos { get; set; }
        public virtual ICollection<SodBol> SodBols { get; set; }
        public virtual ICollection<SodPt> SodPts { get; set; }
        public virtual ICollection<SpcInvD> SpcInvDs { get; set; }
        public virtual ICollection<TakeBack> TakeBacks { get; set; }
        public virtual ICollection<Upsinvoice> Upsinvoices { get; set; }
    }
}
