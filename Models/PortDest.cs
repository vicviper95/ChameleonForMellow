using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PortDest
    {
        public PortDest()
        {
            BolSailDays = new HashSet<BolSailDay>();
            BpmLocations = new HashSet<BpmLocation>();
            InLandTrDays = new HashSet<InLandTrDay>();
            PoBols = new HashSet<PoBol>();
            PoEtaEstimates = new HashSet<PoEtaEstimate>();
            PoTs = new HashSet<PoT>();
        }

        public int PortDestId { get; set; }
        public string DestName { get; set; }
        public int? NsIntId { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? NsSyncTime { get; set; }
        public DateTime? AddedDate { get; set; }
        public string PortName { get; set; }
        public bool IsActive { get; set; }
        public string PortCode { get; set; }

        public virtual ICollection<BolSailDay> BolSailDays { get; set; }
        public virtual ICollection<BpmLocation> BpmLocations { get; set; }
        public virtual ICollection<InLandTrDay> InLandTrDays { get; set; }
        public virtual ICollection<PoBol> PoBols { get; set; }
        public virtual ICollection<PoEtaEstimate> PoEtaEstimates { get; set; }
        public virtual ICollection<PoT> PoTs { get; set; }
    }
}
