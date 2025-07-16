using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Category5
    {
        public Category5()
        {
            BpmItems = new HashSet<BpmItem>();
        }

        public int Cat5Id { get; set; }
        public string Cat5 { get; set; }
        public int? NsIntId { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
    }
}
