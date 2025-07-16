using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvtDailyTrxT
    {
        public InvtDailyTrxT()
        {
            InvtDailyTrxDs = new HashSet<InvtDailyTrxD>();
        }

        public int InvtDailyTrxTId { get; set; }
        public int LocationTypeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual LocationType LocationType { get; set; }
        public virtual ICollection<InvtDailyTrxD> InvtDailyTrxDs { get; set; }
    }
}
