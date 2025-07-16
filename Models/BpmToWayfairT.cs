using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BpmToWayfairT
    {
        public BpmToWayfairT()
        {
            EdiWayfair810s = new HashSet<EdiWayfair810>();
            EdiWayfair846Bs = new HashSet<EdiWayfair846B>();
            EdiWayfair855s = new HashSet<EdiWayfair855>();
            EdiWayfair856s = new HashSet<EdiWayfair856>();
            EdiWayfair865s = new HashSet<EdiWayfair865>();
            EdiWayfair869s = new HashSet<EdiWayfair869>();
            EdiWayfair940s = new HashSet<EdiWayfair940>();
        }

        public int TransactionId { get; set; }
        public int? InterchangeId { get; set; }

        public virtual BpmToWayfairIc Interchange { get; set; }
        public virtual ICollection<EdiWayfair810> EdiWayfair810s { get; set; }
        public virtual ICollection<EdiWayfair846B> EdiWayfair846Bs { get; set; }
        public virtual ICollection<EdiWayfair855> EdiWayfair855s { get; set; }
        public virtual ICollection<EdiWayfair856> EdiWayfair856s { get; set; }
        public virtual ICollection<EdiWayfair865> EdiWayfair865s { get; set; }
        public virtual ICollection<EdiWayfair869> EdiWayfair869s { get; set; }
        public virtual ICollection<EdiWayfair940> EdiWayfair940s { get; set; }
    }
}
