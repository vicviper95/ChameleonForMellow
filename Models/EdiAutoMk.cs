using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiAutoMk
    {
        public int AutoSendId { get; set; }
        public int EpId { get; set; }
        public byte FgcId { get; set; }
        public bool IsAutoOn { get; set; }

        public virtual Edipartner Ep { get; set; }
        public virtual EdiFgc Fgc { get; set; }
    }
}
