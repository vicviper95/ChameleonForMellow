using Chameleon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
    public class InvFeedsGeneralSettingDTO
    {
        public int ZeroOutBufferMainSL { get; set; }
        public int ZeroOutBufferBANC { get; set; }
        public string LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public int SalesHistoryLowDataSwitchQty { get; set; }
        public int AmazonRatioOnLowData { get; set; }
        public int eBayRatioOnLowData { get; set; }
        public int OverstockRatioOnLowData { get; set; }
        public int WalmartRatioOnLowData { get; set; }
        public int WayfairRatioOnLowData { get; set; }
        public int BpmRatioOnLowData { get; set; }
        public int MellowRatioOnLowData { get; set; }
        public int HouzzRatioOnLowData { get; set; }
        public int SetBOMRatio { get; set; }
        public int TotalOfRatioOnLowData { get; set; }
        public int AmazonLowStockQty { get; set; }
        public bool IsAmazonLowStockOn { get; set; }
        public int AbcRatioA { get; set; }
        public int AbcRatioB { get; set; }
        public int AbcRatioC { get; set; }
        public int AbcRatioAnoB { get; set; }
        public int AbcRatioAnoC { get; set; }
        public int AbcRatioBnoC { get; set; }
        public int AbcOthersOverstock { get; set; }
        public int AbcOtherseBay { get; set; }
        public int AbcOthersBPMWeb { get; set; }
        public int AbcOthersMellowWeb { get; set; }
        public int AbcOthersHouzz { get; set; }
        public int AbcOthersTarget { get; set; }
        public int AbcOthersHomeDepot { get; set; }
        public int WmtminQtyAllowance { get; set; }
        public int WalmartTopSellers { get; set; }
        public int WalmartTopSellersDistributionRatio { get; set; }
        public bool IsActivatedWmttopSellers { get; set; }
        public bool IsActivatedWFSvsWHs { get; set; }
        public int WFSvsWHsBufferQty { get; set; }
    //public List<InvFeedsRule> marketRuleList { get; set; }
    }
}
