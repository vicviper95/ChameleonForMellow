using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BinInvtAdj
    {
        public int BinInvtAdjId { get; set; }
        public int BinInvtCurId { get; set; }
        public int QtyBegin { get; set; }
        public int QtyAdjust { get; set; }
        public int QtyEnd { get; set; }
        public int EmployeeId { get; set; }
        public DateTime TimeAdjusted { get; set; }

        public virtual BinInvtCur BinInvtCur { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
