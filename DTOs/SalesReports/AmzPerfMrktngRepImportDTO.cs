namespace Chameleon.DTOs.SalesReports
{
    public class AmzPerfMrktngRepImportDTO
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string portfolioName { get; set; }
        public string currency { get; set; }
        public string campaignName { get; set; }
        public string adGroupName { get; set; }
        public string advertisedAsin { get; set; }
        public int impressions { get; set; }
        public int clicks { get; set; }
        public string clickThruRate { get; set; }
        public string costPerClick { get; set; }
        public string spend { get; set; }
        public string totalSalesIn14Day { get; set; }
        public string totalAdvertisingCostOfSales { get; set; }
        public string totalReturnOnAdvertisingSpend { get; set; }
        public int totalOrdersIn14Day { get; set; }
        public int totalUnitsIn14Day { get; set; }
        public string conversionRateIn14Day { get; set; }
    }
}
