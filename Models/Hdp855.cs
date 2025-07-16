using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Hdp855
    {
        public int Hdp855Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int SoTId { get; set; }

        public virtual HdpP2bIc AckIc { get; set; }
        public virtual HdpB2pT EdiTs { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
