using Chameleon.DTOs.Account;
using Chameleon.DTOs.Employee;
using Chameleon.Models;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;



namespace Chameleon.Controllers
{
  public class AccountController : Controller
  {
    private readonly KOALAContext _kc;
    private readonly ILogger<AccountController> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AccountController(KOALAContext context, ILogger<AccountController> logger,  IHttpContextAccessor httpContextAccessor)
    {
      _kc = context;
      _logger = logger;
      _httpContextAccessor = httpContextAccessor;
    }


    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Login()
    {
      return View();
    }



    //resetMyPassword

    // This is for sending temporary password to email account
    // By Brian Yi on 09/26/2022
    [AllowAnonymous]
    [HttpPost("/Account/sendTmpPassword")]
    public async Task<IActionResult> sendTmpPassword(JsonElement body)
    {

      Console.WriteLine("Here~!");
      JsonResult jsonData = Json(true);
      return jsonData;
    }

    // Password Reset Page
    // By Brian Yi on 09/26/2022
    [AllowAnonymous]
    [HttpGet("PasswordReset")]
    public ViewResult PasswordReset()
    {
      return View();
    }

    // Employee Authorization Admin. Page
    // By Brian Yi on 11/10/2022
    [Authorize]
    [HttpGet("AuthorizationAdmin")]
    public ViewResult AuthorizationAdmin()
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);

      return View();
    }




    //For Personal Preferance Setting
    // By Brian Yi on 09/14/2021
    [Authorize]
    [HttpGet("Preference")]
    public async Task<ViewResult> Preference()
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      EmpChameleonConfig empChameleonConfig = await _kc.EmpChameleonConfigs
        .Where(e => e.EmployeeId == empId)
        .Include(e => e.Employee)
        .FirstOrDefaultAsync();

      if(empChameleonConfig == null)
      {
        empChameleonConfig = new EmpChameleonConfig()
        {
          EmployeeId = empId,
          PrivilegeLevelInventory = 0,
          HasInventoryNotification = false
        };
        
        await _kc.EmpChameleonConfigs.AddAsync(empChameleonConfig);
        await _kc.SaveChangesAsync();
      }
      EmployeePreference employeePreference = new EmployeePreference(){
        LoginId = empChameleonConfig.Employee.LoginId,
        EmpChameleonConfigId = empChameleonConfig.EmpChameleonConfigId,
        PrivilegeLevelInventory = (int)empChameleonConfig.PrivilegeLevelInventory,
        HasInventoryNotification = (bool)empChameleonConfig.HasInventoryNotification
      };
      return View(employeePreference);
    }

    //For Logout Page
    // By Brian Yi on 09/14/2021
    [Authorize]
    [HttpGet("Logout")]
    public async Task<ViewResult> Logout()
    {
      await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
      return View();
    }


    //UpdatePersonalPreference

    //For Chameleon Personal Preference Setting
    // By Brian Yi on 09/14/2021
    [Authorize]
    [HttpPost("/Account/UpdatePersonalPreference")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdatePersonalPreference([FromForm] EmployeePreference tmpModel)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      //string json = System.Text.Json.JsonSerializer.Serialize(body);
      //EmpChameleonConfig empChameleon = Newtonsoft.Json.JsonConvert.DeserializeObject<EmpChameleonConfig>(json);
      EmpChameleonConfig empChameleonConfig = await _kc.EmpChameleonConfigs
        .Where(e => e.EmployeeId == empId)
        .FirstOrDefaultAsync();
      empChameleonConfig.HasInventoryNotification = tmpModel.HasInventoryNotification;
      _kc.EmpChameleonConfigs.Update(empChameleonConfig);
      await  _kc.SaveChangesAsync();
      return await Task.FromResult(RedirectToAction("Index", "Home"));
    }




    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult> Login(EmployeeLoginDTO empLogin)
    {
      var tmpUser = User;
      Employee emp = await _kc.Employees.FirstOrDefaultAsync(e => e.LoginId == empLogin.LoginId);
      //int? empId = emp.LoginID.FirstOrDefault(e => e.);
      string message = "";
      if (emp == null)
      {
        message = "Employee login is incorrect";
        ModelState.AddModelError("", message);
      }
      else if (VerifyPasswordHash(empLogin.Password, emp.PasswordHash, emp.PasswordSalt))
      {
        message = "Login success";
        Department tmpDept = await _kc.Departments.FirstOrDefaultAsync(x => x.DepartmentId.Equals(emp.DepartmentId));
        //string tmpRole = tmpDept.DeptShortName;
        string tmpRole = "Employee";
        DeptManager deptManager = await _kc.DeptManagers.FirstOrDefaultAsync(d => d.EmployeeId == emp.EmployeeId);
        string tmpName = (emp.EmployeeName != null) ? emp.EmployeeName : (emp.LegalName != null) ? emp.LegalName : emp.LoginId;

        List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, emp.LoginId), // LoginID
                new Claim(ClaimTypes.Name, tmpName), // Either EmployeeName, LegalName, or LoginID
                new Claim(ClaimTypes.SerialNumber, emp.EmployeeId.ToString()), // Employee_id
                new Claim(ClaimTypes.Actor, (deptManager != null ? "1" : "0")), // Whether manager or not
                new Claim(ClaimTypes.Role, tmpRole), // Department
                new Claim(ClaimTypes.PrimaryGroupSid, (tmpDept.DepartmentId.ToString() != null ? tmpDept.DepartmentId.ToString() : "1")), // Department ID
                new Claim(ClaimTypes.Hash, emp.PasswordHash) // Password Hash
            };
        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
        var authProperties = new AuthenticationProperties { RedirectUri = "/Bookmarks/Index", };
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

        return RedirectToAction("Index", "Home");
      }
      else
      {
        await HttpContext.SignOutAsync();
        message = "Incorrect password";
        ModelState.AddModelError("", message);
      }
      ViewBag.Message = message;
      return View(empLogin);
    }
    public static bool VerifyPasswordHash(string enteredPassword, string storedHash, string storedSalt)
    {
      var saltBytes = Convert.FromBase64String(storedSalt);
      var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
      return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
    }

    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
