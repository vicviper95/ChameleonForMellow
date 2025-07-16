using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsInvoiceD
    {
        public int NsInvoiceDId { get; set; }
        public int NsInvoiceTId { get; set; }
        public int NsIntId { get; set; }
        public int LineId { get; set; }
        public int ItemNoId { get; set; }
        public int Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public string Memo { get; set; }
        public int GlaccountId { get; set; }

        public virtual GlAccount Glaccount { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual NsInvoiceT NsInvoiceT { get; set; }
    }
}
