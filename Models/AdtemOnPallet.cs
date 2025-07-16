using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdtemOnPallet
    {
        public int ItemOnPalletId { get; set; }
        public int PalletId { get; set; }
        public int ItemNoId { get; set; }
        public int ItemQty { get; set; }

        public virtual KoItemno ItemNo { get; set; }
        public virtual AdPalletOnBol Pallet { get; set; }
    }
}
