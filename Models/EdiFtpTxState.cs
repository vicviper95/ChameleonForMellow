using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiFtpTxState
    {
        public EdiFtpTxState()
        {
            EdiSeko940s = new HashSet<EdiSeko940>();
        }

        public int FtpTxStateId { get; set; }
        public string FtpTxState { get; set; }

        public virtual ICollection<EdiSeko940> EdiSeko940s { get; set; }
    }
}
