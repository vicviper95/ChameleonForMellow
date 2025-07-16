using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BillCreditT
    {
        public BillCreditT()
        {
            BillCreditDs = new HashSet<BillCreditD>();
            DrayageFeet = new HashSet<DrayageFoot>();
            FreightInvoiceTs = new HashSet<FreightInvoiceT>();
        }

        public int BillCreditTId { get; set; }
        public int? NsIntId { get; set; }
        public string TsNo { get; set; }
        public string DocNo { get; set; }
        public DateTime Date { get; set; }
        public int? PoTId { get; set; }
        public string Memo { get; set; }
        public DateTime AddedTime { get; set; }
        public int VendorId { get; set; }
        public int? BolFeeTId { get; set; }
        public int? BolEntryId { get; set; }

        public virtual BolEntry BolEntry { get; set; }
        public virtual BolFoot BolFeeT { get; set; }
        public virtual PoT PoT { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<BillCreditD> BillCreditDs { get; set; }
        public virtual ICollection<DrayageFoot> DrayageFeet { get; set; }
        public virtual ICollection<FreightInvoiceT> FreightInvoiceTs { get; set; }
    }
}
