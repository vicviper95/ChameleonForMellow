using RestSharp;
using System;
using Newtonsoft.Json.Linq;
using System.Net;
using Chameleon.Services.AmazonService.AmazonLib.SellingPartnerAPIAA;

namespace Chameleon.Services.AmazonService.AmazonLib { 
  public class Authentication { 
    public string access_token { get; set; }
    public string refresh_token { get; set; }

    public Authentication()
    {
       var client = new RestClient("https://api.amazon.com/auth/o2/token");
       var request = new RestRequest(Method.POST);

       var client_id = lwaAuthCreds.ClientId;
       var client_secret = lwaAuthCreds.ClientSecret;
       var refresh_tokenViaVendor = lwaAuthCreds.RefreshToken;

       request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
       request.AddParameter("application/x-www-form-urlencoded", $"client_id={client_id}&client_secret={client_secret}&refresh_token={refresh_tokenViaVendor}&grant_type=refresh_token", ParameterType.RequestBody);
       IRestResponse response = client.Execute(request);
       if (response.StatusCode != HttpStatusCode.OK)
       {
           //("Access Token cannot obtain, process terminate");
       }
       var jObject = JObject.Parse(response.Content);
       access_token = jObject.GetValue("access_token").ToString();
       refresh_token = jObject.GetValue("refresh_token").ToString();
    }

    public AWSAuthenticationCredentials awsAuthenticationCredentials = new AWSAuthenticationCredentials
    {
      AccessKeyId = "AKIAQ5NZQ7PEHDILCCA4",
      SecretKey = "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",
      Region = "us-east-1"
    };

    public LWAAuthorizationCredentials lwaAuthCreds = new LWAAuthorizationCredentials
    {
      ClientId = "amzn1.application-oa2-client.2eecbdb458e2430fb9c361afd6993386",
      ClientSecret = "3b0e366e71e484b10f265681d64daf0e3eda68a568d727ceb13751fd8ff6a5b5",
      RefreshToken = "Atzr|IwEBIA4BTpsSdmN2jTV4BigxTPdSHAyT-NNxFTVTqHRC8X2UKd-3GdxmmOgLKKEJsbfEY635OxLKL6Rzefa6fVI4BNvRzpNPlQjIHChLEAsa--R8xp9p4cyB4dYonL6yjoQ-mbJZq1sOc3aYQrfzr7qIPrhJ6x-x0abmb-5qas-8nxpp8KhpPqO5uyqeCJecalTdcQY36o6HkS_N7dd_rvs32s6PX_6S15JbfiwctLzoQh9J9jOf5O6tkvHa3qo3k1RuyLBr1T_zw7vjXFknDbX-tzZyr17hsE31xW4beqOdC3ZaFzW8wK_eIRZJffzO8lguBHM",
      Endpoint = new Uri("https://api.amazon.com/auth/o2/token")
    };

    //public void SetAccessToken()
    //{
    //  var client = new RestClient("https://api.amazon.com/auth/o2/token");
    //  var request = new RestRequest(Method.POST);

    //  var client_id = lwaAuthCreds.ClientId;
    //  var client_secret = lwaAuthCreds.ClientSecret;
    //  var refresh_tokenViaVendor = lwaAuthCreds.RefreshToken;

    //  request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
    //  request.AddParameter("application/x-www-form-urlencoded", $"client_id={client_id}&client_secret={client_secret}&refresh_token={refresh_tokenViaVendor}&grant_type=refresh_token", ParameterType.RequestBody);
    //  IRestResponse response = client.Execute(request);
    //  if (response.StatusCode != HttpStatusCode.OK)
    //  {
    //    //("Access Token cannot obtain, process terminate");
    //  }
    //  var jObject = JObject.Parse(response.Content);
    //  access_token = jObject.GetValue("access_token").ToString();
    //  refresh_token = jObject.GetValue("refresh_token").ToString();
    //}
  }
}
