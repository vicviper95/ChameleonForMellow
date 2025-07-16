using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Baw940
    {
        public int Baw940Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int SoTId { get; set; }

        public virtual BawB2pT EdiTs { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
