using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EventLogPo
    {
        public int LogId { get; set; }
        public string EventDesc { get; set; }
        public DateTime EventTime { get; set; }
        public int? ChangeBy { get; set; }
    }
}
