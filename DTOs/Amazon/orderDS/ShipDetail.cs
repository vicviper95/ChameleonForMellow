using System;
using System.Collections.Generic;
using System.Text;

namespace Chameleon.DTOs.Amazon.orderDS
{
  public class ShipDetail
  {
    public bool isPriorityShipment{ get; set; }
    public bool isScheduledDeliveryShipment { get; set; }
    public bool isPslipRequired { get; set; }
    public bool isGift { get; set; }
    public string shipMethod { get; set; }
    public ShipmentDates shipmentDates { get; set; }
   
  }
  public class ShipmentDates
  {
    public DateTime requiredShipDate { get; set; }
    public DateTime promisedDeliveryDate { get; set; }
  }
}

