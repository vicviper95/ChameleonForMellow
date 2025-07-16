using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MslBinNo
    {
        public MslBinNo()
        {
            BinCntLists = new HashSet<BinCntList>();
            BinInvtCurs = new HashSet<BinInvtCur>();
            MsBinScans = new HashSet<MsBinScan>();
            MsInvAtBins = new HashSet<MsInvAtBin>();
            PhysCountMsls = new HashSet<PhysCountMsl>();
            PickTasks = new HashSet<PickTask>();
            SodPts = new HashSet<SodPt>();
        }

        public int BinNoId { get; set; }
        public string ZoneId { get; set; }
        public int? RowId { get; set; }
        public int? ColId { get; set; }
        public string PosId { get; set; }
        public string LevelId { get; set; }
        public string Note { get; set; }
        public int IsUsable { get; set; }
        public string BinNo { get; set; }
        public string BinNoHr { get; set; }
        public int? NsIntId { get; set; }
        public int LocationId { get; set; }

        public virtual BpmLocation Location { get; set; }
        public virtual ICollection<BinCntList> BinCntLists { get; set; }
        public virtual ICollection<BinInvtCur> BinInvtCurs { get; set; }
        public virtual ICollection<MsBinScan> MsBinScans { get; set; }
        public virtual ICollection<MsInvAtBin> MsInvAtBins { get; set; }
        public virtual ICollection<PhysCountMsl> PhysCountMsls { get; set; }
        public virtual ICollection<PickTask> PickTasks { get; set; }
        public virtual ICollection<SodPt> SodPts { get; set; }
    }
}
