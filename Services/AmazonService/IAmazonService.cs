using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Chameleon.Services.ServiceUtil;
using Chameleon.Models;

namespace Chameleon.Services.AmazonService
{
    public interface IAmazonService
    {
        public Task<Hashtable> InsertAmazonOrder(SearchType SearchType, List<string> SoNums);
        public Task<Hashtable> GetAmazonOrders(string startDate, string endDate);
        public Task<dynamic> GetErrorPo();
        public Task<dynamic> GetAmazonMissingPO();
    }
}
