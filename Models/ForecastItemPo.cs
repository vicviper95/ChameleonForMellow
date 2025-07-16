using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ForecastItemPo
    {
        public long ForecastItemPoId { get; set; }
        public long? ItemNoId { get; set; }
        public long? FcPoqty { get; set; }
        public long? ForcastItemId { get; set; }

        public virtual ForecastRepItem ForcastItem { get; set; }
    }
}
