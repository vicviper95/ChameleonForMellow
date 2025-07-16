using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BinItemScan
    {
        public int BinItemScanId { get; set; }
        public int BinInvtCurId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime TimeScanned { get; set; }
        public int InvtCntTId { get; set; }
        public int CountCycleNo { get; set; }

        public virtual BinInvtCur BinInvtCur { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual InvtCntT InvtCntT { get; set; }
    }
}
