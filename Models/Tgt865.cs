using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Tgt865
    {
        public int Tgt865Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int KoCoTId { get; set; }

        public virtual TgtP2bIc AckIc { get; set; }
        public virtual TgtB2pT EdiTs { get; set; }
        public virtual KoCoT KoCoT { get; set; }
    }
}
