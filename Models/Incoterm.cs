using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Incoterm
    {
        public Incoterm()
        {
            PoTs = new HashSet<PoT>();
        }

        public int IncotermId { get; set; }
        public int NsIntId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PoT> PoTs { get; set; }
    }
}
