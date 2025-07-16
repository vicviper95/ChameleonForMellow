using System.Threading.Tasks;
using Chameleon.DTOs.Employee;
using Chameleon.Services;

namespace Chameleon.Data
{
  public interface IAuthRepository
  {
         Task<ServiceResponse<int>> Register(EmployeeLoginDTO emp, string password);
         Task<ServiceResponse<string>> Login(string loginId, string password);
         Task<bool> UserExists(string loginId);

  }
}
