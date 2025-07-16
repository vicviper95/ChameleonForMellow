using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiWayfair860
    {
        public int Wayfair860Id { get; set; }
        public int? EdiTscnId { get; set; }
        public int? AckIccnId { get; set; }
        public string EdiRxState { get; set; }
        public int? OrderId { get; set; }
        public int? InterchangeId { get; set; }
        public int? IcId { get; set; }

        public virtual BpmToWayfairIc AckIccn { get; set; }
        public virtual WayfairToBpmIc Ic { get; set; }
        public virtual Order Order { get; set; }
    }
}
