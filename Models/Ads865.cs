using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Ads865
    {
        public int Ads865Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int SoTId { get; set; }
        public int KoCoTId { get; set; }

        public virtual AdsP2bIc AckIc { get; set; }
        public virtual AdsB2pT EdiTs { get; set; }
        public virtual KoCoT KoCoT { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
