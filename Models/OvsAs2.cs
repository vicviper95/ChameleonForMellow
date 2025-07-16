using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class OvsAs2
    {
        public int OvsAs2Id { get; set; }
        public int EdiIcId { get; set; }

        public virtual OvsB2pIc EdiIc { get; set; }
    }
}
