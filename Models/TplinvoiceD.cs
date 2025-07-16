using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TplinvoiceD
    {
        public int TplinvoiceDId { get; set; }
        public int TplinvoiceTId { get; set; }
        public int TplinvoiceTypeId { get; set; }
        public DateTime? SoDate { get; set; }
        public string PoNo { get; set; }
        public int? ItemNoId { get; set; }
        public int? OrderQty { get; set; }
        public decimal? OrderAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int InvoiceQty { get; set; }
        public decimal InvoiceAmount { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual TplinvoiceT TplinvoiceT { get; set; }
        public virtual TplinvoiceType TplinvoiceType { get; set; }
    }
}
