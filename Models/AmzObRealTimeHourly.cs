using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzObRealTimeHourly
    {
        public int RealTimeId { get; set; }
        public int IcrId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Asin { get; set; }
        public long? OrdUnit { get; set; }
        public decimal? OrdRevenue { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual MkIcr Icr { get; set; }
    }
}
