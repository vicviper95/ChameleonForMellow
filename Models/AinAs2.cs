using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AinAs2
    {
        public int AinAs2Id { get; set; }
        public int EdiIcId { get; set; }

        public virtual AinB2pIc EdiIc { get; set; }
    }
}
