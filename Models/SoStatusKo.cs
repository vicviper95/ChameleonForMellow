using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SoStatusKo
    {
        public SoStatusKo()
        {
            KoSoDs = new HashSet<KoSoD>();
            SoDs = new HashSet<SoD>();
        }

        public int SoStatusKoId { get; set; }
        public string StatusKo { get; set; }

        public virtual ICollection<KoSoD> KoSoDs { get; set; }
        public virtual ICollection<SoD> SoDs { get; set; }
    }
}
