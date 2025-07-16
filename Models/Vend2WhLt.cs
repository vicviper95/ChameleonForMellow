using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Vend2WhLt
    {
        public int V2wltId { get; set; }
        public int VendorId { get; set; }
        public int LocationId { get; set; }
        public int LeadTime { get; set; }
        public DateTime? AddedDate { get; set; }

        public virtual BpmLocation Location { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
