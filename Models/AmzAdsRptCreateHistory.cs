using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzAdsRptCreateHistory
    {
        public int RptId { get; set; }
        public int ReportTypeId { get; set; }
        public int TimeFrameId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime AddedTime { get; set; }
        public int CountInsert { get; set; }
        public int AdsProductId { get; set; }

        public virtual AmzAdsProductType AdsProduct { get; set; }
        public virtual AmzAdsReportType ReportType { get; set; }
        public virtual AmzAdsTimeFrameType TimeFrame { get; set; }
    }
}
