using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FreightInvoiceLine
    {
        public int FreightInvoiceLineId { get; set; }
        public int FreightInvoiceDId { get; set; }
        public int FreightCategoryId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Rate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }

        public virtual GlAccount Account { get; set; }
        public virtual FreightCategory FreightCategory { get; set; }
        public virtual FreightInvoiceD FreightInvoiceD { get; set; }
    }
}
