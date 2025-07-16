using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RealTimeInvUpdate
    {
        public RealTimeInvUpdate()
        {
            RealTimeInvUpdDetails = new HashSet<RealTimeInvUpdDetail>();
        }

        public long RealTimeInvUpdateId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual ICollection<RealTimeInvUpdDetail> RealTimeInvUpdDetails { get; set; }
    }
}
