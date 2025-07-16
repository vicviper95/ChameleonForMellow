using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiFtpRxState
    {
        public EdiFtpRxState()
        {
            EdiSeko846s = new HashSet<EdiSeko846>();
            EdiSeko945s = new HashSet<EdiSeko945>();
        }

        public int FtpRxStateId { get; set; }
        public string FtpRxState { get; set; }

        public virtual ICollection<EdiSeko846> EdiSeko846s { get; set; }
        public virtual ICollection<EdiSeko945> EdiSeko945s { get; set; }
    }
}
