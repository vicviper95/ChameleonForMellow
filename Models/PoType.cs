using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoType
    {
        public PoType()
        {
            PoTs = new HashSet<PoT>();
        }

        public int PoTypeId { get; set; }
        public int NsIntId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<PoT> PoTs { get; set; }
    }
}
