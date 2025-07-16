using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstItemClass
    {
        public int FcstClassId { get; set; }
        public DateTime FcstDate { get; set; }
        public byte ItemClassId { get; set; }
        public int ItemNoId { get; set; }
        public DateTime LastModDate { get; set; }

        public virtual ItemClass ItemClass { get; set; }
        public virtual BpmItem ItemNo { get; set; }
    }
}
