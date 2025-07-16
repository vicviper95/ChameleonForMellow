﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SchAppointment
    {
        public int UniqueId { get; set; }
        public int? Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? AllDay { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public int? Label { get; set; }
        public int? ResourceId { get; set; }
        public string ResourceIds { get; set; }
        public string ReminderInfo { get; set; }
        public string RecurrenceInfo { get; set; }
        public string CustomField1 { get; set; }
    }
}
