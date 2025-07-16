using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class DeptManager
    {
        public int? DepartmentId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateEnd { get; set; }
        public int DeptManagerId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
