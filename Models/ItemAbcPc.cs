using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemAbcPc
    {
        public int ItemAbcPcId { get; set; }
        public DateTime FcstDate { get; set; }
        public int FcstChannelId { get; set; }
        public int ItemNoId { get; set; }
        public int ItemStatusId { get; set; }
        public string Abc { get; set; }
        public string Xyz { get; set; }
        public decimal? StdDev { get; set; }
        public decimal? TurnOverRatio { get; set; }
        public int? QtyAvg1yr { get; set; }
        public int? QtyAvg6mo { get; set; }
        public int? QtyAvg3mo { get; set; }
        public int? QtyAvg1mo { get; set; }
        public int? QtyLastWk { get; set; }
        public int? MinQty { get; set; }
        public int? MaxQty { get; set; }
        public decimal AvgQty { get; set; }
        public int TotalQty { get; set; }
        public decimal TotalAmount { get; set; }
        public int SalesWeeksYr { get; set; }
        public DateTime? FirstInvDate { get; set; }
        public DateTime? LastInvDate { get; set; }
        public int? QtyAvailable { get; set; }
        public decimal? WkOfSupply { get; set; }

        public virtual FcstChannel FcstChannel { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual ItemStatus ItemStatus { get; set; }
    }
}
