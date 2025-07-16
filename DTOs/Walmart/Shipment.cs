using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Walmart
{

    public class Shipment
    {
        public Ordershipment orderShipment { get; set; }
    }

    public class Ordershipment
    {
        public Orderlines orderLines { get; set; }
    }

    public class Orderlines
    {
        public Orderline[] orderLine { get; set; }
    }

    public class Orderline
    {
        public string lineNumber { get; set; }
        public Orderlinestatuses orderLineStatuses { get; set; }
    }

    public class Orderlinestatuses
    {
        public Orderlinestatu[] orderLineStatus { get; set; }
    }

    public class Orderlinestatu
    {
        public string status { get; set; }
        public Asn asn { get; set; }
        public Statusquantity statusQuantity { get; set; }
        public Trackinginfo trackingInfo { get; set; }
    }

    public class Asn
    {
        public string packageASN { get; set; }
        public string palletASN { get; set; }
    }

    public class Statusquantity
    {
        public string unitOfMeasurement { get; set; }
        public string amount { get; set; }
    }

    public class Trackinginfo
    {
        public string shipDateTime { get; set; }
        public Carriername carrierName { get; set; }
        public string methodCode { get; set; }
        public string trackingNumber { get; set; }
        public string trackingURL { get; set; }
    }

    public class Carriername
    {
        public object otherCarrier { get; set; }
        public string carrier { get; set; }
    }

}
