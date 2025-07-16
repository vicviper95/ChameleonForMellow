using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvRealTime
    {
        public int InvRealTimeId { get; set; }
        public DateTime TimeRecord { get; set; }
        public int LocationId { get; set; }
        public int ItemNoId { get; set; }
        public int QtyOnHand { get; set; }
        public int QtyAvail { get; set; }
        public int QtyBackOrd { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
    }
}
