using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdArnChange
    {
        public int ChangeId { get; set; }
        public int ArnId { get; set; }
        public string ValChange { get; set; }
        public DateTime ModTime { get; set; }
        public int ModByWho { get; set; }

        public virtual AdArn Arn { get; set; }
    }
}
