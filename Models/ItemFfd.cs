using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemFfd
    {
        public int IfdId { get; set; }
        public int? NsIntId { get; set; }
        public int IftId { get; set; }
        public int SoDId { get; set; }
        public int QtyFulfilled { get; set; }
        public string TrackNo { get; set; }
        public DateTime? SoDate { get; set; }
        public string CustSku { get; set; }
        public bool? IsAsnuploaded { get; set; }
        public bool? IsValid { get; set; }

        public virtual ItemFft Ift { get; set; }
        public virtual SoD SoD { get; set; }
    }
}
