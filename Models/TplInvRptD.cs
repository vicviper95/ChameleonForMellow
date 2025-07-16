using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TplInvRptD
    {
        public int TplInvRptDId { get; set; }
        public int TplInvRptTId { get; set; }
        public int ItemNoId { get; set; }
        public int? QtyOnHand { get; set; }
        public int? QtyAvail { get; set; }
        public int? QtyUnAvail { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual TplInvRptT TplInvRptT { get; set; }
    }
}
