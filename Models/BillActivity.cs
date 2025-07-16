using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BillActivity
    {
        public BillActivity()
        {
            VendorBillDs = new HashSet<VendorBillD>();
        }

        public int BillActivityId { get; set; }
        public int BillCategoryId { get; set; }
        public string Activity { get; set; }
        public int? ExpenseCategoryId { get; set; }
        public int AccountId { get; set; }
        public int? CostAllocationMethodId { get; set; }

        public virtual GlAccount Account { get; set; }
        public virtual BillCategory BillCategory { get; set; }
        public virtual CostAllocationMethod CostAllocationMethod { get; set; }
        public virtual NsExpenseCategory ExpenseCategory { get; set; }
        public virtual ICollection<VendorBillD> VendorBillDs { get; set; }
    }
}
