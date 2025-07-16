using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EmployeeAuthorization
    {
        public int EmployeeId { get; set; }
        public int? InventoryFeedsWarehouses { get; set; }
        public int? InventoryFeedsMainFeeds { get; set; }
        public int? InventoryFeedsSets { get; set; }
        public int? InventoryFeedsRemarkGrouping { get; set; }
        public int? InventoryFeedsAmazon { get; set; }
        public int? InventoryFeedsOverstock { get; set; }
        public int? InventoryFeedsWalmart { get; set; }
        public int? InventoryFeedsWayfair { get; set; }
        public int? InventoryFeedsHomeDepot { get; set; }
        public int? InventoryFeedsTarget { get; set; }
        public int? InventoryFeedseBay { get; set; }
        public int? InventoryFeedsBpm { get; set; }
        public int? InventoryFeedsMellowHome { get; set; }
        public int? InventoryFeedsAdmin { get; set; }
    }
}
