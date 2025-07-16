using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ApisSoprocess
    {
        public ApisSoprocess()
        {
            SoErrors = new HashSet<SoError>();
        }

        public int ProcessId { get; set; }
        public string ProcessType { get; set; }

        public virtual ICollection<SoError> SoErrors { get; set; }
    }
}
