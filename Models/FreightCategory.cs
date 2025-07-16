using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FreightCategory
    {
        public FreightCategory()
        {
            FreightInvoiceLines = new HashSet<FreightInvoiceLine>();
        }

        public int FreightCategoryId { get; set; }
        public string Category { get; set; }
        public string FreightType { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual ICollection<FreightInvoiceLine> FreightInvoiceLines { get; set; }
    }
}
