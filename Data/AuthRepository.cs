using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Chameleon.DTOs.Employee;
using Chameleon.Models;
using Chameleon.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Chameleon.Data
{
  public class AuthRepository : IAuthRepository
  {
    private readonly KOALAContext _kc;
    private readonly IConfiguration _configuration;
    public AuthRepository(KOALAContext kc, IConfiguration configuration)
    {
      _configuration = configuration;
      _kc = kc;
    }
    public async Task<ServiceResponse<string>> Login(string loginId, string password)
    {
      ServiceResponse<string> response = new ServiceResponse<string>();
      Employee emp = await _kc.Employees.FirstOrDefaultAsync(x => x.LoginId.ToLower().Equals(loginId.ToLower()));
      if (emp == null)
      {
        response.Success = false;
        response.Message = "User not found.";
      }
      else if (!VerifyPasswordHash(password, emp.PasswordHash, emp.PasswordSalt))
      {
        response.Success = false;
        response.Message = "Wrong password";
      }
      else
      {
        response.Data = await CreateToken(emp);
      }

      return response;
    }

    public Task<ServiceResponse<int>> Register(EmployeeLoginDTO emp, string password)
    {
      throw new NotImplementedException();
    }

    public Task<bool> UserExists(string loginId)
    {
      throw new NotImplementedException();
    }

    //private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    //{
    //  using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
    //  {
    //    var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    //    for (int i = 0; i < computedHash.Length; i++)
    //    {
    //      if (computedHash[i] != passwordHash[i])
    //      {
    //        return false;
    //      }
    //    }
    //    return true;
    //  }
    //}
    public static bool VerifyPasswordHash(string enteredPassword, string storedHash, string storedSalt)
    {
      var saltBytes = Convert.FromBase64String(storedSalt);
      var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
      return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
    }

    // Create token
    private async Task<string> CreateToken(Employee emp)
    {
      //      Employee emp = await _kc.Employees.FirstOrDefaultAsync(x => x.LoginId.ToLower().Equals(loginId.ToLower()));
      // Need to modify for further development
      // 0: reg. employee; 1: Manager; 
      Department tmpDept = await _kc.Departments.FirstOrDefaultAsync(x => x.DepartmentId.Equals(emp.DepartmentId));
      string tmpRole = tmpDept.DeptShortName;
      string tmpName = (emp.EmployeeName != null) ? emp.EmployeeName : (emp.LegalName != null) ? emp.LegalName: emp.LoginId;
      
      // nothing can be null here!
      List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, emp.LoginId), // LoginID
                new Claim(ClaimTypes.Name, tmpName), // Either EmployeeName, LegalName, or LoginID
                new Claim(ClaimTypes.SerialNumber, emp.EmployeeId.ToString()), // Employee_id
                new Claim(ClaimTypes.Role, tmpRole), // Department
                new Claim(ClaimTypes.PrimaryGroupSid, tmpDept.DepartmentId.ToString()), // Department ID
                new Claim(ClaimTypes.Hash, emp.PasswordHash) // Password Hash
            };

      SymmetricSecurityKey key = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)
      );

      SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(1),
        SigningCredentials = creds
      };

      JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
      SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }
  }
}
