using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvToD
    {
        public int ToDId { get; set; }
        public int ToTId { get; set; }
        public int LineNo { get; set; }
        public string CustSku { get; set; }
        public int ItemNoId { get; set; }
        public int QtyOrder { get; set; }
        public int QtyShipped { get; set; }
        public int QtyInTransit { get; set; }
        public int QtyReceived { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime LastModTime { get; set; }
        public DateTime? NsSyncTime { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual InvToT ToT { get; set; }
    }
}
