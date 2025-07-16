using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ApiauthorityLevel
    {
        public ApiauthorityLevel()
        {
            Employees = new HashSet<Employee>();
        }

        public int ApiauthorityLevelId { get; set; }
        public string AuthorityLevel { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
