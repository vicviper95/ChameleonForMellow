using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoBillD
    {
        public PoBillD()
        {
            VendorReturnDs = new HashSet<VendorReturnD>();
        }

        public int PoBillDId { get; set; }
        public int PoBillTId { get; set; }
        public int? PoDId { get; set; }
        public int? Qty { get; set; }
        public decimal? Amount { get; set; }
        public int? NsIntId { get; set; }
        public int? AccountId { get; set; }
        public string Memo { get; set; }
        public decimal? Rate { get; set; }
        public int? LocationId { get; set; }

        public virtual GlAccount Account { get; set; }
        public virtual BpmLocation Location { get; set; }
        public virtual PoBillT PoBillT { get; set; }
        public virtual PoD PoD { get; set; }
        public virtual ICollection<VendorReturnD> VendorReturnDs { get; set; }
    }
}
