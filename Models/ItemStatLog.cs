using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemStatLog
    {
        public int ItemStatLogId { get; set; }
        public int ItemNoId { get; set; }
        public int ItemStatusId { get; set; }
        public int? AddedById { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Employee AddedBy { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual ItemStatus ItemStatus { get; set; }
    }
}
