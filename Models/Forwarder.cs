using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Forwarder
    {
        public Forwarder()
        {
            PoBols = new HashSet<PoBol>();
        }

        public int ForwarderId { get; set; }
        public int? NsIntId { get; set; }
        public string FwdName { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime LastModTime { get; set; }
        public DateTime? NsSyncTime { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<PoBol> PoBols { get; set; }
    }
}
