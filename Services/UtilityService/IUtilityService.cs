using Chameleon.DTOs.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chameleon.Services.UtilityService
{
  public interface IUtilityService
  {
    Task<bool> SendEmail(List<EmailAddressDTO> emailList, string titleOfEmail, string contentOfEmail);
  }
}
