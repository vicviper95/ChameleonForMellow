using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MsInvAtBin
    {
        public MsInvAtBin()
        {
            MsInvAdjEntries = new HashSet<MsInvAdjEntry>();
        }

        public int InvAtBinId { get; set; }
        public int BinNoId { get; set; }
        public int ItemNoId { get; set; }
        public int QtyOnHand { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }
        public string Note { get; set; }

        public virtual MslBinNo BinNo { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual ICollection<MsInvAdjEntry> MsInvAdjEntries { get; set; }
    }
}
