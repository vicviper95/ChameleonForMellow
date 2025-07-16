using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Ain753
    {
        public int Ain753Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int BolId { get; set; }

        public virtual AinP2bIc AckIc { get; set; }
        public virtual AdBol Bol { get; set; }
        public virtual AinB2pT EdiTs { get; set; }
    }
}
