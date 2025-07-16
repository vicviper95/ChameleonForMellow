using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FreightInvoiceRef
    {
        public int FreightInvoiceRefId { get; set; }
        public int FreightInvoiceDId { get; set; }
        public int? PoTId { get; set; }
        public int? ToTId { get; set; }

        public virtual FreightInvoiceD FreightInvoiceD { get; set; }
        public virtual PoT PoT { get; set; }
        public virtual ToT ToT { get; set; }
    }
}
