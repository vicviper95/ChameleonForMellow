using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WayPoTkD
    {
        public WayPoTkD()
        {
            WayPoTkNs = new HashSet<WayPoTkN>();
        }

        public int TickedDId { get; set; }
        public int TicketId { get; set; }
        public int PoDId { get; set; }
        public int LastModE { get; set; }
        public DateTime LastModT { get; set; }

        public virtual PoD PoD { get; set; }
        public virtual WayPoTkT Ticket { get; set; }
        public virtual ICollection<WayPoTkN> WayPoTkNs { get; set; }
    }
}
