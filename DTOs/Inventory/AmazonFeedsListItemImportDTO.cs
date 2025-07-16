using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class AmazonFeedsListItemImportDTO
  {
    public string SKU { get; set; }
    public string UPC { get; set; }
    public string ASIN { get; set; }
  }
}
