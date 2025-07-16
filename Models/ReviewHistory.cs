using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ReviewHistory
    {
        public int ReviewHistoryId { get; set; }
        public DateTime Date { get; set; }
        public int MarketPlaceId { get; set; }
        public string SellerUnqId { get; set; }
        public double? Rating { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime? LastModDateTime { get; set; }
        public DateTime? AddedDateTime { get; set; }
    }
}
