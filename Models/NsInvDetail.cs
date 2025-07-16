using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsInvDetail
    {
        public int InvLineId { get; set; }
        public int InvoiceId { get; set; }
        public int ItemNoId { get; set; }
        public int QtyShipped { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscAmt { get; set; }
        public decimal? VatAmt { get; set; }
        public decimal? FeeAmt { get; set; }
        public int? NsOdLineId { get; set; }

        public virtual NsInvoice Invoice { get; set; }
        public virtual KoItemno ItemNo { get; set; }
    }
}
