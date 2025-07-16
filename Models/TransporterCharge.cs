using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TransporterCharge
    {
        public TransporterCharge()
        {
            Transporters = new HashSet<Transporter>();
        }

        public int ChargeId { get; set; }
        public int TransporterId { get; set; }
        public decimal PrePull { get; set; }
        public decimal StoragePerDay { get; set; }
        public decimal LatePerDay { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public virtual Transporter Transporter { get; set; }
        public virtual ICollection<Transporter> Transporters { get; set; }
    }
}
