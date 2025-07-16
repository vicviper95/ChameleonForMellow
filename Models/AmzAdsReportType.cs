using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzAdsReportType
    {
        public AmzAdsReportType()
        {
            AmzAdsRptCreateHistories = new HashSet<AmzAdsRptCreateHistory>();
        }

        public int RptTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<AmzAdsRptCreateHistory> AmzAdsRptCreateHistories { get; set; }
    }
}
