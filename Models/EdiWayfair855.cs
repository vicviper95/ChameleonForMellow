using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiWayfair855
    {
        public int Wayfair855Id { get; set; }
        public int? EdiTscnId { get; set; }
        public string EdiTxState { get; set; }
        public int? OrderId { get; set; }
        public int? AckIccnId { get; set; }

        public virtual BpmToWayfairT EdiTscn { get; set; }
        public virtual Order Order { get; set; }
    }
}
