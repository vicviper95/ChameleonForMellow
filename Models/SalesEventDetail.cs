using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SalesEventDetail
    {
        public int SalesEventDetailId { get; set; }
        public int SalesEventId { get; set; }
        public int ItemListingId { get; set; }
        public decimal? RegularPrice { get; set; }
        public decimal? RequestedPrice { get; set; }
        public decimal? ApprovedPrice { get; set; }
        public DateTime? LastModDateTime { get; set; }
        public DateTime? AddedDateTime { get; set; }

        public virtual ItemListingItemno ItemListing { get; set; }
        public virtual SalesEvent SalesEvent { get; set; }
    }
}
