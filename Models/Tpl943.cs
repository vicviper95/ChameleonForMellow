using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Tpl943
    {
        public int Tpl943Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int PoTId { get; set; }

        public virtual TplP2bIc AckIc { get; set; }
        public virtual TplB2pT EdiTs { get; set; }
        public virtual PoT PoT { get; set; }
    }
}
