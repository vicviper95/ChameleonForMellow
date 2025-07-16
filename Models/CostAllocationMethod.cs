using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CostAllocationMethod
    {
        public CostAllocationMethod()
        {
            BillActivities = new HashSet<BillActivity>();
        }

        public int AllocationMethodId { get; set; }
        public string Method { get; set; }

        public virtual ICollection<BillActivity> BillActivities { get; set; }
    }
}
