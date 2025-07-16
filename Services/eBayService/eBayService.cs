using Chameleon.DTOs.eBay;
using Chameleon.ebay.sellFulfillment;
using Chameleon.Models;
using Chameleon.Services.ServiceUtil;
using Chameleon.Services.SuiteTalkerService;
using eBay.ApiClient.Auth.OAuth2;
using eBay.ApiClient.Auth.OAuth2.Model;
using EbayEventNotificationSDK;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SuitetalkerService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using YamlDotNet.RepresentationModel;

namespace Chameleon.Services.eBayService
{
    public class eBayService: IeBayService
    {
        private readonly KOALAContext _kc;
        private readonly ILogger<eBayService> _logger;
        private OAuth2Api oAuth2Api = new OAuth2Api();
        private readonly sell_fulfillment_v1_oas3Client sell_Fulfillment;
        private readonly UtilMethods _utilMethods;

        public eBayService(KOALAContext kc, ILogger<eBayService> logger)
        {
            _kc = kc;
            _logger = logger;
            sell_Fulfillment = new sell_fulfillment_v1_oas3Client(new System.Net.Http.HttpClient());
            _utilMethods = new UtilMethods(kc);
        }

        public bool saveNotification(Rootobject body)
        {
            EBayNotification notification = new EBayNotification();
            notification.Topic = body.metadata.topic;
            notification.SchemaVerison = body.metadata.schemaVersion;
            notification.Deprecated = body.metadata.deprecated;

            notification.NotificationId = body.notification.notificationId;
            notification.EventDate = DateTime.Parse(body.notification.eventDate);
            notification.PublishDate = DateTime.Parse(body.notification.publishDate);
            notification.PublishAttemtCount = body.notification.publishAttemptCount;

            notification.UserName = body.notification.data.username;
            notification.UserId = body.notification.data.userId;
            notification.EiasToken = body.notification.data.eiasToken;
            try
            {
                _kc.EBayNotifications.Add(notification);
                _kc.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public async Task<Hashtable> ebayGetOrders() 
        {

            string token = GetAndSaveAccessToken(OAuthEnvironment.PRODUCTION);
            //string token = "v^1.1#i^1#r^0#p^3#f^0#I^3#t^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";   
            DateTime? max = (await (from sot in _kc.SoTs
                                    join sod in _kc.SoDs on sot.SoTId equals sod.SoTId
                                    join cust in _kc.Customers on sot.CustomerId equals cust.CustomerId
                                    where (
                                    sot.CustomerId == 12)
                                    orderby sot.CustOrderTime descending
                                    select sot
             ).FirstOrDefaultAsync()).CustOrderTime;

           
            if(max == null)
            {
                max = (await (from sot in _kc.SoTs
                                        join sod in _kc.SoDs on sot.SoTId equals sod.SoTId
                                        join cust in _kc.Customers on sot.CustomerId equals cust.CustomerId
                                        where (
                                        sot.CustomerId == 12)
                                        orderby sot.AddedTime descending
                                        select sot
                ).FirstOrDefaultAsync()).AddedTime;
            }
            string start = max.Value.AddDays(-2).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

            OrderSearchPagedCollection ordersearh = await sell_Fulfillment.GetOrdersAsync(null, $"creationdate:%5B{start}..%5D", null, null, null, token);
            ordersearh.Orders = ordersearh.Orders.OrderBy(x => x.CreationDate).ToList();
            Hashtable resCollector = new Hashtable();
            List<List<string>> succeed = new List<List<string>>();
            List<List<string>> fail = new List<List<string>>();
            resCollector.Add("succeed", succeed);
            resCollector.Add("fail", fail);

            List<BpmLocation> bpmLocations = _kc.BpmLocations.ToList();
            List<SoError> poErrors = new List<SoError>();
            List<SoError> koErrors = _kc.SoErrors.ToList();
            List<int> SoT_ids = new List<int>();
            List<Models.Country> countries = _kc.Countries.ToList();
            List<ShipVium> koShipvias = _kc.ShipVia.ToList();
            List<MkIcr> eBaySKUs = _kc.MkIcrs.Where(x => x.MarketId == 5).ToList();
            int total = ordersearh.Orders.Count;
            string errDetail = "";
            int idx = 0;

            DateTime dtnow = DateTime.Now;
            int cutOffTime = _kc.BpmBizRules.Where(x => x.BpmBizRulesId == 1).FirstOrDefault().DsCutOffTime.Value;           
            if (dtnow.Hour > cutOffTime) 
                dtnow = dtnow.AddDays(1);
            var nextBizDay = (DateTime)(from o in _kc.DimDates
                                       where o.DateTime >= dtnow.Date && o.IsWeekday == true && o.IsBpmholiday == false
                                       select o.DateTime).Min();

            foreach (EbayOrder po in ordersearh.Orders)
            {
                #region Test
                //if (idx != 0)
                //    continue;
                //idx++;
                #endregion
                bool isExist = _kc.SoTs.Any(x => x.PoNo == po.OrderId);
                if (isExist)
                {
                    total -= 1;
                    continue;
                }

                SoT SoT = new SoT();
                SoT.CustomerId = 12;
                SoT.PoNo = po.OrderId;

                if (po.FulfillmentStartInstructions.Count == 0 || po.FulfillmentStartInstructions.Any(x => x.FulfillmentInstructionsType != "SHIP_TO"))
                {
                    errDetail = _utilMethods.BuildEmailLine(errDetail, $"({SoT.PoNo})No fullfillment Info Lines: \"{po.OrderId}\" Solution: Contact eBay about lack of info");
                    errDetail = _utilMethods.BuildEmailLine(errDetail, $"-----------------------------------------------------------");
                    continue;
                }

                //SoT.IoNo = po.customerOrderId;
                SoT.SoDate = DateTime.Parse(po.CreationDate).ToLocalTime();
                SoT.CustOrderTime = DateTime.Parse(po.CreationDate).ToLocalTime();

                FulfillmentStartInstruction shipInfo = po.FulfillmentStartInstructions.Where(x => x.FulfillmentInstructionsType == "SHIP_TO").First();
                SoT.ShipToName = shipInfo.ShippingStep.ShipTo.FullName;
                SoT.Address1 = shipInfo.ShippingStep.ShipTo.ContactAddress.AddressLine1;
                SoT.Address2 = shipInfo.ShippingStep.ShipTo.ContactAddress.AddressLine2;
                SoT.City = shipInfo.ShippingStep.ShipTo.ContactAddress.City;
                SoT.State = shipInfo.ShippingStep.ShipTo.ContactAddress.StateOrProvince;
                SoT.Zip = shipInfo.ShippingStep.ShipTo.ContactAddress.PostalCode;
                SoT.Country = _utilMethods.CountryCodeToName(po.Buyer.TaxAddress.CountryCode, CountryMode.Alpha2, countries);
                SoT.ExpShipDate = nextBizDay.Date;
                SoT.ShipWindowStart = nextBizDay.Date;
                SoT.ShipWindowEnd = DateTime.Parse(shipInfo.MinEstimatedDeliveryDate).ToLocalTime().Date;
                SoT.PhoneNo = shipInfo.ShippingStep.ShipTo.PrimaryPhone.PhoneNumber1;
                SoT.BulkBuy = 0;
                SoT.Source = "API";
                SoT.LastModTime = DateTime.Now;
                SoT.AddedTime = DateTime.Now;
                decimal soTotal = 0;
                decimal? unitePrice;
                int shipviaId;
                bool isError = false;
                // Fedex => UPS
                //if (shipInfo.ShippingStep.ShippingServiceCode == "FedExHomeDelivery")
                //{
                //    shipviaId = koShipvias.Find(x => x.ShipViaName == "FedEX Home Delivery").ShipViaId;
                //}
                //else
                //{
                //    errDetail = _utilMethods.BuildEmailLine(errDetail, $"({SoT.PoNo})shipping name : {shipInfo.ShippingStep.ShippingServiceCode}");
                //    shipviaId = 14; // LTL truck
                //    isError = true;
                //}
                shipviaId = 15;
                int lineNum = 0;
                foreach (LineItem line in po.LineItems)
                {
                    SoD SoD = new SoD();
                    SoD.ShipScac = shipInfo.ShippingStep.ShippingServiceCode;
                    SoD.SoT = SoT;
                    SoD.SoDate = DateTime.Parse(po.CreationDate);
                    SoD.SoTId = SoT.SoTId;
                    SoD.ShipViaId = shipviaId;
                    SoD.ExpShipDate = nextBizDay.Date;
                    SoD.ShipWindowStart = nextBizDay.Date;
                    SoD.ShipWindowEnd = DateTime.Parse(shipInfo.MinEstimatedDeliveryDate).ToLocalTime().Date;
                    SoD.TargetDate = DateTime.Parse(shipInfo.MaxEstimatedDeliveryDate).ToLocalTime().Date;
                    SoD.CustSku = line.Sku;
                    int? item_id = eBaySKUs.Find(x => x.CustSku == line.Sku)?.ItemNoId;
                    if (item_id == null)
                    {
                        errDetail = _utilMethods.BuildEmailLine(errDetail, $"({SoT.PoNo})Unkown Customer SKU: \"{line.Sku}\"");
                        item_id = 1879; // unknown item
                        unitePrice = 0;
                        isError = true;
                    }

                    unitePrice = Convert.ToDecimal(line.LineItemCost.Value)/ Convert.ToInt32(line.Quantity);

                    SoD.ItemNoId = item_id.Value;
                    SoD.ItemNo = _kc.BpmItems.Where(x => x.ItemNoId == SoD.ItemNoId).FirstOrDefault();
                    //if (SoD.ItemNoId == 1879)
                    //{
                    //    errDetail = _utilMethods.BuildEmailLine(errDetail, $"({SoT.PoNo})Ship Location : TBD");
                    //    SoD.ShipFromWhId = 32;
                    //    isError = true;
                    //}
                    SoD.ShipFromWhId = 32;
                    SoD.CustSku = line.Sku;
                    SoD.LineTotal = Convert.ToDecimal(line.Total.Value);
                    soTotal += SoD.LineTotal.Value;
                    SoD.UnitPrice = unitePrice.Value;
                    SoD.SoStatusKoId = 1;
                    SoD.QtyOrdered = Convert.ToInt32(line.Quantity);
                    SoD.PriceLevelId = 1;
                    SoD.QtyBackOrdered = 0;
                    SoD.QtyRejected = 0;
                    SoD.QtyCommitted = 0;
                    SoD.QtyInvoiced = 0;
                    SoD.IsRejectAcpt = 0;
                    SoD.AutoBol = 0;
                    SoD.SodLineNo = ++lineNum;
                    SoD.LastModTime = DateTime.Now;
                    SoD.AddedTime = DateTime.Now;
                    SoT.SoDs.Add(SoD);
                }

				SoT.SoTotal = soTotal;
				// check ship from location 
				//SoT = await _utilMethods.SetPickWarehouse(SoT);
				//bool is3PL = _kc.BpmLocations.Where(x => x.LocationId == SoT.SoDs.FirstOrDefault().ShipFromWhId).FirstOrDefault().Is3Pl;
				//int? offset = _kc.BpmLocations.Where(x => x.LocationId == SoT.SoDs.FirstOrDefault().ShipFromWhId).FirstOrDefault().TimeOffset;
				//if (offset != null && is3PL && offset != 0 && dtnow.Hour > cutOffTime - offset)
				//{
				//    DateTime temDt = dtnow.AddDays(1);
				//    nextBizDay = (DateTime)(from o in _kc.DimDates
				//                                where o.DateTime >= temDt.Date && o.IsWeekday == true && o.IsBpmholiday == false
				//                                select o.DateTime).Min();
				//    SoT.ShipWindowStart = nextBizDay.Date;
				//    SoT.ExpShipDate = nextBizDay.Date;
				//    foreach (SoD SoD in SoT.SoDs)
				//    {
				//        SoD.ShipWindowStart = nextBizDay.Date;
				//        SoD.ExpShipDate = nextBizDay.Date;
				//    }

				//}
				//SoTs.Add(SoT);

				try
				{
					_kc.Add(SoT);
					_kc.SaveChanges();
					((List<List<string>>)resCollector["succeed"]).Add(new List<string>() { SoT.PoNo });
					SoT_ids.Add(SoT.SoTId);
				}
                catch(Exception e)
                {
                    ((List<List<string>>)resCollector["fail"]).Add(new List<string>() { SoT.PoNo });
					errDetail = _utilMethods.BuildEmailLine(errDetail, $"({SoT.PoNo})Insert Error: \"{SoT.PoNo}\"");
					continue;
				}

				if (isError)
					errDetail = _utilMethods.BuildEmailLine(errDetail, $"-----------------------------------------------------------");
			}

            if(SoT_ids.Count>0)
			    await APIClient.Client.SalesOrderPickWHAsync(SoT_ids);

			if (errDetail != "")
            {
                MailService.Send("Need Actions For eBay Order Process", errDetail, "youngjae.jo@mellow-home.com", "", true);
            }

            if (((List<List<string>>)resCollector["fail"]).Count > 0)
            {
                MailService.Send("(850)Founded ebay Error", "check log", "youngjae.jo@mellow-home.com", "", true);
            }

            return resCollector;
        }
        public async Task<EbayOrder> ebayGetOrder(string poNo)
        {
            string token = GetAndSaveAccessToken(OAuthEnvironment.PRODUCTION);
            ResponseData resEbay = await sell_Fulfillment.GetOrderAsync(null, poNo, token);
            if (resEbay.Code != HttpStatusCode.OK)
                return null;
            return (EbayOrder)resEbay.resData;
        }
        public async Task<EbayOrder> ebayGetOrder(string poNo, string token)
        {
            ResponseData resEbay = await sell_Fulfillment.GetOrderAsync(null, poNo, token);
            if (resEbay.Code != HttpStatusCode.OK)
                return null;
            return (EbayOrder)resEbay.resData;
        }
        public async Task<Hashtable> Send_eBayShipment()
        {
            Hashtable res = new Hashtable();
            DateTime standardDate = DateTime.Parse("2022-10-05");
            _kc.Database.SetCommandTimeout(120);
            List<SoT> PreAsnLst = _kc.SoTs
                                  .Include(x => x.SoDs)
                                  .Include(x => ((SoD)x.SoDs).ItemFfds)
                                  .Include(x => x.ItemFfts)
                                  .Include(x => ((SoD)x.SoDs).ShipFromWh)
                                  .Include(x => ((SoD)x.SoDs).ShipVia)
                                  .Include(x => x.ApisoStatus)
                                  .Where(x => x.SoDate >= standardDate &&
                                              x.CustomerId == 12 &&
                                              x.SoDs.All(y => y.ItemFfds.Count != 0) &&
                                              x.ApisoStatus == null &&
                                              x.ItemFfts.All(z => z.IfStatusId == 3)
                                              ).ToList();

            //_kc.Database.SetCommandTimeout(120);
            //List<SoT> PreAsnLst = _kc.SoTs
            //          .Include(x => x.SoDs)
            //          .Include(x => ((SoD)x.SoDs).ItemFfds)
            //          .Include(x => x.ItemFfts)
            //          .Include(x => ((SoD)x.SoDs).ShipFromWh)
            //          .Include(x => ((SoD)x.SoDs).ShipVia)
            //          .Include(x => x.ApisoStatus)
            //          .Where(x => x.PoNo == "01-08789-90746" &&
            //                      x.CustomerId == 12 &&
            //                      x.SoDs.All(y => y.ItemFfds.Count != 0) &&
            //                      x.ApisoStatus == null &&
            //                      x.ItemFfts.All(z => z.IfStatusId == 3)
            //                      ).ToList();
            if (PreAsnLst.Count == 0)
                return res;
            string token = GetAndSaveAccessToken(OAuthEnvironment.PRODUCTION);
            string errDetail = "";
            List<SoError> errorApis = new List<SoError>();
            List<SoError> koErrors = await _kc.SoErrors.Where(x => x.CustomerId == 12 && x.ProcessId == (int)ProcessType.SendASN).ToListAsync();
            foreach (SoT sot in PreAsnLst)
            {
                bool isError = false;
                string poNo = sot.PoNo;
                EbayOrder order = await ebayGetOrder(poNo, token);
                if(order == null )
                {
                    if(!_kc.SoErrors.Any(x => x.PoNo == poNo))
                    {
                        string detail = $"PoNo:{poNo}, Not found from eBay";
                        _utilMethods.AddInvalidation(errorApis, detail, poNo, null, ErrorType.Unknown, 12, ProcessType.GetOrder);
                        _utilMethods.BuildSyncResData(res, false, detail);
                        isError = true;
                    }
                    continue;
                }
                bool validateType = order.FulfillmentStartInstructions.Any(x => x.FulfillmentInstructionsType == "SHIP_TO");
                bool isNullShipDate = sot.ItemFfts.FirstOrDefault().ShipDate == null;
                if (isNullShipDate)
                {
                    string detail = $"PoNo:{poNo}, No actual shipping date on our DB";
                    _utilMethods.AddInvalidation(errorApis, detail, poNo, null, ErrorType.NotFoundFromDB, 12, ProcessType.SendASN);
                    _utilMethods.BuildSyncResData(res, false, detail);
                    errDetail = _utilMethods.BuildEmailLine(errDetail, detail);
                    isError = true;
                    continue;
                }
                if (!validateType)
                {
                    string detail = $"PoNo:{poNo}, No shipping info from eBay";
                    _utilMethods.AddInvalidation(errorApis, detail, poNo, null, ErrorType.ErrResponse, 12, ProcessType.SendASN);
                    _utilMethods.BuildSyncResData(res, false, detail);
                    errDetail = _utilMethods.BuildEmailLine(errDetail, detail);
                    isError = true;
                    continue;
                }

                string shippedTimedUTC = sot.ItemFfts.FirstOrDefault().ShipDate.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                string carrierCode = order.FulfillmentStartInstructions.Where(x => x.FulfillmentInstructionsType == "SHIP_TO").DefaultIfEmpty().FirstOrDefault().ShippingStep.ShippingCarrierCode;
                ShippingFulfillmentDetails shippingFulfillmentDetails = new ShippingFulfillmentDetails();
                int succeedCnt = 0;
                foreach (SoD sod in sot.SoDs)
                {
                    bool foundItemLine = order.LineItems.Any(x => x.Sku == sod.CustSku);
                    if (foundItemLine)
                    {
                        LineItem line = order.LineItems.Where(x => x.Sku == sod.CustSku).FirstOrDefault();

                        if(line.LineItemFulfillmentStatus == "FULFILLED")
                        {
                            succeedCnt++;
                            _utilMethods.BuildSyncResData(res, "Manual", poNo +"/"+ sod.CustSku);
                            continue;
                        }

                        //If itemFFD has multiple line for one item, It count every qty and collect tracking# 
                        #region If itemFFD has multiple line for one item, It count every qty and collect tracking# 
                        int qtyFullfilled = sod.ItemFfds.FirstOrDefault().QtyFulfilled;
                        int totalQty = 0;
                        int totalReqQty = 0;
                        string[] trackingNums = new string[0];
                        for (int i = 0; i < sod.ItemFfds.Count; i++)
                        {
                            totalReqQty += sod.ItemFfds.ElementAt(i).QtyFulfilled;

                            if (sod.ItemFfds.ElementAt(i).TrackNo.Contains(','))
                            {
                                string[] splitedTrackNos = sod.ItemFfds.ElementAt(i).TrackNo.Split(',');
                                // check number of tracking# matches with qty fulfilled
                                trackingNums = trackingNums.Concat(splitedTrackNos).ToArray();
                                totalQty += trackingNums.Length;

                            }
                            else if (sod.ItemFfds.ElementAt(i).TrackNo.Contains(' '))
                            {
                                string[] splitedTrackNos = sod.ItemFfds.ElementAt(i).TrackNo.Split(' ');
                                // check number of tracking# matches with qty fulfilled
                                trackingNums = trackingNums.Concat(splitedTrackNos).ToArray();
                                totalQty += trackingNums.Length;

                            }
                            else
                            {
                                trackingNums = trackingNums.Concat(new string[] { sod.ItemFfds.ElementAt(i).TrackNo }).ToArray();
                                totalQty += trackingNums.Length;
                            }
                        }
                        #endregion
                        if (totalReqQty == totalQty)
                        {
                            foreach (string trackingNo in trackingNums)
                            {
                                shippingFulfillmentDetails.LineItems = new List<LineItemReference>();

                                LineItemReference lineItem = new LineItemReference();
                                lineItem.LineItemId = line.LineItemId;
                                lineItem.Quantity = null;
                                shippingFulfillmentDetails.LineItems.Add(lineItem);

                                shippingFulfillmentDetails.ShippedDate = shippedTimedUTC;
                                shippingFulfillmentDetails.ShippingCarrierCode = carrierCode;
                                shippingFulfillmentDetails.TrackingNumber = trackingNo;
                                HttpStatusCode send = await sell_Fulfillment.CreateShippingFulfillmentAsync(poNo, shippingFulfillmentDetails, token);                               
                                if(send == HttpStatusCode.Created)
                                    succeedCnt++;
                            }
                        }
                        else
                        {
                            string detail = $"PoNo:{poNo}, Tracking Qty do not match with fulfiled qty / SO#: {sot.SoNo}, PO#: {poNo}";
                            _utilMethods.AddInvalidation(errorApis, detail, poNo, null, ErrorType.NotFoundFromDB, 12, ProcessType.SendASN);
                            _utilMethods.BuildSyncResData(res, false, detail);
                            errDetail = _utilMethods.BuildEmailLine(errDetail, detail);
                            isError = true;
                        }

                    }
                    else
                    {
                        string detail = $"PoNo:{poNo}, No founded line from eBay";
                        _utilMethods.AddInvalidation(errorApis, detail, poNo, null, ErrorType.ErrResponse, 12, ProcessType.SendASN);
                        _utilMethods.BuildSyncResData(res, false, detail);
                        errDetail = _utilMethods.BuildEmailLine(errDetail, detail);
                        isError = true;
                        continue;
                    }
                }

                if (succeedCnt == 0)
                {
                    string detail = $"PoNo:{poNo}, Zero fulfiiled.";
                    errDetail = _utilMethods.BuildEmailLine(errDetail, detail);
                    _utilMethods.BuildSyncResData(res, false, poNo);
                    isError = true;
                }
                else if (succeedCnt < order.LineItems.Count)
                {
                    string detail = $"PoNo:{poNo}, Partial fulfiiled.";
                    errDetail = _utilMethods.BuildEmailLine(errDetail, detail);
                    _utilMethods.BuildSyncResData(res, "Partial", poNo);
                    isError = true;
                }
                else
                { 
                    _utilMethods.BuildSyncResData(res, true, poNo);
                    ApisoStatus apipoStatus = new ApisoStatus();
                    apipoStatus.SoTId = _kc.SoTs.Where(x => x.PoNo == poNo).FirstOrDefault().SoTId;
                    apipoStatus.PoNo = sot.PoNo;
                    apipoStatus.CustId = 12;
                    apipoStatus.IsAcked = false;
                    apipoStatus.SentAsn = true;
                    apipoStatus.SentAsnTime = DateTime.Now;
                    _kc.ApisoStatuses.Add(apipoStatus);
                    _kc.SaveChanges();
                }

                if (isError)
                    errDetail = _utilMethods.BuildEmailLine(errDetail, $"----------------------------------------------------------------------------<br/>");

            }
            if (errorApis.Count() > 0)
            {
                //MailService.Send("(856)Detected Error(s) at eBay", "Please Check  Chameleon-> Sales-> Walmart-> Walmart SO-> Error\n  URL: https://bestpricequality.net:9458/walmart", "it@bpmatt.com", "", true);
                errorApis.RemoveAll(x => koErrors.Select(z => z.PoNo).Contains(x.PoNo) && koErrors.Select(z => z.ProcessId).Contains(2));
                _kc.SoErrors.AddRange(errorApis);
                _kc.SaveChanges();
            }
            if (errDetail != "")
            {
                //MailService.Send("Need Actions For eBay Order Process", errDetail, "edisupport@bpmatt.com", "", true);
                MailService.Send("Need Actions For eBay Order Process", errDetail, "youngjae.jo@mellow-home.com", "", true);

            }
            #region test
            //string token = GetAndSaveAccessToken(OAuthEnvironment.PRODUCTION);
            //EbayOrder order = await ebayGetOrder("05-09057-53537", token);
            //ShippingFulfillmentDetails shippingFulfillmentDetails = new ShippingFulfillmentDetails();
            //LineItemReference lineItem = new LineItemReference();
            //lineItem.LineItemId = order.LineItems.ElementAt(0).LineItemId;
            ////lineItem.Quantity = 1;
            //shippingFulfillmentDetails.LineItems = new List<LineItemReference>();
            //shippingFulfillmentDetails.LineItems.Add(lineItem);
            //shippingFulfillmentDetails.ShippedDate = DateTime.Parse("2022-09-07 08:48:43.000").ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            //bool validateType = order.FulfillmentStartInstructions.Any(x => x.FulfillmentInstructionsType == "SHIP_TO");
            //if (validateType)
            //{
            //    shippingFulfillmentDetails.ShippingCarrierCode = order.FulfillmentStartInstructions.Where(x => x.FulfillmentInstructionsType == "SHIP_TO").DefaultIfEmpty().FirstOrDefault().ShippingStep.ShippingCarrierCode;
            //}
            //else
            //{
            //    //log
            //}
            //shippingFulfillmentDetails.TrackingNumber = "277666438961";
            //var send = await sell_Fulfillment.CreateShippingFulfillmentAsync("05-09057-53537", shippingFulfillmentDetails, token);
            #endregion
            return res;
        }
        private string GetAndSaveAccessToken(OAuthEnvironment environment)
        {
            EbayRefreshToken ebayRefreshToken = _kc.EbayRefreshTokens.FirstOrDefault();
            IList<string> scopes = new List<string>() { "https://api.ebay.com/oauth/api_scope/sell.fulfillment" };
            OAuthResponse oAuthResponse;
            if (ebayRefreshToken == null || ebayRefreshToken.ExpiresTime < DateTime.Now)
            {
                UserCredential userCredential = ReadUserNamePassword(environment);
                if ("<sandbox-username>".Equals(userCredential.UserName) || "<production-username>".Equals(userCredential.UserName) || "<sandbox-user-password>".Equals(userCredential.Pwd) || "<production-user-password>".Equals(userCredential.Pwd))
                {
                    Console.WriteLine("User name and password are not specified in test-config-sample.yaml");
                    return "";
                }
                String authorizationUrl = oAuth2Api.GenerateUserAuthorizationUrl(environment, scopes, null);
                Console.WriteLine("AuthorizationUrl => " + authorizationUrl);
                String authorizationCode = GetAuthorizationCode(authorizationUrl, userCredential);
                Console.WriteLine("AuthorizationCode => " + authorizationCode);
                oAuthResponse = oAuth2Api.ExchangeCodeForAccessToken(environment, authorizationCode);

                if (ebayRefreshToken == null)
                {
                    ebayRefreshToken = new EbayRefreshToken();
                    ebayRefreshToken.Token = oAuthResponse.RefreshToken.Token;
                    ebayRefreshToken.ExpiresTime = oAuthResponse.RefreshToken.ExpiresOn;
                    ebayRefreshToken.TokenType = oAuthResponse.AccessToken.TokenType.ToString();
                    _kc.EbayRefreshTokens.Add(ebayRefreshToken);
                    _kc.SaveChanges();
                }
                else
                {
                    ebayRefreshToken.Token = oAuthResponse.RefreshToken.Token;
                    ebayRefreshToken.ExpiresTime = oAuthResponse.RefreshToken.ExpiresOn;
                    ebayRefreshToken.TokenType = oAuthResponse.AccessToken.TokenType.ToString();
                    _kc.Update(ebayRefreshToken);
                    _kc.SaveChanges();
                }
            }
            else
            {
                String refreshToken = ebayRefreshToken.Token;
                oAuthResponse = oAuth2Api.GetAccessToken(environment, refreshToken, scopes);
            }
            return oAuthResponse.AccessToken.Token;
        }
        private UserCredential ReadUserNamePassword(OAuthEnvironment environment)
        {
            UserCredential userCredential = new UserCredential();
            YamlStream yaml = new YamlStream();
            StreamReader streamReader = new StreamReader("././Services/eBayService/eBayLib/Samples/ebay-ID-Info.yaml");
            yaml.Load(streamReader);
            var rootNode = (YamlMappingNode)yaml.Documents[0].RootNode;
            foreach (var firstLevelNode in rootNode.Children)
            {
                foreach (var node in firstLevelNode.Value.AllNodes)
                {
                    String configEnvironment = ((YamlScalarNode)firstLevelNode.Key).Value;
                    if ((environment.ConfigIdentifier().Equals(OAuthEnvironment.PRODUCTION.ConfigIdentifier()) && "sandbox-user".Equals(configEnvironment))
                        || (environment.ConfigIdentifier().Equals(OAuthEnvironment.SANDBOX.ConfigIdentifier()) && "production-user".Equals(configEnvironment)))
                    {
                        continue;
                    }
                    if (node is YamlMappingNode)
                    {
                        foreach (var keyValuePair in ((YamlMappingNode)node).Children)
                        {
                            if ("username".Equals(keyValuePair.Key.ToString()))
                            {
                                userCredential.UserName = keyValuePair.Value.ToString();
                            }
                            else
                            {
                                userCredential.Pwd = keyValuePair.Value.ToString();
                            }
                        }
                    }
                }
            }
            return userCredential;
        }
        private String GetAuthorizationCode(String authorizationUrl, UserCredential userCredential)
        {
            IWebDriver driver = new ChromeDriver(@"././Services/eBayService/eBayLib/Samples");
            //Submit login form
            driver.Navigate().GoToUrl(authorizationUrl);
            IWebElement userId = driver.FindElement(By.Id("userid"));
            IWebElement continueBtn = driver.FindElement(By.Id("signin-continue-btn"));
            IWebElement password = driver.FindElement(By.Id("pass"));
            IWebElement submit = driver.FindElement(By.Id("sgnBt"));
            userId.SendKeys(userCredential.UserName);
            continueBtn.Click();
            //Wait for success page
            Thread.Sleep(5000);
            password.SendKeys(userCredential.Pwd);
            submit.Click();
            //Wait for success page
            Thread.Sleep(2000);
            
            String successUrl = driver.Url;
            
            //Handle consent
            if (successUrl.Contains("/consents"))
            {
                IWebElement consent = driver.FindElement(By.Id("submit"));
                consent.Click();
                Thread.Sleep(2000);
                successUrl = driver.Url;
            }
            
            int iqs = successUrl.IndexOf('?');
            String querystring = (iqs < successUrl.Length - 1) ? successUrl.Substring(iqs + 1) : String.Empty;
            // Parse the query string variables into a NameValueCollection.
            NameValueCollection queryParams = HttpUtility.ParseQueryString(querystring);
            String code = queryParams.Get("code");
            driver.Quit();
            
            return code;            
        }
        public async Task<Hashtable> GeteBayOrders(string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);
            end = end.AddHours(24);
            end = end.AddMilliseconds(-1000);
            DateTime? wmtLastSyncTime = null;

            SoT sotsWmt = _kc.SoTs.Where(x => x.CustomerId == 12)?.OrderByDescending(x => x.AddedTime).FirstOrDefault();
            if (sotsWmt != null)
            {
                wmtLastSyncTime = sotsWmt.AddedTime;
            }

            Hashtable hashtable = new Hashtable();

            var koSoTs = await (from sot in _kc.SoTs
                                join sod in _kc.SoDs on sot.SoTId equals sod.SoTId
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
                                sot.CustomerId == 12)
                                && (sot.SoDate >= start && sot.SoDate <= end)
                                select new
                                {
                                    KodId = sod.SoDId,
                                    soId = sot.SoNo,
                                    customer = cust.CustName,
                                    OrderNo = sot.PoNo,
                                    sku = item.ItemName,
                                    date = sot.CustOrderTime == null ? sot.SoDate : sot.CustOrderTime,
                                    trackingNo = fulfill == null ? null : fulfill.TrackNo,
                                    shipDate = sot.ExpShipDate,
                                    asnSentTime = ps == null ? null : ps.SentAsnTime,
                                    carrier = via.ShipViaName,
                                    WareHouse = loc.LocName,
                                    qty = sod.QtyOrdered,
                                    unitePrice = sod.UnitPrice,
                                    totalPrice = sod.QtyOrdered * sod.UnitPrice,
                                    orderStatus = status.StatusKo,
                                    addedTime = sot.AddedTime,
                                }
                                ).ToListAsync();

            hashtable.Add("data", koSoTs);
            hashtable.Add("wmtLastSyncTime", wmtLastSyncTime);
            return hashtable;
        }
        public async Task<dynamic> GetError()
        {
            var errors = await (from poe in _kc.SoErrors
                                join sot in _kc.SoTs on poe.PoNo equals sot.PoNo
                                join sod in _kc.SoDs on sot.SoTId equals sod.SoTId
                                join cust in _kc.Customers on poe.CustomerId equals cust.CustomerId
                                join errCat in _kc.ErrorCategories on poe.ErrorCatId equals errCat.ErrorCatId
                                join proc in _kc.ApisSoprocesses on poe.ProcessId equals proc.ProcessId
                                where poe.CustomerId == 12 && poe.IsResolved == false
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
            return errors;


        }

    }
}
