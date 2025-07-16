using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Ovs846
    {
        public int Ovs846Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }

        public virtual OvsP2bIc AckIc { get; set; }
        public virtual OvsB2pT EdiTs { get; set; }
    }
}
