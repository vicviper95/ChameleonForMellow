using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzProductEligibility
    {
        public AmzProductEligibility()
        {
            AmzProductEligibilityDetails = new HashSet<AmzProductEligibilityDetail>();
        }

        public int ProductEligibilityId { get; set; }
        public string Asin { get; set; }
        public int IcrId { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual ICollection<AmzProductEligibilityDetail> AmzProductEligibilityDetails { get; set; }
    }
}
