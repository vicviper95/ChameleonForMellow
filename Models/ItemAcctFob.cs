using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemAcctFob
    {
        public int ItemAcctFobId { get; set; }
        public int ItemNoId { get; set; }
        public decimal FobCost { get; set; }
        public DateTime DateOn { get; set; }
        public bool IsAmzDi { get; set; }
        public bool IsZinus { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }
        public int? EmployeeId { get; set; }

        public virtual BpmItem ItemNo { get; set; }
    }
}
