using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CancelDetail
    {
        public int CancelLineId { get; set; }
        public int OrderLineId { get; set; }
        public int QtyRequested { get; set; }
        public int? QtyAccepted { get; set; }
        public int CancelId { get; set; }
        public DateTime? TimeProcessed { get; set; }
        public DateTime? TimeReported { get; set; }

        public virtual Cancel Cancel { get; set; }
        public virtual OrderDetail OrderLine { get; set; }
    }
}
