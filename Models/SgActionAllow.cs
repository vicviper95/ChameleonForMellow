using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SgActionAllow
    {
        public int SgaaId { get; set; }
        public int ScanGunId { get; set; }
        public int InvTxTypeId { get; set; }
        public int IsAllowed { get; set; }

        public virtual InvTxType InvTxType { get; set; }
        public virtual ScanGun ScanGun { get; set; }
    }
}
