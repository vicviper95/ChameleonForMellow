using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PalletType
    {
        public PalletType()
        {
            BpmItems = new HashSet<BpmItem>();
            KoItemnos = new HashSet<KoItemno>();
            SodBols = new HashSet<SodBol>();
        }

        public int PalletTypeId { get; set; }
        public string PalType { get; set; }
        public int? NsIntId { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
        public virtual ICollection<KoItemno> KoItemnos { get; set; }
        public virtual ICollection<SodBol> SodBols { get; set; }
    }
}
