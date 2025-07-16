using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class LocationType
    {
        public LocationType()
        {
            BpmLocations = new HashSet<BpmLocation>();
            InventoryAgingTs = new HashSet<InventoryAgingT>();
            InvtDailyTrxTs = new HashSet<InvtDailyTrxT>();
        }

        public int LocationTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<BpmLocation> BpmLocations { get; set; }
        public virtual ICollection<InventoryAgingT> InventoryAgingTs { get; set; }
        public virtual ICollection<InvtDailyTrxT> InvtDailyTrxTs { get; set; }
    }
}
