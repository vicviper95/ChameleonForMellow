using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Security.Claims;
using Chameleon.Models;
using Microsoft.AspNetCore.Http;
using Chameleon.DTOs.SalesReports;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace Chameleon.Services.SalesReportsService
{
  public class SalesReportsService : ISalesReportsService
  {
    private readonly KOALAContext _kc;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public SalesReportsService(IMapper mapper, KOALAContext kc, IHttpContextAccessor httpContextAccessor)
    {
      _kc = kc;
      _mapper = mapper;
      _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ImportResponseDTO> ImportAmzPerfMrktReport(Employee emp, List<AmzPerfMrktngRepImportDTO> amzRepList)
    {
      ImportResponseDTO serviceResponse = new ImportResponseDTO();
      serviceResponse.errorOnImport = false;
      string tmpErrorMessage;


      DateTime todayDate = DateTime.Now;
      int amazonMarketId = 1;

      //List<AmazonAdReport> amzReports = await _kc.AmazonAdReports.ToListAsync();
      AmazonAdReport tmpReport = new AmazonAdReport();
      //DateTime tmpEndDate = new DateTime();
      DateTime tmpStartDate = new DateTime();
      List<AmazonAdRepDetail> tmpAmzAdDetails = new List<AmazonAdRepDetail>();
      AmazonAdRepDetail tmpDetail = new AmazonAdRepDetail();
      AmazonAdRepDetailHistory tmpHistory = new AmazonAdRepDetailHistory();
      List<MkIcr> amzIcrs = await _kc.MkIcrs
        .Where(a => a.MarketId == amazonMarketId)
        .ToListAsync();
      MkIcr tmpIcr = new MkIcr();
      double tmpCTR, tmpCPC, tmp14Sales, tmpSpend, tmpAcos, tmpRoas, tmpFDCR = new double();
      DateOnly tmpEndDate = new DateOnly();
      try
      {
        foreach (AmzPerfMrktngRepImportDTO tmpDTO in amzRepList)
        {
          tmpEndDate = DateOnly.Parse(tmpDTO.endDate);
          //tmpEndDate = DateTime.Parse(tmpDTO.endDate);
          tmpStartDate = DateTime.Parse(tmpDTO.startDate);
          tmpReport = await _kc.AmazonAdReports
            .Where(a => a.EndDate.Day == tmpEndDate.Day
            && a.EndDate.Year == tmpEndDate.Year
            && a.EndDate.Month == tmpEndDate.Month
            && a.CampaignName == tmpDTO.campaignName)
            .FirstOrDefaultAsync();

          if (tmpReport == null)
          {
            tmpReport = new AmazonAdReport()
            {
              EndDate = DateTime.Parse(tmpDTO.endDate),
              CreatedDate = todayDate,
              CampaignName = tmpDTO.campaignName,
              AdGroupName = tmpDTO.adGroupName
            };
            await _kc.AmazonAdReports.AddAsync(tmpReport);
          }
          else
          {
            tmpReport.LastModifiedDate = todayDate;
          }
          await _kc.SaveChangesAsync();

          tmpAmzAdDetails = await _kc.AmazonAdRepDetails
            .Where(a => a.AdId == tmpReport.AdId)
            .ToListAsync();
          tmpIcr = amzIcrs.Where(i => i.CustAsin == tmpDTO.advertisedAsin).First();

          if (tmpAmzAdDetails == null || tmpAmzAdDetails.Count == 0)
          {
            tmpDetail = new AmazonAdRepDetail()
            {
              AdId = tmpReport.AdId,
              StartDate = tmpStartDate,
              PortfolioName = tmpDTO.portfolioName,
              AdvertisedAsin = tmpDTO.advertisedAsin,
              IcrId = tmpIcr.IcrId,
              CreatedDate = todayDate
            };
            await _kc.AmazonAdRepDetails.AddAsync(tmpDetail);

          }
          else
          {
            tmpDetail = tmpAmzAdDetails.Where(d => d.AdvertisedAsin == tmpDTO.advertisedAsin).FirstOrDefault();

            if (tmpDetail == null)
            {
              tmpDetail = new AmazonAdRepDetail()
              {
                AdId = tmpReport.AdId,
                StartDate = tmpStartDate,
                PortfolioName = tmpDTO.portfolioName,
                AdvertisedAsin = tmpDTO.advertisedAsin,
                IcrId = tmpIcr.IcrId,
                CreatedDate = todayDate
              };
              await _kc.AmazonAdRepDetails.AddAsync(tmpDetail);
            }
            else { tmpDetail.LastModifiedDate = todayDate; }

          } // End of checking Detail 
          await _kc.SaveChangesAsync();
          //tmpCPC, tmpSpend, tmpAcos, tmpRoas, tmpFDCR
          tmpCTR = (tmpDTO.clickThruRate != "" ? ConvertToDouble(tmpDTO.clickThruRate.Replace("%", "")) : 0);
          tmpCPC = (tmpDTO.costPerClick != "" ? ConvertToDouble(tmpDTO.costPerClick.Replace("$", "")) :0);
          tmpSpend = (tmpDTO.spend != "" ? ConvertToDouble(tmpDTO.spend.Replace("$", "")):0);
          tmp14Sales = (tmpDTO.totalSalesIn14Day != "" ? ConvertToDouble(tmpDTO.totalSalesIn14Day.Replace("$", "")):0);
          tmpAcos = (tmpDTO.totalAdvertisingCostOfSales != "" ? ConvertToDouble(tmpDTO.totalAdvertisingCostOfSales.Replace("%", "")):0);
          tmpRoas = (tmpDTO.totalReturnOnAdvertisingSpend != "" ? ConvertToDouble(tmpDTO.totalReturnOnAdvertisingSpend):0);
          tmpFDCR = (tmpDTO.conversionRateIn14Day != "" ? ConvertToDouble(tmpDTO.conversionRateIn14Day.Replace("%", "")):0);

          tmpHistory = new AmazonAdRepDetailHistory()
          {
            AdDetailId = tmpDetail.AdDetailId,
            Impressions = tmpDTO.impressions,
            Clicks = tmpDTO.clicks,
            ClickThruRateCtr = (decimal)tmpCTR,
            CostPerClickCpc = (decimal)tmpCPC,
            Spend = (decimal)tmpSpend,
            FourteenDayTotalSales = (decimal)tmp14Sales,
            TotalAdvertisingCostOfSalesAcos = (decimal)tmpAcos,
            TotalReturnOnAdvertisingSpendRoas = (decimal)tmpRoas,
            FourteenDayTotalOrders = tmpDTO.totalOrdersIn14Day,
            FourteenDayTotalUnits = tmpDTO.totalUnitsIn14Day,
            FourteenDayConversionRate = (decimal)tmpFDCR,
            CreatedDate = todayDate
          };
          await _kc.AmazonAdRepDetailHistories.AddAsync(tmpHistory);
        }// End of foreach
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        serviceResponse.errorOnImport = true;
        if (serviceResponse.errorMessages == null) { serviceResponse.errorMessages = new List<string>(); }
        serviceResponse.errorMessages.Add("Check with IT : " + ex.Message);
        return serviceResponse;

      }

      return serviceResponse;
    }

    // Get Amazon Performance Marketing Report
    // By Brian Yi on 1/26/2023
    public async Task<List<AmazonAdReport>> GetAmazonAdReports()
    {
      List<AmazonAdReport> serviceResponse = await _kc.AmazonAdReports.ToListAsync();
      return serviceResponse;
    }

    // Get Amazon Performance Marketing Report SKU History
    // By Brian Yi on 1/26/2023
    public async Task<List<AmazonAdRepDetail>> GetAmzAdSkus(int amzAdRepNo)
    {
      List<AmazonAdRepDetail> serviceResponse = await _kc.AmazonAdRepDetails
          .Where(a => a.AdId == amzAdRepNo)
          .ToListAsync();
      return serviceResponse;
    }

    // Get Amazon Performance Marketing Report SKU History
    // By Brian Yi on 1/26/2023
    public async Task<List<AmazonAdRepDetailHistory>> GetAmzAdSkuHistory(int amzAdSkuNo)
    {
      List<AmazonAdRepDetailHistory> serviceResponse = await _kc.AmazonAdRepDetailHistories
          .Where(a => a.AdDetailId == amzAdSkuNo)
          .ToListAsync();
      return serviceResponse;
    }

    private double ConvertToDouble(string s)
    {
      char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
      double result = 0;
      try
      {
        if (s != null)
          if (!s.Contains(","))
            result = double.Parse(s, CultureInfo.InvariantCulture);
          else
            result = Convert.ToDouble(s.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
      }
      catch (Exception e)
      {
        try
        {
          result = Convert.ToDouble(s);
        }
        catch
        {
          try
          {
            result = Convert.ToDouble(s.Replace(",", ";").Replace(".", ",").Replace(";", "."));
          }
          catch
          {
            throw new Exception("Wrong string-to-double format");
          }
        }
      }
      return result;
    }



  }
}
