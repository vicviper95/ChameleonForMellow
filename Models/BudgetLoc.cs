using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BudgetLoc
    {
        public BudgetLoc()
        {
            BpmLocations = new HashSet<BpmLocation>();
            CatBudgets = new HashSet<CatBudget>();
        }

        public int BudgetLocId { get; set; }
        public string Name { get; set; }
        public int InvtUseOrder { get; set; }
        public bool IsActive { get; set; }
        public int? BudgetMkId { get; set; }

        public virtual BudgetMk BudgetMk { get; set; }
        public virtual ICollection<BpmLocation> BpmLocations { get; set; }
        public virtual ICollection<CatBudget> CatBudgets { get; set; }
    }
}
