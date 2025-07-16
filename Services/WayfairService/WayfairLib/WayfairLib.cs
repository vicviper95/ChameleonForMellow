using System;
using System.Net;
using System.Collections.Generic;
using RestSharp; // Version 106.6.10
using Newtonsoft.Json.Linq; // Version 1.0.0


namespace Chameleon.Services.WayfairService.WayfairLib
{
    public class WayfairLib
    {
         
        // Credentials
        public String CLIENT_ID = "8ZRFBpVee77DigpV--ScVg";
        public String CLIENT_SECRET = "0JL32j_FGO0FEAT-uSNdjCv6lkJ5xZoLen-RrqV-aJ3vpe1RtRvI6aadGXDAcX0UQJjOYAoaxlupqDszrVzeHg";

        // Endpoints
        public String API_URL = "https://api.wayfair.com/v1/graphql";
        public String Sandbox_URL = "https://sandbox.api.wayfair.com/v1/graphql";
        public String AUTH_URL = "https://sso.auth.wayfair.com/oauth/token";

        //public String QUERY = "query getCastleGatePurchaseOrders {getCastleGatePurchaseOrders (limit: 10,hasResponse: false) {poNumber,poDate,estimatedShipDate,customerName,customerAddress1,customerAddress2,customerCity,customerState,customerPostalCode,orderType,shippingInfo {shipSpeed,carrierCode},packingSlipUrl,warehouse {id,name,address {name,address1,address2,address3,city,state,country,postalCode}},products {partNumber,quantity,price,event {id,type,name,startDate,endDate}},shipTo {name,address1,address2,address3,city,state,country,postalCode,phoneNumber}}}";
        //public String VARIABLES = @"null";

        /// <summary>
        /// Helper function to send an HTTP request through the requests python library.
        /// </summary>
        /// <returns>
        /// The response from the HTTP request
        /// </returns>
        /// <param name="method">HTTP request method (POST, GET, PUT, DELETE, etc.)</param>
        /// <param name="url">URL for the request</param>
        /// <param name="bodyContentType">Content type for the body parameter (application/json, etc.)</param>
        /// <param name="body">Payload for the request (if it applies)</param>
        /// <param name="headers">Headers for the request (authorization, content-type, cache-control, etc.)</param>
        public IRestResponse SendRequest(Method method, string url, string bodyContentType = "", string body = "", Dictionary<string, string> headers = null)
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(method);
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }
            if (method == Method.POST)
            {
                request.AddParameter(bodyContentType, body, ParameterType.RequestBody);
            }
            IRestResponse response = client.Execute(request);
            HttpStatusCode responseStatus = response.StatusCode;
            // TODO you can handle more response codes here (HttpStatusCode.Unauthorized, HttpStatusCode.NotFound, HttpStatusCode.InternalServerError, ...)
            switch (responseStatus)
            {
                case HttpStatusCode.OK:
                    return response;
                default:
                    throw new Exception($"Request failed with status {response.StatusDescription}, response {response.Content}");
            }
        }

        /// <summary>
        /// Function that formats the HTTP Graphql request with the needed headers and correct Graphql mutation or query
        /// payload to send to the Wayfair api. The payload is a string in the format
        /// {“query” : {Graphql query or mutation}, “variables”: {query or mutation variables JSON}}
        /// </summary>
        /// <returns>
        /// The parsed response from the GraphQL endpoint as a JObject
        /// </returns>
        /// <param name="token">Token used for authentication</param>
        /// <param name="query">GraphQL query or mutation</param>
        /// <param name="variables">GraphQL variables for the query or mutation as valid JSON</param>
        public string SendGraphQLRequest(string token, string query, string variables)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("content-type", "application/json");
            headers.Add("cache-control", "no-cache");
            headers.Add("authorization", $"Bearer {token}");
            string graphQLOperation = $@" ""query"": ""{query}"", ""variables"": {variables}";

            string graphQLPayload = $"{{{graphQLOperation}}}";
            try
            {
                IRestResponse response = SendRequest(Method.POST, Sandbox_URL, "application/json", graphQLPayload, headers);
                return response.Content;
            }
            catch (Exception e)
            {
                // TODO Graphql HTTP request failed so you should handle that situation here (logging, etc.)
                Console.WriteLine($"Problem executing the GraphQL request: {e.Message}");
            }
            return null;
        }

        /// <summary>
        /// Function used to get an authentication token based on a client's id and secret. The token will later
        /// be passed into the authentication header for the HTTP request in the format of "Bearer {TOKEN}". If the
        /// request throws an exception or the user can't be authenticated, then the function will return None and
        /// the error will be printed out to the console.
        /// </summary>
        /// <returns>
        /// An authentication token string
        /// </returns>
        /// <param name="clientID">ID of the client</param>
        /// <param name="clientSecret">Secret of the client</param>
        public string FetchToken()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("content-type", "application/json");
            headers.Add("cache-control", "no-cache");
            string authCredentials = $@"
                ""grant_type"": ""client_credentials"",
                ""client_id"": ""{CLIENT_ID}"",
                ""client_secret"": ""{CLIENT_SECRET}"",
                ""audience"": ""https://api.wayfair.com""
            ";
            string authPayload = $"{{{authCredentials}}}";
            try
            {
                IRestResponse response = SendRequest(Method.POST, AUTH_URL, "application/json", authPayload, headers);
                return (string)JObject.Parse(response.Content)["access_token"];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not retrieve a token for the request: {e.Message}");
                System.Environment.Exit(1);
            }
            return "";
        }

    
    }
}
