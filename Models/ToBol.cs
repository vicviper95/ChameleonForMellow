using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ToBol
    {
        public ToBol()
        {
            BolFeet = new HashSet<BolFoot>();
            ToContainers = new HashSet<ToContainer>();
        }

        public int ToBolId { get; set; }
        public string BoLno { get; set; }

        public virtual ICollection<BolFoot> BolFeet { get; set; }
        public virtual ICollection<ToContainer> ToContainers { get; set; }
    }
}
