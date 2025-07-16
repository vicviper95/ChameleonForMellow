using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TplinvoiceType
    {
        public TplinvoiceType()
        {
            TplinvoiceDs = new HashSet<TplinvoiceD>();
            TplinvoiceRates = new HashSet<TplinvoiceRate>();
        }

        public int TplinvoiceTypeId { get; set; }
        public string TypeName { get; set; }
        public int LocationId { get; set; }

        public virtual BpmLocation Location { get; set; }
        public virtual ICollection<TplinvoiceD> TplinvoiceDs { get; set; }
        public virtual ICollection<TplinvoiceRate> TplinvoiceRates { get; set; }
    }
}
