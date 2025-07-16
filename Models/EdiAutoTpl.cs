using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiAutoTpl
    {
        public int EdiTplLocId { get; set; }
        public int EpId { get; set; }
        public int LocId { get; set; }
        public byte FgcId { get; set; }
        public bool IsAutoOn { get; set; }
        public bool IsActive { get; set; }

        public virtual Edipartner Ep { get; set; }
        public virtual EdiFgc Fgc { get; set; }
        public virtual BpmLocation Loc { get; set; }
    }
}
