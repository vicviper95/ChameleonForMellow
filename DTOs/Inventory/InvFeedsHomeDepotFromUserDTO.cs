using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class InvFeedsHomeDepotFromUserDTO
  {
    public string historyDate { get; set; }
    public string CustomerId { get; set; }
    public List<InvFeedsHomeDepotFromUserItemDTO> feedsList { get; set; }
  }
}
