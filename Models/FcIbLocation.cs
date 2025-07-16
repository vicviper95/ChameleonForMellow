using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcIbLocation
    {
        public FcIbLocation()
        {
            ForecastRepItems = new HashSet<ForecastRepItem>();
        }

        public int FcIbLocationId { get; set; }
        public string Location { get; set; }

        public virtual ICollection<ForecastRepItem> ForecastRepItems { get; set; }
    }
}
