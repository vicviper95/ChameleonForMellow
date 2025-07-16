using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemStdPrice
    {
        public int StdPriceId { get; set; }
        public int MarketPlaceId { get; set; }
        public int PriceYear { get; set; }
        public int ItemListingId { get; set; }
        public decimal RegPrice { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }

        public virtual ItemListingItemno ItemListing { get; set; }
        public virtual KoMarketPlace MarketPlace { get; set; }
    }
}
