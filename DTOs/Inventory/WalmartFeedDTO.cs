using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class WalmartFeedDTO
  {
    public string SKU { get; set; }
    public string AvailabilityCode { get; set; }
    public int Qty { get; set; }
    public string FulfillmentLagTime { get; set; }
  }
}
