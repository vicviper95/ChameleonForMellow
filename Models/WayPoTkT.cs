using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WayPoTkT
    {
        public WayPoTkT()
        {
            WayPoTkDs = new HashSet<WayPoTkD>();
        }

        public int TicketId { get; set; }
        public string TicketNo { get; set; }
        public DateTime AddedDate { get; set; }
        public int AddedBy { get; set; }
        public int StatusId { get; set; }

        public virtual WayPoTk Status { get; set; }
        public virtual ICollection<WayPoTkD> WayPoTkDs { get; set; }
    }
}
