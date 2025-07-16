using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Chameleon.Models;
using SuitetalkerService;
using Chameleon.Services.ServiceUtil;
namespace Chameleon.Services.SuiteTalkerService.SuiteTalkLib
{
    public class SuiteTalkerUtil : SuiteTalkerAuth
    {
        public SuiteTalkerUtil(bool isProduction) : base(isProduction)
        {

        }
        
        public async Task<bool> GetSalesListByPo(DateTime onAfterTime)
        {
                SearchEnumMultiSelectField _type = new SearchEnumMultiSelectField()
                {
                    @operator = SearchEnumMultiSelectFieldOperator.anyOf,
                    operatorSpecified = true,
                    searchValue = new string[] { "_salesOrder" },
                };

                SearchDateField _dateCreated = new SearchDateField()
                {
                    @operator = SearchDateFieldOperator.onOrAfter,
                    operatorSpecified = true,
                    searchValue = onAfterTime,
                    searchValueSpecified = true,
                };

                SearchTextNumberField _poNo = new SearchTextNumberField()
                {
                    @operator = SearchTextNumberFieldOperator.equalTo,
                    operatorSpecified = true,
                    searchValue = "68QRXOXY"
                };

                TransactionSearchBasic transactionSearchBasic = new TransactionSearchBasic()
                {
                    type = _type,
                    dateCreated = _dateCreated,
                    otherRefNum = _poNo,
                    //customFieldList = new SearchCustomField[] { _marketPlace },
                    mainLine = new SearchBooleanField() { searchValue = true, searchValueSpecified = true },
                };

                TransactionSearchRow transactionSearchRow = new TransactionSearchRow()
                {
                    basic = new TransactionSearchRowBasic
                    {
                        internalId = new SearchColumnSelectField[] { new SearchColumnSelectField() },
                        entity = new SearchColumnSelectField[] { new SearchColumnSelectField() },                   // Customer ID
                        otherRefNum = new SearchColumnTextNumberField[] { new SearchColumnTextNumberField() },      // PO #
                    }
                };

                TransactionSearchAdvanced transactionSearchAdvanced = new TransactionSearchAdvanced
                {
                    criteria = new TransactionSearch() { basic = transactionSearchBasic },
                    columns = transactionSearchRow
                };

                searchResponse response = await Client.searchAsync(CreateTokenPassport(), null, Partner, GetSearchPreferences(), transactionSearchAdvanced);

            if (response.searchResult.status.isSuccess)
                return response.searchResult.totalRecords > 0;
            return false;

        }

