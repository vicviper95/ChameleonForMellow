using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmtP2bIc
    {
        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short? Fgc { get; set; }
        public string EdiStr { get; set; }
        public string EdiFname { get; set; }
    }
}
