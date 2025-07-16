using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdBolChange
    {
        public int ChangeId { get; set; }
        public int BolId { get; set; }
        public DateTime ModTime { get; set; }
        public int ModByWho { get; set; }
        public string ValChange { get; set; }

        public virtual AdBol Bol { get; set; }
    }
}
