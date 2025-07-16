using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PurchaseConfig
    {
        public int PurchaseConfigId { get; set; }
        public int? CurrentWeek { get; set; }
        public int? CurWeekBpmpreNo { get; set; }
        public int? CurWeekCcguspreNo { get; set; }
        public int? CurWeekCgcanadaPreNo { get; set; }
        public int? CurWeekCgukpreNo { get; set; }
        public int? CurWeekWfspreNo { get; set; }
        public int? CurWeekFbacanadaPreNo { get; set; }
        public int? ApprovalNo { get; set; }
        public int? CurApprovalYear { get; set; }
    }
}
