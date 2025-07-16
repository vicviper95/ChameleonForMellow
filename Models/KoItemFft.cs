using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoItemFft
    {
        public KoItemFft()
        {
            Baw945s = new HashSet<Baw945>();
            KoItemFfds = new HashSet<KoItemFfd>();
            Way945s = new HashSet<Way945>();
        }

        public int KoIftId { get; set; }
        public int? SoTId { get; set; }
        public string PoNo { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual SoT SoT { get; set; }
        public virtual ICollection<Baw945> Baw945s { get; set; }
        public virtual ICollection<KoItemFfd> KoItemFfds { get; set; }
        public virtual ICollection<Way945> Way945s { get; set; }
    }
}
