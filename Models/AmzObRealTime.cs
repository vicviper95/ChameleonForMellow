using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzObRealTime
    {
        public int RealTId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int? OrdUnit { get; set; }
        public decimal? OrdRev { get; set; }
        public DateTime AddedTime { get; set; }
        public string Asin { get; set; }
        public int? IcrId { get; set; }
    }
}
