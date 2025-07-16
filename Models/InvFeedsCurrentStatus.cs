using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsCurrentStatus
    {
        public long InvFeedsCurrentStatusId { get; set; }
        public long RealTimeInvUpdateId { get; set; }
        public int ItemNoId { get; set; }
        public string ItemName { get; set; }
        public int QtyAvailMainSl { get; set; }
        public int QtyOnHandMainSl { get; set; }
        public int StagePomainSl { get; set; }
        public int QtyAvailZinusTracy { get; set; }
        public int QtyOnHandZinusTracy { get; set; }
        public int StagePozinusTracy { get; set; }
        public int QtyAvailZinusChs { get; set; }
        public int QtyOnHandZinusChs { get; set; }
        public int StagePozinusChs { get; set; }
    }
}
