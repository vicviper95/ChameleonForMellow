using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BpmAs2
    {
        public int BpmAs2Id { get; set; }
        public int EdiIcId { get; set; }

        public virtual AdsB2pIc EdiIc { get; set; }
        public virtual BawB2pIc EdiIc1 { get; set; }
        public virtual WayB2pIc EdiIc2 { get; set; }
        public virtual AinB2pIc EdiIcNavigation { get; set; }
    }
}
