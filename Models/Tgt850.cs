using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Tgt850
    {
        public int Tgt850Id { get; set; }
        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public int EdiTsId { get; set; }
        public string RxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int? SoTId { get; set; }

        public virtual TgtB2pIc AckIc { get; set; }
        public virtual TgtP2bIc Ic { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
