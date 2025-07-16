using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Department
    {
        public Department()
        {
            Announcements = new HashSet<Announcement>();
            DeptManagers = new HashSet<DeptManager>();
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string DeptName { get; set; }
        public int NsIntId { get; set; }
        public string DeptShortName { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<DeptManager> DeptManagers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
