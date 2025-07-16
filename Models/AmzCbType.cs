using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzCbType
    {
        public AmzCbType()
        {
            AmzChargeBacks = new HashSet<AmzChargeBack>();
        }

        public int CbTypeId { get; set; }
        public string CbType { get; set; }

        public virtual ICollection<AmzChargeBack> AmzChargeBacks { get; set; }
    }
}
