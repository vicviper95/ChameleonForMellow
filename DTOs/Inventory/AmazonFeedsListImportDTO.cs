using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class AmazonFeedsListImportDTO
  {
    public string customerId { get; set; }
    
    public List<AmazonFeedsListItemImportDTO> skuList { get; set; }
  }
}
