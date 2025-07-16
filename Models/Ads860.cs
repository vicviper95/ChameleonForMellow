using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Ads860
    {
        public int Ads860Id { get; set; }
        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public int EdiTsId { get; set; }
        public string RxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int? SoTId { get; set; }
        public int KoCoTId { get; set; }

        public virtual AdsB2pIc AckIc { get; set; }
        public virtual AdsP2bIc Ic { get; set; }
        public virtual KoCoT KoCoT { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
