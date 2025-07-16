using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ReasonNameType
    {
        public ReasonNameType()
        {
            AmzProductEligibilityDetails = new HashSet<AmzProductEligibilityDetail>();
        }

        public int ReasonTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<AmzProductEligibilityDetail> AmzProductEligibilityDetails { get; set; }
    }
}
