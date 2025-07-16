using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class WalmartFeedsListImportDTO
  {
    public string customerId { get; set; }
    public List<WalmartFeedsListItemImportDTO> skuList { get; set; }
  }
}
