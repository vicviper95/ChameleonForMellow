using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvPay
    {
        public int InvPayId { get; set; }
        public int? InvTId { get; set; }
        public int? PaymentId { get; set; }
        public int CustomerId { get; set; }
        public string Memo { get; set; }
        public decimal Amount { get; set; }
        public string InvNo { get; set; }
        public DateTime Date { get; set; }
        public string RemitNo { get; set; }
    }
}
