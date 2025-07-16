using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EmpChameleonConfig
    {
        public int EmpChameleonConfigId { get; set; }
        public int? PrivilegeLevelInventory { get; set; }
        public bool? HasInventoryNotification { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? ChLastLogOnDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
