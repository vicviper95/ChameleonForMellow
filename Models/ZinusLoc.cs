using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ZinusLoc
    {
        public ZinusLoc()
        {
            BpmLocations = new HashSet<BpmLocation>();
        }

        public int ZinusLocId { get; set; }
        public string ZinusName { get; set; }

        public virtual ICollection<BpmLocation> BpmLocations { get; set; }
    }
}
