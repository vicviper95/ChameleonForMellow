using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class HouzzFeedsListImportDTO
  {
    public string customerId { get; set; }
    public List<HouzzFeedsListItemImportDTO> skuList { get; set; }
  }
}
