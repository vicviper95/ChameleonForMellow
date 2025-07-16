using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstAvgSqa
    {
        public int FcstAvgSaId { get; set; }
        public DateTime FcstDate { get; set; }
        public int FcstChannelId { get; set; }
        public int ItemNoId { get; set; }
        public int ItemStatusId { get; set; }
        public int? QtyAvg1yr { get; set; }
        public int? QtyAvg6mo { get; set; }
        public int? QtyAvg3mo { get; set; }
        public int? QtyAvg1mo { get; set; }
        public int? QtyLastWk { get; set; }
        public int? QtyMax { get; set; }
        public int? AmtAvg1yr { get; set; }
        public int? AmtAvg6mo { get; set; }
        public int? AmtAvg3mo { get; set; }
        public int? AmtAvg1mo { get; set; }
        public int? AmtLastWk { get; set; }
        public int? AmtMax { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual ItemStatus ItemStatus { get; set; }
    }
}
