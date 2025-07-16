using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ContStatus
    {
        public ContStatus()
        {
            Containers = new HashSet<Container>();
        }

        public int ContStatusId { get; set; }
        public string StatusCont { get; set; }

        public virtual ICollection<Container> Containers { get; set; }
    }
}
