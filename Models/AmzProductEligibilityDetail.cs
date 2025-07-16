using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzProductEligibilityDetail
    {
        public int EligiblityId { get; set; }
        public int ProductEligibilityId { get; set; }
        public int? ServerityId { get; set; }
        public int? ReasonNameId { get; set; }
        public string HelpUrl { get; set; }
        public string Message { get; set; }
        public int OverallStatusId { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual OverallStatusType OverallStatus { get; set; }
        public virtual AmzProductEligibility ProductEligibility { get; set; }
        public virtual ReasonNameType ReasonName { get; set; }
        public virtual ServerityType Serverity { get; set; }
    }
}
