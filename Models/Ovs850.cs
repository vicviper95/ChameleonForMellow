using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Ovs850
    {
        public int Ovs850Id { get; set; }
        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public int EdiTsId { get; set; }
        public string RxStatus { get; set; }
        public int AckIcId { get; set; }
        public int? SoTId { get; set; }

        public virtual OvsB2pIc AckIc { get; set; }
        public virtual OvsP2bIc Ic { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
