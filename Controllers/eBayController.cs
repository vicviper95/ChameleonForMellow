using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chameleon.Services.SuiteTalkerService;
using Chameleon.Models;
using Chameleon.Services.WalmartService;
using Microsoft.AspNetCore.Authorization;
using SuitetalkerService;
using System.Text.Json;
using Chameleon.Services.ServiceUtil;
using Chameleon.DTOs.Walmart;
using System.Security.Cryptography;
using System.Text;
using Chameleon.DTOs.eBay;
using Chameleon.Services.eBayService;
using EbayEventNotificationSDK.Utils;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using EbayEventNotificationSDK.Models;
using EbayEventNotificationSDK;
using EbayEventNotificationSDK.Processor;
using Chameleon.Services;
using EbayEventNotificationSDK.Client;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Chameleon.ebay.sellFulfillment;
using System.Net.Http;

namespace Chameleon.Controllers
{

  [Route("ebay")]
  [ApiController]
  public class eBayController : Controller
  {
    private readonly IeBayService _eBayService;
    private readonly ISuiteTalkerService _suiteTalkerService;
    private readonly KOALAContext _kc;
    private readonly ISignatureValidator signatureValidator;
    private readonly ILogger<eBayController> logger;
    private readonly IPublicKeyClient publicKeyClient;
    private readonly IEndPointValidator endpointValidator;
    private readonly IConfigEbay config;
    private readonly sell_fulfillment_v1_oas3Client sell_Fulfillment;

    public eBayController(KOALAContext kc, IeBayService eBayService, ISuiteTalkerService suiteTalkerService, ILogger<eBayController> logger, ISignatureValidator validator, IEndPointValidator endPointValidator, IPublicKeyClient publicKeyClient, IConfigEbay configuration)
    {
      _suiteTalkerService = suiteTalkerService;
      _kc = kc;
      _eBayService = eBayService;
      this.logger = logger;
      this.signatureValidator = validator;
      this.endpointValidator = endPointValidator;
      this.publicKeyClient = publicKeyClient;
      this.config = configuration;
      this.sell_Fulfillment = new sell_fulfillment_v1_oas3Client(new HttpClient());
    }

    [Authorize]
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    [Route("webhook")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public ActionResult process([FromBody] Rootobject message, [FromHeader(Name = "X-EBAY-SIGNATURE")] String signatureHeader)
    {
      try
      {
        //logger.LogInformation(1001, "SignatureHeader: " + signatureHeader);
        string json = JsonConvert.SerializeObject(message);
        //logger.LogInformation(1001, "object: " + json);
        if (signatureValidator.validate(message, signatureHeader))
        {
          process(message);
          bool saveNotification = _eBayService.saveNotification(message);
          //if (saveNotification)
          //    logger.LogInformation(1001, "Save Notification: " + saveNotification);
          //else
          //    logger.LogInformation(1001, "Save Notification: " + saveNotification);
          //MailService.Send("Event notification", "200", "youngjae.jo@mellow-home.com", "", true);
          return StatusCode(200);
        }
        else
        {
          MailService.Send("Event notification", "412", "youngjae.jo@mellow-home.com", "", true);
          return StatusCode(412);
        }
      }
      catch (Exception e)
      {
        logger.LogError("Signature validation processing failure:" + e.Message);
        MailService.Send("Event notification", "500", "youngjae.jo@mellow-home.com", "", true);
        return StatusCode(500);
      }
    }

    [HttpGet]
    [Route("webhook")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<ChallengeResponse> validate([FromQuery(Name = "challenge_code")] string challengeCode)
    {
      try
      {
        return endpointValidator.generateChallengeResponse(challengeCode);
      }
      catch (Exception ex)
      {
        logger.LogError("Endpoint validation failure:" + ex.Message);
        return StatusCode(500);
      }
    }

    [HttpGet]
    [Route("getPos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetEbayPOs()
    {
      JsonResult res = Json(await _eBayService.ebayGetOrders());
      //string token = publicKeyClient.fetchUserToken(config.environment);
      //try
      //{
      //    OrderSearchPagedCollection ordersearh = await sell_Fulfillment.GetOrdersAsync(null, "creationdate:%5B2022-07-06T08:25:43.511Z..%5D", null, null, null, token);

      //}
      //catch(Exception e)
      //{

      //}
      return res;
    }

    [HttpGet]
    [Route("getPo/{poNo}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetEbayPO(string poNo)
    {
      JsonResult res = Json(await _eBayService.ebayGetOrder(poNo));
      //string token = publicKeyClient.fetchUserToken(config.environment);
      //try
      //{
      //    OrderSearchPagedCollection ordersearh = await sell_Fulfillment.GetOrdersAsync(null, "creationdate:%5B2022-07-06T08:25:43.511Z..%5D", null, null, null, token);

      //}
      //catch(Exception e)
      //{

      //}
      return res;
    }

    [Authorize]
    [HttpGet("searchPO")]
    public async Task<IActionResult> eBayOrders(string startDate, string endDate)
    {
      JsonResult jsonData = Json(await _eBayService.GeteBayOrders(startDate, endDate));
      return jsonData;
    }
    [HttpGet]
    [Route("sendShipment")]
    public async Task<IActionResult> eBaySendASN()
    {
      JsonResult jsonData = Json(await _eBayService.Send_eBayShipment());
      return jsonData;
    }
    [Authorize]
    [HttpGet("getError")]
    public async Task<dynamic> GetError()
    {
      JsonResult erros = Json(await _eBayService.GetError());
      return erros;
    }

    //[HttpGet]
    //[Route("createSub")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    //public async Task<ActionResult> CreateSubscription()
    //{
    //    //System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
    //    //commerce_notification_v1_oas3Client commerce_Notification_V1_Oas3Client = new commerce_notification_v1_oas3Client(httpClient);
    //    //var token = publicKeyClient.fetchToken("PRODUCTION");
    //    //DestinationRequest destination = new DestinationRequest();
    //    //destination.Name = "Mellow";
    //    //destination.Status = "ENABLED";
    //    //destination.DeliveryConfig = new DeliveryConfig();
    //    //destination.DeliveryConfig.Endpoint = "https://bestpricequality.net:9467/ebay/webhook";
    //    //destination.DeliveryConfig.VerificationToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9eyJuYW1lIjoieWoifQ";
    //    //destination.AdditionalProperties = new Dictionary<string, object>();
    //    //destination.AdditionalProperties.Add("Authorization", token);
    //    //var res = await commerce_Notification_V1_Oas3Client.CreateDestinationAsync(destination);


    //    //CreateSubscriptionRequest body = new CreateSubscriptionRequest();
    //    //body.TopicId = "MARKETPLACE_ACCOUNT_DELETION";
    //    //body.Status = "DISABLED";
    //    //body.DestinationId = "mellow06-23-22";
    //    //SubscriptionPayloadDetail detail = new SubscriptionPayloadDetail();
    //    //detail.Format = "JSON";
    //    //detail.SchemaVersion = "1.0";
    //    //detail.DeliveryProtocol = "HTTPS";
    //    //body.Payload = detail;


    //    return StatusCode(200);
    //}

    private void process(Rootobject message)
    {
      TopicEnum topicEnum = (TopicEnum)Enum.Parse(typeof(TopicEnum), message.metadata.topic);
      MessageProcessorFactory.getProcessor(topicEnum).process(message);
    }


  }



  public class ChallengeRes
  {
    public string challengeResponse { get; set; }
  }




}
