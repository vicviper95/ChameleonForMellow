using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class BpmMellowFeedsListImportDTO
  {
    public string customerId { get; set; }
    public List<BpmMellowFeedsListItemImportDTO> skuList { get; set; }

  }
}
