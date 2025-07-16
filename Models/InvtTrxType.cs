using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvtTrxType
    {
        public InvtTrxType()
        {
            InvtDailyTrxDs = new HashSet<InvtDailyTrxD>();
        }

        public int InvtTrxTypeId { get; set; }
        public string Type { get; set; }
        public int? RecordTypeId { get; set; }
        public bool IsDbf { get; set; }

        public virtual InvtTrxRecordType RecordType { get; set; }
        public virtual ICollection<InvtDailyTrxD> InvtDailyTrxDs { get; set; }
    }
}
