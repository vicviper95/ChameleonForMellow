using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoAmzvendorRptNetPpm
    {
        public int NetPpmId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string ItemName { get; set; }
        public string Asin { get; set; }
        public string Subcategory { get; set; }
        public string Title { get; set; }
        public decimal? NetPpm { get; set; }
        public decimal? NetPpmPercentOfTotal { get; set; }
        public decimal? NetPpmPriorPeriod { get; set; }
        public decimal? NetPpmLastYear { get; set; }
    }
}
