using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Amazon.orderDS
{
  public class ShipToParty
  {
    public string name { get; set; }
    public string addressLine1 { get; set; }
    public string addressLine2 { get; set; }
    public string addressLine3 { get; set; }
    public string city { get; set; }
    public string county { get; set; }
    public string stateOrRegion { get; set; }
    public string postalCode { get; set; }
    public string countryCode { get; set; }
    public string phone { get; set; }

  }
}
