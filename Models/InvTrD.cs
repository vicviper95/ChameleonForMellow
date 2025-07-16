using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvTrD
    {
        public int InvTrDId { get; set; }
        public int InvTrTId { get; set; }
        public int LineId { get; set; }
        public int ItemNoId { get; set; }
        public int FrLocId { get; set; }
        public int ToLocId { get; set; }
        public int Qty { get; set; }
        public int NsIntId { get; set; }

        public virtual BpmLocation FrLoc { get; set; }
        public virtual InvTrT InvTrT { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation ToLoc { get; set; }
    }
}
