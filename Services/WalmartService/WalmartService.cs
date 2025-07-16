using Chameleon.DTOs.Walmart;
using Chameleon.Models;
using Chameleon.Services.ServiceUtil;
using Chameleon.Services.SuiteTalkerService.SuiteTalkLib;
using Chameleon.Services.WalmartService.WalmartLib;
using EFCore.BulkExtensions;
using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using SuitetalkerService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Chameleon.Services.WalmartService
{
    public class WalmartService : IWalmartService
    {
        private readonly KOALAContext _kc;
        private readonly Walmart _walmart;
        private readonly UtilMethods _utilMethods;
        private readonly SuiteTalker _suiteTalker;
        private readonly ILogger<WalmartService> _logger;
        public WalmartService(KOALAContext kc, ILogger<WalmartService> logger)
        {
            _kc = kc;
            _walmart = new Walmart();
            _utilMethods = new UtilMethods(kc);
            _suiteTalker = new SuiteTalker(false, kc);
            _logger = logger;
        }
        public async Task<Hashtable> SearchAndInsert(SearchType type, WmtPos POs, orderLineStatusValueType? status)
        {
            await InsertWmtItmes();
            Dictionary<string, WmtOrder[]> orderCollector = new Dictionary<string, WmtOrder[]>();
            int total = 0;
            var walmartIds = await _kc.BpmLocations.Where(x => x.LocIdWalmart != null).Select(x => new { x.LocationId, x.LocIdWalmart }).ToListAsync();
            foreach (var loc in walmartIds)
            {
                if (type == SearchType.Date)
                {
                    WmtOrder[] orders;
                    if (status == orderLineStatusValueType.Created)
                    {
                        string start = DateTime.Now.AddDays(-60).ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ssZ");
                        string end = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ssZ");
                        orders = await _walmart.OrderProcess.GetOrdersByDate(start, end, loc.LocIdWalmart, orderLineStatusValueType.Created);
                    }
                    else
                    {
                        _kc.Database.SetCommandTimeout(120);
                        DateTime? max = (await (from sot in _kc.SoTs
                                                join sod in _kc.SoDs on sot.SoTId equals sod.SoTId
                                                join cust in _kc.Customers on sot.CustomerId equals cust.CustomerId
                                                where (
                                                sot.CustomerId == 26)
                                                orderby sot.CustOrderTime descending
                                                select sot
                                          ).FirstOrDefaultAsync()).CustOrderTime;
                        //test
                        //string start = DateTime.Now.AddDays(-4).ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ssZ");
                        //string end = DateTime.Now.AddDays(-2).ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ssZ");

                        string start = max.Value.AddHours(-8).ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ssZ");
                        string end = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ssZ");

                        //string end = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ssZ");

                        orders = await _walmart.OrderProcess.GetOrdersByDate(start, end, loc.LocIdWalmart, null);
                    }
                    if (orders.Length > 0)
                    {
                        if (orderCollector.ContainsKey(loc.LocIdWalmart))
                        {
                            // mean there is duplicated LocIdWalmart    
                        }
                        else
                        {
                            orderCollector.Add(loc.LocIdWalmart, orders);
                            total += orders.Length;
                        }
                    }
                }
                else if (POs.POs.Count > 0 && type == SearchType.PoNumber)
                {
                    WmtOrder[] wmtOrders = new WmtOrder[0];
                    foreach (string po in POs.POs)
                    {
                        WmtOrder order = await _walmart.OrderProcess.GetAnOrderByPoId(po, loc.LocIdWalmart);
                        if (order.purchaseOrderId != null)
                            wmtOrders = wmtOrders.Concat(new WmtOrder[] { order }).ToArray();
                    }
                    if (wmtOrders.Length > 0)
                        orderCollector.Add(loc.LocIdWalmart, wmtOrders);
                    total += wmtOrders.Length;
                }
            }
            Hashtable res = InsertWmtOrder(orderCollector, ref total);
            return res;
        }
        private Hashtable InsertWmtOrder(Dictionary<string, WmtOrder[]> orderCollector, ref int total)
        {
            Hashtable resCollector = new Hashtable();
            List<List<string>> succeed = new List<List<string>>();
            List<List<string>> fail = new List<List<string>>();
            resCollector.Add("succeed", succeed);
            resCollector.Add("fail", fail);

            List<BpmLocation> bpmLocations = _kc.BpmLocations.ToList();
            List<SoError> poErrors = new List<SoError>();
            List<SoError> koErrors = _kc.SoErrors.ToList();
            List<Models.Country> countries = _kc.Countries.ToList();
            List<ShipVium> koShipvias = _kc.ShipVia.ToList();
            List<WmtCarrier> wmtCarriers = _kc.WmtCarriers.ToList();
            List<MkIcr> wmtSKUs = _kc.MkIcrs.Where(x => x.MarketId == 16).ToList();
            var realInv = _kc.InvRealTimes.ToList();
            var coSkus = _kc.ItemTrkCoOs.Include(x=>x.ItemNo).ThenInclude(x=>x.InvRealTimes).ToList();
            string errDetail = "";
            int cutOffTime = _kc.BpmBizRules.Where(x => x.BpmBizRulesId == 1).FirstOrDefault().DsCutOffTime.Value;

            foreach (var loc in orderCollector)
            {
                DateTime dtnow = DateTime.Now;
                DateTime nextBizDay = DateTime.Now;
                int locId = _kc.BpmLocations.Where(x => x.LocIdWalmart == loc.Key).FirstOrDefault().LocationId;
                bool is3PL = _kc.BpmLocations.Where(x => x.LocationId == locId).FirstOrDefault().Is3Pl;
                int? offset = _kc.BpmLocations.Where(x => x.LocationId == locId).FirstOrDefault().TimeOffset;
                if (offset != null && is3PL && offset != 0 && dtnow.Hour > cutOffTime - offset)
                {
                    dtnow = dtnow.AddDays(1);
                    nextBizDay = (DateTime)(from o in _kc.DimDates
                                            where o.DateTime >= dtnow.Date && o.IsWeekday == true && o.IsBpmholiday == false
                                            select o.DateTime).Min();
                }
                else
                {
                    if (dtnow.Hour > cutOffTime)
                        dtnow = dtnow.AddDays(1);
                    nextBizDay = (DateTime)(from o in _kc.DimDates
                                            where o.DateTime >= dtnow.Date && o.IsWeekday == true && o.IsBpmholiday == false
                                            select o.DateTime).Min();
                }

                foreach (WmtOrder po in loc.Value)
                {
                    if (_kc.SoTs.Any(x => x.PoNo == po.purchaseOrderId))
                    {
                        total -= 1;
                        continue;
                    }

                    bool isError = false;
                    bool foundPrice = true;
                    SoT SoT = new SoT();
                    SoT.CustomerId = 26;
                    SoT.PoNo = po.purchaseOrderId;

                    SoT.IoNo = po.customerOrderId;
                    SoT.SoDate = po.orderDate.ToLocalTime();
                    SoT.CustOrderTime = po.orderDate.ToLocalTime();
                    SoT.ShipToName = po.shippingInfo.postalAddress.name;
                    if (po.shippingInfo.postalAddress.address1.Length < 56)
                    {
                        SoT.Address1 = po.shippingInfo.postalAddress.address1;
                    }
                    else
                    {
                        errDetail = _utilMethods.BuildEmailLine(errDetail, $"PO#: {SoT.PoNo},(please add address on NS manually) Length of address letter over than 55: " +
                                                                           $"<br/>{po.shippingInfo.postalAddress.name}" +
                                                                           $"<br/>{po.shippingInfo.postalAddress.address1}, {po.shippingInfo.postalAddress.address2}" +
                                                                           $"<br/>{po.shippingInfo.postalAddress.city}, {po.shippingInfo.postalAddress.state} {po.shippingInfo.postalAddress.postalCode} {po.shippingInfo.postalAddress.country}" +
                                                                           $"<br/>{po.shippingInfo.postalAddress.country}");
                        isError = true;
                    }
                    SoT.Address2 = po.shippingInfo.postalAddress.address2;
                    SoT.City = po.shippingInfo.postalAddress.city;
                    SoT.State = po.shippingInfo.postalAddress.state;
                    SoT.Zip = po.shippingInfo.postalAddress.postalCode;
                    SoT.Country = _utilMethods.CountryCodeToName(po.shippingInfo.postalAddress.country, CountryMode.Alpha2, countries);
                    SoT.ExpShipDate = po.shippingInfo.estimatedShipDate.ToLocalTime();
                    SoT.ShipWindowStart = po.shippingInfo.estimatedShipDate.ToLocalTime();
                    SoT.ShipWindowEnd = po.shippingInfo.estimatedShipDate.ToLocalTime();
                    SoT.VendorCode = loc.Key.ToString();
                    SoT.PhoneNo = po.shippingInfo.phone;
                    SoT.BulkBuy = 0;
                    SoT.PoType = "DS";
                    SoT.Source = "API";
                    SoT.LastModTime = DateTime.Now;
                    SoT.AddedTime = DateTime.Now;
                    decimal soTotal = 0;
                    decimal? unitePrice;

                    foreach (var order in po.orderLines)
                    {

                        SoD SoD = new SoD();
                        var koShipVis = wmtCarriers.Find(x => x.CarIdApi == order.originalCarrierMethod);
                        int shipviaId;
                        if (koShipVis == null)
                        {
                            isError = true;
                            errDetail = _utilMethods.BuildEmailLine(errDetail, $"PO#: {po.purchaseOrderId} Unknown Shipping Method#: \"{order.originalCarrierMethod}\"");
                            shipviaId = 45; // LTL truck
                        }
                        else
                        {
                            shipviaId = Convert.ToInt32(koShipVis.ShipViaId.Value);
                            SoD.ShipScac = order.originalCarrierMethod;
                        }

                        SoD.SoT = SoT;
                        SoD.SoDate = po.orderDate.ToLocalTime();
                        SoD.SoTId = SoT.SoTId;
                        SoD.ShipFromWhId = _kc.BpmLocations.Where(x => x.LocIdWalmart == loc.Key).FirstOrDefault().LocationId;
                        SoD.ShipViaId = shipviaId;
                        SoD.ExpShipDate = po.shippingInfo.estimatedShipDate.ToLocalTime();
                        SoD.ShipWindowStart = po.shippingInfo.estimatedShipDate.ToLocalTime();
                        SoD.ShipWindowEnd = po.shippingInfo.estimatedShipDate.ToLocalTime();
                        SoD.TargetDate = po.shippingInfo.estimatedDeliveryDate.ToLocalTime();
                        SoD.CustSku = order.item.sku;
                        int? item_id = wmtSKUs.Find(x => x.CustSku == order.item.sku)?.ItemNoId;
                        if (item_id == null)
                        {
                            errDetail = _utilMethods.BuildEmailLine(errDetail, $"PO#: {po.purchaseOrderId} Unkown Customer SKU: \"{order.item.sku}\"");
                            item_id = 1879; // unknown item
                            unitePrice = 0;
                            isError = true;
                        }
                        else
                        {

                            unitePrice = _kc.ActualWmtPrices.AsNoTracking().Where(x => x.ItemNo == item_id.Value && x.ItemType == 7).FirstOrDefault()?.Price;
                            if (unitePrice == null)
                            {
                                errDetail = _utilMethods.BuildEmailLine(errDetail, $"PO#: {po.purchaseOrderId} Unkown Unite Cost: \"{order.item.sku}\"");
                                foundPrice = false;
                                isError = true;
                            }
                        }
                        SoD.ItemNoId = item_id.Value;
                        SoD.CustSku = order.item.sku;
                        SoD.LineTotal = unitePrice.Value * Convert.ToInt32(order.orderLineQuantity.amount);
                        soTotal += SoD.LineTotal.Value;
                        SoD.UnitPrice = unitePrice.Value;
                        SoD.SoStatusKoId = 1;
                        SoD.QtyOrdered = Convert.ToInt32(order.orderLineQuantity.amount);
                        SoD.PriceLevelId = 1;
                        SoD.QtyBackOrdered = 0;
                        SoD.QtyRejected = 0;
                        SoD.QtyCommitted = 0;
                        SoD.QtyInvoiced = 0;
                        SoD.IsRejectAcpt = 0;
                        SoD.AutoBol = 0;
                        SoD.SodLineNo = Convert.ToInt32(order.lineNumber);
                        SoD.LastModTime = DateTime.Now;
                        SoD.AddedTime = DateTime.Now;
                        SoT.SoDs.Add(SoD);
                    }
                    if (isError)
                        errDetail = _utilMethods.BuildEmailLine(errDetail, $"----------------------------------------------------------------------------<br/>");

                    SoT.SoTotal = soTotal;

                    foreach (var gItem in SoT.SoDs.GroupBy(x => new { x.ItemNoId, x.ShipFromWhId }))
                    {
                        var foundCoSku = coSkus.Find(x => x.ItemNoId == gItem.Key.ItemNoId);
                        if (foundCoSku != null)
                        {
                            var foundInv = realInv.Find(x => x.ItemNoId == gItem.Key.ItemNoId && x.LocationId == gItem.Key.ShipFromWhId && x.QtyAvail >= gItem.Sum(z => z.QtyOrdered));
                            var foundInvCoItem = realInv.Find(x => x.ItemNoId == foundCoSku.CoItemNoId && x.LocationId == gItem.Key.ShipFromWhId && x.QtyAvail > 0);

                            if (foundInv == null && foundInvCoItem != null)
                            {
                                foreach (var sod in gItem)
                                {
                                    sod.ItemNoId = foundCoSku.CoItemNoId;
                                }
                            }
                        }
                    }

                    if (foundPrice)
                    {
                        try
                        {
                            _kc.SoTs.Add(SoT);
                            _kc.SaveChanges();
                            ((List<List<string>>)resCollector["succeed"]).Add(new List<string>() { SoT.PoNo });
                        }
                        catch (Exception e)
                        {
                            _kc.SoTs.Local.Remove(SoT);
                            ((List<List<string>>)resCollector["fail"]).Add(new List<string>() { $"{SoT.PoNo} : {e.Message}" });
                            continue;
                        }
                    }

                }
            }
            if (errDetail != "")
            {
                MailService.Send("Need Actions For Walmart Order Process", errDetail, "edisupport@bpmatt.com", "", true);
            }
            resCollector["Total"] = total;

            if (((List<List<string>>)resCollector["fail"]).Count > 0)
            {
                MailService.Send("(850)Founded Walmart Error", "check log", "youngjae.jo@mellow-home.com", "", true);
            }
            _suiteTalker.salesOrderProcess.CreateSOtoNS();
            return resCollector;
        }
        public async Task<bool> InsertWmtItmes()
        {

            List<WmtReport> wmtReports = await _walmart.OrderProcess.GetItemReport();
            List<ActualWmtPrice> wmtPrices = new List<ActualWmtPrice>();
            List<MkIcr> nsIcrs = new List<MkIcr>();
            string priceChangedDetail = "";
            foreach (WmtReport item in wmtReports)
            {
                ActualWmtPrice price = _kc.ActualWmtPrices.Where(x => x.WmtItemNo == Convert.ToInt32(item.wm)).FirstOrDefault();
                if (item.sku == "ONLINE")
                    continue;
                if (price != null) // logic only for price
                {

                    decimal unitPrice = Convert.ToDecimal(item.cost);
                    int decimalCount = BitConverter.GetBytes(decimal.GetBits(unitPrice)[3])[2];
                    #region found Wmt set 3 decimal place for currency 2022/12/12
                    if (decimalCount > 2)
                    {
                        priceChangedDetail = _utilMethods.BuildEmailLine(priceChangedDetail, $"Detected More than 2 Decimal {price.CustSku}:{unitPrice}");
                        unitPrice = Math.Truncate(100 * unitPrice) / 100;
                    }
                    #endregion
                    if (Convert.ToDecimal(unitPrice) != price.Price)
                    {
                        decimal original = price.Price;
                        price.Price = Convert.ToDecimal(unitPrice);
                        price.LastUpdateDate = DateTime.Parse(item.lastUpdationDate);
                        price.LastModDate = DateTime.Now;

                        priceChangedDetail = _utilMethods.BuildEmailLine(priceChangedDetail, $"{price.CustSku}: {original} -> {price.Price}");
                        _kc.Update(price);
                        _kc.SaveChanges();
                    }
                    continue;
                }
                int? temNo;
                string temSku = item.sku;
                if (temSku.Contains("&nbsp;"))
                {
                    temSku = temSku.Replace("&nbsp;", "");
                    temNo = _kc.BpmItems.Where(x => x.ItemName == temSku).FirstOrDefault()?.ItemNoId;
                }
                string realCustSku = temSku;
                temNo = _kc.MkIcrs.Where(x => x.CustSku == temSku).FirstOrDefault()?.ItemNoId;
                
                if(temNo == null)
                {
                    temSku = temSku.Replace("WMT-", "");
                    temNo = _kc.BpmItems.Where(x => x.ItemName == temSku).FirstOrDefault()?.ItemNoId;
                }
                if (temNo == null)
                {
                    temSku = item.sku;
                    temSku = temSku.Replace("WM-", "BP-");
                    temNo = _kc.BpmItems.Where(x => x.ItemName == temSku).FirstOrDefault()?.ItemNoId;
                    temSku = temSku.Replace("WMT-", "BP-");
                    temNo = _kc.BpmItems.Where(x => x.ItemName == temSku).FirstOrDefault()?.ItemNoId;
                    if (temNo == null)
                    {
                        temSku = temSku.Replace("BP-", "BPM-");
                        temNo = _kc.BpmItems.Where(x => x.ItemName == temSku).FirstOrDefault()?.ItemNoId;
                    }
                    if (temNo == null)
                    {
                        temSku = temSku.Replace("BPM-", "BPP-");
                        temNo = _kc.BpmItems.Where(x => x.ItemName == temSku).FirstOrDefault()?.ItemNoId;
                    }
                    if (temNo == null)
                    {
                        temSku = temSku.Replace("BPP-", "DT-");
                        temNo = _kc.BpmItems.Where(x => x.ItemName == temSku).FirstOrDefault()?.ItemNoId;
                    }
                    if (temNo == null)
                    {
                        temSku = temSku.Replace("DT-", "ML-");
                        temNo = _kc.BpmItems.Where(x => x.ItemName == temSku).FirstOrDefault()?.ItemNoId;
                    }
                    if (temNo == null)
                    {
                        temSku = temSku.Replace("ML-", "");
                        temNo = _kc.BpmItems.Where(x => x.ItemName == temSku).FirstOrDefault()?.ItemNoId;
                    }
                }
                if (temNo != null)
                {
                    MkIcr nsIcr = new MkIcr();
                    nsIcr.MarketId = 16;
                    nsIcr.CustAsin = item.itemId;
                    nsIcr.CustUpc = item.upc;
                    nsIcr.LaunchDate = DateTime.Parse(item.itemCreationDate);
                    nsIcr.IsDisco = false;
                    nsIcr.IsNew = true;
                    nsIcr.ItemNoId = temNo.Value;
                    nsIcr.CustSku = realCustSku;
                    nsIcr.AddedTime = DateTime.Now;
                    nsIcr.LastModTime = DateTime.Now;
                    MailService.Send("(Walmart) New Item Is Detected", $"Customer SKU:{realCustSku} // Need to add flag whethere DSV or Bulk Buy", "youngjae.jo@mellow-home.com", "", true);
                    _kc.MkIcrs.Add(nsIcr);
                    _kc.SaveChanges();
                }
                else
                {
                    MailService.Send("(Walmart) New Item Is Detected", $"Customer SKU:{realCustSku}", "youngjae.jo@mellow-home.com", "", true);
                    continue;
                }
                price = new ActualWmtPrice();
                price.CustSku = item.sku;
                price.ItemNo = temNo.Value;
                price.WmtItemNo = Convert.ToInt32(item.wm);
                if (item.cost == "")
                {
                    //need log
                }
                else
                    price.Price = Convert.ToDecimal(item.cost);
                price.StartDate = item.offerStartDate != "" ? DateTime.Parse(item.offerStartDate) : null;
                price.LastUpdateDate = item.lastUpdationDate != "" ? DateTime.Parse(item.lastUpdationDate) : null;
                price.EndDate = item.offerEndDate != "" ? DateTime.Parse(item.offerEndDate) : null;
                price.CeatedTime = DateTime.Now;
                price.LastModDate = DateTime.Now;
                wmtPrices.Add(price);
            }

            if (priceChangedDetail != "")
                MailService.Send("WMT Price Changed", priceChangedDetail, "youngjae.jo@mellow-home.com", "", true);

            if (wmtPrices.Count > 0)
            {
                _kc.ActualWmtPrices.AddRange(wmtPrices);
                _kc.SaveChanges();
            }
            return true;
        }
        public async Task<Hashtable> SendAckOrders()
        {
            DateTime standard = DateTime.Parse("2022-04-01");
            //DateTime from = DateTime.Now.AddDays(-1).Date;
            List<SoT> sots = await _kc.SoTs.Include(x => x.SoDs)
                                           .Include(x => ((SoD)x.SoDs).ShipFromWh)
                                           .Include(x => x.ApisoStatus)
                                           .Include(x => x.SoCancel)
                                    .Where(x =>
                                    x.SoDs.Any(y => y.SoStatusKoId != 9) &&
                                    x.SoDate >= standard &&
                                    //x.SoDate >= from &&
                                    x.CustomerId == 26 && (
                                    x.ApisoStatus == null ||
                                    x.ApisoStatus.IsAcked == false) &&
                                    x.SoDs.Count > 0
                                    && (x.SoCancel == null || (x.SoCancel != null && x.SoCancel.IsCancelled == false))
                                    ).ToListAsync();

            List<SoError> koErrors = await _kc.SoErrors.Where(x => x.CustomerId == 26 && x.IsResolved == false).ToListAsync();
            List<SoError> errorApis = new List<SoError>();
            Hashtable res = new Hashtable();
            int countNotCommitted = 0;
            string notCommitDetail = "";
            foreach (SoT sot in sots)
            {
                ApisoStatus apipoStatus = _kc.ApisoStatuses.Where(x => x.SoTId == sot.SoTId || x.PoNo == sot.PoNo).FirstOrDefault();
                if (apipoStatus != null && apipoStatus.IsAcked == true)
                    continue;
                string whId = sot.SoDs.FirstOrDefault().ShipFromWh.LocIdWalmart;
                string whName = sot.SoDs.FirstOrDefault().ShipFromWh.LocName;
                WmtOrder wmtOrder = await _walmart.OrderProcess.GetAnOrderByPoId(sot.PoNo, whId);
                for (int i = 0; i < 10 && wmtOrder.purchaseOrderId == null; i++)
                {
                    wmtOrder = await _walmart.OrderProcess.GetAnOrderByPoId(sot.PoNo, whId);
                    Thread.Sleep(5000);
                }
                if (wmtOrder.purchaseOrderId == null)   //not found po
                {
                    List<string> whIds = _kc.BpmLocations.Select(x => x.LocIdWalmart).Where(x => x != null).ToList();
                    foreach (string wh in whIds)
                    {
                        for (int i = 0; i < 5 && wmtOrder.purchaseOrderId == null; i++)
                        {
                            wmtOrder = await _walmart.OrderProcess.GetAnOrderByPoId(sot.PoNo, wh);

                        }
                        if (wmtOrder.purchaseOrderId != null)
                        {
                            whId = wh;
                            break;
                        }
                    }
                    if (wmtOrder.purchaseOrderId == null)
                    {
                        string detail = $"Warehouse: {whName}, PO# : {sot.PoNo}";
                        _utilMethods.AddInvalidation(errorApis, detail, sot.PoNo, null, ErrorType.ErrResponse, 26, ProcessType.GetOrder);
                        _utilMethods.BuildSyncResData(res, false, $"{whName}/{sot.PoNo}");
                        continue;
                    }

                }
                else
                {
                    if (koErrors.Where(x => x.PoNo == sot.PoNo && x.ProcessId == (int)ProcessType.GetOrder).Any())
                    {
                        IEnumerable<SoError> resolved = koErrors.Where(x => x.PoNo.Equals(sot.PoNo) && x.ProcessId == (int)ProcessType.GetOrder);
                        foreach (SoError poErr in resolved)
                        {
                            poErr.IsResolved = true;
                        }
                        _kc.SoErrors.UpdateRange(resolved);
                        _kc.SaveChanges();
                    }

                }
                bool isCreated = true;
                bool isNotCancelled = true;
                bool isAllCommited = true;
                foreach (var lines in wmtOrder.orderLines)
                {
                    foreach (var line in lines.orderLineStatuses)
                    {
                        if (line.status != orderLineStatusValueType.Created)
                        {
                            isCreated = false;
                            if (line.status == orderLineStatusValueType.Cancelled || line.status == orderLineStatusValueType.Refund)
                            {
                                if (line.status == orderLineStatusValueType.Cancelled)
                                {
                                    if (sot.SoCancel == null)
                                    {
                                        int sotId = sot.SoTId;
                                        SoCancel poCancel = new SoCancel();
                                        poCancel.SoTId = sotId;
                                        poCancel.CustId = 26;
                                        poCancel.MrklocId = whId;
                                        poCancel.PoNo = sot.PoNo;
                                        poCancel.IsCancelled = true;
                                        poCancel.ReqTime = DateTime.Now;
                                        poCancel.CancelledTime = DateTime.Now;
                                        _kc.Add(poCancel);
                                        _kc.SaveChanges();
                                    }
                                    else
                                    {
                                        sot.SoCancel.IsCancelled = true;
                                        sot.SoCancel.CancelledTime = DateTime.Now;
                                        _kc.Update(sot.SoCancel);
                                        _kc.SaveChanges();

                                    }
                                }
                                isNotCancelled = false;
                                continue;
                            }
                        }
                    }

                    if (isNotCancelled && !isCreated)
                    {
                        if (apipoStatus == null)
                        {
                            apipoStatus = new ApisoStatus();
                            apipoStatus.SoTId = sot.SoTId;
                            apipoStatus.PoNo = wmtOrder.purchaseOrderId;
                            apipoStatus.CustId = 26;
                            apipoStatus.IsAcked = true;
                            apipoStatus.SentAsn = false;
                            apipoStatus.Ackedtime = DateTime.Now;
                            _kc.Add(apipoStatus);
                            _kc.SaveChanges();
                        }
                        else
                        {
                            apipoStatus.IsAcked = true;
                            apipoStatus.Ackedtime = DateTime.Now;
                            _kc.Update(apipoStatus);
                            _kc.SaveChanges();
                        }
                        if (koErrors.Where(x => x.ProcessId == (int)ProcessType.SendAck && x.PoNo == wmtOrder.purchaseOrderId).Any())
                        {
                            IEnumerable<SoError> resolved = koErrors.Where(x => x.ProcessId == (int)ProcessType.SendAck && x.PoNo == wmtOrder.purchaseOrderId);
                            foreach (SoError poErr in resolved)
                            {
                                poErr.IsResolved = true;
                            }
                            _kc.SoErrors.UpdateRange(resolved);
                            _kc.SaveChanges();
                        }
                    }
                    else if (isNotCancelled && isCreated)
                    {
                        foreach (SoD sod in sot.SoDs)
                        {
                            if (sod.SoStatusKoId == 1)// 1 = New
                            {
                                isAllCommited = false;
                                continue;
                            }
                            if (sod.SoStatusKoId != 4 && sod.SoStatusKoId != 5 && sod.SoStatusKoId != 6 && sod.SoStatusKoId != 7) // 4 committed // need logging
                            {
                                countNotCommitted++;
                                isAllCommited = false;
                                notCommitDetail = _utilMethods.BuildEmailLine(notCommitDetail, $"PO#: {sot.PoNo}");
                                continue;
                            }
                        }
                    }
                    #region ex1
                    //foreach (var line in lines.orderLineStatuses)
                    //{
                    //    if (line.status != orderLineStatusValueType.Created)
                    //    {
                    //        if (line.status == orderLineStatusValueType.Cancelled || line.status == orderLineStatusValueType.Refund)
                    //            continue;
                    //        else
                    //        {
                    //            if (apipoStatus == null)
                    //            {
                    //                apipoStatus = new ApisoStatus();
                    //                apipoStatus.SoTId = sot.SoTId;
                    //                apipoStatus.PoNo = wmtOrder.purchaseOrderId;
                    //                apipoStatus.CustId = 26;
                    //                apipoStatus.IsAcked = true;
                    //                apipoStatus.SentAsn = false;
                    //                apipoStatus.Ackedtime = DateTime.Now;
                    //            }
                    //            else
                    //            {
                    //                apipoStatus.IsAcked = true;
                    //                apipoStatus.Ackedtime = DateTime.Now;
                    //                _kc.Update(apipoStatus);
                    //                _kc.SaveChanges();
                    //            }
                    //            if (koErrors.Where(x=> x.ProcessId == (int)ProcessType.SendAck && x.PoNo == wmtOrder.purchaseOrderId).Any())
                    //            {
                    //                IEnumerable<SoError> resolved = koErrors.Where(x=>x.ProcessId == (int)ProcessType.SendAck && x.PoNo == wmtOrder.purchaseOrderId);
                    //                foreach (SoError poErr in resolved)
                    //                {
                    //                    poErr.IsResolved = true;
                    //                }
                    //                _kc.SoErrors.UpdateRange(resolved);
                    //                _kc.SaveChanges();
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        foreach (SoD sod in sot.SoDs)
                    //        {
                    //            if (sod.SoStatusKoId != 4) // 4 committed // need logging
                    //                continue;
                    //        }

                    //        bool sentAck = await _walmart.OrderProcess.SendAck(sot.PoNo, whId);
                    //        if (apipoStatus == null)
                    //        {
                    //            apipoStatus = new ApisoStatus();
                    //            apipoStatus.SoTId = sot.SoTId;
                    //            apipoStatus.PoNo = wmtOrder.purchaseOrderId;
                    //            apipoStatus.CustId = 26;
                    //            apipoStatus.SentAsn = false;
                    //            if (sentAck == true)
                    //            {
                    //                apipoStatus.IsAcked = true;
                    //                apipoStatus.Ackedtime = DateTime.Now;
                    //                if (res.Contains(sentAck))
                    //                {
                    //                    ((List<string>)res[sentAck]).Add(wmtOrder.purchaseOrderId);
                    //                }
                    //                else
                    //                {
                    //                    succeed.Add(wmtOrder.purchaseOrderId);
                    //                    res.Add(sentAck, succeed);
                    //                }
                    //            }
                    //            else
                    //            {
                    //                apipoStatus.IsAcked = false;
                    //                string detail = $"Warehouse ID: {whId}, PO#: {sot.PoNo}";
                    //                _utilMethods.AddInvalidation(errorApis, detail, sot.PoNo, null, ErrorType.ErrResponse, 26, ProcessType.SendAck);
                    //                if (res.Contains(sentAck))
                    //                {
                    //                    ((List<string>)res[sentAck]).Add(wmtOrder.purchaseOrderId);
                    //                }
                    //                else
                    //                {
                    //                    failed.Add(wmtOrder.purchaseOrderId);
                    //                    res.Add(sentAck, failed);
                    //                }
                    //            }
                    //            _kc.ApisoStatuses.Add(apipoStatus);
                    //            _kc.SaveChanges();
                    //        }
                    //        else
                    //        {
                    //            if (sentAck == true)
                    //            {
                    //                apipoStatus.IsAcked = true;
                    //                if (res.Contains(sentAck))
                    //                {
                    //                    ((List<string>)res[sentAck]).Add(wmtOrder.purchaseOrderId);
                    //                }
                    //                else
                    //                {
                    //                    succeed.Add(wmtOrder.purchaseOrderId);
                    //                    res.Add(sentAck, succeed);
                    //                }
                    //                _kc.ApisoStatuses.Update(apipoStatus);
                    //                _kc.SaveChanges();
                    //            }
                    //            else
                    //            {
                    //                string detail = $"Warehouse ID: {whId}, PO#: {sot.PoNo}";
                    //                _utilMethods.AddInvalidation(errorApis, detail, sot.PoNo, null, ErrorType.ErrResponse, 26, ProcessType.SendAck);
                    //                if (res.Contains(sentAck))
                    //                {
                    //                    ((List<string>)res[sentAck]).Add(wmtOrder.purchaseOrderId);
                    //                }
                    //                else
                    //                {
                    //                    failed.Add(wmtOrder.purchaseOrderId);
                    //                    res.Add(sentAck, failed);
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                    #endregion
                }
                if (isNotCancelled && isCreated && isAllCommited)
                {
                    IRestResponse response = await _walmart.OrderProcess.SendAck(sot.PoNo, whId);

                    for (int i = 0; i < 4 && response.StatusCode != HttpStatusCode.OK; i++)
                    {
                        response = await _walmart.OrderProcess.SendAck(sot.PoNo, whId);
                    }
                    if (apipoStatus == null)
                    {
                        apipoStatus = new ApisoStatus();
                        apipoStatus.SoTId = sot.SoTId;
                        apipoStatus.PoNo = wmtOrder.purchaseOrderId;
                        apipoStatus.CustId = 26;
                        apipoStatus.SentAsn = false;
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            apipoStatus.IsAcked = true;
                            apipoStatus.Ackedtime = DateTime.Now;
                            _utilMethods.BuildSyncResData(res, true, sot.PoNo);
                        }
                        else
                        {
                            apipoStatus.IsAcked = false;
                            string detail = $"Warehouse ID: {whId}, PO#: {sot.PoNo}, Status: {response.StatusCode}, Error Msg:{response.ErrorMessage}";
                            _utilMethods.AddInvalidation(errorApis, detail, sot.PoNo, null, ErrorType.ErrResponse, 26, ProcessType.SendAck);
                            _utilMethods.BuildSyncResData(res, false, sot.PoNo);
                        }
                        _kc.ApisoStatuses.Add(apipoStatus);
                        _kc.SaveChanges();
                    }
                    else
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            apipoStatus.IsAcked = true;
                            apipoStatus.Ackedtime = DateTime.Now;
                            _utilMethods.BuildSyncResData(res, true, sot.PoNo);
                            _kc.ApisoStatuses.Update(apipoStatus);
                            _kc.SaveChanges();
                        }
                        else
                        {
                            string detail = $"Warehouse ID: {whId}, PO#: {sot.PoNo}, Status: {response.StatusCode}, Error Msg:{response.ErrorMessage}";
                            _utilMethods.AddInvalidation(errorApis, detail, sot.PoNo, null, ErrorType.ErrResponse, 26, ProcessType.SendAck);
                            _utilMethods.BuildSyncResData(res, false, sot.PoNo);
                        }
                    }
                    if (koErrors.Where(x => x.PoNo == sot.PoNo && x.ProcessId == (int)ProcessType.SendAck).Any() && response.StatusCode == HttpStatusCode.OK)
                    {
                        IEnumerable<SoError> resolved = koErrors.Where(x => x.PoNo.Equals(sot.PoNo) && x.ProcessId == (int)ProcessType.SendAck);
                        foreach (SoError poErr in resolved)
                        {
                            poErr.IsResolved = true;
                        }
                        _kc.SoErrors.UpdateRange(resolved);
                        _kc.SaveChanges();
                    }
                }
            }
            if (errorApis.Count() > 0)
            {
                errorApis.RemoveAll(x => koErrors.Select(z => z.PoNo).Contains(x.PoNo));
                if (errorApis.Count > 0)
                {
                    MailService.Send("(855)Detected Error at Walmart", "Please Check  Chameleon-> Sales-> Walmart-> Walmart SO-> Error \n  URL: https://bestpricequality.net:9458/walmart", "it@bpmatt.com", "", true);
                }
                _kc.SoErrors.AddRange(errorApis);
                _kc.SaveChanges();
            }
            if (countNotCommitted > 0 && (DateTime.Now.Hour == 9 || DateTime.Now.Hour == 15))
                MailService.Send("(855)Detected Backorder(s) at Walmart", $"{notCommitDetail}<br/><br/>Please Check  Chameleon-> Sales-> Walmart-> Walmart SO-> Acknowleged Monitor & resolve it \n  URL: https://bestpricequality.net:9458/walmart", "orderprocess@bpmatt.com", "youngjae.jo@mellow-home.com", true);
            return res;
        }
        public async Task<Dictionary<string, List<string>>> FindCancelledPO()
        {
            Hashtable pos = new Hashtable();
            DateTime now = DateTime.Now;
            string start = now.AddDays(-20).ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ssZ");
            string end = now.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ssZ");
            var walmartIds = await _kc.BpmLocations.Where(x => x.LocIdWalmart != null).Select(x => new { x.LocationId, x.LocIdWalmart, x.LocName }).ToListAsync();
            Dictionary<string, WmtOrder[]> orderCollector = new Dictionary<string, WmtOrder[]>();
            Dictionary<string, List<string>> req = new Dictionary<string, List<string>>();
            int total = 0;
            string cancelDetail = "";
            foreach (var loc in walmartIds)
            {
                WmtOrder[] orders = await _walmart.OrderProcess.GetOrdersByDate(start, end, loc.LocIdWalmart, orderLineStatusValueType.Acknowledged);
                if (orders.Length > 0)
                {
                    orderCollector.Add(loc.LocIdWalmart, orders);
                    total += orders.Length;
                }
            }

            foreach (var loc in orderCollector)
            {
                string warehouse = walmartIds.Where(x => x.LocIdWalmart == loc.Key).FirstOrDefault().LocName;

                foreach (WmtOrder po in loc.Value)
                {
                    bool isCancel = false;
                    foreach (var line in po.orderLines)
                    {
                        if (line.intentToCancel == "TRUE")
                            isCancel = true;

                    }
                    if (isCancel && !_kc.SoCancels.Where(x => x.PoNo == po.purchaseOrderId).Any())
                    {
                        if (req.ContainsKey(warehouse))
                            req[warehouse].Append(po.purchaseOrderId);
                        else
                            req.Add(warehouse, new List<string> { po.purchaseOrderId });

                        if (cancelDetail == "")
                            cancelDetail += $"Location: {warehouse} PO#: {po.purchaseOrderId}";
                        else
                            cancelDetail += $"\nLocation: {warehouse} PO#: {po.purchaseOrderId}";
                        int sotId = _kc.SoTs.Where(x => x.PoNo == po.purchaseOrderId).FirstOrDefault().SoTId;
                        SoCancel poCancel = new SoCancel();
                        poCancel.SoTId = sotId;
                        poCancel.CustId = 26;
                        poCancel.MrklocId = loc.Key;
                        poCancel.PoNo = po.purchaseOrderId;
                        poCancel.IsCancelled = false;
                        poCancel.ReqTime = DateTime.Now;
                        _kc.Add(poCancel);
                        _kc.SaveChanges();
                    }
                }
            }

            if (cancelDetail != "")
                MailService.Send("Detected Cancellation Request(s) at Walmart", cancelDetail, "orderprocess@bpmatt.com", "youngjae.jo@mellow-home.com", true);
            List<SoCancel> canLst = _kc.SoCancels.Where(x => x.IsCancelled == false && x.IsShipped == false && x.CustId == 26).ToList();
            foreach (SoCancel po in canLst)
            {
                WmtOrder order = await _walmart.OrderProcess.GetAnOrderByPoId(po.PoNo, po.MrklocId);
                foreach (orderLineType line in order.orderLines)
                {
                    if (line.orderLineStatuses[0].status == orderLineStatusValueType.Cancelled)
                    {
                        po.IsCancelled = true;
                        po.CancelledTime = line.statusDate;
                        _kc.Update(po);
                        _kc.SaveChanges();
                    }
                    if (line.orderLineStatuses[0].status == orderLineStatusValueType.Shipped)
                    {
                        po.IsShipped = true;
                        _kc.Update(po);
                        _kc.SaveChanges();
                    }
                }
            }
            now = DateTime.Now;
            //string fromExSD = now.Date.ToString("yyyy-MM-dd'T'HH:mm:ssZ");
            //string toExSD = now.AddDays(1).Date.ToString("yyyy-MM-dd'T'HH:mm:ssZ");
            string fromExSD = now.Date.AddDays(-2).ToString("yyyy-MM-dd'T'HH:mm:ssZ");
            string toExSD = now.Date.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ssZ");
            orderCollector = new Dictionary<string, WmtOrder[]>();
            foreach (var loc in walmartIds)
            {
                WmtOrder[] orders = await _walmart.OrderProcess.GetOrdersByDate(null, null, loc.LocIdWalmart, orderLineStatusValueType.Cancelled, fromExSD, toExSD);
                if (orders.Length > 0)
                {
                    orderCollector.Add(loc.LocIdWalmart, orders);
                    total += orders.Length;
                }
            }
            foreach (var loc in orderCollector)
            {
                string warehouse = walmartIds.Where(x => x.LocIdWalmart == loc.Key).FirstOrDefault().LocName;
                foreach (WmtOrder po in loc.Value)
                {
                    if (_kc.SoCancels.Where(x => x.PoNo == po.purchaseOrderId).Any())
                        continue;
                    else
                    {
                        if (req.ContainsKey("Cancelled"))
                            req[warehouse].Append(po.purchaseOrderId);
                        else
                            req.Add("Cancelled", new List<string> { po.purchaseOrderId });

                        SoCancel poCancel = new SoCancel();
                        if (_kc.SoTs.Any(x => x.PoNo == po.purchaseOrderId))
                        {
                            int sotId = _kc.SoTs.Where(x => x.PoNo == po.purchaseOrderId).FirstOrDefault().SoTId;
                            poCancel.SoTId = sotId;
                        }
                        poCancel.CustId = 26;
                        poCancel.MrklocId = loc.Key;
                        poCancel.PoNo = po.purchaseOrderId;
                        poCancel.IsCancelled = true;
                        poCancel.ReqTime = DateTime.Now;
                        _kc.Add(poCancel);
                        _kc.SaveChanges();
                    }

                }
            }
            return req;
        }
        public async Task<Hashtable> SendTrackingNumber()
        {
            Hashtable res = new Hashtable();
            IRestResponse response = null;
            List<ShipVium> shipVia = _kc.ShipVia.ToList();
            List<SoError> koErrors = await _kc.SoErrors.Where(x => x.CustomerId == 26 && x.ProcessId == (int)ProcessType.SendASN).ToListAsync();
            List<SoError> errorApis = new List<SoError>();
            DateTime standardDate = DateTime.Parse("2022-06-11");
            _kc.Database.SetCommandTimeout(180);
            try
            {
                List<SoT> PreAsnLst = _kc.SoTs
                                   .Include(x => x.SoDs)
                                   .Include(x => ((SoD)x.SoDs).ItemFfds)
                                   .Include(x => x.ItemFfts)
                                   .Include(x => ((SoD)x.SoDs).ShipFromWh)
                                   .Include(x => ((SoD)x.SoDs).ShipVia)
                                   .Include(x => x.ApisoStatus)
                                   .Where(x => x.SoDate >= standardDate &&
                                               x.CustomerId == 26 &&
                                               x.SoDs.All(y => y.ItemFfds.Count != 0) &&
                                               x.ApisoStatus.IsAcked == true &&
                                               x.ApisoStatus.SentAsn == false &&
                                               x.ItemFfts.All(z => z.IfStatusId == 3)
                                               ).ToList();

                string lstTrackingQtyNotMatching = "";
                foreach (var sot in PreAsnLst)
                {
                    string poNo = sot.PoNo;
                    //Check sent or not 
                    ApisoStatus apipoStatus = _kc.ApisoStatuses.Where(x => x.CustId == 26 && x.PoNo == poNo).FirstOrDefault();
                    if (apipoStatus != null && apipoStatus.SentAsn == true)
                        continue;

                    bool isAllShipped = true;
                    BpmLocation wmtLoc = sot.SoDs.FirstOrDefault().ShipFromWh;
                    string whId = wmtLoc.LocIdWalmart;
                    WmtOrder wmtOrder = await _walmart.OrderProcess.GetAnOrderByPoId(poNo, wmtLoc.LocIdWalmart);
                    for (int i = 0; i < 10 && wmtOrder.purchaseOrderId == null; i++)
                    {
                        wmtOrder = await _walmart.OrderProcess.GetAnOrderByPoId(sot.PoNo, whId);
                        Thread.Sleep(5000);
                    }
                    if (wmtOrder.purchaseOrderId == null)   //not found po & retry
                    {
                        List<string> whIds = _kc.BpmLocations.Select(x => x.LocIdWalmart).Where(x => x != null).ToList();
                        foreach (string wh in whIds)
                        {
                            wmtOrder = await _walmart.OrderProcess.GetAnOrderByPoId(sot.PoNo, wh);
                            for (int i = 0; i < 5 && wmtOrder.purchaseOrderId == null; i++)
                            {
                                wmtOrder = await _walmart.OrderProcess.GetAnOrderByPoId(sot.PoNo, wh);
                            }
                            if (wmtOrder.purchaseOrderId != null)
                            {
                                whId = wh;
                                break;

                            }
                        }
                        if (wmtOrder.purchaseOrderId == null)
                        {
                            string detail = $"SO#: {sot.SoNo}, PO#: {poNo}, Warehouse: {wmtLoc.LocName}";
                            _utilMethods.AddInvalidation(errorApis, detail, poNo, null, ErrorType.ErrResponse, 26, ProcessType.SendASN);
                            _utilMethods.BuildSyncResData(res, false, detail);
                            continue;
                        }
                    }
                    else
                    {
                        if (koErrors.Where(x => x.PoNo == poNo && x.ProcessId == (int)ProcessType.GetOrder).Any())
                        {
                            IEnumerable<SoError> resolved = koErrors.Where(x => x.PoNo.Equals(poNo) && x.ProcessId == (int)ProcessType.GetOrder);
                            foreach (SoError poErr in resolved)
                            {
                                poErr.IsResolved = true;
                            }
                            _kc.SoErrors.UpdateRange(resolved);
                            _kc.SaveChanges();
                        }

                    }
                    // check status in lines
                    foreach (var lines in wmtOrder.orderLines)
                    {
                        foreach (var line in lines.orderLineStatuses)
                        {
                            if (line.status != orderLineStatusValueType.Delivered && line.status != orderLineStatusValueType.Shipped && line.status != orderLineStatusValueType.Cancelled)
                                isAllShipped = false;
                        }
                    }

                    if (!isAllShipped)// need to ship
                    {
                        DateTime shippedDate = sot.ItemFfts.FirstOrDefault().ShipDate.Value;
                        ShipInfo shipInfo = new ShipInfo();
                        ShipVium shipMethod = sot.SoDs.FirstOrDefault().ShipVia;
                        if (shipMethod.NsShipItem.ToLower().Contains("fedex"))
                        {
                            shipInfo.carrier = carrierType.FedEx;
                            if (shipMethod.ShippingType == "Ground")
                            {
                                shipInfo.shippingType = shippingMethodCodeType.Standard;
                            }
                            else if (shipMethod.ShippingType == "Express")
                            {
                                shipInfo.shippingType = shippingMethodCodeType.Express;
                            }
                        }
                        else if (shipMethod.NsShipItem.ToLower().Contains("ups"))
                        {
                            shipInfo.carrier = carrierType.UPS;
                            if (shipMethod.ShippingType == "Ground")
                            {
                                shipInfo.shippingType = shippingMethodCodeType.Standard;
                            }
                            else if (shipMethod.ShippingType == "Express")
                            {
                                shipInfo.shippingType = shippingMethodCodeType.Express;
                            }
                        }
                        else if (shipMethod.NsShipItem.ToLower().Contains("ltl"))
                        {
                            string scac = _kc.SoTs.Include(x => x.SoDs).Where(x => x.PoNo == poNo).Select(x => x.SoDs).FirstOrDefault().Select(x => x.ShipScac).FirstOrDefault();
                            if (scac != null)
                            {
                                string carrierName = (from car in _kc.WmtCarriers
                                                      join shi in _kc.ShipCarriers on car.CarrierId equals shi.CarrierId
                                                      where car.CarIdApi == scac
                                                      select shi).FirstOrDefault().CarrierName;
                                if (Enum.GetNames(typeof(carrierType)).Any(x => x.ToLower() == carrierName.ToLower()))
                                {
                                    shipInfo.carrier = (carrierType)Enum.Parse(typeof(carrierType), carrierName, true);
                                    shipInfo.shippingType = shippingMethodCodeType.Standard;
                                }
                                else
                                {
                                    string detail = $"Unknown SCAC, SO#: {sot.SoNo}, PO#: {poNo}, Warehouse: {wmtLoc.LocName}";
                                    _utilMethods.AddInvalidation(errorApis, detail, poNo, null, ErrorType.Unknown, 26, ProcessType.SendASN);
                                    _utilMethods.BuildSyncResData(res, false, detail);

                                    continue;
                                }
                            }
                        }

                        Shipment shipment = new Shipment();
                        Ordershipment ordershipment = new Ordershipment();
                        Orderlines orderlines = new Orderlines();
                        int idx = 0;
                        int totalReqQty = 0;
                        int totalQty = 0;
                        orderlines.orderLine = new Orderline[wmtOrder.orderLines.Length];
                        foreach (orderLineType order in wmtOrder.orderLines)
                        {
                            string[] trackingNums = new string[0];
                            //check order line status
                            bool isShippedOrCancel = false;
                            foreach (var line in order.orderLineStatuses)
                            {
                                if (line.status == orderLineStatusValueType.Delivered || line.status == orderLineStatusValueType.Shipped || line.status == orderLineStatusValueType.Cancelled)
                                    isShippedOrCancel = true;
                            }
                            if (isShippedOrCancel)
                                continue;

                            //search from order line of our side  
                            SoD sod = sot.SoDs.Where(x => x.SodLineNo == Convert.ToInt32(order.lineNumber)).FirstOrDefault();
                            for (int i = 0; i < sod.ItemFfds.Count; i++)
                            {
                                if (sod.ItemFfds.ElementAt(i).TrackNo.Contains(','))
                                {
                                    string[] splitedTrackNos = sod.ItemFfds.ElementAt(i).TrackNo.Split(',');
                                    // check number of tracking# matches with qty fulfilled
                                    if (sod.ItemFfds.ElementAt(i).QtyFulfilled <= splitedTrackNos.Count())
                                    {
                                        trackingNums = trackingNums.Concat(splitedTrackNos).ToArray();
                                        totalQty += trackingNums.Length;
                                    }
                                }
                                else if (sod.ItemFfds.ElementAt(i).TrackNo.Contains(' '))
                                {
                                    string[] splitedTrackNos = sod.ItemFfds.ElementAt(i).TrackNo.Split(' ');
                                    // check number of tracking# matches with qty fulfilled
                                    if (sod.ItemFfds.ElementAt(i).QtyFulfilled <= splitedTrackNos.Count())
                                    {
                                        trackingNums = trackingNums.Concat(splitedTrackNos).ToArray();
                                        totalQty += trackingNums.Length;
                                    }
                                }
                                else
                                {
                                    trackingNums = trackingNums.Concat(new string[] { sod.ItemFfds.ElementAt(i).TrackNo }).ToArray();
                                    totalQty += trackingNums.Length;
                                }
                                totalReqQty += sod.ItemFfds.ElementAt(i).QtyFulfilled;
                            }

                            Orderline orderline = buildAsnLine(order, sod, shippedDate, shipInfo, String.Join(" ", trackingNums));
                            orderlines.orderLine[idx] = orderline;
                            idx++;
                        }

                        if (totalReqQty == totalQty)
                        {
                            orderlines.orderLine = orderlines.orderLine.Where(x => x != null).ToArray();
                            ordershipment.orderLines = orderlines;
                            shipment.orderShipment = ordershipment;
                            string jsonBody = JsonConvert.SerializeObject(shipment);
                            response = await _walmart.OrderProcess.SendASNShipment(jsonBody, poNo, whId, shipInfo);
                            for (int i = 0; i < 7 && response.StatusCode != HttpStatusCode.OK; i++)
                            {
                                response = await _walmart.OrderProcess.SendASNShipment(jsonBody, poNo, whId, shipInfo);
                            }

                            if (response.StatusCode == HttpStatusCode.OK) //succeed
                            {
                                if (apipoStatus == null)
                                {
                                    apipoStatus = new ApisoStatus();
                                    apipoStatus.SoTId = _kc.SoTs.Where(x => x.PoNo == poNo).FirstOrDefault().SoTId;
                                    apipoStatus.PoNo = wmtOrder.purchaseOrderId;
                                    apipoStatus.CustId = 26;
                                    apipoStatus.IsAcked = true;
                                    apipoStatus.SentAsn = true;
                                    apipoStatus.Ackedtime = DateTime.Now;
                                    apipoStatus.SentAsnTime = DateTime.Now;
                                    _kc.ApisoStatuses.Add(apipoStatus);
                                    _kc.SaveChanges();
                                }
                                else
                                {
                                    apipoStatus.SentAsn = true;
                                    apipoStatus.SentAsnTime = DateTime.Now;
                                    _kc.Update(apipoStatus);
                                    _kc.SaveChanges();
                                }
                                _utilMethods.BuildSyncResData(res, true, poNo);
                            }
                            else // failed
                            {
                                string detail = $"SO#: {sot.SoNo}, PO#: {poNo}, Warehouse: {wmtLoc.LocName}";
                                _utilMethods.AddInvalidation(errorApis, detail, poNo, null, ErrorType.Unknown, 26, ProcessType.SendASN);
                                _utilMethods.BuildSyncResData(res, false, detail);

                            }
                        }
                        else
                        {
                            string detail = $"Tracking qty doesn't match with order qty / SO#: {sot.SoNo}, PO#: {poNo}, Warehouse: {wmtLoc.LocName}";
                            //_utilMethods.AddInvalidation(errorApis, detail, poNo, null, ErrorType.Unknown, 26, ProcessType.SendASN);
                            _utilMethods.BuildSyncResData(res, false, detail);
                            lstTrackingQtyNotMatching = _utilMethods.BuildEmailLine(lstTrackingQtyNotMatching, $"SO#: {sot.SoNo}, PO#: {poNo}, Warehouse: {wmtLoc.LocName}");
                        }

                    }
                    else
                    {
                        if (apipoStatus == null)
                        {
                            apipoStatus = new ApisoStatus();
                            apipoStatus.SoTId = _kc.SoTs.Where(x => x.PoNo == poNo).FirstOrDefault().SoTId;
                            apipoStatus.PoNo = wmtOrder.purchaseOrderId;
                            apipoStatus.CustId = 26;
                            apipoStatus.IsAcked = true;
                            apipoStatus.SentAsn = true;
                            apipoStatus.Ackedtime = DateTime.Now;
                            apipoStatus.SentAsnTime = DateTime.Now;
                            _kc.ApisoStatuses.Add(apipoStatus);
                            _kc.SaveChanges();
                        }
                        else
                        {
                            apipoStatus.SentAsn = true;
                            apipoStatus.SentAsnTime = DateTime.Now;
                            _kc.Update(apipoStatus);
                            _kc.SaveChanges();
                        }
                    }

                    if (isAllShipped == true || (response != null && response.StatusCode == HttpStatusCode.OK))// check & change resolved error from SoErrors
                    {
                        if (koErrors.Where(x => x.PoNo == poNo && x.ProcessId == (int)ProcessType.SendASN).Any())
                        {
                            IEnumerable<SoError> resolved = koErrors.Where(x => x.PoNo.Equals(poNo) && x.ProcessId == (int)ProcessType.SendASN);
                            foreach (SoError poErr in resolved)
                            {
                                poErr.IsResolved = true;
                            }
                            _kc.SoErrors.UpdateRange(resolved);
                            _kc.SaveChanges();
                        }
                    }
                    response = null;
                }
                if (lstTrackingQtyNotMatching != "")
                {
                    MailService.Send("(856)Tracking qty doesn't match with order qty", lstTrackingQtyNotMatching, "youngjae.jo@mellow-home.com", "", true);
                }

                if (errorApis.Count() > 0)
                {
                    MailService.Send("(856)Detected Error(s) at Walmart", "Please Check  Chameleon-> Sales-> Walmart-> Walmart SO-> Error\n  URL: https://bestpricequality.net:9458/walmart", "it@bpmatt.com", "", true);
                    errorApis.RemoveAll(x => koErrors.Select(z => z.PoNo).Contains(x.PoNo) && koErrors.Select(z => z.ProcessId).Contains(2));
                    _kc.SoErrors.AddRange(errorApis);
                    _kc.SaveChanges();
                }
                if (res.Count == 0)
                    res.Add("Status", "Nothing Changed");
                return res;
            }
            catch (Exception e)
            {
                MailService.Send("(856)Unexpected Error", "Check WMT API", "youngjae.jo@mellow-home.com", "it@bpmatt.com", true);
                return res;
            }
        }
        private Orderline buildAsnLine(orderLineType order, SoD sod, DateTime shippedDate, ShipInfo shipInfo, string trackingNum)
        {
            Orderline orderline = new Orderline();
            Orderlinestatu orderlinestatus = new Orderlinestatu();
            orderline.lineNumber = order.lineNumber;
            orderlinestatus.status = "Shipped";

            orderlinestatus.asn = new Asn();
            orderlinestatus.asn.packageASN = trackingNum.Split(" ")[0];

            orderlinestatus.statusQuantity = new Statusquantity();
            orderlinestatus.statusQuantity.amount = order.orderLineQuantity.amount;
            orderlinestatus.statusQuantity.unitOfMeasurement = order.orderLineQuantity.unitOfMeasurement;

            orderlinestatus.trackingInfo = new Trackinginfo();
            orderlinestatus.trackingInfo.shipDateTime = shippedDate.ToString("yyyy-MM-ddTHH:mm:ss");

            orderlinestatus.trackingInfo.carrierName = new Carriername();
            orderlinestatus.trackingInfo.carrierName.otherCarrier = null;
            orderlinestatus.trackingInfo.carrierName.carrier = shipInfo.carrier.ToString();

            orderlinestatus.trackingInfo.methodCode = shipInfo.shippingType.ToString();
            orderlinestatus.trackingInfo.trackingNumber = trackingNum;

            Orderlinestatuses orderlinestatuses = new Orderlinestatuses();
            orderlinestatuses.orderLineStatus = new Orderlinestatu[] { orderlinestatus };
            orderline.orderLineStatuses = orderlinestatuses;

            return orderline;
        }
        public async Task<Hashtable> GetWmtOrders(string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);
            end = end.AddHours(24);
            end = end.AddMilliseconds(-1000);
            DateTime? wmtLastSyncTime = null;

            SoT sotsWmt = _kc.SoTs.Where(x => x.CustomerId == 26)?.OrderByDescending(x => x.AddedTime).FirstOrDefault();
            if (sotsWmt != null)
            {
                wmtLastSyncTime = sotsWmt.AddedTime;
            }

            Hashtable hashtable = new Hashtable();

            var koSoTs = await (from sot in _kc.SoTs
                                join sod in _kc.SoDs on sot.SoTId equals sod.SoTId
                                //join fft in _kc.ItemFfts on sot.SoTId equals fft.SoTId
                                join ffd in _kc.ItemFfds on sod.SoDId equals ffd.SoDId into fd
                                from fulfill in fd.DefaultIfEmpty()
                                join loc in _kc.BpmLocations on sod.ShipFromWhId equals loc.LocationId
                                join via in _kc.ShipVia on sod.ShipViaId equals via.ShipViaId
                                join item in _kc.BpmItems on sod.ItemNoId equals item.ItemNoId
                                join status in _kc.SoStatusKos on sod.SoStatusKoId equals status.SoStatusKoId
                                join cust in _kc.Customers on sot.CustomerId equals cust.CustomerId
                                join ps in _kc.ApisoStatuses on sot.SoTId equals ps.SoTId into p
                                from ps in p.DefaultIfEmpty()
                                where (
                                sot.CustomerId == 26)
                                && (sot.SoDate >= start && sot.SoDate <= end)
                                select new
                                {
                                    KodId = sod.SoDId,
                                    soId = sot.SoNo,
                                    customer = cust.CustName,
                                    OrderNo = sot.PoNo,
                                    sku = item.ItemName,
                                    date = sot.CustOrderTime == null ? sot.SoDate : sot.CustOrderTime,
                                    //shipWindowStart = kot.ShipWindowStart,
                                    //shipWindowEnd = kot.ShipWindowEnd,
                                    shipDate = sot.ShipWindowEnd == null ? sot.ExpShipDate : sot.ShipWindowEnd,
                                    asnSentTime = ps == null ? null : ps.SentAsnTime,
                                    ackedtime = ps == null ? null : ps.Ackedtime,
                                    trackingNo = fulfill == null ? null : fulfill.TrackNo,
                                    carrier = via.ShipViaName,
                                    WareHouse = loc.LocName,
                                    qty = sod.QtyOrdered,
                                    unitePrice = sod.UnitPrice,
                                    totalPrice = sod.QtyOrdered * sod.UnitPrice,
                                    //sorce = sot.Source,
                                    //date = kot.CustOrdTime,
                                    //Name = kot.ShipToName,
                                    orderStatus = status.StatusKo,
                                    addedTime = sot.AddedTime,
                                    //qtyAvaliale = inv.QtyAvail,
                                    //dropShipLastSyncTime = dropShipLastSyncTime,
                                    //dirLastSyncTime = dirLastSyncTime
                                }
                                ).ToListAsync();

            hashtable.Add("data", koSoTs);
            hashtable.Add("wmtLastSyncTime", wmtLastSyncTime);
            return hashtable;
        }
        public async Task<dynamic> GetASNError()
        {
            var errors = await _kc.SoErrors
            .Include(x => x.Customer)
            .Include(x => x.ErrorCat)
            .Include(x => x.Process)
            .Where(x => (x.CustomerId == 26 && x.ProcessId == 2))
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
            return errors;

        }
        public async Task<dynamic> GetError()
        {
            _kc.Database.SetCommandTimeout(120);

            var errors = await (from poe in _kc.SoErrors
                                join sot in _kc.SoTs on poe.PoNo equals sot.PoNo
                                join sod in _kc.SoDs on sot.SoTId equals sod.SoTId
                                join cust in _kc.Customers on poe.CustomerId equals cust.CustomerId
                                join errCat in _kc.ErrorCategories on poe.ErrorCatId equals errCat.ErrorCatId
                                join proc in _kc.ApisSoprocesses on poe.ProcessId equals proc.ProcessId
                                where poe.CustomerId == 26 && poe.IsResolved == false
                                select new
                                {
                                    errorId = poe.ErrorId,
                                    procesId = proc.ProcessId,
                                    action = proc.ProcessType,
                                    errorCat = errCat.CatType,
                                    poNo = poe.PoNo,
                                    customer = cust.CustName,
                                    custSKU = poe.CustSku,
                                    detail = poe.Detail,
                                    isReSolved = poe.IsResolved,
                                    createdTime = poe.CeatedTime,
                                    resolvedTime = poe.ResolvedTime,
                                    shipvia = sod.ShipViaId,
                                    koSkuId = sod.ItemNoId,
                                    scac = sod.ShipScac
                                }
                          ).ToListAsync();
            var resolvedLst = errors.Where(x => x.koSkuId != 1879 && x.scac != null && x.procesId == (int)ProcessType.GetOrder).ToList(); // unknown and tbd
            List<SoError> updateLst = _kc.SoErrors.Where(x => resolvedLst.Select(y => y.errorId).Contains(x.ErrorId)).ToList();
            if (updateLst.Count > 0)
            {
                foreach (SoError err in updateLst)
                {
                    err.IsResolved = true;
                    err.ResolvedTime = DateTime.Now;
                }
                _kc.UpdateRange(updateLst);
                _kc.SaveChanges();
            }
            errors.RemoveAll(x => x.koSkuId != 1879 && x.scac != null && x.procesId == (int)ProcessType.GetOrder);

            //var errors = await _kc.SoErrors
            //.Include(x => x.Customer)
            //.Include(x => x.ErrorCat)
            //.Include(x => x.Process)
            //.Where(x => (x.CustomerId == 26 && (x.ProcessId == 1 || x.ProcessId == 2)))
            //.Select(x => new
            //{
            //    action = x.Process.ProcessType,
            //    errorCat = x.ErrorCat.CatType,
            //    poNo = x.PoNo,
            //    customer = x.Customer.CustName,
            //    custSKU = x.CustSku,
            //    detail = x.Detail,
            //    isReSolved = x.IsResolved,
            //    createdTime = x.CeatedTime,
            //    resolvedTime = x.ResolvedTime
            //}
            //)
            //.ToListAsync();
            return errors;


        }
        public async Task<dynamic> GetMissingNsSync()
        {
            DateTime standard = new DateTime(2022, 2, 17, 0, 0, 0);
            //DateTime beforeTime = DateTime.Now.AddMinutes(-10);
            DateTime beforeTime = DateTime.Now;

            var koSots = await _kc.SoTs
            .Include(x => x.SoDs)
            .Include(x => x.Customer.Market)
            .Where(x => (x.AddedTime > standard && x.AddedTime > standard && x.AddedTime < beforeTime) && x.NsSyncTime == null && (x.Source == "API" || x.Source == "EDI") && (x.CustomerId == 26))
            .Select(x => new
            {
                customer = x.Customer.CustName,
                poNo = x.PoNo,
                custOrdTime = x.AddedTime
            }).ToListAsync();
            return koSots;

            //.Where(x => x.AddedDate > standard && x.KoSoDs.Any(y => y.NsSyncTime == null) && (x.Source == "API" || x.Source == "EDI"))
            //.Where(x => x.AddedDate > standard && x.KoSoDs.Count > 0 && x.Source == "EDI")
            //.Where(x => x.AddedDate > standard && x.PoNo == "MxhXcJPlV")
        }
        public async Task<dynamic> GetPendingAck(string startDate, string endDate)
        {

            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);
            DateTime standardDate = DateTime.Parse("2022-03-14");
            var sots = _kc.SoTs.Include(x => x.SoDs)
                               .Include(x => x.ApisoStatus)
                               .Include(x => ((SoD)x.SoDs).ShipFromWh)
                               .Include(x => ((SoD)x.SoDs).ItemNo)
                               .Include(x => ((SoD)x.SoDs).SoStatusKo)
                               .Include(x => x.SoCancel)
                        .Where(x => x.SoDate >= standardDate &&
                        x.SoDate >= start && x.SoDate <= end && x.CustomerId == 26
                        && x.CustomerId == 26 && (x.ApisoStatus == null || x.ApisoStatus.IsAcked == false) && x.NsIntId != null &&
                        (x.SoCancel.IsCancelled == false || x.SoCancel == null) && x.SoDs.Any(y => y.SoStatusKoId != 9)

                        )
                        .Select(x => new
                        {
                            x.PoNo,
                            x.SoDate,
                            x.SoTotal,
                            x.SoDs.Count,
                            committedCount = x.SoDs.Where(x => x.SoStatusKoId == 4).Count(),
                            x.SoDs.FirstOrDefault().ShipFromWh.LocName,
                            sod = x.SoDs.Select(x => new { x.ItemNo.ItemName, x.QtyOrdered, x.UnitPrice, x.SoStatusKo.StatusKo })
                        });


            return sots;
        }
        public async Task<dynamic> GetPendingAsn(string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);
            DateTime standardDate = DateTime.Parse("2022-03-14");
            var sots = _kc.SoTs.Include(x => x.SoDs)
                               .Include(x => x.ApisoStatus)
                               .Include(x => ((SoD)x.SoDs).ShipFromWh)
                               .Include(x => ((SoD)x.SoDs).ItemNo)
                               .Include(x => x.SoCancel)
                        .Where(x =>
                                  x.ShipWindowEnd >= standardDate &&
                                  x.CustomerId == 26 &&
                                 (x.ApisoStatus == null || x.ApisoStatus.SentAsn == false) &&
                                  x.ShipWindowEnd >= start &&
                                  x.ShipWindowEnd <= end &&
                                 (x.SoCancel.IsCancelled == false || x.SoCancel == null) && x.SoDs.Any(y => y.SoStatusKoId != 9)
                                 )
                        .Select(x => new
                        {
                            x.PoNo,
                            x.SoDate,
                            ExpShipDate = x.ShipWindowEnd,
                            x.SoTotal,
                            x.SoDs.Count,
                            x.SoDs.FirstOrDefault().ShipFromWh.LocName,
                            sod = x.SoDs.Select(x => new { x.ItemNo.ItemName, x.QtyOrdered, x.UnitPrice })
                        });
            return sots;
        }
        public async Task<dynamic> GetPendingCancel()
        {
            var sots = _kc.SoTs.Include(x => x.SoDs)
                               .Include(x => ((SoD)x.SoDs).ShipFromWh)
                               .Include(x => ((SoD)x.SoDs).ItemNo)
                               .Include(x => x.SoCancel)
                        .Where(x => (x.SoCancel.IsCancelled == false && x.SoCancel.IsShipped == false)
                                 )
                        .Select(x => new
                        {
                            x.PoNo,
                            x.SoDate,
                            x.SoTotal,
                            x.SoDs.Count,
                            sod = x.SoDs.Select(x => new { x.ItemNo.ItemName, x.QtyOrdered, x.UnitPrice, x.SoStatusKo.StatusKo })
                        });


            return sots;
        }
        public async Task<bool> GetRetailPrice()
        {
            List<WmtReport> wmtReports = await _walmart.OrderProcess.GetItemReport();
            DateTime today = DateTime.Now.Date;
            foreach (WmtReport item in wmtReports)
            {
                //if (item.availableInventoryUnits == "" || item.availableInventoryUnits == "0")
                //    continue;

                ActualWmtPrice wmItem = _kc.ActualWmtPrices.Where(x => x.WmtItemNo == Convert.ToInt32(item.wm) && x.ItemType == 7).FirstOrDefault();
                if (wmItem == null)
                    continue;
                RetailPriceHistory retailPrice = new RetailPriceHistory();
                retailPrice.RptTime = today;
                retailPrice.MarketPlaceId = 3;
                retailPrice.SellerId = 4;
                retailPrice.ItemNoId = wmItem.ItemNo;
                retailPrice.Price = item.price != "" ? Convert.ToDecimal(item.price) : 0;
                retailPrice.IsOos = item.availableInventoryUnits == "" || item.availableInventoryUnits == "0" ? true : false;
                _kc.RetailPriceHistories.Add(retailPrice);
                _kc.SaveChanges();

            }
            return true;
        }
    }
    public class ItemLst
    {
        public int? itemId;
        public int? itemType;
    }
    public class ShipInfo
    {
        public carrierType carrier;
        public shippingMethodCodeType shippingType;
    }
    public class GroupedPO
    {
        public string po { get; set; }
        public string location { get; set; }
        public string shipmethod { get; set; }
        public string trackingNums { get; set; }
        public string? shipTime { get; set; }
    }
}
