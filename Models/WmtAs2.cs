using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmtAs2
    {
        public int WmtAs2Id { get; set; }
        public int EdiIcId { get; set; }

        public virtual WmtB2pIc EdiIc { get; set; }
    }
}
