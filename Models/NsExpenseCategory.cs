using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsExpenseCategory
    {
        public NsExpenseCategory()
        {
            BillActivities = new HashSet<BillActivity>();
            VendorBillDs = new HashSet<VendorBillD>();
        }

        public int Id { get; set; }
        public int NsIntId { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }
        public bool IsInactive { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual GlAccount Account { get; set; }
        public virtual ICollection<BillActivity> BillActivities { get; set; }
        public virtual ICollection<VendorBillD> VendorBillDs { get; set; }
    }
}
