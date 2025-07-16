using Chameleon.DTOs.Employee;
using Chameleon.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Chameleon.Controllers
{
  public class HomeController : Controller
  {
    private readonly KOALAContext _kc;
    private readonly ILogger<HomeController> _logger;

    public HomeController(KOALAContext context, ILogger<HomeController> logger)
    {
      _kc = context;
      _logger = logger;
    }

    public IActionResult IndexBak()
    {
      return View();
    }

    //[Authorize]
    //
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult> IndexBak(EmployeeLoginDTO empLogin)
    {
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
        string tmpName = (emp.EmployeeName != null) ? emp.EmployeeName : (emp.LegalName != null) ? emp.LegalName : emp.LoginId;

        List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, emp.LoginId), // LoginID
                new Claim(ClaimTypes.Name, tmpName), // Either EmployeeName, LegalName, or LoginID
                new Claim(ClaimTypes.SerialNumber, emp.EmployeeId.ToString()), // Employee_id
                new Claim(ClaimTypes.Role, tmpRole), // Department
                new Claim(ClaimTypes.PrimaryGroupSid, tmpDept.DepartmentId.ToString()), // Department ID
                new Claim(ClaimTypes.Hash, emp.PasswordHash) // Password Hash
            };
        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
        var authProperties = new AuthenticationProperties { RedirectUri = "/Bookmarks/Index", };
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

        return RedirectToAction("Index", "Bookmarks");
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

    [Authorize]
    public async Task<IActionResult> Index()
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);

      Announcement latestAncmnt = await _kc.Announcements
        .Where(anc => anc.IsPublicAncmnt == true)
        .OrderByDescending(anc => anc.AncmntId)
        .FirstOrDefaultAsync();

      EmpChameleonConfig empChameleonConfig = await _kc.EmpChameleonConfigs
        .Where(ecc => ecc.EmployeeId == empId)
        .FirstOrDefaultAsync();
      
      Employee employee = await _kc.Employees
        .Where(e => e.EmployeeId == empId)
        .FirstOrDefaultAsync();
      DateTime lastLogOnTime = (DateTime)(employee.LastLogOnTime != null ? employee.LastLogOnTime : DateTime.Now);

      string notifications = "Have a nice day! :)\n" + "Your last login was "
        + lastLogOnTime.ToString("MM/dd/yyyy h:mm tt") +"\n";
      DateTime startDate;
      DateTime todayDate = DateTime.Now;
      if(todayDate.DayOfWeek == DayOfWeek.Monday) 
      { startDate = new DateTime(todayDate.AddDays(-5).Year, todayDate.AddDays(-5).Month, todayDate.AddDays(-5).Day, 0, 0, 0); }
      else if(todayDate.DayOfWeek == DayOfWeek.Tuesday)
      { startDate = new DateTime(todayDate.AddDays(-4).Year, todayDate.AddDays(-4).Month, todayDate.AddDays(-4).Day, 0, 0, 0); }
      else
      { startDate = new DateTime(todayDate.AddDays(-3).Year, todayDate.AddDays(-3).Month, todayDate.AddDays(-3).Day, 0, 0, 0); }
      employee.LastLogOnTime = DateTime.Now;
      _kc.SaveChanges();
      if(empChameleonConfig != null)
      {
        if(empChameleonConfig.HasInventoryNotification == true)
        {
          notifications = "\tYour last login was "
        + ((DateTime)(await _kc.Employees.Where(e => e.EmployeeId == empId).FirstOrDefaultAsync()).LastLogOnTime).ToString("MM/dd/yyyy h:mm tt") +"\n"
        +"\tWhat happend in last 3 days:\n"; 
          // Checking Inv
          List<InvFeedsReport> invFeedsReports = await _kc.InvFeedsReports
            .Where(ifr => ifr.CreatedDate >= startDate)
            .Include(ifr => ifr.CreatedByNavigation)
            .ToListAsync();

          List<InvFeedsSkuconflictReport> invFeedsSkuconflictReports = await _kc.InvFeedsSkuconflictReports
            .Where(ifs => ifs.ImportedDate >= startDate)
            .Include(ifs => ifs.Customer)
            .Include(ifs => ifs.ImportedByNavigation)
            .ToListAsync();

          foreach(InvFeedsReport feedsReportDto in invFeedsReports)
          {
            notifications += "The inventory feeding report is created by " + (feedsReportDto.CreatedByNavigation != null ? feedsReportDto.CreatedByNavigation.LoginId: "someone") +"\n\t in "
              + ((DateTime)feedsReportDto.CreatedDate).ToString("MM/dd/yyyy h:mm tt") +"\n";
          }
          foreach(InvFeedsSkuconflictReport skuConflictReportDto in invFeedsSkuconflictReports)
          {
            notifications += "The feed list of " + skuConflictReportDto.Customer.CustName + " was updated by " + skuConflictReportDto.ImportedByNavigation.LoginId
              +"\n\t in "+ ((DateTime)skuConflictReportDto.ImportedDate).ToString("MM/dd/yyyy h:mm tt") +"\n";
          }
        }
        empChameleonConfig.ChLastLogOnDate = DateTime.Now;
        _kc.EmpChameleonConfigs.Update(empChameleonConfig);
        await _kc.SaveChangesAsync();
      }
      else
      {
        empChameleonConfig = new EmpChameleonConfig()
        {
          EmployeeId = empId,
          PrivilegeLevelInventory = 0,
          HasInventoryNotification = true
        };
        await _kc.EmpChameleonConfigs.AddAsync(empChameleonConfig);
        await _kc.SaveChangesAsync();
      }
      
      HomeAnnouncementNotificationsDTO homeAnnouncementNotificationsDTO = new HomeAnnouncementNotificationsDTO(){
        announcement = latestAncmnt,
        notifications = notifications
      };
      
      //return View(latestAncmnt);
      return View(homeAnnouncementNotificationsDTO);
    }


    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public static bool VerifyPasswordHash(string enteredPassword, string storedHash, string storedSalt)
    {
      var saltBytes = Convert.FromBase64String(storedSalt);
      var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
      return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
    }


    // By Brian Yi on 06/06/2021
    // Get Employee ID from cookie
    public int GetUserId(ClaimsIdentity claimsIdentity)
    {
      string result="";
      foreach(var claim in claimsIdentity.Claims)
      { 
        if(claim.Type == ClaimTypes.SerialNumber)
        { result = claim.Value; break;}
      }
       return Int32.Parse(result);
    }

  }
}
