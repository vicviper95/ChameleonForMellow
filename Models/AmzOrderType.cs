using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzOrderType
    {
        public AmzOrderType()
        {
            AmzChargeBacks = new HashSet<AmzChargeBack>();
        }

        public int OrderTypeId { get; set; }
        public string OrderType { get; set; }

        public virtual ICollection<AmzChargeBack> AmzChargeBacks { get; set; }
    }
}
