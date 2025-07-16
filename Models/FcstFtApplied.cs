using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstFtApplied
    {
        public int FtAppliedId { get; set; }
        public DateTime FcstDate { get; set; }
        public DateTime WkBegDate { get; set; }
        public short? FcstMarketId { get; set; }
        public decimal SeasonFactor { get; set; }
        public decimal GrowthFactor { get; set; }
        public DateTime LastModDate { get; set; }
    }
}
