using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class WayfairFeedsListImportDTO
  {
    public string customerId { get; set; }
    public List<WayfairFeedsListItemImportDTO> skuList { get; set; }
  }
}
