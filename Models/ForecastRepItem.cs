using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ForecastRepItem
    {
        public ForecastRepItem()
        {
            ForecastItemPos = new HashSet<ForecastItemPo>();
        }

        public long ForecastItemId { get; set; }
        public long ForecastReportId { get; set; }
        public long? ItemNoId { get; set; }
        public int? FcObChannelId { get; set; }
        public long? FcObQty { get; set; }
        public string FcItemRank { get; set; }
        public long? ForecastItemPoId { get; set; }
        public int? FcIbLocationId { get; set; }
        public long? FcIbQty { get; set; }
        public short? WeekOfYear { get; set; }
        public DateTime? StartDate { get; set; }

        public virtual FcIbLocation FcIbLocation { get; set; }
        public virtual FcObChannel FcObChannel { get; set; }
        public virtual ForecastReport ForecastReport { get; set; }
        public virtual ICollection<ForecastItemPo> ForecastItemPos { get; set; }
    }
}
