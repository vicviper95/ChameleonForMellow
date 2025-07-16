using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MkPayment
    {
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public string PayNo { get; set; }
        public DateTime PayDate { get; set; }
        public decimal PayTotal { get; set; }
        public string Memo { get; set; }
        public DateTime? AddedTime { get; set; }
        public int? AddedEmp { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? ModifiedByWho { get; set; }
        public int? NsIntId { get; set; }
        public string RemitNo { get; set; }
    }
}
