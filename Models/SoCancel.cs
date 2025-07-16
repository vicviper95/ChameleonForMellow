using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SoCancel
    {
        public int SoCancelId { get; set; }
        public int? SoTId { get; set; }
        public int CustId { get; set; }
        public string MrklocId { get; set; }
        public string PoNo { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsShipped { get; set; }
        public DateTime? ReqTime { get; set; }
        public DateTime? CancelledTime { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
