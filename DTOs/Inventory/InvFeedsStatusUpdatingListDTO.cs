using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class InvFeedsStatusUpdatingListDTO
  {
    public string customerId;
    public List<InvFeedsMarketSKUStatusDTO> skuList { get; set; }
  }
}
