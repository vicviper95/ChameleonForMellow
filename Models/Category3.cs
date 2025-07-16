using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Category3
    {
        public Category3()
        {
            BpmItems = new HashSet<BpmItem>();
            KoItemnos = new HashSet<KoItemno>();
        }

        public int Cat3Id { get; set; }
        public string Cat3 { get; set; }
        public int? NsIntId { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
        public virtual ICollection<KoItemno> KoItemnos { get; set; }
    }
}
