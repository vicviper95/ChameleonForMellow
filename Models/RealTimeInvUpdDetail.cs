using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RealTimeInvUpdDetail
    {
        public long RealTimeInvUpdDetailId { get; set; }
        public int LocationId { get; set; }
        public int ItemNoId { get; set; }
        public int? QtyAvail { get; set; }
        public int? QtyOnHand { get; set; }
        public int? QtyOnBackOrder { get; set; }
        public long? RealTimeInvUpdateId { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
        public virtual RealTimeInvUpdate RealTimeInvUpdate { get; set; }
    }
}
