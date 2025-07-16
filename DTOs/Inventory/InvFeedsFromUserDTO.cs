using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class InvFeedsFromUserDTO
  {
    public string historyDate { get; set; }
    public string CustomerId { get; set; }
    public string BpmLocId { get; set; }
    public List<InvFeedsFromUserItemDTO> feedsList { get; set; }
  }
}
