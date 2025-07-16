using System.Collections.Generic;

namespace Chameleon.DTOs.Inventory
{
  public class InventoryFeedsImportResponseDTO
  {
    public bool isOkay { get; set; }
    public List<string> errorMessages { get; set; }
  }
}
