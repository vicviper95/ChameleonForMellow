using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiSeko945
    {
        public EdiSeko945()
        {
            EdiSeko945Errors = new HashSet<EdiSeko945Error>();
        }

        public int Seko945Id { get; set; }
        public int InterchangeId { get; set; }
        public int? EdiStateId { get; set; }
        public string EdiFileName { get; set; }
        public string AckFileName { get; set; }
        public int? AckInterchangeKey { get; set; }
        public int? EdiStatusId { get; set; }
        public string MasterBol { get; set; }
        public int? OrderId { get; set; }

        public virtual EdiSekoBpmToSeko AckInterchangeKeyNavigation { get; set; }
        public virtual EdiFtpRxState EdiState { get; set; }
        public virtual EdiStatus EdiStatus { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<EdiSeko945Error> EdiSeko945Errors { get; set; }
    }
}
