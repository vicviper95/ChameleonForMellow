using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemFobVc
    {
        public int ItemFobVcId { get; set; }
        public DateTime BegDateMo { get; set; }
        public int ItemNoId { get; set; }
        public int VendorId { get; set; }
        public string Country { get; set; }
        public decimal FobAvg4 { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
