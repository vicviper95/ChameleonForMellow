using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SoStatusN
    {
        public SoStatusN()
        {
            SoDs = new HashSet<SoD>();
        }

        public int SoStatusNsId { get; set; }
        public string StatusNs { get; set; }
        public int? NsIntId { get; set; }

        public virtual ICollection<SoD> SoDs { get; set; }
    }
}
