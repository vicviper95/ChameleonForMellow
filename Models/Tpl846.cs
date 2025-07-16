using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Tpl846
    {
        public int Tpl846Id { get; set; }
        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public int EdiTsId { get; set; }
        public string RxStatus { get; set; }
        public int AckIcId { get; set; }
        public int PartnerId { get; set; }

        public virtual TplB2pIc AckIc { get; set; }
        public virtual TplP2bIc Ic { get; set; }
    }
}
