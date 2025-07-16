using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdInvValuation
    {
        public int AdInvValuationId { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
        public int ItemNoId { get; set; }
        public int Qty { get; set; }
        public double Amount { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
    }
}
