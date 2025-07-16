using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmazonAdRepDetailHistory
    {
        public int AdDetailHistoryId { get; set; }
        public int AdDetailId { get; set; }
        public int? Impressions { get; set; }
        public int? Clicks { get; set; }
        public decimal? ClickThruRateCtr { get; set; }
        public decimal? CostPerClickCpc { get; set; }
        public decimal? Spend { get; set; }
        public decimal? FourteenDayTotalSales { get; set; }
        public decimal? TotalAdvertisingCostOfSalesAcos { get; set; }
        public decimal? TotalReturnOnAdvertisingSpendRoas { get; set; }
        public int? FourteenDayTotalOrders { get; set; }
        public int? FourteenDayTotalUnits { get; set; }
        public decimal? FourteenDayConversionRate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public decimal? SevenDayOtherSkuSalse { get; set; }
        public int? SevenDayOtherSkuUnit { get; set; }

        public virtual AmazonAdRepDetail AdDetail { get; set; }
    }
}
