using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsInvoice
    {
        public NsInvoice()
        {
            NsInvDetails = new HashSet<NsInvDetail>();
            NsInvRemits = new HashSet<NsInvRemit>();
        }

        public int InvoiceId { get; set; }
        public int OrderId { get; set; }
        public string InvNo { get; set; }
        public DateTime InvDate { get; set; }
        public decimal InvTotal { get; set; }
        public decimal InvGross { get; set; }
        public decimal InvNet { get; set; }
        public decimal InvBalance { get; set; }
        public int IsClosed { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? AddedTime { get; set; }
        public int? AddedByWho { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? ModifiedByWho { get; set; }
        public int? NsIntId { get; set; }

        public virtual NsOrder Order { get; set; }
        public virtual ICollection<NsInvDetail> NsInvDetails { get; set; }
        public virtual ICollection<NsInvRemit> NsInvRemits { get; set; }
    }
}
