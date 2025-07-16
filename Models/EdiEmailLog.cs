using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiEmailLog
    {
        public int EdiEmailLogId { get; set; }
        public DateTime TimeSent { get; set; }
        public string EmailTitle { get; set; }
        public string EmailTo { get; set; }
    }
}
