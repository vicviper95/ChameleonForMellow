using System.Collections.Generic;

namespace Chameleon.DTOs.Purchase
{
  public class PrePOLogisticsImportResponseDTO
  {
    public bool errorOnImport { get; set; }
    public List<string> errorMessages { get; set; }
  }
}
