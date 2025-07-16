using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EmployeeStatus
    {
        public EmployeeStatus()
        {
            Employees = new HashSet<Employee>();
        }

        public int EmpStatusId { get; set; }
        public string EmpStatus { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
