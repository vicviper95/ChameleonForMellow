using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstWkInvt
    {
        public int BegInvId { get; set; }
        public DateTime FcstDate { get; set; }
        public DateTime WkBegDate { get; set; }
        public short FcstLocId { get; set; }
        public int ItemNoId { get; set; }
        public int QtyBeg { get; set; }
        public int? QtyAdj { get; set; }
        public int? QtyEndM1 { get; set; }
        public int? QtyEndM2 { get; set; }
        public int? QtyEndM3 { get; set; }
        public DateTime LastModDate { get; set; }

        public virtual FcstLocation FcstLoc { get; set; }
        public virtual BpmItem ItemNo { get; set; }
    }
}
