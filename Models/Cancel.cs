using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Cancel
    {
        public Cancel()
        {
            CancelDetails = new HashSet<CancelDetail>();
        }

        public int CancelId { get; set; }
        public int OrderId { get; set; }
        public DateTime TimeRequested { get; set; }
        public int? SalesRepId { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<CancelDetail> CancelDetails { get; set; }
    }
}
