using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdsAs2
    {
        public int AdsAs2Id { get; set; }
        public int EdiIcId { get; set; }

        public virtual AdsB2pIc EdiIc { get; set; }
    }
}
