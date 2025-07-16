using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsDailyZeroOutSku
    {
        public long InvFeedsDailyZeroOutSkuid { get; set; }
        public int? ItemNoId { get; set; }
        public string ItemName { get; set; }
        public int? ItemLocId { get; set; }
        public string LocationName { get; set; }
        public DateTime? ZeroOutDate { get; set; }
        public int? CreatedBy { get; set; }
        public bool? OverrideBackOrderRule { get; set; }
    }
}
