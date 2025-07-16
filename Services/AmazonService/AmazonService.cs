using Chameleon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chameleon.Services.AmazonService.AmazonLib;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using Chameleon.Services.ServiceUtil;
using Chameleon.DTOs.Amazon;
using Chameleon.DTOs.Amazon.orderDS;
using Chameleon.DTOs.Amazon.order;
using System.Globalization;

namespace Chameleon.Services.AmazonService
{
    public class AmazonService : IAmazonService
    {
        private readonly KOALAContext _kc;
        private readonly Amazon _amazon;
        private readonly UtilMethods _utilMethods;
        public AmazonService(KOALAContext kc)
        {
            _kc = kc;
            _amazon = new Amazon();
            _utilMethods = new UtilMethods(kc);
        }

        public async Task<Hashtable>InsertAmazonOrder(SearchType searchType, List<string> poNums)
        {
            List<AMZDSOrder> amzDsOrders = new List<AMZDSOrder>();
            List<AMZDirOrder> amzDirOrders = new List<AMZDirOrder>();
            Hashtable apiResponse = new Hashtable();
            Hashtable resCollector = new Hashtable();
            List<List<string>> succeed = new List<List<string>>();
            List<List<string>> fail = new List<List<string>>();
            resCollector.Add("succeed", succeed);
            resCollector.Add("fail", fail);

            KoSoT desDropship = _kc.KoSoTs.Where(x => x.CustomerId == 5 )?.OrderByDescending(x => x.CustOrdTime).FirstOrDefault();
            KoSoT desDirFF = _kc.KoSoTs.Where(x => x.CustomerId == 2 || x.CustomerId == 4)?.OrderByDescending(x => x.CustOrdTime).FirstOrDefault();
            List<SoError> errors = _kc.SoErrors.ToList();
            if(searchType == SearchType.Date)
            {
                ////Dropship
                //if (desDropship != null && desDropship.CustOrdTime != null)
                //{
                //    string fromDate = desDropship.CustOrdTime.Value.ToUniversalTime().ToString("o");
                //    string toDate = DateTime.Now.ToUniversalTime().ToString("o");
                //    amzDsOrders = await _amazon.PoProcess.GetDSOrderListByDate(fromDate, toDate);
                //}
                //else
                //{
                //    string fromDate = DateTime.Now.AddDays(-1).ToString("o");
                //    string toDate = DateTime.Now.ToUniversalTime().ToString("o");
                //    amzDsOrders = await _amazon.PoProcess.GetDSOrderListByDate(fromDate, toDate);
                //}

                // API Logic
                //if (desDirFF != null && desDirFF.CustOrdTime != null)
                //{
                //    string fromDate = desDirFF.CustOrdTime.Value.ToUniversalTime().ToString("o");
                //    string toDate = DateTime.Now.ToUniversalTime().ToString("o");
                //    apiResponse = await _amazon.PoProcess.GetDirOrderListByDate(fromDate, toDate);
                //    if (apiResponse.ContainsKey(true))
                //    { 
                //        amzDirOrders = (List<AMZDirOrder>)apiResponse[true];
                //    }
                //    else
                //    {
                //        resCollector.Add("error response", "Wrong response type!");
                //        return resCollector;
                //    }
                //}

                //For Edi logic
                if (desDirFF != null)
                {
                    string fromDate = desDirFF.SoDate.AddHours(-8).ToString("o");
                    string toDate = DateTime.Now.AddHours(-1).ToUniversalTime().ToString("o");
                    apiResponse = await _amazon.PoProcess.GetDirOrderListByDate(fromDate, toDate, PurchaseOrderState.New);

                    if (apiResponse.ContainsKey(true))
                    {
                        amzDirOrders = (List<AMZDirOrder>)apiResponse[true];
                    }
                    else
                    {
                        resCollector.Add("error response", "Wrong response type!");
                        return resCollector;
                    }
                }
                else
                {
                    string fromDate = DateTime.Now.AddDays(-1).ToString("o");
                    string toDate = DateTime.Now.ToUniversalTime().ToString("o");
                    if (apiResponse.ContainsKey(true))
                    { 
                        amzDirOrders = (List<AMZDirOrder>)apiResponse[true];
                    }
                    else
                    {
                        resCollector.Add("error response", "Wrong response type!");
                        return resCollector;
                    }
                }
            }
            else
            {
                apiResponse = await _amazon.PoProcess.GetDirOdersListByPONum(poNums);
                if (apiResponse.ContainsKey(true))
                {
                    amzDirOrders = (List<AMZDirOrder>)apiResponse[true];
                }
                else
                {
                    resCollector.Add("error response", "Wrong response type!");
                    return resCollector;
                }
            }
            //amzDirOrders = amzDirOrders.FindAll(x => x.purchaseOrderState == "New");
            if (amzDirOrders.Count == 0)
                return resCollector;

            List<BpmItem> koItems = await _kc.BpmItems.ToListAsync();
            List<NsIcr> amzSKUs = await _kc.NsIcrs.Where(x => x.CustomerId == 2 || x.CustomerId == 4 || x.CustomerId == 5).ToListAsync();
            List<BpmLocation> bpmLocations = await _kc.BpmLocations.ToListAsync();
            List<ShipVium> koShipvias = await _kc.ShipVia.ToListAsync();
            List<AdAfcid> koAdAFCIDAll = _kc.AdAfcids.Where(x => x.CustomerId == 2 || x.CustomerId == 4).ToList();
            List<SoError> poErrors = new List<SoError>();
            List<KoSoT> koSoTs = new List<KoSoT>();
            List<Models.Country> countries = _kc.Countries.ToList();

            try
            {
                foreach (AMZDirOrder dirOrder in amzDirOrders)
                {
                    bool isUnknownField = false;
                    if (_kc.KoSoTs.Any(x => x.PoNo == dirOrder.purchaseOrderNumber))
                        continue;
                    // Set Amazon Direct KoSot up.
                    KoSoT koSoT = new KoSoT();
                    if (dirOrder.orderDetails.sellingParty.partyId == "BEWQ0")  // "BEWQ0" is direct order, vender ID
                        koSoT.CustomerId = 2; //Dir
                    else
                        koSoT.CustomerId = 4; //DI
                    koSoT.VendorCode = dirOrder.orderDetails.sellingParty.partyId;
                    koSoT.PoNo = dirOrder.purchaseOrderNumber;
                    koSoT.SoDate = dirOrder.orderDetails.POLocalDate;
                    koSoT.CustOrdTime = dirOrder.orderDetails.POLocalDate;
                    #region Set FC ID	
                    var afcID = koAdAFCIDAll.Find(x => x.FcAid == dirOrder.orderDetails.shipToParty.partyId);
                    if (afcID == null)
                    {
                        afcID = new AdAfcid();
                        afcID.CustomerId = koSoT.CustomerId;
                        afcID.Country = "US";
                        afcID.FcAid = dirOrder.orderDetails.shipToParty.partyId;

                        _kc.AdAfcids.Add(afcID);
                        _kc.SaveChanges();

                        string errDetail = $"Unknown AFC ID: \"{dirOrder.orderDetails.shipToParty.partyId}\" Related DB: \"ord.AdAFCID\"";
                        _utilMethods.AddInvalidation(poErrors, errDetail, null, null, ErrorType.NotFoundFromDB, koSoT.CustomerId, ProcessType.GetOrder);

                        koAdAFCIDAll = _kc.AdAfcids.Where(x => x.CustomerId == 2 || x.CustomerId == 4).ToList();
                        afcID = koAdAFCIDAll.Find(x => x.FcAid == dirOrder.orderDetails.shipToParty.partyId);
                        isUnknownField = true;
                    }

                    koSoT.ShipToAfcId = afcID.AmazonFcId;
                    koSoT.ShipToName = afcID.FcName;
                    koSoT.Address1 = afcID.Address1;
                    koSoT.Address2 = afcID.Address2;
                    koSoT.Address3 = afcID.Address3;
                    koSoT.City = afcID.City;
                    koSoT.State = afcID.State;
                    koSoT.Zip = afcID.Zip;
                    koSoT.Country = afcID.Country;
                    #endregion

                    koSoT.AddedDate = DateTime.Now.Date;
                    koSoT.Source = "API";

                    string[] words = { "--" };
                    string[] splitWindowDate = dirOrder.orderDetails.shipWindow.Split(words, StringSplitOptions.None);
                    DateTime windowStart = DateTime.ParseExact(splitWindowDate[0], "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture);
                    DateTime windowEnd = DateTime.ParseExact(splitWindowDate[1], "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture); ;
                    koSoT.ShipWindowStart = windowStart;
                    koSoT.ShipWindowEnd = windowEnd;
                    koSoT.ExpShipDate = windowEnd;

                    #region Items
                    foreach (Items item in dirOrder.orderDetails.items)
                    {
                        KoSoD koSoD = new KoSoD();

                        if (koSoT.CustomerId == 4) // DI
                        {
                            koSoD.ShipFromWhId = 2; //AMZCN}
                            koSoD.ShipViaId = 14; // LTL-AMZ

                        }
                        else
                        {
                            koSoD.ShipViaId = 14; // LTL-AMZ
                            koSoD.ShipFromWhId = 32; //TBD
                        }

                        int? item_id = amzSKUs.Find(x => x.CustSku == item.vendorProductIdentifier)?.ItemNoId;
                        if (item_id == null)
                        {
                            string errDetail = $"Unknown Customer SKU: \"{item.vendorProductIdentifier}\" Related DB: \"ord.NsICR\"";
                            _utilMethods.AddInvalidation(poErrors, errDetail, dirOrder.purchaseOrderNumber, item.vendorProductIdentifier, ErrorType.NotFoundFromDB, koSoT.CustomerId, ProcessType.GetOrder);
                            koSoD.ItemNoId = 1879; // Unknown Cust SKU
                            isUnknownField = true;
                        }
                        else
                        {
                            koSoD.ItemNoId = item_id.Value;
                        }
                        koSoD.CustSku = item.vendorProductIdentifier;
                        koSoD.UnitPrice = Convert.ToDecimal(item.netCost.amount);
                        koSoD.OrderStatusId = 1;
                        koSoD.QtyOrdered = item.orderedQuantity.amount;
                        koSoD.LastModTime = DateTime.Now.Date;
                        koSoD.KoLineNo = Convert.ToInt32(item.itemSequenceNumber);
                        //koSoD.NsSyncTime = DateTime.Now;
                        koSoT.KoSoDs.Add(koSoD);
                    }
                    #endregion

                    if (isUnknownField)
                    {
                        ((List<List<string>>)resCollector["fail"]).Add(new List<string>() { koSoT.PoNo });
                    }  
                    else
                    {
                        ((List<List<string>>)resCollector["succeed"]).Add(new List<string>() { koSoT.PoNo });
                    }
                    koSoTs.Add(koSoT);
                }

                foreach (AMZDSOrder dsOrder in amzDsOrders)
                {
                    if (_kc.KoSoTs.Any(x => x.PoNo == dsOrder.purchaseOrderNumber))
                        continue;
                    KoSoT koSoT = new KoSoT();
                    koSoT.CustomerId = 5;
                    koSoT.PoNo = dsOrder.purchaseOrderNumber;
                    koSoT.IoNo = dsOrder.orderDetails.customerOrderNumber;
                    koSoT.SoDate = dsOrder.orderDetails.POLocalDate;
                    koSoT.ShipToName = dsOrder.orderDetails.shipToParty.name;
                    koSoT.Address1 = dsOrder.orderDetails.shipToParty.addressLine1;
                    koSoT.Address2 = dsOrder.orderDetails.shipToParty.addressLine2;
                    koSoT.Address3 = dsOrder.orderDetails.shipToParty.addressLine3;
                    koSoT.City = dsOrder.orderDetails.shipToParty.city;
                    koSoT.State = dsOrder.orderDetails.shipToParty.stateOrRegion;
                    koSoT.Zip = dsOrder.orderDetails.shipToParty.postalCode;
                    koSoT.CustOrdTime = dsOrder.orderDetails.POLocalDate;
                    koSoT.AddedDate = DateTime.Now.Date;
                    koSoT.Source = "API";
                    koSoT.Country = _utilMethods.CountryCodeToName(dsOrder.orderDetails.shipToParty.countryCode, CountryMode.Alpha2, countries);
                    koSoT.ExpShipDate = dsOrder.orderDetails.shipmentDetails.shipmentDates.requiredShipDate.ToLocalTime();
                    var koShipVis = koShipvias.Find(x => x.SvcAmazon == dsOrder.orderDetails.shipmentDetails.shipMethod);
                    if (koShipVis == null)
                    {
                        string errDetail = $"Unknown Ship Speed: \"{dsOrder.orderDetails.shipmentDetails.shipMethod}\" Related DB: \"ord.shipvia\"";
                        _utilMethods.AddInvalidation(poErrors, errDetail, dsOrder.purchaseOrderNumber, null, ErrorType.NotFoundFromDB, koSoT.CustomerId, ProcessType.GetOrder);
                        continue;
                    }
                    int? locId = bpmLocations.Find(x => x.LocIdAmazon == dsOrder.orderDetails.shipFromParty.partyId).LocationId;
                    if (locId == null)
                    {
                        string errDetail = $"Unknown Location ID: \"{dsOrder.orderDetails.shipFromParty.partyId}\"! Related DB: \"ord.BPMLocation\"";
                        _utilMethods.AddInvalidation(poErrors, errDetail, dsOrder.purchaseOrderNumber, null, ErrorType.NotFoundFromDB, koSoT.CustomerId, ProcessType.GetOrder);
                        continue;
                    }

                    foreach (ItemDetail item in dsOrder.orderDetails.items)
                    {
                        KoSoD koSoD = new KoSoD();
                        koSoD.KoSoT = koSoT;
                        koSoD.KoSoTId = koSoT.KoSoTId;
                        koSoD.ShipFromWhId = locId.Value;
                        koSoD.ShipViaId = koShipVis.ShipViaId;
                        int? item_id = amzSKUs.Find(x => x.CustSku == item.vendorProductIdentifier)?.ItemNoId;
                        if (item_id == null)
                        {
                            string errDetail = $"Unkown Customer SKU: \"{item.vendorProductIdentifier}\" Related DB: \"ord.NsICR\"";
                            _utilMethods.AddInvalidation(poErrors, errDetail, dsOrder.purchaseOrderNumber, item.vendorProductIdentifier, ErrorType.NotFoundFromDB, koSoT.CustomerId, ProcessType.GetOrder);
                            continue;
                        }
                        koSoD.ItemNoId = item_id.Value;
                        koSoD.CustSku = item.vendorProductIdentifier;
                        koSoD.UnitPrice = Convert.ToDecimal(item.netPrice.amount);
                        koSoD.OrderStatusId = 1;
                        koSoD.QtyOrdered = item.orderedQuantity.amount;
                        koSoD.KoLineNo = item.itemSequenceNumber;
                        koSoD.LastModTime = DateTime.Now;
                        koSoD.KoLineNo = item.itemSequenceNumber;
                        koSoT.KoSoDs.Add(koSoD);
                    }
                    if (koSoT.KoSoDs.Count == dsOrder.orderDetails.items.Count)
                        koSoTs.Add(koSoT);
                    else
                    {
                        continue;
                    }
                }

                foreach (KoSoT sot in koSoTs)
                {
                    if (_kc.SoErrors.Any(x => x.PoNo == sot.PoNo) && _kc.SoErrors.Any(x => x.ProcessId == ((int)ProcessType.GetOrder)))
                    {
                        SoError errSo = await _kc.SoErrors.FirstOrDefaultAsync(x => x.PoNo == sot.PoNo);
                        errSo.IsResolved = true;
                        errSo.ResolvedTime = DateTime.Now;
                        _kc.SaveChanges();
                    }
                }
                if (koSoTs.Count > 0)
                {
                    await _kc.KoSoTs.AddRangeAsync(koSoTs);
                    await _kc.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                string errDetail = $"Failed Sync with Amazon PO.";
                _utilMethods.AddInvalidation(poErrors, errDetail, null, null, ErrorType.Unknown, null, ProcessType.GetOrder);
                poErrors.RemoveAll(x => errors.Select(z => z.PoNo).Contains(x.PoNo) && errors.Select(z => z.CustSku).Contains(x.CustSku));
                _kc.SoErrors.AddRange(poErrors);
                _kc.SaveChanges();

                return resCollector;
            }
            if (poErrors.Count > 0)
            {
               poErrors.RemoveAll(x => errors.Select(z => z.PoNo).Contains(x.PoNo) && errors.Select(z => z.CustSku).Contains(x.CustSku));
               _kc.SoErrors.AddRange(poErrors);
               _kc.SaveChanges();

            }
            return resCollector;
        }
        public async Task<Hashtable> GetAmazonOrders(string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);
            end = end.AddHours(24);
            DateTime? dropShipLastSyncTime = null;
            DateTime? dirLastSyncTime = null;

            //KoSoT sotsDS = _kc.KoSoTs.Where(x => x.CustomerId == 5)?.OrderByDescending(x => x.CustOrdTime).FirstOrDefault();
            //if (sotsDS != null && sotsDS.CustOrdTime != null)
            //{
            //    dropShipLastSyncTime = sotsDS.CustOrdTime.Value.ToUniversalTime();
            //}
            //KoSoT sotsDir = _kc.KoSoTs.Where(x => x.CustomerId == 2 || x.CustomerId == 4)?.OrderByDescending(x => x.CustOrdTime).FirstOrDefault();
            //if (sotsDir != null && sotsDir.CustOrdTime != null)
            //{
            //    dirLastSyncTime = sotsDir.CustOrdTime.Value.ToUniversalTime();
            //}

            KoSoT sotsDir = _kc.KoSoTs.Where(x => x.CustomerId == 2 || x.CustomerId == 4)?.OrderByDescending(x => x.SoDate).FirstOrDefault();
            if (sotsDir != null)
            {
                dirLastSyncTime = sotsDir.SoDate;
            }

            Hashtable hashtable = new Hashtable();

            var koSoTs = await (from kot in _kc.KoSoTs
                                join kod in _kc.KoSoDs on kot.KoSoTId equals kod.KoSoTId
                                join loc in _kc.BpmLocations on kod.ShipFromWhId equals loc.LocationId
                                join via in _kc.ShipVia on kod.ShipViaId equals via.ShipViaId
                                join item in _kc.BpmItems on kod.ItemNoId equals item.ItemNoId
                                join afc in _kc.AdAfcids on kot.ShipToAfcId equals afc.AmazonFcId
                                join status in _kc.SoStatusKos on kod.OrderStatusId equals status.SoStatusKoId
                                join cust in _kc.Customers on kot.CustomerId equals cust.CustomerId
                                //join inv in _kc.InvRealTimes on new
                                //{
                                //    key1 = kod.ShipFromWhId,
                                //    key2 = kod.ItemNoId
                                //}
                                //equals
                                //new
                                //{
                                //    key1 = inv.LocationId,
                                //    key2 = inv.ItemNoId
                                //}
                                where (
                                //kot.CustomerId == 5 || 
                                kot.CustomerId == 2 || kot.CustomerId == 4)
                                && (kot.SoDate >= start && kot.SoDate <= end)
                                select new
                                {                                
                                    KodId = kod.KoSoDId,
                                    customer = cust.CustName,
                                    OrderNo = kot.PoNo,
                                    sku = item.ItemName,
                                    date = kot.SoDate,
                                    shipWindowStart = kot.ShipWindowStart,
                                    shipWindowEnd = kot.ShipWindowEnd,
                                    shipDate = kot.ExpShipDate,
                                    carrier = via.ShipViaName,
                                    WareHouse = loc.LocName,
                                    fcaId = afc.FcAid,
                                    qty = kod.QtyOrdered,
                                    unitePrice = kod.UnitPrice,
                                    totalPrice = kod.QtyOrdered * kod.UnitPrice,
                                    sorce = kot.Source,
                                    //date = kot.CustOrdTime,
                                    //Name = kot.ShipToName,
                                    //OrderStatus = status.StatusKo,
                                    //qtyAvaliale = inv.QtyAvail,
                                    //dropShipLastSyncTime = dropShipLastSyncTime,
                                    //dirLastSyncTime = dirLastSyncTime
                                }
                                ).ToListAsync();

            hashtable.Add("data", koSoTs);
            hashtable.Add("dropShipLastSyncTime", dropShipLastSyncTime);
            hashtable.Add("dirLastSyncTime", dirLastSyncTime);
            return hashtable;
        }
        public async Task<dynamic> GetErrorPo()
        {
            var poErrors = await _kc.SoErrors
           .Include(x => x.Customer)
           .Include(x => x.ErrorCat)
           .Include(x => x.Process)
           .Where(x => (x.CustomerId == 2 || x.CustomerId == 4|| x.CustomerId == 5))
           .Select(x => new
           {
               action = x.Process.ProcessType,
               errorCat = x.ErrorCat.CatType,
               poNo = x.PoNo,
               customer = x.Customer.CustName,
               custSKU = x.CustSku,
               detail = x.Detail,
               isReSolved = x.IsResolved,
               createdTime = x.CeatedTime,
               resolvedTime = x.ResolvedTime
           }
           )
           .ToListAsync();
            return poErrors;
        }

        public async Task<dynamic> GetAmazonMissingPO()
        {
            DateTime standard = new DateTime(2021, 11, 20, 0, 0, 0);
            DateTime beforeTime = DateTime.Now.AddMinutes(-30);
            var koSots = await _kc.KoSoTs
            .Include(x => x.KoSoDs)
            .Include(x => x.Customer.Market)
            .Where(x => (x.AddedDate > standard && x.CustOrdTime > standard && x.CustOrdTime < beforeTime) && x.KoSoDs.Any(y => y.NsSyncTime == null) && x.Source == "API" && (x.CustomerId == 2 || x.CustomerId == 4))
            .Select(x => new
            {
                customer = x.Customer.CustName,
                poNo = x.PoNo,
                custOrdTime = x.CustOrdTime

            })
            //.Where(x => x.AddedDate > standard && x.KoSoDs.Any(y => y.NsSyncTime == null) && (x.Source == "API" || x.Source == "EDI"))
            //.Where(x => x.AddedDate > standard && x.KoSoDs.Count > 0 && x.Source == "EDI")
            //.Where(x => x.AddedDate > standard && x.PoNo == "MxhXcJPlV")
            .ToListAsync();

            return koSots;
        }          
    }
}
