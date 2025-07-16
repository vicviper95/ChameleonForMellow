using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chameleon.Models;
using Chameleon.Services.SalesReportsService;
using System.Net.Http;
using Chameleon.Services.SalesService;
using Microsoft.AspNetCore.Authorization;

namespace Chameleon.Controllers
{
  [Route("Sales")]
  [ApiController]
  public class SalesController : Controller
  {
    private readonly KOALAContext _kc;

    private readonly ISalesService _salesService;

    // Initialize
    public SalesController(KOALAContext context, ISalesService saleService)
    {
      _kc = context;
      _salesService = saleService;
    }

    public IActionResult Index()
    {
      return View();
    }

    // For Amazon Promotions for Inventory Feeding
    // By Brian Yi on 03/15/2023
    [Authorize]
    [HttpGet("PromoAmazonStatusIdx")]
    public ViewResult PromoAmazonStatusIdx()
    {
      return View();
    }

    // For BPM Promotions for Inventory Feeding
    // By Brian Yi on 03/15/2023
    [Authorize]
    [HttpGet("PromoBPMStatusIdx")]
    public ViewResult PromoBPMStatusIdx()
    {
      return View();
    }

    // For eBay Promotions for Inventory Feeding
    // By Brian Yi on 03/15/2023
    [Authorize]
    [HttpGet("PromoeBayStatusIdx")]
    public ViewResult PromoeBayStatusIdx()
    {
      return View();
    }


    // For Home Depot Promotions for Inventory Feeding
    // By Brian Yi on 03/15/2023
    [Authorize]
    [HttpGet("PromoHomeDepotStatusIdx")]
    public ViewResult PromoHomeDepotStatusIdx()
    {
      return View();
    }

    // For Mellow Promotions for Inventory Feeding
    // By Brian Yi on 03/15/2023
    [Authorize]
    [HttpGet("PromoMellowStatusIdx")]
    public ViewResult PromoMellowStatusIdx()
    {
      return View();
    }
    
    // For Overstock Promotions for Inventory Feeding
    // By Brian Yi on 03/15/2023
    [Authorize]
    [HttpGet("PromoOverstockStatusIdx")]
    public ViewResult PromoOverstockStatusIdx()
    {
      return View();
    }
    
    // For Target Promotions for Inventory Feeding
    // By Brian Yi on 03/15/2023
    [Authorize]
    [HttpGet("PromoTargetStatusIdx")]
    public ViewResult PromoTargetStatusIdx()
    {
      return View();
    }
    
    // For Walmart Promotions for Inventory Feeding
    // By Brian Yi on 03/15/2023
    [Authorize]
    [HttpGet("PromoWalmartStatusIdx")]
    public ViewResult PromoWalmartStatusIdx()
    {
      return View();
    }

    // For Wayfair Promotions for Inventory Feeding
    // By Brian Yi on 03/15/2023
    [Authorize]
    [HttpGet("PromoWayfairStatusIdx")]
    public ViewResult PromoWayfairStatusIdx()
    {
      return View();
    }





  }
}
