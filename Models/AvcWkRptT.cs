using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AvcWkRptT
    {
        public AvcWkRptT()
        {
            AvcWkRptDs = new HashSet<AvcWkRptD>();
            AvcWkRptPs = new HashSet<AvcWkRptP>();
        }

        public int AvcWkRptTId { get; set; }
        public DateTime SundayOfWk { get; set; }
        public int AddedUserId { get; set; }

        public virtual ICollection<AvcWkRptD> AvcWkRptDs { get; set; }
        public virtual ICollection<AvcWkRptP> AvcWkRptPs { get; set; }
    }
}
