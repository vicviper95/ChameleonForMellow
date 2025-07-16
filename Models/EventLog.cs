using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EventLog
    {
        public int EventLogId { get; set; }
        public int ServiceId { get; set; }
        public string Module { get; set; }
        public int SeverityId { get; set; }
        public string Message { get; set; }
        public DateTime EventTime { get; set; }

        public virtual EventService Service { get; set; }
        public virtual EventSeverity Severity { get; set; }
    }
}
