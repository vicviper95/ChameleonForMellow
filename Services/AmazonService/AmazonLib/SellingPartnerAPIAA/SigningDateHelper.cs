using System;
namespace Chameleon.Services.AmazonService.AmazonLib.SellingPartnerAPIAA
{
    public class SigningDateHelper : IDateHelper
    {
        public DateTime GetUtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
