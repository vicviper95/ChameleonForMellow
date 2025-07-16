using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BudgetSum
    {
        public int BudgetId { get; set; }
        public DateTime FirstDoM { get; set; }
        public int BudgetCuId { get; set; }
        public decimal SalesBudget { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public int LastModBy { get; set; }
        public DateTime LastModDate { get; set; }

        public virtual BudgetCust BudgetCu { get; set; }
    }
}
