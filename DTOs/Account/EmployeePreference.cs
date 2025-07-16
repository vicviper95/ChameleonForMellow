using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Account
{
  public class EmployeePreference
  {
    public string LoginId { get; set; }
    public int EmpChameleonConfigId { get; set; }
    public int PrivilegeLevelInventory { get; set; }
    public bool HasInventoryNotification { get; set; }
  }
}
