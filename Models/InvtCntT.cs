using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvtCntT
    {
        public InvtCntT()
        {
            BinCntLists = new HashSet<BinCntList>();
            BinInvtCurs = new HashSet<BinInvtCur>();
            BinItemScans = new HashSet<BinItemScan>();
            MsBinScans = new HashSet<MsBinScan>();
        }

        public int InvtCntTId { get; set; }
        public string CountName { get; set; }
        public int CountTypeId { get; set; }
        public int LocationId { get; set; }
        public DateTime DateFr { get; set; }
        public DateTime DateTo { get; set; }
        public int CountCycleNo { get; set; }
        public bool IsCountDone { get; set; }

        public virtual CountType CountType { get; set; }
        public virtual BpmLocation Location { get; set; }
        public virtual ICollection<BinCntList> BinCntLists { get; set; }
        public virtual ICollection<BinInvtCur> BinInvtCurs { get; set; }
        public virtual ICollection<BinItemScan> BinItemScans { get; set; }
        public virtual ICollection<MsBinScan> MsBinScans { get; set; }
    }
}
