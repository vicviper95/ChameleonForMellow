using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class eBayFeedsListImportDTO
  {
    public string customerId { get; set; }
    public List<eBayFeedsListItemImportDTO> skuList { get; set; }
  }
}
