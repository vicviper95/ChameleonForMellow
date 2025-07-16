using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Category2
    {
        public Category2()
        {
            BpmItems = new HashSet<BpmItem>();
            KoItemnos = new HashSet<KoItemno>();
        }

        public int Cat2Id { get; set; }
        public string Cat2 { get; set; }
        public int? NsIntId { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
        public virtual ICollection<KoItemno> KoItemnos { get; set; }
    }
}
