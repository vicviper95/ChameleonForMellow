using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BawAs2
    {
        public int BawAs2Id { get; set; }
        public int EdiIcId { get; set; }

        public virtual BawB2pIc EdiIc { get; set; }
    }
}
