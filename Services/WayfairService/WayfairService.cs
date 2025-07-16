using Chameleon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using EFCore.BulkExtensions;
using System.Collections;
using Chameleon.DTOs.Wayfair;
using Chameleon.Services.WayfairService.WayfairLib;
using Chameleon.Services.ServiceUtil;

namespace Chameleon.Services.WayfairService
{
    public class WayfairService : IWayfairService
    {
        private readonly KOALAContext _kc;
        private readonly Wayfair _wayfair;
        public WayfairService(KOALAContext kc)
        {
            _kc = kc;
            _wayfair = new Wayfair();
        }
        public async Task<bool> InsertWayfairOrder(SearchType searchType, List<string> PoNums)
        {
            WayfairPO wayfair = _wayfair.PoProcess;
            List<BpmItem> koItems = await _kc.BpmItems.ToListAsync();
            List<NsIcr> WafairSKUs = await _kc.NsIcrs.Where(x => x.CustomerId == 29 || x.CustomerId == 28).ToListAsync();
            List<BpmLocation> bpmLocations = await _kc.BpmLocations.ToListAsync();
            List<ShipVium> koShipvias = await _kc.ShipVia.ToListAsync();
            List<SoError> poErrors = new List<SoError>();
            string strDSOrder = "";

            if (searchType == SearchType.Date)
            {
                KoSoT sots = _kc.KoSoTs.Where(x => x.CustomerId == 29)?.OrderByDescending(x => x.CustOrdTime).FirstOrDefault();
                if (sots != null && sots.CustOrdTime != null)
                {
                    DateTime fromDate = sots.CustOrdTime.Value.ToUniversalTime();
                    strDSOrder = wayfair.GetDropshipSoByDate(fromDate);
                }
                else
                {
                    DateTime fromDate = DateTime.Now.AddDays(-2);
                    strDSOrder = wayfair.GetDropshipSoByDate(fromDate);
                }
            }
            else if (searchType == SearchType.PoNumber)
            {
                strDSOrder = wayfair.GetDropshipSOBySoNum(PoNums);
            }

            if (strDSOrder.Contains("errors"))
            {
                InvalidRes error = JsonSerializer.Deserialize<InvalidRes>(strDSOrder);
                foreach (Error err in error.errors)
                    AddInvalidation(poErrors, err.message, null, null, ErrorType.ErrResponse);
                _kc.SoErrors.AddRange(poErrors);
                _kc.SaveChanges();
                return false;
            }
            else
            {
                SoError errSo = await _kc.SoErrors.FirstOrDefaultAsync(x => x.ErrorCatId == ((int)ErrorType.ErrResponse));
                if (errSo != null)
                {
                    errSo.IsResolved = true;
                    errSo.ResolvedTime = DateTime.Now;
                    _kc.SaveChanges();
                }

            }

            WafairDSOrder dsOrder = JsonSerializer.Deserialize<WafairDSOrder>(strDSOrder);
            Getdropshippurchaseorder[] WFOrders = dsOrder.data.getDropshipPurchaseOrders;
            List<KoSoT> koSoTs = new List<KoSoT>();
            try
            {
                foreach (Getdropshippurchaseorder order in WFOrders)
                {
                    if (_kc.KoSoTs.Any(x => x.PoNo == order.poNumber))
                        continue;
                    KoSoT koSoT = new KoSoT();
                    koSoT.CustomerId = 29; // WF Dropship;
                    koSoT.PoNo = order.poNumber;
                    koSoT.ExpShipDate = Convert.ToDateTime(order.estimatedShipDate).ToUniversalTime();
                    koSoT.SoDate = order.poLocalDate;
                    koSoT.ShipToName = order.customerName;
                    koSoT.Address1 = order.customerAddress1;
                    koSoT.Address2 = order.customerAddress2;
                    koSoT.City = order.customerCity;
                    koSoT.State = order.customerState;
                    koSoT.Zip = order.customerPostalCode;
                    koSoT.Country = "United State";
                    koSoT.CustOrdTime = order.poLocalDate;
                    koSoT.AddedDate = DateTime.Now.Date;
                    koSoT.Source = "API";

                    // need to add DB
                    int? shipViaId = null;
                    if (order.shippingInfo.carrierCode == "FDEG")
                    {
                        if (order.shippingInfo.shipSpeed == "FEDEX_HOME")
                        {
                            shipViaId = 11; //FedEX Home Delivery 
                        }
                        else if (order.shippingInfo.shipSpeed == "GROUND")
                        {
                            shipViaId = 4; //FedEx Ground
                        }
                        else if (order.shippingInfo.shipSpeed == "SECOND_DAY_AIR")
                        {
                            shipViaId = 7; //FedEx 2 Day
                        }
                        else if (order.shippingInfo.shipSpeed == "NEXT_DAY")
                        {
                            shipViaId = 6; //FedEx Standard Overnight
                        }
                        else
                        {
                            string errDetail = $"Unknown Ship Speed: \"{order.shippingInfo.shipSpeed}\" From Fedex! Related DB: \"ord.shipvia\"";
                            AddInvalidation(poErrors, errDetail, order, null, ErrorType.NotFoundFromDB);
                            continue;
                        }
                    }
                    else if (order.shippingInfo.carrierCode == "EXLA")
                    {
                        if (order.shippingInfo.shipSpeed == "CURBSIDE")
                        {
                            shipViaId = 13; //LTL Paperwork Only Carrier Other
                        }
                        else
                        {
                            string errDetail = $"Unknown Ship Speed: \"{order.shippingInfo.shipSpeed}\" From LTL Related DB: \"ord.shipvia\"";
                            AddInvalidation(poErrors, errDetail, order, null, ErrorType.NotFoundFromDB);
                            continue;
                        }
                    }
                    else
                    {
                        string errDetail = $"Unknown Carrier Code: \"{order.shippingInfo.carrierCode}\" Related DB: \"ord.shipvia\"";
                        AddInvalidation(poErrors, errDetail, order, null, ErrorType.NotFoundFromDB);
                        continue;
                    }
                    int? locId = bpmLocations.Find(x => x.LocIdWayfair == order.warehouse.id)?.LocationId;
                    if (locId == null)
                    {
                        string errDetail = $"Unknown Location ID: \"{order.warehouse.id}\"! Related DB: \"ord.BPMLocation\"";
                        AddInvalidation(poErrors, errDetail, order, null, ErrorType.NotFoundFromDB);
                        continue;
                    }
                    foreach (Product item in order.products)
                    {
                        KoSoD koSoD = new KoSoD();
                        koSoD.KoSoT = koSoT;
                        koSoD.KoSoTId = koSoT.KoSoTId;
                        koSoD.ShipFromWhId = locId.Value;
                        koSoD.ShipViaId = shipViaId.Value;
                        int? item_id = WafairSKUs.Find(x => x.CustSku == item.partNumber)?.ItemNoId;
                        if (item_id == null)
                        {
                            string errDetail = $"Unkown Customer SKU: \"{item.partNumber}\" Related DB: \"ord.NsICR\"";
                            AddInvalidation(poErrors, errDetail, order, item, ErrorType.NotFoundFromDB);
                            continue;
                        }
                        koSoD.ItemNoId = item_id.Value;
                        koSoD.CustSku = item.partNumber;
                        koSoD.UnitPrice = Convert.ToDecimal(item.price);
                        koSoD.OrderStatusId = 1;
                        koSoD.QtyOrdered = Convert.ToInt32(item.quantity);
                        koSoD.LastModTime = DateTime.Now;
                        koSoT.KoSoDs.Add(koSoD);
                    }
                    if (koSoT.KoSoDs.Count == order.products.Length)
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
                string errDetail = $"Failed Sync with Wayfair.";
                AddInvalidation(poErrors, errDetail, null, null, ErrorType.NotFoundFromDB);
                _kc.SoErrors.AddRange(poErrors);
                _kc.SaveChanges();
                return false;
            }
            if (poErrors.Count > 0)
            {
                _kc.SoErrors.AddRange(poErrors);
                _kc.SaveChanges();
            }
            return true;
        }
        public async Task<Hashtable> GetWFOrders(string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);
            end = end.AddHours(24);
            DateTime? lastSyncTime = null;
            KoSoT sots = _kc.KoSoTs.Where(x => x.CustomerId == 29)?.OrderByDescending(x => x.CustOrdTime).FirstOrDefault();
            if (sots != null && sots.CustOrdTime != null)
            {
                lastSyncTime = sots.CustOrdTime.Value.ToUniversalTime();
            }
            Hashtable hashtable = new Hashtable();

            var koSoTs = await (from kot in _kc.KoSoTs
                                join kod in _kc.KoSoDs on kot.KoSoTId equals kod.KoSoTId
                                join loc in _kc.BpmLocations on kod.ShipFromWhId equals loc.LocationId
                                join via in _kc.ShipVia on kod.ShipViaId equals via.ShipViaId
                                join item in _kc.BpmItems on kod.ItemNoId equals item.ItemNoId
                                join status in _kc.SoStatusKos on kod.OrderStatusId equals status.SoStatusKoId
                                join inv in _kc.InvRealTimes on new
                                {
                                    key1 = kod.ShipFromWhId,
                                    key2 = kod.ItemNoId
                                }
                                equals
                                new
                                {
                                    key1 = inv.LocationId,
                                    key2 = inv.ItemNoId
                                }
                                where kot.CustomerId == 29 && (kot.CustOrdTime >= start && kot.CustOrdTime <= end)
                                select new
                                {
                                    KodId = kod.KoSoDId,
                                    OrderNo = kot.PoNo,
                                    Name = kot.ShipToName,
                                    Date = kot.CustOrdTime,
                                    ShipDate = kot.ExpShipDate,
                                    SKU = item.ItemName,
                                    Price = kod.UnitPrice,
                                    Carrier = via.ShipViaCode,
                                    WareHouse = loc.LocName,
                                    OrderStatus = status.StatusKo,
                                    qtyAvaliale = inv.QtyAvail,
                                    lastSyncTime = lastSyncTime,
                                }
                                ).ToListAsync();

            hashtable.Add("data", koSoTs);
            hashtable.Add("lastSyncTime", lastSyncTime);
            return hashtable;
        }
        public async Task<dynamic> GetErrorSo()
        {
            var poErrors = await _kc.SoErrors
           .Include(x => x.Customer)
           .Include(x => x.ErrorCat)
           .Include(x => x.Process)
           .Where(x => (x.CustomerId == 29))
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
        public void AddInvalidation(List<SoError> errorApis, string detail, Getdropshippurchaseorder order, Product product, ErrorType errorType)
        {
            SoError errorSo = new SoError();
            errorSo.ProcessId = 1;
            errorSo.CustomerId = 29;
            errorSo.Detail = detail;
            errorSo.ErrorCatId = ((int)errorType);
            errorSo.IsResolved = false;
            errorSo.CeatedTime = DateTime.Now;
            if (errorType == ErrorType.NotFoundFromDB)
            {
                errorSo.PoNo = order.poNumber;
                errorSo.CustSku = product?.partNumber;

            }
            errorApis.Add(errorSo);
        }
    }

}
