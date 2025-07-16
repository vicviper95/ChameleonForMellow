using SuitetalkerService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Services.SuiteTalkerService
{
    public interface ISuiteTalkerService
    {
        //public Task<searchResponse> TestNsClient();
        //public Task<bool> TestHasPo();
        public Task<Hashtable> InsertPoToNs();
        Task<List<SearchRow>> GetDuplicateLineWalmart();
    }
}
