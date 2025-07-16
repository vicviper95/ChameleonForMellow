using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmsMetric
    {
        public int InvtMetricId { get; set; }
        public DateTime Date { get; set; }
        public int ItemNoId { get; set; }
        public double TurnRatioRatio { get; set; }
        public double SellThroughRatio { get; set; }
    }
}
