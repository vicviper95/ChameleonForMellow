using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EventService
    {
        public EventService()
        {
            EventLogs = new HashSet<EventLog>();
        }

        public int EventServiceId { get; set; }
        public string Service { get; set; }

        public virtual ICollection<EventLog> EventLogs { get; set; }
    }
}
