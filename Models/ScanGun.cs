using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ScanGun
    {
        public ScanGun()
        {
            InvCountEntries = new HashSet<InvCountEntry>();
            SgActionAllows = new HashSet<SgActionAllow>();
        }

        public int ScanGunId { get; set; }
        public string ScanGunNo { get; set; }
        public string IpAddress { get; set; }
        public string ModelNo { get; set; }
        public int IsActive { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<InvCountEntry> InvCountEntries { get; set; }
        public virtual ICollection<SgActionAllow> SgActionAllows { get; set; }
    }
}
