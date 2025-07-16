using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EventSeverity
    {
        public EventSeverity()
        {
            EventLogs = new HashSet<EventLog>();
        }

        public int SeverityId { get; set; }
        public string Severity { get; set; }

        public virtual ICollection<EventLog> EventLogs { get; set; }
    }
}
