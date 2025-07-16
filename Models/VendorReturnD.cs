using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VendorReturnD
    {
        public int VendorReturnDId { get; set; }
        public int VendorReturnTId { get; set; }
        public int NsIntId { get; set; }
        public int LineId { get; set; }
        public int ItemNoId { get; set; }
        public int LocationId { get; set; }
        public int Qty { get; set; }
        public decimal? Rate { get; set; }
        public decimal Amount { get; set; }
        public int? PoDId { get; set; }
        public int? PoBillDId { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
        public virtual PoBillD PoBillD { get; set; }
        public virtual PoD PoD { get; set; }
        public virtual VendorReturnT VendorReturnT { get; set; }
    }
}
