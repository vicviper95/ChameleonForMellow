using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcObChannel
    {
        public FcObChannel()
        {
            ForecastRepItems = new HashSet<ForecastRepItem>();
        }

        public int FcObChannelId { get; set; }
        public string Channel { get; set; }

        public virtual ICollection<ForecastRepItem> ForecastRepItems { get; set; }
    }
}
