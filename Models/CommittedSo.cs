using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CommittedSo
    {
        public int UnqId { get; set; }
        public int DateKey { get; set; }
        public int MarketPlaceId { get; set; }
        public int ItemnoId { get; set; }
        public int QtyOstd { get; set; }
        public int QtyOrdered { get; set; }

        public virtual DimDate DateKeyNavigation { get; set; }
        public virtual KoItemno Itemno { get; set; }
        public virtual KoMarketPlace MarketPlace { get; set; }
    }
}
