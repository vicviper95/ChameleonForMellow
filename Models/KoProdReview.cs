using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoProdReview
    {
        public int ReviewId { get; set; }
        public string SellerUnqId { get; set; }
        public string ItemNo { get; set; }
        public int MarketPlaceId { get; set; }
        public string RevId { get; set; }
        public string RevTitle { get; set; }
        public string RevText { get; set; }
        public DateTime? RevDate { get; set; }
        public string RevName { get; set; }
        public int? RevRating { get; set; }
        public string RevOption1 { get; set; }
        public string RevOption2 { get; set; }
        public string RevOption3 { get; set; }
        public string RevImage { get; set; }
    }
}
