using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Category4
    {
        public Category4()
        {
            BpmItems = new HashSet<BpmItem>();
        }

        public int Cat4Id { get; set; }
        public string Cat4 { get; set; }
        public int? NsIntId { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
    }
}
