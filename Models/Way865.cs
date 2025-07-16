using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Way865
    {
        public int Way865Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int KoCoTId { get; set; }

        public virtual WayP2bIc AckIc { get; set; }
        public virtual WayB2pT EdiTs { get; set; }
        public virtual KoCoT KoCoT { get; set; }
    }
}
