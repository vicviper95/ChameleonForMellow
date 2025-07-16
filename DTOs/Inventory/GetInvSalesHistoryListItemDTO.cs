using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class GetInvSalesHistoryListItemDTO
  {
    public int ItemNoId { get; set; }
    public string ItemName { get; set; }
    public string AmazonCustSKU { get; set; }
    public int AmazonDropShip { get; set; }
    public int WayfairDropShip { get; set; }
    public string WayfairCustSKU { get; set; }
    public int Walmart { get; set; }
    public string WalmartCustSKU { get; set; }
    public int OverstockDropShip { get; set; }
    public string OverstockCustSKU { get; set; }
    public int eBay { get; set; }
    public string eBayCustSKU { get; set; }
    public int etcMarket {get; set; }
    public int MellowWeb { get; set; }
    public int BPMWeb { get; set; }
    public int Houzz { get; set; }
    public int totalSalesQty { get; set; }
  }
}
