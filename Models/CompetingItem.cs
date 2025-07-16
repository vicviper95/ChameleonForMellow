using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CompetingItem
    {
        public int CompetingItemId { get; set; }
        public string MarketItemId { get; set; }
        public int MarketPlaceId { get; set; }
        public int SellerId { get; set; }
        public int ItemNoId { get; set; }
        public string ListingTitle { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual KoMarketPlace MarketPlace { get; set; }
        public virtual KoSeller Seller { get; set; }
    }
}
