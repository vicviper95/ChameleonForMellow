using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Wmt856
    {
        public int Wmt856Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int? IftId { get; set; }
        public int SoTId { get; set; }

        public virtual WmtP2bIc AckIc { get; set; }
        public virtual WmtB2pT EdiTs { get; set; }
        public virtual ItemFft Ift { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
