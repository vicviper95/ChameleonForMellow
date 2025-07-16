using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzObTracffic
    {
        public int TrafficId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Asin { get; set; }
        public string ProductTitle { get; set; }
        public int? GlanceView { get; set; }
        public string ItemName { get; set; }
        public int ItemNoId { get; set; }

        public virtual BpmItem ItemNo { get; set; }
    }
}
