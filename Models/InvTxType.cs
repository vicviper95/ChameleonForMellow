using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvTxType
    {
        public InvTxType()
        {
            InvCountEntries = new HashSet<InvCountEntry>();
            MsInvAdjEntries = new HashSet<MsInvAdjEntry>();
            SgActionAllows = new HashSet<SgActionAllow>();
        }

        public int InvTxTypeId { get; set; }
        public string InvTxType1 { get; set; }

        public virtual ICollection<InvCountEntry> InvCountEntries { get; set; }
        public virtual ICollection<MsInvAdjEntry> MsInvAdjEntries { get; set; }
        public virtual ICollection<SgActionAllow> SgActionAllows { get; set; }
    }
}
