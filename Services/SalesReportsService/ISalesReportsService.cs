using Chameleon.DTOs.SalesReports;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Chameleon.Models;

namespace Chameleon.Services.SalesReportsService
{
    public interface ISalesReportsService
    {
        Task<ImportResponseDTO> ImportAmzPerfMrktReport (Employee emp, List<AmzPerfMrktngRepImportDTO> amzRepList);
        Task<List<AmazonAdReport>> GetAmazonAdReports();
        Task<List<AmazonAdRepDetail>> GetAmzAdSkus(int amzAdRepNo);
        Task<List<AmazonAdRepDetailHistory>> GetAmzAdSkuHistory(int amzAdSkuNo);
    }
}
