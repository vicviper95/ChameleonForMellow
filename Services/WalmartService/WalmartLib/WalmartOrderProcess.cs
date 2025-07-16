using Chameleon.DTOs.Walmart;
using Chameleon.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SuitetalkerService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Chameleon.Services.WalmartService
{
    public class WalmartOrderProcess : WalmartAuth
    {
        public WalmartOrderProcess() : base()
        {

        }
        public async Task<WmtOrder> GetAnOrderByPoId(string poId, string WhId)
        {
            string base_url = "https://api-gateway.walmart.com";
            string address = "/v3/orders/" + poId;
            WmtOrder result = new WmtOrder();
            var client = new RestClient(base_url);
            IRestRequest request = new RestRequest(address, Method.GET);

            request.AddQueryParameter("shipNode", WhId);

            var fullUrl = client.BuildUri(request);
            string signture = GetSignature(fullUrl.ToString(), "GET");

            request.AddHeader("Accept", "application/xml");
            request.AddHeader("WM_CONSUMER.ID", ConsumerId);
            request.AddHeader("WM_SVC.NAME", "Walmart Supplier");
            request.AddHeader("WM_QOS.CORRELATION_ID", RandomId);
            request.AddHeader("WM_SEC.TIMESTAMP", TimesStamp);
            request.AddHeader("WM_SEC.AUTH_SIGNATURE", signture);
            request.AddHeader("WM_CONSUMER.CHANNEL.TYPE", ChannelType);

            IRestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var serializer = new XmlSerializer(typeof(WmtOrder));
                using (TextReader reader = new StringReader(response.Content))
                {
                    result = (WmtOrder)serializer.Deserialize(reader);
                }
                return result;
            }
            else
            {
                return result;
            }
        }
        public async Task<List<WmtReport>> GetItemReport()
        {
            string base_url = "https://api-gateway.walmart.com";
            string address = "/v3/getReport";
            WmtOrder result = new WmtOrder();
            List<WmtReport> wmtReports = new List<WmtReport>();
            var client = new RestClient(base_url);
            IRestRequest request = new RestRequest(address, Method.GET);

            request.AddQueryParameter("type", "vendor_item");
            request.AddQueryParameter("version", "2");

            var fullUrl = client.BuildUri(request);
            string signture = GetSignature(fullUrl.ToString(), "GET");

            request.AddHeader("Accept", "application/xml");
            request.AddHeader("WM_CONSUMER.ID", ConsumerId);
            request.AddHeader("WM_SVC.NAME", "Walmart Supplier");
            request.AddHeader("WM_QOS.CORRELATION_ID", RandomId);
            request.AddHeader("WM_SEC.TIMESTAMP", TimesStamp);
            request.AddHeader("WM_SEC.AUTH_SIGNATURE", signture);
            request.AddHeader("WM_CONSUMER.CHANNEL.TYPE", ChannelType);

            IRestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Read bytes
                byte[] fileBytes = response.RawBytes;
                var headervalue = response.Headers.FirstOrDefault(x => x.Name == "Content-Disposition")?.Value;
                string contentDispositionString = Convert.ToString(headervalue);
                ContentDisposition contentDisposition = new ContentDisposition(contentDispositionString);
                string fileName = contentDisposition.FileName;
                // you can write a own logic for download file on SFTP,Local local system location

                Stream data = new MemoryStream(fileBytes);
                //System.IO.File.WriteAllBytes("D:\\" + fileName, fileBytes);

                ZipArchive archive = new ZipArchive(data);
                DataTable rawTable = new DataTable();
                foreach (ZipArchiveEntry entry in archive.Entries)
                {

                    using (var reader = new StreamReader(entry.Open()))
                    {
                        CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
                        {
                            Delimiter = ",",
                            HasHeaderRecord = true,
                            ShouldSkipRecord = record => record.Record.All(string.IsNullOrEmpty)
                        };

                        using (var csv = new CsvReader(reader, config))
                        {
                            using (var dr = new CsvDataReader(csv))
                            {
                                rawTable.Load(dr);
                            }
                        }
                    }
                }
                foreach (DataRow row in rawTable.Rows)
                {
                    WmtReport wmtReport = new WmtReport();
                    wmtReport.vendorId = row["VENDOR ID"].ToString();
                    wmtReport.sku = row["SKU"].ToString();
                    wmtReport.productName = row["PRODUCT NAME"].ToString();
                    wmtReport.productCategory = row["PRODUCT CATEGORY"].ToString();
                    wmtReport.shortDescription = row["SHORT DESCRIPTION"].ToString();
                    wmtReport.longDescription = row["LONG DESCRIPTION"].ToString();
                    wmtReport.cost = row["COST"].ToString();
                    wmtReport.price = row["PRICE"].ToString();
                    wmtReport.currency = row["CURRENCY"].ToString();
                    wmtReport.buyBoxShippingPrice = row["BUY BOX ITEM PRICE"].ToString();
                    wmtReport.publishStatus = row["PUBLISH STATUS"].ToString();
                    wmtReport.lifecycleStatus = row["LIFECYCLE STATUS"].ToString();
                    wmtReport.availabilityStatus = row["AVAILABILITY STATUS"].ToString();
                    wmtReport.shipMethods = row["SHIP METHODS"].ToString();
                    wmtReport.wpid = row["WPID"].ToString();
                    wmtReport.itemId = row["ITEM ID"].ToString();
                    wmtReport.wm = row["WM#"].ToString();
                    wmtReport.gtin = row["GTIN"].ToString();
                    wmtReport.upc = row["UPC"].ToString();
                    wmtReport.primaryImageUrl = row["PRIMARY IMAGE URL"].ToString();
                    wmtReport.shelfName = row["SHELF NAME"].ToString();
                    wmtReport.primaryCatPath = row["PRIMARY CAT PATH"].ToString();
                    wmtReport.offerStartDate = row["OFFER START DATE"].ToString();
                    wmtReport.offerEndDate = row["OFFER END DATE"].ToString();
                    wmtReport.itemCreationDate = row["ITEM CREATION DATE"].ToString();
                    wmtReport.lastUpdationDate = row["ITEM LAST UPDATED"].ToString();
                    wmtReport.itemPageUrl = row["ITEM PAGE URL"].ToString();
                    wmtReport.reviewCount = row["REVIEWS COUNT"].ToString();
                    wmtReport.averageRating = row["AVERAGE RATING"].ToString();
                    wmtReport.productTaxCode = row["PRODUCT TAX CODE"].ToString();
                    wmtReport.shippingWeight = row["SHIPPING WEIGHT"].ToString();
                    wmtReport.shippingWeightUnit = row["SHIPPING WEIGHT UNIT"].ToString();
                    wmtReport.statusChangeReason = row["STATUS CHANGE REASON"].ToString();
                    wmtReport.availableInventoryUnits = row["AVAILABLE INVENTORY UNITS"].ToString();
                    wmtReports.Add(wmtReport);
                }
                return wmtReports;
            }
            else
            {
                return wmtReports;
            }
        }
        public async Task<WmtOrder[]> GetOrdersByDate(string start, string endTime, string WhId, orderLineStatusValueType? status, string fromExSD = null, string toExSD = null)
        {
            WalmartAuth walmart = new WalmartAuth();
            WmtOrder[] wmtOrders = new WmtOrder[0];
            string base_url = "https://api-gateway.walmart.com";
            string address = "/v3/orders";
            bool isNext = true;
            var client = new RestClient(base_url);
            IRestRequest request = new RestRequest(address, Method.GET);

            request.AddQueryParameter("shipNode", WhId);
            if (start != null && endTime != null)
            {
                request.AddQueryParameter("createdStartDate", start);
                request.AddQueryParameter("createdEndDate", endTime);
            }

            if (fromExSD != null && toExSD != null)
            {
                request.AddQueryParameter("fromExpectedShipDate", fromExSD);
                request.AddQueryParameter("toExpectedShipDate", toExSD);
            }
            request.AddQueryParameter("limit", "200");
            if (status != null)
                request.AddQueryParameter("status", status.ToString());

            var fullUrl = client.BuildUri(request);
            string signture = GetSignature(fullUrl.ToString(), "GET");
            setWmtHeader(request, signture);

            IRestResponse response = await client.ExecuteAsync(request);

            while (isNext)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var serializer = new XmlSerializer(typeof(ordersListType));
                    ordersListType result;

                    using (TextReader reader = new StringReader(response.Content))
                    {
                        result = (ordersListType)serializer.Deserialize(reader);
                    }

                    wmtOrders = wmtOrders.Concat(result.elements).ToArray();
                    if (result.meta.nextCursor == null)
                    {
                        isNext = false;
                        continue;
                    }
                    else
                    {
                        request = new RestRequest("/v3/orders" + result.meta.nextCursor, Method.GET);
                        fullUrl = client.BuildUri(request);
                        signture = GetSignature(fullUrl.ToString(), "GET");
                        setWmtHeader(request, signture);
                    }
                    response = await client.ExecuteAsync(request);

                }
                else
                {
                    isNext = false;
                    //need logging
                }

            }
            return wmtOrders;
        }
        public async Task<WmtOrder[]> GetNewOrdersByDate(string start, string endTime, string WhId)
        {
            WalmartAuth walmart = new WalmartAuth();
            WmtOrder[] wmtOrders = new WmtOrder[0];
            string base_url = "https://api-gateway.walmart.com";
            string address = "/v3/orders/released";
            bool isNext = true;
            var client = new RestClient(base_url);
            IRestRequest request = new RestRequest(address, Method.GET);

            request.AddQueryParameter("shipNode", WhId);
            request.AddQueryParameter("createdStartDate", start);
            request.AddQueryParameter("createdEndDate", endTime);
            request.AddQueryParameter("limit", "200");

            var fullUrl = client.BuildUri(request);
            string signture = GetSignature(fullUrl.ToString(), "GET");
            setWmtHeader(request, signture);

            IRestResponse response = await client.ExecuteAsync(request);

            while (isNext)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var serializer = new XmlSerializer(typeof(ordersListType));
                    ordersListType result;

                    using (TextReader reader = new StringReader(response.Content))
                    {
                        result = (ordersListType)serializer.Deserialize(reader);
                    }

                    wmtOrders = wmtOrders.Concat(result.elements).ToArray();
                    if (result.meta.nextCursor == null)
                    {
                        isNext = false;
                        continue;
                    }
                    else
                    {
                        request = new RestRequest("/v3/orders" + result.meta.nextCursor, Method.GET);
                        fullUrl = client.BuildUri(request);
                        signture = GetSignature(fullUrl.ToString(), "GET");
                        setWmtHeader(request, signture);
                    }
                    response = await client.ExecuteAsync(request);

                }
                else
                {
                    isNext = false;
                    //need logging
                }

            }
            return wmtOrders;
        }
        public async Task<IRestResponse> SendAck(string poNo, string WhId)
        {
            string base_url = "https://api-gateway.walmart.com";
            string address = "/v3/orders/" + poNo + "/acknowledge";

            var client = new RestClient(base_url);
            IRestRequest request = new RestRequest(address, Method.POST);

            request.AddQueryParameter("shipNode", WhId);
            request.AddJsonBody("");
            var fullUrl = client.BuildUri(request);
            string signture = GetSignature(fullUrl.ToString(), "POST");

            request.AddHeader("Accept", "application/xml");
            request.AddHeader("WM_CONSUMER.ID", ConsumerId);
            request.AddHeader("WM_SVC.NAME", "Walmart Supplier");
            request.AddHeader("WM_QOS.CORRELATION_ID", RandomId);
            request.AddHeader("WM_SEC.TIMESTAMP", TimesStamp);
            request.AddHeader("WM_SEC.AUTH_SIGNATURE", signture);
            request.AddHeader("WM_CONSUMER.CHANNEL.TYPE", ChannelType);
            return await client.ExecuteAsync(request);

        }
        public async Task<IRestResponse> SendASNShipment(string jsonBody, string poNo, string WhId, ShipInfo shipInfo)
        {
            string base_url = "https://api-gateway.walmart.com";
            string address = "/v3/orders/" + poNo + "/shipping";

            var client = new RestClient(base_url);
            IRestRequest request = new RestRequest(address, Method.POST);

            request.AddQueryParameter("shipNode", WhId);
            request.AddJsonBody(jsonBody);
            var fullUrl = client.BuildUri(request);
            string signture = GetSignature(fullUrl.ToString(), "POST");

            request.AddHeader("Accept", "application/xml");
            request.AddHeader("WM_CONSUMER.ID", ConsumerId);
            request.AddHeader("WM_SVC.NAME", "Walmart Supplier");
            request.AddHeader("WM_QOS.CORRELATION_ID", RandomId);
            request.AddHeader("WM_SEC.TIMESTAMP", TimesStamp);
            request.AddHeader("WM_SEC.AUTH_SIGNATURE", signture);
            request.AddHeader("WM_CONSUMER.CHANNEL.TYPE", ChannelType);

            return await client.ExecuteAsync(request);
        }
    }
}
