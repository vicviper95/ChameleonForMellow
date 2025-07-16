using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class OverstockFeedsListImportDTO
  {
    public string customerId;
    
    public List<OverstockFeedsListItemImportDTO> skuList { get; set; }
  }
}
