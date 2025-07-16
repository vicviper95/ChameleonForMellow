using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Category6
    {
        public Category6()
        {
            BpmItems = new HashSet<BpmItem>();
        }

        public int Cat6Id { get; set; }
        public string Cat6 { get; set; }
        public int? NsIntId { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
    }
}
