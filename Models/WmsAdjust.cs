using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmsAdjust
    {
        public WmsAdjust()
        {
            WmsAdjustDetails = new HashSet<WmsAdjustDetail>();
        }

        public int AdjustId { get; set; }
        public DateTime DateTime { get; set; }
        public int? AdjusterId { get; set; }
        public int? ApproverId { get; set; }
        public string AdjustNo { get; set; }

        public virtual Employee Adjuster { get; set; }
        public virtual Employee Approver { get; set; }
        public virtual ICollection<WmsAdjustDetail> WmsAdjustDetails { get; set; }
    }
}
