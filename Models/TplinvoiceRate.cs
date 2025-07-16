using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TplinvoiceRate
    {
        public int TplinvoiceRateId { get; set; }
        public int LocationId { get; set; }
        public int? TplinvoiceTypeId { get; set; }
        public int? ItemNoId { get; set; }
        public decimal Rate { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
        public virtual TplinvoiceType TplinvoiceType { get; set; }
    }
}
