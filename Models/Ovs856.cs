using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Ovs856
    {
        public int Ovs856Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int? IftId { get; set; }
        public int SoTId { get; set; }

        public virtual OvsP2bIc AckIc { get; set; }
        public virtual OvsB2pT EdiTs { get; set; }
        public virtual ItemFft Ift { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
