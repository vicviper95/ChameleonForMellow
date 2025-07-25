﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Way846B
    {
        public int Way846BId { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }

        public virtual WayP2bIc AckIc { get; set; }
        public virtual WayB2pT EdiTs { get; set; }
    }
}
