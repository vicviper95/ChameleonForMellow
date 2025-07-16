using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Promotion
    {
        public int PromotionId { get; set; }
        public string EventName { get; set; }
        public int? StatusId { get; set; }
        public int? ItemNoId { get; set; }
        public int? Icrid { get; set; }
        public int? MarketId { get; set; }
        public decimal? FundingPerUnit { get; set; }
        public int? PromotionTypeId { get; set; }
        public decimal? CurrentWsc { get; set; }
        public decimal? PromoWsc { get; set; }
        public decimal? CurrentAsp { get; set; }
        public decimal? SuggestedPromoAsp { get; set; }
        public decimal? ActualPromoAsp { get; set; }
        public decimal? WasPrice { get; set; }
        public int? InventoryFeedingRatio { get; set; }
        public int? DiscountPercentage { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsHistory { get; set; }
        public int? MasterPromotionId { get; set; }
    }
}
