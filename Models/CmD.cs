using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CmD
    {
        public int CmDId { get; set; }
        public int? NsIntId { get; set; }
        public int? InvDId { get; set; }
        public int CmTId { get; set; }
        public int CmLineNo { get; set; }
        public int ItemNoId { get; set; }
        public int QtyCm { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public DateTime? SoDate { get; set; }
        public string MemoLine { get; set; }
        public DateTime? LastModTime { get; set; }
        public int? InvLineNo { get; set; }

        public virtual CmT CmT { get; set; }
        public virtual InvD InvD { get; set; }
        public virtual BpmItem ItemNo { get; set; }
    }
}
