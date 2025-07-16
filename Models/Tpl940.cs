using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Tpl940
    {
        public int Tpl940Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int SoTId { get; set; }

        public virtual TplP2bIc AckIc { get; set; }
        public virtual TplB2pT EdiTs { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
