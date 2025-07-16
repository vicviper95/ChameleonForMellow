using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoBillT
    {
        public PoBillT()
        {
            DrayageFeet = new HashSet<DrayageFoot>();
            FreightInvoiceTs = new HashSet<FreightInvoiceT>();
            PoBillDs = new HashSet<PoBillD>();
            VendorReturnTs = new HashSet<VendorReturnT>();
        }

        public int PoBillTId { get; set; }
        public int? PoTId { get; set; }
        public string ExternalId { get; set; }
        public int? NsIntId { get; set; }
        public string RefNo { get; set; }
        public string TransNo { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal Amount { get; set; }
        public int StatusId { get; set; }
        public string Memo { get; set; }
        public string Source { get; set; }
        public DateTime AddedDateTime { get; set; }
        public DateTime LastModDateTime { get; set; }
        public int VendorId { get; set; }
        public bool IsInbill { get; set; }
        public int? BolFeeTId { get; set; }
        public int? BolEntryId { get; set; }

        public virtual BolEntry BolEntry { get; set; }
        public virtual BolFoot BolFeeT { get; set; }
        public virtual PoT PoT { get; set; }
        public virtual PoBillStatus Status { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<DrayageFoot> DrayageFeet { get; set; }
        public virtual ICollection<FreightInvoiceT> FreightInvoiceTs { get; set; }
        public virtual ICollection<PoBillD> PoBillDs { get; set; }
        public virtual ICollection<VendorReturnT> VendorReturnTs { get; set; }
    }
}
