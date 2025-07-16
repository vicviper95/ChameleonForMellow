using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Walmart
{
    public class WmtReport
    {
        public string vendorId { get; set; }
        public string sku { get; set; }
        public string productName { get; set; }
        public string productCategory { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public string cost { get; set; }
        public string price { get; set; }
        public string currency { get; set; }
        public string buyBoxShippingPrice { get; set; }
        public string publishStatus { get; set; }
        public string lifecycleStatus { get; set; }
        public string availabilityStatus { get; set; }
        public string shipMethods { get; set; }
        public string wpid { get; set; }
        public string itemId { get; set; }
        public string wm { get; set; }
        public string gtin { get; set; }
        public string upc { get; set; }
        public string primaryImageUrl { get; set; }
        public string shelfName { get; set; }
        public string primaryCatPath { get; set; }
        public string offerStartDate { get; set; }
        public string offerEndDate { get; set; }
        public string itemCreationDate { get; set; }
        public string lastUpdationDate { get; set; }
        public string itemPageUrl { get; set; }
        public string reviewCount { get; set; }
        public string averageRating { get; set; }
        public string productTaxCode { get; set; }
        public string shippingWeight { get; set; }
        public string shippingWeightUnit { get; set; }
        public string statusChangeReason { get; set; }
        public string availableInventoryUnits { get; set; }


    }
}
