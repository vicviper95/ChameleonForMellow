using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WfadsReportD
    {
        public int ReportDId { get; set; }
        public int ReportTId { get; set; }
        public int? ClassTypeId { get; set; }
        public string StoreUrl { get; set; }
        public int Clicks { get; set; }
        public int Impressions { get; set; }
        public decimal Spend { get; set; }
        public decimal CostPerClick { get; set; }
        public decimal ClickThroughRate { get; set; }
        public decimal? EffectiveCost { get; set; }
        public int? KeywordId { get; set; }
        public int? ProductId { get; set; }
        public int? WvtId { get; set; }
        public int? WctId { get; set; }
        public int? WctHaloId { get; set; }

        public virtual WfadsClassType ClassType { get; set; }
        public virtual WfadsReportDKeyword Keyword { get; set; }
        public virtual WfadsReportDProduct Product { get; set; }
        public virtual WfadsReportT ReportT { get; set; }
        public virtual WfadsReportDWt Wct { get; set; }
        public virtual WfadsReportDWt WctHalo { get; set; }
        public virtual WfadsReportDWt Wvt { get; set; }
    }
}
