using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Hdp846
    {
        public int Hdp846Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }

        public virtual HdpP2bIc AckIc { get; set; }
        public virtual HdpB2pT EdiTs { get; set; }
    }
}
