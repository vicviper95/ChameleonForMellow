using System.Collections.Generic;

namespace Chameleon.DTOs.Inventory
{
  public class InvFeedsImportResponse
  {
    public bool isOkay { get; set; }
    public List<string> errorMessages { get; set; }
  }
}
