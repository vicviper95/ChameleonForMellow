using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvtTrxRecordType
    {
        public InvtTrxRecordType()
        {
            InvtTrxTypes = new HashSet<InvtTrxType>();
        }

        public int InvtTrxRecordTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<InvtTrxType> InvtTrxTypes { get; set; }
    }
}
