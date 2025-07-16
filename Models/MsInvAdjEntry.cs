using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MsInvAdjEntry
    {
        public int IcAdjId { get; set; }
        public int InvAtBinId { get; set; }
        public int QtyAdjust { get; set; }
        public int EmployeeId { get; set; }
        public DateTime TimeAdjusted { get; set; }
        public int InvTxTypeId { get; set; }
        public int QtyBegin { get; set; }
        public int QtyEnd { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual MsInvAtBin InvAtBin { get; set; }
        public virtual InvTxType InvTxType { get; set; }
    }
}
