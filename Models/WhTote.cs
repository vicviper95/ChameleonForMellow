using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WhTote
    {
        public int WhToteId { get; set; }
        public int LocationId { get; set; }
        public string ToteNo { get; set; }
        public DateTime TimeAdded { get; set; }

        public virtual BpmLocation Location { get; set; }
    }
}
