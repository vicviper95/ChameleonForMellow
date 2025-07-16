using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvStatus
    {
        public InvStatus()
        {
            InvTs = new HashSet<InvT>();
            NsInvoiceTs = new HashSet<NsInvoiceT>();
        }

        public int InvStatusId { get; set; }
        public string Status { get; set; }
        public int? NsIntId { get; set; }

        public virtual ICollection<InvT> InvTs { get; set; }
        public virtual ICollection<NsInvoiceT> NsInvoiceTs { get; set; }
    }
}
