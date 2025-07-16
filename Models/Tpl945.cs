using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Tpl945
    {
        public int Tpl945Id { get; set; }
        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public int EdiTsId { get; set; }
        public string RxStatus { get; set; }
        public int AckIcId { get; set; }
        public int? SoTId { get; set; }
        public int? IftId { get; set; }
        public int PartnerId { get; set; }

        public virtual TplB2pIc AckIc { get; set; }
        public virtual TplP2bIc Ic { get; set; }
        public virtual ItemFft Ift { get; set; }
        public virtual EdiPatrnerInfo Partner { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
