using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CrdPay
    {
        public int CrdPayId { get; set; }
        public int? CrdTId { get; set; }
        public int PaymentId { get; set; }
        public string Memo { get; set; }
    }
}
