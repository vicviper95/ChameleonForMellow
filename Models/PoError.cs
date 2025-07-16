using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoError
    {
        public int ErrorId { get; set; }
        public int ErrorCatId { get; set; }
        public int ProcessId { get; set; }
        public string PoNo { get; set; }
        public int CustomerId { get; set; }
        public string CustSku { get; set; }
        public string Detail { get; set; }
        public bool IsResolved { get; set; }
        public DateTime CeatedTime { get; set; }
        public DateTime? ResolvedTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ErrorCategory ErrorCat { get; set; }
        public virtual ApisPoprocess Process { get; set; }
    }
}
