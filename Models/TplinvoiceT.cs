using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TplinvoiceT
    {
        public TplinvoiceT()
        {
            TplinvoiceDs = new HashSet<TplinvoiceD>();
        }

        public int TplinvoiceTId { get; set; }
        public int LocationId { get; set; }
        public string InvoiceNo { get; set; }

        public virtual BpmLocation Location { get; set; }
        public virtual ICollection<TplinvoiceD> TplinvoiceDs { get; set; }
    }
}
