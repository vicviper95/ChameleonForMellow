using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MsBinScan
    {
        public int BinScanId { get; set; }
        public int BinNoId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime TimeScanned { get; set; }
        public int CountCycleNo { get; set; }
        public int InvtCntTId { get; set; }

        public virtual MslBinNo BinNo { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual InvtCntT InvtCntT { get; set; }
    }
}
