using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class OverallStatusType
    {
        public OverallStatusType()
        {
            AmzProductEligibilityDetails = new HashSet<AmzProductEligibilityDetail>();
        }

        public int OverallStatusId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<AmzProductEligibilityDetail> AmzProductEligibilityDetails { get; set; }
    }
}
