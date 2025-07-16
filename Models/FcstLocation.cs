using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstLocation
    {
        public FcstLocation()
        {
            BpmLocations = new HashSet<BpmLocation>();
            FcstAvgSos = new HashSet<FcstAvgSo>();
            FcstWkInvts = new HashSet<FcstWkInvt>();
            FcstWkPos = new HashSet<FcstWkPo>();
            FcstWkSos = new HashSet<FcstWkSo>();
        }

        public short FcstLocId { get; set; }
        public string LocName { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual ICollection<BpmLocation> BpmLocations { get; set; }
        public virtual ICollection<FcstAvgSo> FcstAvgSos { get; set; }
        public virtual ICollection<FcstWkInvt> FcstWkInvts { get; set; }
        public virtual ICollection<FcstWkPo> FcstWkPos { get; set; }
        public virtual ICollection<FcstWkSo> FcstWkSos { get; set; }
    }
}
