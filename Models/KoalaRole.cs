using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoalaRole
    {
        public KoalaRole()
        {
            Employees = new HashSet<Employee>();
        }

        public int KoalaRoleId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOpsManager { get; set; }
        public bool IsAduser { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
