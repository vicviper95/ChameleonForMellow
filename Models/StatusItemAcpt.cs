using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class StatusItemAcpt
    {
        public StatusItemAcpt()
        {
            SoDs = new HashSet<SoD>();
        }

        public int AcptStatusId { get; set; }
        public string ItAcptStatus { get; set; }
        public string ItAcptAbbr { get; set; }

        public virtual ICollection<SoD> SoDs { get; set; }
    }
}
