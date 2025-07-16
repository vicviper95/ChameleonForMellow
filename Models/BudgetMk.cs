using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BudgetMk
    {
        public BudgetMk()
        {
            BudgetDetails = new HashSet<BudgetDetail>();
            BudgetLocs = new HashSet<BudgetLoc>();
            CatBudgets = new HashSet<CatBudget>();
            Customers = new HashSet<Customer>();
        }

        public int BudgetMkId { get; set; }
        public string MarketName { get; set; }
        public bool IsCatBudget { get; set; }

        public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }
        public virtual ICollection<BudgetLoc> BudgetLocs { get; set; }
        public virtual ICollection<CatBudget> CatBudgets { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
