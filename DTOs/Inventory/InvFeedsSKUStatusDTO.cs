using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class InvFeedsSKUStatusDTO
  {
    public int ItemNoId { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    public int AmazonIcrId { get; set; }
    public bool AmazonFeedsEnable { get; set; }
    public string AmazonCustSKU { get; set; }
    public string AmazonUPC { get; set; }
    public string ASIN { get; set; }
    public string AmazonLastModifiedTime { get; set; }
    public string AmazonLastModifiedBy { get; set; }
    public int BPMIcrId { get; set; }
    public string BPMCustSKU { get; set; }
    public bool BPMFeedsEnable { get; set; }
    public string BPMLastModifiedTime { get; set; }
    public string BPMLastModifiedBy { get; set; }
    public int eBayIcrId { get; set; }
    public string eBayCustSKU { get; set; }
    public bool eBayFeedsEnable { get; set; }
    public string eBayLastModifiedTime { get; set; }
    public string eBayLastModifiedBy { get; set; }
    public int HouzzIcrId { get; set; }
    public string HouzzCustSKU { get; set; }
    public bool HouzzFeedsEnable { get; set; }
    public string HouzzLastModifiedTime { get; set; }
    public string HouzzLastModifiedBy { get; set; }
    public int MellowIcrId { get; set; }
    public string MellowCustSKU { get; set; }
    public bool MellowFeedsEnable { get; set; }
    public string MellowLastModifiedTime { get; set; }
    public string MellowLastModifiedBy { get; set; }
    public int OverstockIcrId { get; set; }
    public bool OverstockFeedsEnable { get; set; }
    public string OverstockCustSKU { get; set; }
    public string OverstockUPC { get; set; }
    public string OverstockLastModifiedTime { get; set; }
    public string OverstockLastModifiedBy { get; set; }
    public int WalmartIcrId { get; set; }
    public bool WalmartFeedsEnable { get; set; }
    public string WalmartCustSKU { get; set; }
    public string WalmartUPC { get; set; }
    public string WalmartLastModifiedTime { get; set; }
    public string WalmartLastModifiedBy { get; set; }
    public int WayfairIcrId { get; set; }
    public bool WayfairFeedsEnable { get; set; }
    public string WayfairCustSKU { get; set; }
    public string WayfairUPC { get; set; }
    public string WayfairLastModifiedTime { get; set; }
    public string WayfairLastModifiedBy { get; set; }
  }
}
