using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemSoldByComponent
    {
        public int UnqId { get; set; }
        public int DateKey { get; set; }
        public int MarketPlaceId { get; set; }
        public int ItemnoId { get; set; }
        public int QtySold { get; set; }

        public virtual DimDate DateKeyNavigation { get; set; }
        public virtual KoItemno Itemno { get; set; }
        public virtual KoMarketPlace MarketPlace { get; set; }
    }
}
