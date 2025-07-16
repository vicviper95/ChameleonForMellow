using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VendorBillD
    {
        public VendorBillD()
        {
            LandedCosts = new HashSet<LandedCost>();
        }

        public int VendorBillDId { get; set; }
        public int VendorBillTId { get; set; }
        public int LineId { get; set; }
        public int ActivityId { get; set; }
        public int? ExpenseCategoryId { get; set; }
        public int AccountId { get; set; }
        public decimal AmountInvoice { get; set; }
        public decimal AmountAllocation { get; set; }
        public string Description { get; set; }
        public string Memo { get; set; }
        public string Bolno { get; set; }
        public string ContainerNo { get; set; }

        public virtual GlAccount Account { get; set; }
        public virtual BillActivity Activity { get; set; }
        public virtual NsExpenseCategory ExpenseCategory { get; set; }
        public virtual VendorBillT VendorBillT { get; set; }
        public virtual ICollection<LandedCost> LandedCosts { get; set; }
    }
}
