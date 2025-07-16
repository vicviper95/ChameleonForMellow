using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmsCycleCountPlan
    {
        public int CycleCountPlanId { get; set; }
        public int WhouseId { get; set; }
        public int ItemNoId { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }

        public virtual KoItemno ItemNo { get; set; }
        public virtual KoLocation Whouse { get; set; }
    }
}
