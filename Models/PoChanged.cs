using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoChanged
    {
        public int PoChangedId { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime ChangedTime { get; set; }
        public int? PoBolId { get; set; }
        public int? PoTId { get; set; }

        public virtual PoBol PoBol { get; set; }
        public virtual PoT PoT { get; set; }
    }
}
