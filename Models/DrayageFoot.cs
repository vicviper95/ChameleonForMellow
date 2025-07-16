using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class DrayageFoot
    {
        public DrayageFoot()
        {
            DrayageFeeDs = new HashSet<DrayageFeeD>();
        }

        public int DrayageFeeTId { get; set; }
        public int? VendorId { get; set; }
        public string InvNo { get; set; }
        public DateTime InvDate { get; set; }
        public decimal Amount { get; set; }
        public int? PoBillTId { get; set; }
        public int? BillCreditTId { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual BillCreditT BillCreditT { get; set; }
        public virtual PoBillT PoBillT { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<DrayageFeeD> DrayageFeeDs { get; set; }
    }
}
