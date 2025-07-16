using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzProgram
    {
        public AmzProgram()
        {
            AmzObRptTs = new HashSet<AmzObRptT>();
        }

        public int Id { get; set; }
        public string Program { get; set; }

        public virtual ICollection<AmzObRptT> AmzObRptTs { get; set; }
    }
}
