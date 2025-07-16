using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiBawC2bIc
    {
        public int BawIcId { get; set; }
        public DateTime IcTime { get; set; }
        public string Fgc { get; set; }
        public string EdiString { get; set; }
        public int EdiIcId { get; set; }
    }
}
