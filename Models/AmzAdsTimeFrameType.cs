using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzAdsTimeFrameType
    {
        public AmzAdsTimeFrameType()
        {
            AmzAdsRptCreateHistories = new HashSet<AmzAdsRptCreateHistory>();
        }

        public int TimeFrameId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<AmzAdsRptCreateHistory> AmzAdsRptCreateHistories { get; set; }
    }
}
