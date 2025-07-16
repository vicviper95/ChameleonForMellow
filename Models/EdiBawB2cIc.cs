using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiBawB2cIc
    {
        public EdiBawB2cIc()
        {
            EdiBawB2cas2s = new HashSet<EdiBawB2cas2>();
        }

        public int InterchangeId { get; set; }
        public DateTime IcTime { get; set; }
        public string Fgc { get; set; }
        public string EdiString { get; set; }

        public virtual ICollection<EdiBawB2cas2> EdiBawB2cas2s { get; set; }
    }
}
