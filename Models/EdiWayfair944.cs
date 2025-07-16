using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiWayfair944
    {
        public int Wayfair944Id { get; set; }
        public int? InterchangeId { get; set; }
        public int? EdiTscnId { get; set; }
        public int? AckIccnId { get; set; }
        public int? EdiRxState { get; set; }
        public int? IcId { get; set; }

        public virtual BpmToWayfairIc AckIccn { get; set; }
        public virtual WayfairToBpmIc Ic { get; set; }
    }
}
