using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Services.AmazonService.AmazonLib
{
    public class AmazonShipmentProcess
    {
        Authentication amzAuth = new Authentication();
        //public async Task<Hashtable> SubmitShipmentConfirm(SubmitShipmentConfirmationsRequest submitShipmentConfirmations)
        //{
        //    Hashtable result = new Hashtable();
        //    var client = new RestClient("https://sellingpartnerapi-na.amazon.com");
        //    string order_resource = "/vendor/orders/v1/purchaseOrders";

        //    IRestRequest request = new RestRequest(order_resource, Method.GET);
        //    // origin today
        //    DateTime now = DateTime.Now;

        //    if (nextToken != null)
        //    {
        //        request.AddQueryParameter("nextToken", nextToken);
        //    }

        //    request = new LWAAuthorizationSigner(amzAuth.lwaAuthCreds).Sign(request);
        //    request.AddHeader("x-www-form-urlencoded", amzAuth.access_token);
        //    request = new AWSSigV4Signer(amzAuth.awsAuthenticationCredentials)
        //                          .Sign(request, "sellingpartnerapi-na.amazon.com");

        //    IRestResponse response = await client.ExecuteAsync(request);

        //    return response.Content;
        //}
    }
}
