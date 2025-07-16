using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BinCntList
    {
        public int BinCntListId { get; set; }
        public int InvtCntTId { get; set; }
        public int BinNoId { get; set; }

        public virtual MslBinNo BinNo { get; set; }
        public virtual InvtCntT InvtCntT { get; set; }
    }
}
