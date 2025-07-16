using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FreightInvoiceD
    {
        public FreightInvoiceD()
        {
            FreightInvoiceLines = new HashSet<FreightInvoiceLine>();
            FreightInvoiceRefs = new HashSet<FreightInvoiceRef>();
        }

        public int FreightInvoiceDId { get; set; }
        public int FreightInvoiceTId { get; set; }
        public string Bolno { get; set; }
        public string ContainerNo { get; set; }

        public virtual FreightInvoiceT FreightInvoiceT { get; set; }
        public virtual ICollection<FreightInvoiceLine> FreightInvoiceLines { get; set; }
        public virtual ICollection<FreightInvoiceRef> FreightInvoiceRefs { get; set; }
    }
}
