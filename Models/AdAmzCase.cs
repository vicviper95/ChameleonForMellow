using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdAmzCase
    {
        public int AmzCaseId { get; set; }
        public int AmzCaseNo { get; set; }
        public string CaseDesc { get; set; }
        public string CaseResol { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }
        public int? LastModWho { get; set; }
        public int ArnId { get; set; }
    }
}
