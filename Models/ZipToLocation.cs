using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ZipToLocation
    {
        public int ZipToLocationId { get; set; }
        public int ZipCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
