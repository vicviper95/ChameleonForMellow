using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Category1
    {
        public Category1()
        {
            BpmItems = new HashSet<BpmItem>();
            KoItemnos = new HashSet<KoItemno>();
        }

        public int Cat1Id { get; set; }
        public string Cat1 { get; set; }
        public int? NsIntId { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
        public virtual ICollection<KoItemno> KoItemnos { get; set; }
    }
}
