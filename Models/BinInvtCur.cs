using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BinInvtCur
    {
        public BinInvtCur()
        {
            BinInvtAdjs = new HashSet<BinInvtAdj>();
            BinItemScans = new HashSet<BinItemScan>();
        }

        public int BinInvtCurId { get; set; }
        public int InvtCntTId { get; set; }
        public int BinNoId { get; set; }
        public int ItemNoId { get; set; }
        public int QtyCurrent { get; set; }
        public DateTime TimeAdded { get; set; }
        public int CountCycleNo { get; set; }
        public string Note { get; set; }

        public virtual MslBinNo BinNo { get; set; }
        public virtual InvtCntT InvtCntT { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual ICollection<BinInvtAdj> BinInvtAdjs { get; set; }
        public virtual ICollection<BinItemScan> BinItemScans { get; set; }
    }
}
