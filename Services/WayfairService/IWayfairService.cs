using Chameleon.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chameleon.Services.ServiceUtil;
namespace Chameleon.Services.WayfairService
{
    public interface IWayfairService
    {
        Task<bool> InsertWayfairOrder(SearchType searchType, List<string> SoNums);
        Task<Hashtable> GetWFOrders(string startDate, string endDate);
        Task<dynamic> GetErrorSo();
    }
}
