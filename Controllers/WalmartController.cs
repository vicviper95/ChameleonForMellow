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

namespace Chameleon.Controllers
{

    [Route("walmart")]
    [ApiController]
    public class WalmartController : Controller
    {
        private readonly ISuiteTalkerService _suiteTalkerService;
        private readonly IWalmartService _walmartService;
        private readonly KOALAContext _kc;
        public WalmartController(KOALAContext kc, IWalmartService walmartService, ISuiteTalkerService suiteTalkerService)
        {
            _suiteTalkerService = suiteTalkerService;
            _kc = kc;
            _walmartService = walmartService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("syncWmt")]
        public async Task<IActionResult> InsertWmtItemByDate()
        {
            JsonResult jsonData = Json(await _walmartService.SearchAndInsert(SearchType.Date, null, null));
            return jsonData;
        }
        [HttpGet("syncWmtLng")]
        public async Task<IActionResult> InsertWmtItemByLngDateRange()
        {
            JsonResult jsonData = Json(await _walmartService.SearchAndInsert(SearchType.Date, null, orderLineStatusValueType.Created));
            return jsonData;
        }
        [HttpGet("retrySyncWmt")]
        public async Task<IActionResult> InsertWmtPoByPo([FromBody] WmtPos POs)
        {
            JsonResult jsonData = Json(await _walmartService.SearchAndInsert(SearchType.PoNumber, POs, null));
            return jsonData;
        }
        [HttpGet("sendAck")]
        public async Task<JsonResult> SendAck()
        {
            JsonResult result = Json(await _walmartService.SendAckOrders());
            return result;
        }
        [HttpGet("sendASN")]
        public async Task<JsonResult> SendTrackNo()
        {
            JsonResult result = Json(await _walmartService.SendTrackingNumber());
            return result;
        }
        [HttpGet("SearchPendingCancel")]
        public async Task<JsonResult> FindPenddingNCancelled()
        {
            JsonResult result = Json(await _walmartService.FindCancelledPO());
            return result;
        }
        [Authorize]
        [HttpGet("getAsnError")]
        public async Task<dynamic> GetASNError()
        {
            JsonResult erros = Json(await _walmartService.GetASNError());
            return erros;
        }
        [Authorize]
        [HttpGet("getError")]
        public async Task<dynamic> GetError()
        {
            JsonResult erros = Json(await _walmartService.GetError());
            return erros;
        }
        [Authorize]
        [HttpGet("getPO")]
        public async Task<IActionResult> WmtOrders(string startDate, string endDate)
        {
            JsonResult jsonData = Json(await _walmartService.GetWmtOrders(startDate, endDate));
            return jsonData;
        }
        [HttpGet("getMiss")]
        public async Task<IActionResult> GetWmtMissingPO()
        {
            JsonResult jsonData = Json(await _walmartService.GetMissingNsSync());
            return jsonData;
        }
        [HttpGet("getPendingAck")]
        public async Task<IActionResult> GetWmtPendingAck(string startDate, string endDate)
        {
            JsonResult jsonData = Json(await _walmartService.GetPendingAck(startDate, endDate));
            return jsonData;
        }
        [HttpGet("getPendingAsn")]
        public async Task<IActionResult> GetWmtPendingAsn(string startDate, string endDate)
        {
            JsonResult jsonData = Json(await _walmartService.GetPendingAsn(startDate, endDate));
            return jsonData;
        }
        [HttpGet("getPendingCancel")]
        public async Task<IActionResult> GetWmtPendingCancellation(string startDate, string endDate)
        {
            JsonResult jsonData = Json(await _walmartService.GetPendingCancel());
            return jsonData;
        }
        [HttpGet("insertRetailPrice")]
        public async Task<IActionResult> insertRetailPrice()
        {
           return Json(await _walmartService.GetRetailPrice());
        }
    }
}
