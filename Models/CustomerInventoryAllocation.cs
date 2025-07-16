using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CustomerInventoryAllocation
    {
        public int CustInventoryId { get; set; }
        public DateTime RepotDate { get; set; }
        public int MarketPlaceId { get; set; }
        public int ItemListingId { get; set; }
        public int QtyAvailable { get; set; }
        public int? OrderQty { get; set; }
        public DateTime? OrderDueDate { get; set; }

        public virtual ItemListingItemno ItemListing { get; set; }
        public virtual KoMarketPlace MarketPlace { get; set; }
    }
}
