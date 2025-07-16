using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WfsInvtLog
    {
        public WfsInvtLog()
        {
            WfsInvtHists = new HashSet<WfsInvtHist>();
        }

        public int InvtLogId { get; set; }
        public int ItemNoId { get; set; }
        public int MkIcrId { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual MkIcr MkIcr { get; set; }
        public virtual ICollection<WfsInvtHist> WfsInvtHists { get; set; }
    }
}