        public async Task<Dictionary<int, List<string>>> GetSalesListByMarket(List<int> nsMarkets, DateTime onAfterTime)
        {
            //SetSearchPreferences(false, true);
            Dictionary<int, List<string>> result = new Dictionary<int, List<string>>();
            try
            {
                SearchEnumMultiSelectField _type = new SearchEnumMultiSelectField()
                {
                    @operator = SearchEnumMultiSelectFieldOperator.anyOf,
                    operatorSpecified = true,
                    searchValue = new string[] { "_salesOrder" },
                };

                SearchDateField _dateCreated = new SearchDateField()
                {
                    @operator = SearchDateFieldOperator.onOrAfter,
                    operatorSpecified = true,
                    searchValue = onAfterTime,
                    searchValueSpecified = true,
                };

                SearchMultiSelectCustomField _marketPlace = new SearchMultiSelectCustomField()
                {
                    scriptId = "cseg_marketplace",
                    @operator = SearchMultiSelectFieldOperator.anyOf,
                    operatorSpecified = true,
                    searchValue = nsMarkets.Select(x => new ListOrRecordRef { internalId = x.ToString() }).ToArray(),
                };

                TransactionSearchBasic transactionSearchBasic = new TransactionSearchBasic()
                {
                    type = _type,
                    dateCreated = _dateCreated,
                    customFieldList = new SearchCustomField[] { _marketPlace },
                    mainLine = new SearchBooleanField() { searchValue = true, searchValueSpecified = true },
                };

                TransactionSearchRow transactionSearchRow = new TransactionSearchRow()
                {
                    basic = new TransactionSearchRowBasic
                    {
                        internalId = new SearchColumnSelectField[] { new SearchColumnSelectField() },
                        entity = new SearchColumnSelectField[] { new SearchColumnSelectField() },                   // Customer ID
                        otherRefNum = new SearchColumnTextNumberField[] { new SearchColumnTextNumberField() },      // PO #
                    }
                };

                TransactionSearchAdvanced transactionSearchAdvanced = new TransactionSearchAdvanced
                {
                    criteria = new TransactionSearch() { basic = transactionSearchBasic },
                    columns = transactionSearchRow
                };

                searchResponse response = await Client.searchAsync(CreateTokenPassport(), null, Partner, GetSearchPreferences(), transactionSearchAdvanced);
                SearchResult searchResult = response.searchResult;
                if (searchResult.status.isSuccess)
                {
                    if (searchResult.totalRecords > 0)
                    {
                        for (int i = 1; i <= searchResult.totalPages; i++)
                        {
                            foreach (TransactionSearchRow row in searchResult.searchRowList)
                            {
                                if (row.basic.entity == null || row.basic.otherRefNum == null)
                                    continue;

                                var cust = Convert.ToInt32(row.basic.entity[0].searchValue.internalId);
                                var poNo = row.basic.otherRefNum[0].searchValue;
                                if (poNo == "68QRXOXY")
                                {
                                }
                                if (result.ContainsKey(cust) == false)
                                    result.Add(cust, new List<string> { poNo });
                                else
                                    result[cust].Add(poNo);
                                
                            }
                            if (i + 1 <= searchResult.totalPages)
                            {
                                searchMoreWithIdResponse responseMore = await Client.searchMoreWithIdAsync(CreateTokenPassport(), null, Partner, GetSearchPreferences(), response.searchResult.searchId, i + 1);
                                searchResult = responseMore.searchResult;
                            }
                        }
                    }
                }
                return result;
            }
            catch //(Exception ex)
            {
                return result;
            }
        }
        public static string AddressRegex(string addr)
        {
            
            if (string.IsNullOrEmpty(addr))
                return addr;
            addr = Regex.Replace(addr, @"[^0-9a-zA-Z]+", " ");
            return addr.Length > 55 ? addr.Substring(0, 55) : addr;
        }
        public int CountryNameToCode(string name, List<Models.Country> countries)
        {
            var country = countries.Find(x => string.Compare(x.FullName, name, true) == 0
                                                || string.Compare(x.Alpha2, name, true) == 0
                                                || string.Compare(x.Alpha3, name, true) == 0);
            if (country == null)
                return -1;
            return country.NsIntId.Value;
        }

        //public string CountryCodeToName(SuitetalkerService.Country code, CountryMode isRerunMode, List<Models.Country> _Countries)
        //{
        //    try
        //    {
        //        var country = _Countries.Find(x => x.NsIntId == (int)code);
        //        if (country == null)
        //            return null;

        //        switch (isRerunMode)
        //        {
        //            case CountryMode.FullName:
        //                return country.FullName;
        //            case CountryMode.Alpha2:
        //                return country.Alpha2;
        //            case CountryMode.Alpha3:
        //                return country.Alpha3;
        //        }
        //    }
        //    catch { }
        //    return null;
        //}
        //public SearchResult SearchMoreWithId(string searchId, int pageIndex)
        //{
        //    SearchResult searchResult = null;
        //    int retryCnt = 0;
        //retry:
        //    try
        //    {
        //        searchResult = Service.searchMoreWithId(searchId, pageIndex);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (_ServiceRetry(ref retryCnt))
        //            goto retry;

        //        searchResult = new SearchResult();
        //        searchResult.status = new Status();
        //        searchResult.status.statusDetail = new StatusDetail[]
        //        {
        //            new StatusDetail() { code = StatusDetailCodeType.UNEXPECTED_ERROR, message = ex.Message }
        //        };
        //    }
        //    return searchResult;
        //}
    }
}
