using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoKitTrkNo
    {
        public int KitTrkId { get; set; }
        public int KoIfdId { get; set; }
        public int ChildItemId { get; set; }
        public int ChildQty { get; set; }
        public string TrackNo { get; set; }
    }
}
