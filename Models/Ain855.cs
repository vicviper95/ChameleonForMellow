using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Ain855
    {
        public int Ain855Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int SoTId { get; set; }

        public virtual AinP2bIc AckIc { get; set; }
        public virtual AinB2pT EdiTs { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
