using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CmOrigin
    {
        public CmOrigin()
        {
            RemitClaims = new HashSet<RemitClaim>();
        }

        public int CmOriginId { get; set; }
        public int MarketId { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int ItemId { get; set; }

        public virtual GlAccount Account { get; set; }
        public virtual BpmItem Item { get; set; }
        public virtual Market Market { get; set; }
        public virtual ICollection<RemitClaim> RemitClaims { get; set; }
    }
}
