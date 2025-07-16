using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsPayment
    {
        public NsPayment()
        {
            NsApplieds = new HashSet<NsApplied>();
            NsCrediteds = new HashSet<NsCredited>();
        }

        public int NsPaymentId { get; set; }
        public int NsIntId { get; set; }
        public string DocNo { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Memo { get; set; }
        public string Remittance { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }
        public int? RemitId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual SalesRemit Remit { get; set; }
        public virtual ICollection<NsApplied> NsApplieds { get; set; }
        public virtual ICollection<NsCredited> NsCrediteds { get; set; }
    }
}
