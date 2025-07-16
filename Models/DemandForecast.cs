using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class DemandForecast
    {
        public int DemandFrcId { get; set; }
        public int ItemnoId { get; set; }
        public int LocationId { get; set; }
        public int Qty { get; set; }
        public DateTime DateFuture { get; set; }
        public DateTime AddedDateTime { get; set; }

        public virtual KoItemno Itemno { get; set; }
        public virtual KoLocation Location { get; set; }
    }
}
