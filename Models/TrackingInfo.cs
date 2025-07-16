using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TrackingInfo
    {
        public int TrackingInfoId { get; set; }
        public int OrderLineId { get; set; }
        public string TrackingNumber { get; set; }
        public int ItemNoId { get; set; }

        public virtual KoItemno ItemNo { get; set; }
        public virtual OrderDetail OrderLine { get; set; }
    }
}
