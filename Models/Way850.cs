using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Way850
    {
        public int Way850Id { get; set; }
        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public int EdiTsId { get; set; }
        public string RxStatus { get; set; }
        public int AckIcId { get; set; }
        public int? SoTId { get; set; }

        public virtual WayB2pIc AckIc { get; set; }
        public virtual WayP2bIc Ic { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
