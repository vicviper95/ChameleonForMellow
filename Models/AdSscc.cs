using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdSscc
    {
        public AdSscc()
        {
            AdPallets = new HashSet<AdPallet>();
        }

        public int SsccId { get; set; }
        public int? SoDId { get; set; }
        public long SsccNo { get; set; }
        public DateTime? SoDate { get; set; }
        public int? NsIntId { get; set; }
        public int? PalletId { get; set; }

        public virtual AdPallet Pallet { get; set; }
        public virtual SoD SoD { get; set; }
        public virtual ICollection<AdPallet> AdPallets { get; set; }
    }
}
