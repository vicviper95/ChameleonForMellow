using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BudgetCust
    {
        public BudgetCust()
        {
            BudgetSums = new HashSet<BudgetSum>();
            Customers = new HashSet<Customer>();
        }

        public int BudgetCuId { get; set; }
        public string CustName { get; set; }

        public virtual ICollection<BudgetSum> BudgetSums { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
