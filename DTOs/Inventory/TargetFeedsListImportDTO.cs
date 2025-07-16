using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class TargetFeedsListImportDTO
  {
    public string customerId { get; set; }
    public List<TargetFeedsListItemImportDTO> skuList { get; set; }
  }
}
