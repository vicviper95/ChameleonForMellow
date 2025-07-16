using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Hdp810
    {
        public int Hdp810Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int InvTId { get; set; }

        public virtual HdpP2bIc AckIc { get; set; }
        public virtual HdpB2pT EdiTs { get; set; }
        public virtual InvT InvT { get; set; }
    }
}
