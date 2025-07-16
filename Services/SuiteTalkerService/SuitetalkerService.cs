using AutoMapper.Configuration;
using Chameleon.Models;
using Chameleon.Services.ServiceUtil;
using Chameleon.Services.SuiteTalkerService.SuiteTalkLib;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuitetalkerService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Services.SuiteTalkerService
{
	public class SuiteTalkerService : ISuiteTalkerService
	{
		private readonly KOALAContext _kc;
		private readonly SuiteTalker _suiteTalker;

        public SuiteTalkerService(KOALAContext kc)
		{
            _kc = kc;
            _suiteTalker = new SuiteTalker(true, kc);

        }
        public async Task<Hashtable> InsertPoToNs()
        {
            Hashtable resCollector = new Hashtable();
            List<List<string>> succeed = new List<List<string>>();
            Hashtable fail = new Hashtable();
            resCollector.Add("succeed", succeed);
            resCollector.Add("fail", fail);
           
            try
            {
                SalesOrderProcess soProcess = _suiteTalker.salesOrderProcess;
                DateTime standard = new DateTime(2021, 11, 20, 0, 0, 0);
                DateTime beforeTime = DateTime.Now.AddMinutes(-30);
                List<KoSoT> koSots = await _kc.KoSoTs
                .Include(x => x.KoSoDs)
                .Include(x => ((KoSoD)x.KoSoDs).ItemNo)
                .Include(x => ((KoSoD)x.KoSoDs).ItemNo.NsIcrs)
                .Include(x => ((KoSoD)x.KoSoDs).ShipFromWh)
                .Include(x => ((KoSoD)x.KoSoDs).ShipVia)
                .Include(x => x.Customer.Market)
                .Where(x => (x.AddedDate > standard && x.CustOrdTime > standard && x.CustOrdTime < beforeTime) && x.KoSoDs.Any(y => y.NsSyncTime == null) && x.Source == "API" && (x.CustomerId == 2 || x.CustomerId==4))
                //.Where(x => x.AddedDate > standard && x.KoSoDs.Any(y => y.NsSyncTime == null) && (x.Source == "API" || x.Source == "EDI"))
                //.Where(x => x.AddedDate > standard && x.KoSoDs.Count > 0 && x.Source == "EDI")
                //.Where(x => x.AddedDate > standard && x.PoNo == "MxhXcJPlV")
                .ToListAsync();

                List<int> poMarkets = koSots.Select(x => (int)x.Customer.MarketId).Distinct().ToList();
                Dictionary<int, List<string>> orders = await soProcess.GetSalesListByMarket(poMarkets, DateTime.Now.AddDays(-5));
                List<KoSoT> existData = koSots.FindAll(x => orders.ContainsKey(x.Customer.NsIntId) && orders[x.Customer.NsIntId].Contains(x.PoNo));
                List<KoSoD> ukoSod = new List<KoSoD>();
                DateTime syncTime = DateTime.Now;
                foreach (var koSoT in existData)
                {
                    foreach (var koSoD in koSoT.KoSoDs)
                        koSoD.NsSyncTime = syncTime;
                    ukoSod.AddRange(koSoT.KoSoDs);
                }
                    //_kc.KoSoDs.AddRange(existData);
                await _kc.BulkUpdateAsync(ukoSod);
                ukoSod.Clear();
                koSots.RemoveAll(x => existData.Select(z => z.KoSoTId).Contains(x.KoSoTId));

                Hashtable result = await _suiteTalker.salesOrderProcess.CreateSalesOrder(koSots, resCollector);
                result.Add("totalTry", koSots.Count());
                return result;
            }
            catch (Exception e)
            {
                resCollector.Add("error response", e.Message);
                return resCollector;
            }
        }

        public async Task<List<SearchRow>> GetDuplicateLineWalmart()
        {
            List<SearchRow> orders = await _suiteTalker.salesOrderProcess.GetDuplicateLineWalmart();
            return orders;
        }



        //public async Task<searchResponse> TestNsClient()
        //{
        //    searchResponse response =  await _suiteTalker.salesOrderProcess.TestNsClient();
        //    return response;
        //}
        //public async Task<bool> TestHasPo()
        //{
        //    bool response = await _suiteTalker.salesOrderProcess.TestHasPo();
        //    return response;
        //}

    }
}
