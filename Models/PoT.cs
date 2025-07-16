using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoT
    {
        public PoT()
        {
            BillCreditTs = new HashSet<BillCreditT>();
            DrayageFeeDs = new HashSet<DrayageFeeD>();
            EdiTs = new HashSet<EdiT>();
            FreightInvoiceRefs = new HashSet<FreightInvoiceRef>();
            InvtDailyTrxDs = new HashSet<InvtDailyTrxD>();
            PoBillTs = new HashSet<PoBillT>();
            PoChangeds = new HashSet<PoChanged>();
            PoChanges = new HashSet<PoChange>();
            PoDs = new HashSet<PoD>();
            PoOwnershipTs = new HashSet<PoOwnershipT>();
            PoPackTs = new HashSet<PoPackT>();
            PoRcvTs = new HashSet<PoRcvT>();
            ToTs = new HashSet<ToT>();
            VendorReturnTs = new HashSet<VendorReturnT>();
        }

        public int PoTId { get; set; }
        public int? NsIntId { get; set; }
        public string PoNo { get; set; }
        public string CustRef { get; set; }
        public DateTime PoDate { get; set; }
        public int VendorId { get; set; }
        public int? PortOriginId { get; set; }
        public int? PortDestId { get; set; }
        public int? ActualLocId { get; set; }
        public DateTime? PoEpcd { get; set; }
        public DateTime? PoEtd { get; set; }
        public DateTime? PoEtdConf { get; set; }
        public DateTime? PoEta { get; set; }
        public DateTime? DateEstUnload { get; set; }
        public DateTime? DateRcvd { get; set; }
        public decimal? PoCostTotal { get; set; }
        public int? PoStatusId { get; set; }
        public string Memo { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? LastModTime { get; set; }
        public string Source { get; set; }
        public DateTime? NsSyncTime { get; set; }
        public int? SoTId { get; set; }
        public int? IncotermId { get; set; }
        public int? CountryId { get; set; }
        public string TicketNo { get; set; }
        public DateTime? DateFixedEstUnload { get; set; }
        public int? PoTypeId { get; set; }

        public virtual BpmLocation ActualLoc { get; set; }
        public virtual Country Country { get; set; }
        public virtual Incoterm Incoterm { get; set; }
        public virtual PoStatus PoStatus { get; set; }
        public virtual PoType PoType { get; set; }
        public virtual PortDest PortDest { get; set; }
        public virtual PortOrigin PortOrigin { get; set; }
        public virtual SoT SoT { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<BillCreditT> BillCreditTs { get; set; }
        public virtual ICollection<DrayageFeeD> DrayageFeeDs { get; set; }
        public virtual ICollection<EdiT> EdiTs { get; set; }
        public virtual ICollection<FreightInvoiceRef> FreightInvoiceRefs { get; set; }
        public virtual ICollection<InvtDailyTrxD> InvtDailyTrxDs { get; set; }
        public virtual ICollection<PoBillT> PoBillTs { get; set; }
        public virtual ICollection<PoChanged> PoChangeds { get; set; }
        public virtual ICollection<PoChange> PoChanges { get; set; }
        public virtual ICollection<PoD> PoDs { get; set; }
        public virtual ICollection<PoOwnershipT> PoOwnershipTs { get; set; }
        public virtual ICollection<PoPackT> PoPackTs { get; set; }
        public virtual ICollection<PoRcvT> PoRcvTs { get; set; }
        public virtual ICollection<ToT> ToTs { get; set; }
        public virtual ICollection<VendorReturnT> VendorReturnTs { get; set; }
    }
}
