using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmazonCollection
    {
        public AmazonCollection()
        {
            MkIcrs = new HashSet<MkIcr>();
        }

        public int AmazonCollectionId { get; set; }
        public string CollectionName { get; set; }

        public virtual ICollection<MkIcr> MkIcrs { get; set; }
    }
}
