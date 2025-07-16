using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoChange
    {
        public int PoChangeId { get; set; }
        public int PoTId { get; set; }
        public int PocTypeId { get; set; }
        public int ChgReasonId { get; set; }
        public DateTime OriginalEtd { get; set; }
        public DateTime NewEtd { get; set; }
        public DateTime? NewEuld { get; set; }
        public int PocStatusId { get; set; }
        public int RequesterId { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }
        public string Note { get; set; }
        public string ScmNote { get; set; }
        public DateTime? OriginalEuld { get; set; }

        public virtual PocReason ChgReason { get; set; }
        public virtual PoT PoT { get; set; }
        public virtual PocStatus PocStatus { get; set; }
        public virtual PocType PocType { get; set; }
        public virtual Employee Requester { get; set; }
    }
}
