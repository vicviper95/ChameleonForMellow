using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FedexInvoiceDetail
    {
        public int FedexInvoiceDetailId { get; set; }
        public int FedexInvoiceId { get; set; }
        public string ChargeDesc { get; set; }
        public decimal ChargeAmt { get; set; }

        public virtual FedexInvoice FedexInvoice { get; set; }
    }
}
