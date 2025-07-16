using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoCmD
    {
        public int PoCmDId { get; set; }
        public int PoCmTId { get; set; }
        public int PoCmLineNo { get; set; }
        public int ItemNoId { get; set; }
        public int QtyCm { get; set; }
        public decimal UnitCost { get; set; }
        public decimal LineTotal { get; set; }
        public DateTime? PoDate { get; set; }
        public string MemoLine { get; set; }
        public DateTime? LastModTime { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual PoCmT PoCmT { get; set; }
    }
}
