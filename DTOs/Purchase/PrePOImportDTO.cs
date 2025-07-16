using System;

namespace Chameleon.DTOs.Purchase
{
  public class PrePOImportDTO
  {
    public string poChannel { get; set; }
    public int requestedQty { get; set; }
    public string sku { get; set; }
    public string requestorsNote { get; set; }
    public string mustETADate { get; set; }
    public string approvalLevel { get; set; }
  }
}
