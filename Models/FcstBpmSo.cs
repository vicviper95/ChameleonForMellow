using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstBpmSo
    {
        public int AvgSoId { get; set; }
        public DateTime FcstDate { get; set; }
        public int ItemNoId { get; set; }
        public int QtyAvgYear { get; set; }
        public int QtyAvg12wk { get; set; }
        public int QtyAvg4wk { get; set; }
        public int QtyLastWk { get; set; }
        public int QtyMin { get; set; }
        public int QtyMax { get; set; }
        public DateTime LastModDate { get; set; }

        public virtual BpmItem ItemNo { get; set; }
    }
}
