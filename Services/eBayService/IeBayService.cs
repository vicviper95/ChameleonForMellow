using Chameleon.DTOs.eBay;
using Chameleon.ebay.sellFulfillment;
using eBay.ApiClient.Auth.OAuth2.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Services.eBayService
{
    public interface IeBayService
    {
        public bool saveNotification(Rootobject body);
        public Task<Hashtable> ebayGetOrders();
        public Task<EbayOrder> ebayGetOrder(string poNo);
        public Task<Hashtable> GeteBayOrders(string startDate, string endDate);
        public Task<dynamic> GetError();
        public Task<Hashtable> Send_eBayShipment();

    }
}
