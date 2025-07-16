using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzCbSubType
    {
        public AmzCbSubType()
        {
            AmzChargeBacks = new HashSet<AmzChargeBack>();
        }

        public int CbSubTypeId { get; set; }
        public string CbSubType { get; set; }
        public string CbSubTypeNote { get; set; }

        public virtual ICollection<AmzChargeBack> AmzChargeBacks { get; set; }
    }
}
