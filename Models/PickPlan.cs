using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PickPlan
    {
        public PickPlan()
        {
            PickTasks = new HashSet<PickTask>();
        }

        public int PickPlanId { get; set; }
        public int NsIntId { get; set; }
        public string PtName { get; set; }
        public int Priority { get; set; }

        public virtual ICollection<PickTask> PickTasks { get; set; }
    }
}
