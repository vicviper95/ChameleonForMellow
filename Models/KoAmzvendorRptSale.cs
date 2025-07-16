using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoAmzvendorRptSale
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int? AsinId { get; set; }
        public decimal? OrdRevenue { get; set; }
        public decimal? OrdRevenueTotal { get; set; }
        public decimal? OrdRevenuePrior { get; set; }
        public decimal? OrdRevenueLastYear { get; set; }
        public int? UnitOrdered { get; set; }
        public decimal? UnitOrdTotal { get; set; }
        public decimal? UnitOrdPrior { get; set; }
        public decimal? UnitOrdLastYear { get; set; }
        public int? SalesRank { get; set; }
        public decimal? AvgSalesPrice { get; set; }
        public decimal? AvgSalesPricePrior { get; set; }
        public decimal? GlanceViewPrior { get; set; }
        public decimal? GlanceViewLastYear { get; set; }
        public decimal? RepOos { get; set; }
        public decimal? RepOosTotal { get; set; }
        public decimal? RepOosPrior { get; set; }
        public decimal? LbbPrice { get; set; }
        public string ItemNo { get; set; }
        public int SalesId { get; set; }
        public string Asin { get; set; }
        public decimal Upc { get; set; }
        public string Subcategory { get; set; }
        public string Category { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Title { get; set; }
        public decimal? ConversionRate { get; set; }
        public decimal? GlanceViews { get; set; }
        public string LocName { get; set; }
        public int? CustomerReturns { get; set; }
        public decimal? ShippedCogs { get; set; }

        public virtual NsCustPn AsinNavigation { get; set; }
    }
}
