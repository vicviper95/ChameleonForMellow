using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RemitPayment
    {
        public int RemitPaymentId { get; set; }
        public int? NsIntId { get; set; }
        public int RemitId { get; set; }
        public int CustomerId { get; set; }
        public string PaymentNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual SalesRemit Remit { get; set; }
    }
}
