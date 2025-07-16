using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsApplied
    {
        public int NsAppliedId { get; set; }
        public int? NsPaymentId { get; set; }
        public int NsInvoiceId { get; set; }
        public decimal Amount { get; set; }
        public int? NsCreditMemoId { get; set; }

        public virtual NsCreditMemoT NsCreditMemo { get; set; }
        public virtual NsInvoiceT NsInvoice { get; set; }
        public virtual NsPayment NsPayment { get; set; }
    }
}
