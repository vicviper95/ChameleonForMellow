using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WayfairToBpmIco
    {
        public int InterchangeId { get; set; }
        public DateTime IcTime { get; set; }
        public string EdiString { get; set; }
        public string Fgc { get; set; }
    }
}
