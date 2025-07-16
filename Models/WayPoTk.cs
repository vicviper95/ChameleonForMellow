using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WayPoTk
    {
        public WayPoTk()
        {
            WayPoTkTs = new HashSet<WayPoTkT>();
        }

        public int StatusId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<WayPoTkT> WayPoTkTs { get; set; }
    }
}
