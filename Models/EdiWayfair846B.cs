using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiWayfair846B
    {
        public int Wayfair846Id { get; set; }
        public int? EdiTscnId { get; set; }
        public string EdiTxState { get; set; }
        public int? AckIccnId { get; set; }

        public virtual BpmToWayfairT EdiTscn { get; set; }
    }
}
