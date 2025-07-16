using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class HomeDepotFeedsListImportDTO
  {
    public string customerId { get; set; }
    public List<HomeDepotFeedsListItemImportDTO> skuList { get; set; }
  }
}
