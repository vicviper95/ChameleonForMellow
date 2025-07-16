using Chameleon.DTOs.Walmart;
using Chameleon.Services.ServiceUtil;
using SuitetalkerService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Services.WalmartService
{
    public interface IWalmartService
    {
        Task<Hashtable> SearchAndInsert(SearchType type, WmtPos POs, orderLineStatusValueType? status);
        Task<Hashtable> SendTrackingNumber();
        Task<Dictionary<string, List<string>>> FindCancelledPO();
        Task<dynamic> GetASNError();
        Task<Hashtable> GetWmtOrders(string startDate, string endDate);
        Task<dynamic> GetError();
        Task<Hashtable> SendAckOrders();
        Task<dynamic> GetMissingNsSync();
        Task<dynamic> GetPendingAck(string startDate, string endDate);
        Task<dynamic> GetPendingAsn(string startDate, string endDate);
        Task<dynamic> GetPendingCancel();
        Task<bool> GetRetailPrice();

    }
}
