using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CmRemit
    {
        public int CmRemitId { get; set; }
        public int CrdMemoId { get; set; }
        public int RemitId { get; set; }
        public string RemitNoSub { get; set; }
        public decimal CmTotal { get; set; }
        public int CmPaid { get; set; }
        public int? HasIssue { get; set; }
        public string Note { get; set; }

        public virtual NsRemit Remit { get; set; }
    }
}
