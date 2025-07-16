using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TutorialBranch
    {
        public TutorialBranch()
        {
            TutorialEmployees = new HashSet<TutorialEmployee>();
        }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int MgrId { get; set; }

        public virtual ICollection<TutorialEmployee> TutorialEmployees { get; set; }
    }
}
