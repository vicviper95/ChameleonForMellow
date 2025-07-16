using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Ads846
    {
        public int Ads846Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }

        public virtual AdsP2bIc AckIc { get; set; }
        public virtual AdsB2pT EdiTs { get; set; }
    }
}
