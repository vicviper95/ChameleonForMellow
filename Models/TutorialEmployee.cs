using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TutorialEmployee
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Country { get; set; }
        public int? BranchId { get; set; }
        public int? SuperId { get; set; }

        public virtual TutorialBranch Branch { get; set; }
    }
}
