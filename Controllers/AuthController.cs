using Chameleon.Data;
using Chameleon.DTOs.Employee;
using Chameleon.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _authRepo;
    public AuthController(IAuthRepository authRepo)
    {
      _authRepo = authRepo;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(EmployeeLoginDTO request)
    {
      ServiceResponse<string> response = await _authRepo.Login(request.LoginId, request.Password);

      if (!response.Success)
      {
        return BadRequest(response);
      }
      return Ok(response);
    }
  }
}
