using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstAvgSo
    {
        public int AvgSoId { get; set; }
        public DateTime FcstDate { get; set; }
        public short? FcstMarketId { get; set; }
        public short? FcstLocId { get; set; }
        public int ItemNoId { get; set; }
        public decimal QtyAvg12wk { get; set; }
        public decimal QtyAvg4wk { get; set; }
        public decimal QtyLastWk { get; set; }
        public int QtyMin { get; set; }
        public int QtyMax { get; set; }
        public DateTime LastModDate { get; set; }

        public virtual FcstLocation FcstLoc { get; set; }
        public virtual FcstMarket FcstMarket { get; set; }
        public virtual BpmItem ItemNo { get; set; }
    }
}
