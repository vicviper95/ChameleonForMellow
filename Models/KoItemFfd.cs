using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoItemFfd
    {
        public KoItemFfd()
        {
            KoKitTrkNos = new HashSet<KoKitTrkNo>();
        }

        public int KoIfdId { get; set; }
        public int KoIftId { get; set; }
        public int SoDId { get; set; }
        public int QtyFulfilled { get; set; }
        public string TrackNo { get; set; }
        public DateTime LastModTime { get; set; }
        public DateTime? NsSyncTime { get; set; }

        public virtual KoItemFft KoIft { get; set; }
        public virtual SoD SoD { get; set; }
        public virtual ICollection<KoKitTrkNo> KoKitTrkNos { get; set; }
    }
}
