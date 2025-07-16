using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employee>();
        }

        public int EmpTypeId { get; set; }
        public string EmpType { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
