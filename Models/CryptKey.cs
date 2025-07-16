using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CryptKey
    {
        public int CriptId { get; set; }
        public DateTime RefDate { get; set; }
        public string KeyValue { get; set; }
        public string IvValue { get; set; }
        public DateTime AddedTime { get; set; }
    }
}
