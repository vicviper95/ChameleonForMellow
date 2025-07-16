using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class StateZipCountry
    {
        public int LookupId { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }
}
