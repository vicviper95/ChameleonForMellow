using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SoT
    {
        public SoT()
        {
            CmTs = new HashSet<CmT>();
            EdiTs = new HashSet<EdiT>();
            FedexInvoices = new HashSet<FedexInvoice>();
            InvTs = new HashSet<InvT>();
            InvtDailyTrxDs = new HashSet<InvtDailyTrxD>();
            ItemFfts = new HashSet<ItemFft>();
            KoCoTs = new HashSet<KoCoT>();
            NsInvoiceTs = new HashSet<NsInvoiceT>();
            PoTs = new HashSet<PoT>();
            RemitCmDs = new HashSet<RemitCmD>();
            RemitCms = new HashSet<RemitCm>();
            RemitInvDs = new HashSet<RemitInvD>();
            RemitInvs = new HashSet<RemitInv>();
            SoDs = new HashSet<SoD>();
            SpcInvDs = new HashSet<SpcInvD>();
        }

        public int SoTId { get; set; }
        public int? NsIntId { get; set; }
        public int CustomerId { get; set; }
        public string PoNo { get; set; }
        public string IoNo { get; set; }
        public string SoNo { get; set; }
        public DateTime SoDate { get; set; }
        public DateTime? ShipWindowStart { get; set; }
        public DateTime? ShipWindowEnd { get; set; }
        public DateTime? ExpShipDate { get; set; }
        public string ShipToName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Memo { get; set; }
        public decimal? SoTotal { get; set; }
        public int? BulkBuy { get; set; }
        public string PoType { get; set; }
        public string VendorCode { get; set; }
        public string ShipCode { get; set; }
        public string ShipSpeed { get; set; }
        public string Source { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? NsSyncTime { get; set; }
        public int? ShipToAfcId { get; set; }
        public DateTime? CustOrderTime { get; set; }
        public bool? Born2Run { get; set; }
        public string ShipScac { get; set; }
        public string ShipToAfcGln { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ApisoStatus ApisoStatus { get; set; }
        public virtual SoCancel SoCancel { get; set; }
        public virtual ICollection<CmT> CmTs { get; set; }
        public virtual ICollection<EdiT> EdiTs { get; set; }
        public virtual ICollection<FedexInvoice> FedexInvoices { get; set; }
        public virtual ICollection<InvT> InvTs { get; set; }
        public virtual ICollection<InvtDailyTrxD> InvtDailyTrxDs { get; set; }
        public virtual ICollection<ItemFft> ItemFfts { get; set; }
        public virtual ICollection<KoCoT> KoCoTs { get; set; }
        public virtual ICollection<NsInvoiceT> NsInvoiceTs { get; set; }
        public virtual ICollection<PoT> PoTs { get; set; }
        public virtual ICollection<RemitCmD> RemitCmDs { get; set; }
        public virtual ICollection<RemitCm> RemitCms { get; set; }
        public virtual ICollection<RemitInvD> RemitInvDs { get; set; }
        public virtual ICollection<RemitInv> RemitInvs { get; set; }
        public virtual ICollection<SoD> SoDs { get; set; }
        public virtual ICollection<SpcInvD> SpcInvDs { get; set; }
    }
}
