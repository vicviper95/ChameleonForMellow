using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdPalletOnBol
    {
        public AdPalletOnBol()
        {
            AdtemOnPallets = new HashSet<AdtemOnPallet>();
        }

        public int PalletId { get; set; }
        public int QtyItemTotal { get; set; }
        public int BolId { get; set; }
        public int PalletTypeId { get; set; }

        public virtual PalletType1 PalletType { get; set; }
        public virtual ICollection<AdtemOnPallet> AdtemOnPallets { get; set; }
    }
}
