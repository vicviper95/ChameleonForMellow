using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvCountEntry
    {
        public int IcEntryId { get; set; }
        public int PhysCountId { get; set; }
        public int QtyChange { get; set; }
        public DateTime TimeChange { get; set; }
        public int? ScanGunId { get; set; }
        public string IpAddress { get; set; }
        public int QtyEnding { get; set; }
        public int? InvTxTypeId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual InvTxType InvTxType { get; set; }
        public virtual PhysCountMsl PhysCount { get; set; }
        public virtual ScanGun ScanGun { get; set; }
    }
}
