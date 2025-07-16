using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VStarshipAddr
    {
        public string OrderNumber { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateProvinceCode { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
    }
}
