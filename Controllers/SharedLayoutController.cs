using Chameleon.DTOs.Employee;
using Chameleon.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Chameleon.Controllers
{
    [Route("SharedLayout")]
    [ApiController]
  public class SharedLayoutController : Controller
  {
    private readonly KOALAContext _kc;

    public SharedLayoutController(KOALAContext context)
    {
      _kc = context;
    }
    public IActionResult Index()
    {
      return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> EmployeeAuthentication()
    {
      EmployeeAuthorizationDTO testDTO = new EmployeeAuthorizationDTO();
      testDTO.HideThis = true;
      return PartialView(testDTO);
    }

    
    // By Brian Yi on 06/06/2021
    // Get Employee ID from cookie
    public int GetUserId(ClaimsIdentity claimsIdentity)
    {
      string result = "";
      foreach (var claim in claimsIdentity.Claims)
      {
        if (claim.Type == ClaimTypes.SerialNumber)
        { result = claim.Value; break; }
      }
      return Int32.Parse(result);
    }

  }
}
