using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Baw846
    {
        public int Baw846Id { get; set; }
        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public int EdiTsId { get; set; }
        public string RxStatus { get; set; }
        public int AckIcId { get; set; }

        public virtual BawB2pIc AckIc { get; set; }
        public virtual BawP2bIc Ic { get; set; }
    }
}
