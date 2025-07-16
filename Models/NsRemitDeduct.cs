using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsRemitDeduct
    {
        public int RemitDeductId { get; set; }
        public int RemitId { get; set; }
        public int DeductTypeId { get; set; }
        public decimal AmtTotal { get; set; }
        public string DeductNo { get; set; }
        public int HasIssue { get; set; }
        public decimal? AmtDeduct { get; set; }
        public int? IsClosed { get; set; }

        public virtual NsDeductType DeductType { get; set; }
        public virtual NsRemit Remit { get; set; }
    }
}
