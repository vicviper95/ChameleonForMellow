using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class InvFeedsMarketSKUStatusDTO
  {
    public int ItemNoId { get; set; }
    public string ItemName { get; set; }
    public string ItemStatus { get; set; }
    public string Description { get; set; }
    public int icrId { get; set; }
    public bool IsResolved { get; set; }
    public bool FeedsEnable { get; set; }
    public string ConflictType { get; set; }
    public string yourSKU { get; set; }
    public string CustSKU { get; set; }
    public string CustUPC { get; set; }
    public string ASIN { get; set; }
    public string LastModifiedTime { get; set; }
    public string LastModifiedBy { get; set; }
    public bool WayfairCGStockRule { get; set;}
  }
}
