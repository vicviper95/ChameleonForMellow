using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzCbStatus
    {
        public AmzCbStatus()
        {
            AmzChargeBacks = new HashSet<AmzChargeBack>();
        }

        public int CbStatusId { get; set; }
        public string CbStatus { get; set; }
        public string CbStautsNote { get; set; }

        public virtual ICollection<AmzChargeBack> AmzChargeBacks { get; set; }
    }
}
