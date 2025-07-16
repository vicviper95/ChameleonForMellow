using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvRemit
    {
        public int InvRemitId { get; set; }
        public int InvoiceId { get; set; }
        public int RemitId { get; set; }
        public string RemitNoSub { get; set; }
        public decimal InvTotal { get; set; }
        public decimal InvDeduct { get; set; }
        public decimal InvPaid { get; set; }
        public int HasIssue { get; set; }
        public string Note { get; set; }

        public virtual NsRemit Remit { get; set; }
    }
}
