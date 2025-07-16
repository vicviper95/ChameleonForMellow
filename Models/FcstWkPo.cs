using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstWkPo
    {
        public int WkPoId { get; set; }
        public DateTime FcstDate { get; set; }
        public DateTime WkBegDate { get; set; }
        public short? FcstLocId { get; set; }
        public int ItemNoId { get; set; }
        public int? QtyOrder { get; set; }
        public int? QtyCancel { get; set; }
        public int? QtyRcvd { get; set; }
        public int? QtyOpen { get; set; }
        public int? QtyFcstM1 { get; set; }
        public DateTime LastModDate { get; set; }

        public virtual FcstLocation FcstLoc { get; set; }
        public virtual BpmItem ItemNo { get; set; }
    }
}
