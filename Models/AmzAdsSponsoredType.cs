using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzAdsSponsoredType
    {
        public AmzAdsSponsoredType()
        {
            AmazonAdReports = new HashSet<AmazonAdReport>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<AmazonAdReport> AmazonAdReports { get; set; }
    }
}
