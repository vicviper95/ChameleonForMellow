using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CustLocCode
    {
        public int LocCodeId { get; set; }
        public int MarketId { get; set; }
        public int CustomerId { get; set; }
        public int LocId { get; set; }
        public string LocCode { get; set; }
        public string LocSan { get; set; }
        public DateTime? AddedTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual BpmLocation Loc { get; set; }
        public virtual Market Market { get; set; }
    }
}
