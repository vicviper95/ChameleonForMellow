using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InventoryConfig
    {
        public long InventoryConfigId { get; set; }
        public int? ZeroOutBufferMainSl { get; set; }
        public int? ZeroOutBufferBanc { get; set; }
        public int? SetBomratio { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedBy { get; set; }
        public int? SalesHistoryLowDataSwitchQty { get; set; }
        public int? LowInventoryQty { get; set; }
        public bool? IsAmazonLowStockOn { get; set; }
        public int? AmazonLowStockQty { get; set; }
        public int? ZeroOutBufferSwcaft { get; set; }
        public int? AbcRatioA { get; set; }
        public int? AbcRatioAnoB { get; set; }
        public int? AbcRatioAnoC { get; set; }
        public int? AbcRatioB { get; set; }
        public int? AbcRatioBnoC { get; set; }
        public int? AbcRatioC { get; set; }
        public int? AbcOthersOverstock { get; set; }
        public int? AbcOtherseBay { get; set; }
        public int? AbcOthersBpmweb { get; set; }
        public int? AbcOthersMellowWeb { get; set; }
        public int? AbcOthersHouzz { get; set; }
        public int? AbcOthersTarget { get; set; }
        public int? AbcOthersHomeDepot { get; set; }
        public int? WmtminQtyAllowance { get; set; }
        public int? WalmartTopSellers { get; set; }
        public int? WalmartTopSellersDistributionRatio { get; set; }
        public bool? IsActivatedWmttopSellers { get; set; }
        public bool? IsActivatedSets { get; set; }
        public bool? IsActivatedNewStatusRule { get; set; }
        public bool? IsActivatedDiscoRule { get; set; }
        public int? ZeroOutBufferBasc { get; set; }
        public int? CooMasterSlaveCrossover { get; set; }
        public int? SlaveMkIcrRatio { get; set; }
        public int? WhSwitchingOnWest { get; set; }
        public int? WhSwitchingOnEast { get; set; }
        public int? CheckWayfairCgstockRule { get; set; }
        public int? WayfairCgstockMinQty { get; set; }
        public bool? IsActivatedWfsvsWhs { get; set; }
        public int? WfsvsWhsBufferQty { get; set; }
    }
}
