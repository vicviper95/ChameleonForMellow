using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiCarrier
    {
        public int EdiCarId { get; set; }
        public int EpId { get; set; }
        public string Scac { get; set; }
        public string CarName { get; set; }
        public string CarCode { get; set; }
        public string CarSpeed { get; set; }
        public string RetCode { get; set; }
        public int ShipViaId { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }

        public virtual Edipartner Ep { get; set; }
        public virtual ShipVium ShipVia { get; set; }
    }
}
