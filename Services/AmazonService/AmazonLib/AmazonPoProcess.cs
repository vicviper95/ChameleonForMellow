using Chameleon.DTOs.Amazon;
using Chameleon.DTOs.Amazon.Shipment;
using Chameleon.Services.AmazonService.AmazonLib.SellingPartnerAPIAA;
using Chameleon.Services.ServiceUtil;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chameleon.Services.AmazonService.AmazonLib
{
	public class AmazonPoProcess : Authentication
	{
        public async Task<Hashtable> GetDirOrderListByDate(string from, string to, PurchaseOrderState status)
        {
            Hashtable result = new Hashtable();
            bool isNextToken = true;
            string nextToken = null;
            List<AMZDirOrder> orderListCollector = new List<AMZDirOrder>();
            while (isNextToken)
            {
                string strResponse = await SearchDirWithDate(nextToken, from, to, status);
                var jObject = JObject.Parse(strResponse);
                if (jObject["errors"] != null)
                {
                    result.Add(false, jObject);
                    return result;
                }
                string strPayload = jObject.GetValue("payload").ToString();
                jObject = JObject.Parse(strPayload);

                if (jObject["pagination"] == null)
                    isNextToken = false;
                else
                {
                    string pagination = jObject.GetValue("pagination").ToString();
                    var jObjectForNext = JObject.Parse(pagination);
                    nextToken = jObjectForNext.GetValue("nextToken").ToString();
                }
                string orders = jObject.GetValue("orders").ToString();
                var orderList = JsonConvert.DeserializeObject<List<AMZDirOrder>>(orders);
                orderListCollector.AddRange(orderList);
            }
            result.Add(true, orderListCollector);
            return result;
        }
        public async Task<string> SearchDirWithDate(string nextToken, string from, string to, PurchaseOrderState status)
        {
            var client = new RestClient("https://sellingpartnerapi-na.amazon.com");
            string order_resource = "/vendor/orders/v1/purchaseOrders";

            IRestRequest request = new RestRequest(order_resource, Method.GET);
            // origin today
            DateTime now = DateTime.Now;
            request.AddQueryParameter("createdAfter", from);
            request.AddQueryParameter("createdBefore", to);
            //request.AddQueryParameter("purchaseOrderState", status.ToString());
            if (nextToken != null)
            {
                request.AddQueryParameter("nextToken", nextToken);
            }

            request = new LWAAuthorizationSigner(lwaAuthCreds).Sign(request);
            request.AddHeader("x-www-form-urlencoded", access_token);
            request = new AWSSigV4Signer(awsAuthenticationCredentials)
                                  .Sign(request, "sellingpartnerapi-na.amazon.com");

            IRestResponse response = await client.ExecuteAsync(request);

            return response.Content;
        }
        public async Task<List<AMZDSOrder>> GetDSOrderListByDate(string after, string before)
        {
            bool isNextToken = true;
            string nextToken = null;
            List<AMZDSOrder> orderListCollector = new List<AMZDSOrder>();
            while (isNextToken)
            {
                string strResponse = await SearchDSWithDate(nextToken, after, before);
                var jObject = JObject.Parse(strResponse);
                if (jObject["errors"] != null)
                {
                    return orderListCollector;
                }

                string strPayload = jObject.GetValue("payload").ToString();
                jObject = JObject.Parse(strPayload);

                if (jObject["pagination"] == null)
                    isNextToken = false;
                else
                {
                    string pagination = jObject.GetValue("pagination").ToString();
                    var jObjectForNext = JObject.Parse(pagination);
                    nextToken = jObjectForNext.GetValue("nextToken").ToString();
                }

                string orders = jObject.GetValue("orders").ToString();
                var orderList = JsonConvert.DeserializeObject<List<AMZDSOrder>>(orders);
                orderListCollector.AddRange(orderList);
            }
            return orderListCollector;
        }
        public async Task<string> SearchDSWithDate(string nextToken, string after, string before)
        {
            var client = new RestClient("https://sellingpartnerapi-na.amazon.com");
            string order_resource = "/vendor/directFulfillment/orders/v1/purchaseOrders";

            IRestRequest request = new RestRequest(order_resource, Method.GET);

            DateTime now = DateTime.Now;
            request.AddQueryParameter("createdAfter", after);
            request.AddQueryParameter("createdBefore", before);
            request.AddQueryParameter("status", "NEW");

            if (nextToken != null)
            {
                request.AddQueryParameter("nextToken", nextToken);
            }

            request = new LWAAuthorizationSigner(lwaAuthCreds).Sign(request);
            request.AddHeader("x-www-form-urlencoded", access_token);
            request = new AWSSigV4Signer(awsAuthenticationCredentials)
                                  .Sign(request, "sellingpartnerapi-na.amazon.com");

            IRestResponse response = await client.ExecuteAsync(request);

            return response.Content;
        }
        public async Task<List<AMZDSOrder>> GetDSOdersListByPONum(List<string> poNums)
        {
            List<AMZDSOrder> orderList = await SearchWithPONum(poNums);
            return orderList;
        }
        public async Task<List<AMZDSOrder>> SearchWithPONum(List<string> poNums)
        {
            List<AMZDSOrder> orders = new List<AMZDSOrder>();
            var client = new RestClient("https://sellingpartnerapi-na.amazon.com");
            foreach(string poNum in poNums)
            {
                AMZDSOrder order = new AMZDSOrder();
                string url = $"/vendor/directFulfillment/orders/v1/purchaseOrders/{poNum}";

                IRestRequest request = new RestRequest(url, Method.GET);
                request = new LWAAuthorizationSigner(lwaAuthCreds).Sign(request);
                request.AddHeader("x-www-form-urlencoded", access_token);
                request = new AWSSigV4Signer(awsAuthenticationCredentials)
                                      .Sign(request, "sellingpartnerapi-na.amazon.com");

                IRestResponse response = await client.ExecuteAsync(request);
                var jObject = JObject.Parse(response.Content);
                string strPayload = jObject.GetValue("payload").ToString();
                jObject = JObject.Parse(strPayload);
                order = JsonConvert.DeserializeObject<AMZDSOrder>(strPayload);
                orders.Add(order);
            }
            return orders;
        }
        public async Task<Hashtable> GetDirOdersListByPONum(List<string> poNums)
        {
            Hashtable orderList = await SearchDirWithPONum(poNums);
            return orderList;
        }
        public async Task<Hashtable> SearchDirWithPONum(List<string> poNums)
        {
            List<AMZDirOrder> orders = new List<AMZDirOrder>();
            Hashtable result = new Hashtable();
            var client = new RestClient("https://sellingpartnerapi-na.amazon.com");
            foreach (string poNum in poNums)
            {
                AMZDirOrder order = new AMZDirOrder();
                string url = $"/vendor/orders/v1/purchaseOrders/{poNum}";

                IRestRequest request = new RestRequest(url, Method.GET);
                request = new LWAAuthorizationSigner(lwaAuthCreds).Sign(request);
                request.AddHeader("x-www-form-urlencoded", access_token);
                request = new AWSSigV4Signer(awsAuthenticationCredentials)
                                      .Sign(request, "sellingpartnerapi-na.amazon.com");

                IRestResponse response = await client.ExecuteAsync(request);
                var jObject = JObject.Parse(response.Content);
                if (jObject["errors"] != null)
                {
                    result.Add(false, jObject);
                    return result;
                }
                string strPayload = jObject.GetValue("payload").ToString();
                jObject = JObject.Parse(strPayload);
                order = JsonConvert.DeserializeObject<AMZDirOrder>(strPayload);
                orders.Add(order);
            }
            result.Add(true, orders);
            return result;
        }
        public string Test_SearchDSWithDate(string after, string before)
        {
            var client = new RestClient("https://sandbox.sellingpartnerapi-na.amazon.com");
            string order_resource = "/vendor/directFulfillment/orders/v1/purchaseOrders";

            IRestRequest request = new RestRequest(order_resource, Method.GET);

            DateTime now = DateTime.Now;
            request.AddQueryParameter("createdAfter", after);
            request.AddQueryParameter("createdBefore", before);

            request = new LWAAuthorizationSigner(lwaAuthCreds).Sign(request);
            request.AddHeader("x-www-form-urlencoded", access_token);
            request = new AWSSigV4Signer(awsAuthenticationCredentials)
                                  .Sign(request, "sandbox.sellingpartnerapi-na.amazon.com");

            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        public string Test_ShipConfirm(SubmitShipmentConfirmationsRequest RequestamzOrder)
        {
            string jsonBody = JsonConvert.SerializeObject(RequestamzOrder);
            var client = new RestClient("https://sellingpartnerapi-na.amazon.com");
            string order_resource = "/vendor/directFulfillment/shipping/v1/shipmentConfirmations";

            IRestRequest request = new RestRequest(order_resource, Method.POST);
            request.AddJsonBody(jsonBody);
            request = new LWAAuthorizationSigner(lwaAuthCreds).Sign(request);
            request.AddHeader("x-www-form-urlencoded", access_token);
            request = new AWSSigV4Signer(awsAuthenticationCredentials)
                                  .Sign(request, "sellingpartnerapi-na.amazon.com");


            
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
         
        public void Test_CheckStatus()
        {
            var client = new RestClient("https://sellingpartnerapi-na.amazon.com");
            string order_resource = "/vendor/directFulfillment/transactions/v1/transactions/c7eecdc7-56e2-4633-bc3f-c3ba18879839-20211211000923";

            IRestRequest request = new RestRequest(order_resource, Method.GET);
            request = new LWAAuthorizationSigner(lwaAuthCreds).Sign(request);
            request.AddHeader("x-www-form-urlencoded", access_token);
            request = new AWSSigV4Signer(awsAuthenticationCredentials)
                                  .Sign(request, "sellingpartnerapi-na.amazon.com");


            IRestResponse response = client.Execute(request);
        }
    }
}
