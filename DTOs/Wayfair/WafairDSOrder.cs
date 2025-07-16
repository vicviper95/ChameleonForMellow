using System;
using System.Collections.Generic;
using System.Text;

namespace Chameleon.DTOs.Wayfair
{
    public enum ParcelSize
    {
        small,
        large
    }
    public class WafairDSOrder
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public Getdropshippurchaseorder[] getDropshipPurchaseOrders { get; set; }
    }

    public class Getdropshippurchaseorder
    {
        public string poNumber { get; set; }
        public string poDate { get; set; }
        public DateTime poLocalDate => Convert.ToDateTime(poDate).ToLocalTime();
        public string estimatedShipDate { get; set; }
        public string newShipDate { get; set; }
        public string customerName { get; set; }
        public string customerAddress1 { get; set; }
        public string customerAddress2 { get; set; }
        public string customerCity { get; set; }
        public string customerState { get; set; }
        public string customerPostalCode { get; set; }
        public string orderType { get; set; }
        public Shippinginfo shippingInfo { get; set; }
        public string packingSlipUrl { get; set; }
        public Warehouse warehouse { get; set; }
        public Product[] products { get; set; }
        public Shipto shipTo { get; set; }
    }

    public class Shippinginfo
    {
        public string shipSpeed { get; set; }
        public string carrierCode { get; set; }
        public List<Shipments> parcelShipment { get; set; }
    }
    public class Shipments
    {
        public string trackingNo { get; set; }
        public double weight { get; set; }
        public double volume { get; set; }
        public List<Product> items { get; set; }
        public ParcelSize size { get; set; } = ParcelSize.small;

       
    }
    public class Warehouse
    {
        public string id { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
    }

    public class Address
    {
        public string name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string postalCode { get; set; }
    }

    public class Shipto
    {
        public string name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public object address3 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string postalCode { get; set; }
        public string phoneNumber { get; set; }
    }

    public class Product
    {
        public string partNumber { get; set; }
        public string quantity { get; set; }
        public float price { get; set; }
        public object _event { get; set; }
     
    }

}
