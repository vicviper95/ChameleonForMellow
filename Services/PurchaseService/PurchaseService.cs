using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Security.Claims;
using Chameleon.Models;
using Microsoft.AspNetCore.Http;
using Chameleon.DTOs.Purchase;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;
using System.Text.RegularExpressions;
using System.Globalization;
using Chameleon.Services.UtilityService;
using Chameleon.DTOs.Utility;
using System.Security.Policy;
using System.Web.WebPages;
using RestSharp.Extensions;

namespace Chameleon.Services.PurchaseService
{
  public class PurchaseService : IPurchaseService
  {
    private readonly KOALAContext _kc;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IUtilityService _utilService;
		public PurchaseService(IMapper mapper, KOALAContext kc, IHttpContextAccessor httpContextAccessor, IUtilityService utilityService)
    {
      _kc = kc;
      _mapper = mapper;
      _httpContextAccessor = httpContextAccessor;
			_utilService = utilityService;
		}
    private class EmployeeInfo
    {
      public int EmployeeId { get; set; }
      public string LoginId { get; set; }
    }
    
    private class TotalApprovedPrePO
    {
      public string currentStatus { get; set; }
      public int currentStatusId { get; set; }
      public string poChannel { get; set;}
      public int countOfPrePos { get; set;}
      public string weekOfPrePO { get; set; }
      public string requestorsNote { get; set; }
      public string mgmtsNote { get; set; }
      public string logisticsAccptncNote { get; set; }
      public string logisticsCompleteNote { get; set;}
      public int totalQty { get; set; }
    }

    // Get All PrePOs for PO Acceptance Dashboard
    // By Brian Yi on 01/06/2022
    public async Task<List<PrePOItemDTO>> GetAllPrePOsForDashboard(DateTime startDate, DateTime endDate)
    {
      // Get all PrePOs
      List<PrePo> allPrePOs = await _kc.PrePos
        .Where(p => p.HasDeleted != true && p.CreatedDate >= startDate && p.CreatedDate < endDate)
        .ToListAsync();

      List<PrePOItemDTO> serviceResponse = new List<PrePOItemDTO>();

      List<ItemStatus> itemStatuses = await _kc.ItemStatuses.ToListAsync();
      try
      {
        serviceResponse = allPrePOs.Select(p =>
      new PrePOItemDTO()
      {
        prePOId = p.PrePoid,
        internalPoNo = p.InternalPono,
        isEdited = false,
        requestor = p.Requestor,
        createdBy = p.CreatedBy,
        createdDate = (p.CreatedDate.HasValue ? ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy") : "-"),
        poChannel = p.Pochannel.Replace("_", " "),
       // approvalLevel = (p.ApprovalLevel.HasValue() ? p.ApprovalLevel : "-"),
        sku = p.ItemName,
        skuStatus = (p.ItemStatus != null ? itemStatuses.Where(i => i.ItemStatusId == p.ItemStatus).FirstOrDefault().StatusItem : "-"),
        requestedQty = (p.RequestedQty.HasValue ? (int)p.RequestedQty : 0),
        requestorsNote = p.RequestorsNote,
        mustETADate = (p.MustEtadate.HasValue ? ((DateTime)p.MustEtadate).ToString("MM/dd/yyyy") : "-"),
        //mustETADate = (p.MustEtadate.HasValue ? ("ETA IN " + ((DateTime)p.MustEtadate).ToString("MMMM") + ", "
        //    + ((DateTime)p.MustEtadate).ToString("yyyy")) : "-"),
        hasInitialApproved = (p.HasInitialApproval.HasValue ? (bool)p.HasInitialApproval : false),
        initialApprovedBy = p.InitialApprovedBy,
        initialApprovedById = (p.InitialApprovedById.HasValue ? (int)p.InitialApprovedById : 0),
        initialApprovedDate = (p.InitialApprovedDate.HasValue ? ((DateTime)p.InitialApprovedDate).ToString("MM/dd/yyyy") : "-"),
        mgmtAdjQty = (p.MgmtAdjustedQty.HasValue ? (int)p.MgmtAdjustedQty : 0),
        mgmtsNote = p.MgmtsNote,
        mgmtPrePOAccept = (p.HasMgmtApproved.HasValue ? (bool)p.HasMgmtApproved : false),
        mgmtDateExecuted =( p.MgmtApprovedDate.HasValue ? ((DateTime)p.MgmtApprovedDate).ToString("MM/dd/yyyy") : "-"),
        mgmtApprovedBy = p.MgmtApprovedBy,
        mgmtApprovedById = (p.MgmtApprovedById.HasValue ? (int)p.MgmtApprovedById : 0),
        acceptedByLogistics = (p.HasAcceptedByLogistics.HasValue ? (bool)p.HasAcceptedByLogistics : false),
        acceptedByLogisticsDate = (p.AcceptedByLogisticsDate.HasValue ? ((DateTime)p.AcceptedByLogisticsDate).ToString("MM/dd/yyyy") : "-"),
        logisticsConfirmedQty = (p.LogisticsConfirmedQty.HasValue ? (int)p.LogisticsConfirmedQty : 0),
        logisticsChosenVendor = p.LogisticsChosenVendor,
        logisticsChosenVendorId = (p.LogisticsChosenVendorId.HasValue ? (int)p.LogisticsChosenVendorId : 0),
        logisticsAcceptanceNote = p.LogisticsAcceptanceNote,
        logisticsEtd_c = (p.LogisticsEtdC.HasValue ? ((DateTime)p.LogisticsEtdC).ToString("MM/dd/yyyy") : "-"),
        logisticsRegCompletion = (p.HasLogisticsRegCompletion.HasValue ? (bool)p.HasLogisticsRegCompletion : false),
        logisticsCompletedDate = (p.LogisticsCompletedDate.HasValue ? ((DateTime)p.LogisticsCompletedDate).ToString("MM/dd/yyyy") : "-"),
        logisticsPONoNote = p.LogisticsPonoNote,
        logisticsAcceptedBy = p.LogisticsAcceptedBy,
        logisticsAcceptedById = (p.LogisticsAcceptedById.HasValue ? (int)p.LogisticsAcceptedById : 0),
        logisticsMustETADate = (p.MustEtadateUpdtdByLogistics.HasValue ? (((DateTime)p.MustEtadateUpdtdByLogistics).ToString("MM") + "/"
            + ((DateTime)p.MustEtadateUpdtdByLogistics).ToString("yyyy")) : "-"),
          prePOStatus = (int)p.PrePostatusTypeId
      }).ToList();
      }
      catch (Exception ex) {

        Console.WriteLine(ex.Message);
      }
      return serviceResponse;
    }

    // Get an PrePO detail by InternalPONo
    // By Brian Yi on 01/11/2021
    public async Task<PrePOItemDTO> GetPrePODetail(long id)
    {
      PrePo prePoItem = await _kc.PrePos
        .FirstOrDefaultAsync(p => p.PrePoid == id);

      PrePOItemDTO serviceResponse = new PrePOItemDTO();
      try
      {
        serviceResponse = new PrePOItemDTO()
        {
          prePOId = prePoItem.PrePoid,
          internalPoNo = prePoItem.InternalPono,
          requestor = prePoItem.Requestor,
          createdBy = prePoItem.CreatedBy,
          createdDate = (prePoItem.CreatedDate.HasValue ? ((DateTime)prePoItem.CreatedDate).ToString("g") : "-"),
          poChannel = prePoItem.Pochannel,
          //approvalLevel = prePoItem.ApprovalLevel.ToUpper(),
          sku = prePoItem.ItemName,
          requestedQty = (prePoItem.RequestedQty.HasValue ? (int)prePoItem.RequestedQty : 0),
          requestorsNote = prePoItem.RequestorsNote,
          mustETADate = (prePoItem.MustEtadate.HasValue ? ((DateTime)prePoItem.MustEtadate).ToString("MM/dd/yyyy") : "-"),
          hasInitialApproved = (prePoItem.HasInitialApproval.HasValue ? (bool)prePoItem.HasInitialApproval : false),
          initialApprovedBy = prePoItem.InitialApprovedBy,
          initialApprovedById = (prePoItem.InitialApprovedById.HasValue ? (int)prePoItem.InitialApprovedById : 0),
          initialApprovedDate = (prePoItem.InitialApprovedDate.HasValue ? ((DateTime)prePoItem.InitialApprovedDate).ToString("g") : "-"),
          mgmtAdjQty = (prePoItem.MgmtAdjustedQty.HasValue ? (int)prePoItem.MgmtAdjustedQty : 0),
          mgmtsNote = prePoItem.MgmtsNote,
          mgmtPrePOAccept = (prePoItem.HasMgmtApproved.HasValue ? (bool)prePoItem.HasMgmtApproved : false),
          mgmtDateExecuted = (prePoItem.MgmtApprovedDate.HasValue ? ((DateTime)prePoItem.MgmtApprovedDate).ToString("g") : "-"),
          mgmtApprovedBy = prePoItem.MgmtApprovedBy,
          mgmtApprovedById = (prePoItem.MgmtApprovedById.HasValue ? (int)prePoItem.MgmtApprovedById : 0),
          acceptedByLogistics = (prePoItem.HasAcceptedByLogistics.HasValue ? (bool)prePoItem.HasAcceptedByLogistics : false),
          acceptedByLogisticsDate = (prePoItem.AcceptedByLogisticsDate.HasValue ? ((DateTime)prePoItem.AcceptedByLogisticsDate).ToString("g") : "-"),
          logisticsConfirmedQty = (prePoItem.LogisticsConfirmedQty.HasValue ? (int)prePoItem.LogisticsConfirmedQty : 0),
          logisticsChosenVendor = prePoItem.LogisticsChosenVendor,
          logisticsChosenVendorId = (prePoItem.LogisticsChosenVendorId.HasValue ? (int)prePoItem.LogisticsChosenVendorId : 0),
          logisticsAcceptanceNote = prePoItem.LogisticsAcceptanceNote,
          logisticsEtd_c = (prePoItem.LogisticsEtdC.HasValue ? ((DateTime)prePoItem.LogisticsEtdC).ToString("MM/dd/yyyy") : "-"),
          logisticsRegCompletion = (prePoItem.HasLogisticsRegCompletion.HasValue ? (bool)prePoItem.HasLogisticsRegCompletion : false),
          logisticsCompletedDate = (prePoItem.LogisticsCompletedDate.HasValue ? ((DateTime)prePoItem.LogisticsCompletedDate).ToString("g") : "-"),
          logisticsCompletedBy = prePoItem.LogisticsCompletedBy,
          logisticsPONoNote = prePoItem.LogisticsPonoNote,
          logisticsAcceptedBy = prePoItem.LogisticsAcceptedBy,
          logisticsAcceptedById = (prePoItem.LogisticsAcceptedById.HasValue ? (int)prePoItem.LogisticsAcceptedById : 0),
          logisticsMustETADate = (prePoItem.MustEtadateUpdtdByLogistics.HasValue ? (((DateTime)prePoItem.MustEtadateUpdtdByLogistics).ToString("MM") + "/"
            + ((DateTime)prePoItem.MustEtadateUpdtdByLogistics).ToString("yyyy")) : "-"),
            prePOStatus = (prePoItem.PrePostatusTypeId.HasValue ? (int)prePoItem.PrePostatusTypeId : 0)
        };
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

      return serviceResponse;
    }

    // Need a logic for History(Snapshot)
    public async Task<bool> UpdatePrePO(Employee emp, PrePOItemDTO prePOItemDTO)
    {
      int prePostatus = prePOItemDTO.prePOStatus;
      CultureInfo myCI = new CultureInfo("en-us");
      Calendar myCal = myCI.Calendar;

      // Gets the DTFI properties required by GetWeekOfYear.
      CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
      DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

      string empName = (emp.EmployeeName != null ? emp.EmployeeName : (emp.LegalName != null ? emp.LegalName : emp.LoginId));
      DateTime todayDate = DateTime.Now;
      DateTime etaDate = new DateTime();
      PrePo updatePrePo = await _kc.PrePos
        .Where(p => p.PrePoid == prePOItemDTO.prePOId).FirstOrDefaultAsync();
      PrePohistory prePoHistory = new PrePohistory();

      if (updatePrePo == null) return false;
      prePoHistory.PrePoid = updatePrePo.PrePoid;
      prePoHistory.ModifiedDate = todayDate;
      prePoHistory.ModifiedById = emp.EmployeeId;
      prePoHistory.ModifiedBy = empName;
      prePoHistory.ItemName = updatePrePo.ItemName;
      prePoHistory.RevNo = 1 + await _kc.PrePohistories
        .Where(p => p.PrePoid == prePOItemDTO.prePOId).CountAsync();

      if (prePOItemDTO.sku != updatePrePo.ItemName)
      {
        //updatePrePo.ItemNoId = prePOItemDTO.itemNoId;
        updatePrePo.ItemName = prePOItemDTO.sku;
      }
      if (prePostatus < 2)
      {
        if (prePOItemDTO.mustETADate != "none") 
        { 
          etaDate = DateTime.Parse(prePOItemDTO.mustETADate);
          if (updatePrePo.MustEtadate.HasValue) { prePoHistory.MustEtadate = updatePrePo.MustEtadate; }
          updatePrePo.MustEtadate = etaDate;
        }
        prePoHistory.RequestedQty = updatePrePo.RequestedQty;
        prePoHistory.Pochannel = updatePrePo.Pochannel;
       // prePoHistory.ApprovalLevel = updatePrePo.ApprovalLevel.ToUpper();
        prePoHistory.RequestorsNote = updatePrePo.RequestorsNote;
        prePoHistory.PrePostatusTypeId = 1;
        prePoHistory.ItemName = updatePrePo.ItemName;

        updatePrePo.RequestedQty = prePOItemDTO.requestedQty;
        updatePrePo.Pochannel = prePOItemDTO.poChannel.ToUpper();
        //updatePrePo.ApprovalLevel = ScrubHtml(prePOItemDTO.approvalLevel).ToUpper();
        updatePrePo.RequestorsNote = prePOItemDTO.requestorsNote;
        updatePrePo.PrePostatusTypeId = 1;

      }
      else if (prePostatus < 4)
      {
        //if (prePOItemDTO.mustETADate != "none")
        //{
          //etaDate = DateTime.Parse(prePOItemDTO.mustETADate);
          if (updatePrePo.MustEtadate.HasValue) { prePoHistory.MustEtadate = updatePrePo.MustEtadate; }
          //updatePrePo.MustEtadate = etaDate;
        //}
        prePoHistory.RequestedQty = updatePrePo.RequestedQty;
        prePoHistory.Pochannel = updatePrePo.Pochannel;
        //prePoHistory.ApprovalLevel = updatePrePo.ApprovalLevel.ToUpper();
        prePoHistory.RequestorsNote = updatePrePo.RequestorsNote;
        prePoHistory.MgmtAdjustedQty = updatePrePo.MgmtAdjustedQty;
        prePoHistory.MgmtsNote = updatePrePo.MgmtsNote;
        prePoHistory.PrePostatusTypeId = 3;

        updatePrePo.MgmtAdjustedQty = prePOItemDTO.mgmtAdjQty;
        updatePrePo.MgmtsNote = prePOItemDTO.mgmtsNote;
        updatePrePo.PrePostatusTypeId = 3;

      }
      else if (prePostatus < 6)
      {
        if (prePOItemDTO.logisticsMustETADate != "none") 
        { 
          etaDate = DateTime.Parse(prePOItemDTO.logisticsMustETADate);
          if (updatePrePo.MustEtadateUpdtdByLogistics.HasValue) { prePoHistory.MustEtadateUpdtdByLogistics = updatePrePo.MustEtadateUpdtdByLogistics; }
          updatePrePo.MustEtadateUpdtdByLogistics = etaDate;
        }
        prePoHistory.PrePostatusTypeId = 5;
        //if (prePOItemDTO.mustETADate != "none")
        //{
          //etaDate = DateTime.Parse(prePOItemDTO.mustETADate);
          if (updatePrePo.MustEtadate.HasValue) { prePoHistory.MustEtadate = updatePrePo.MustEtadate; }
          //updatePrePo.MustEtadate = etaDate;
        //}
        prePoHistory.RequestedQty = updatePrePo.RequestedQty;
        prePoHistory.Pochannel = updatePrePo.Pochannel.ToUpper();
        //prePoHistory.ApprovalLevel = updatePrePo.ApprovalLevel;
        prePoHistory.RequestorsNote = updatePrePo.RequestorsNote;
        prePoHistory.MgmtAdjustedQty = updatePrePo.MgmtAdjustedQty;
        prePoHistory.MgmtsNote = updatePrePo.MgmtsNote;

        if (prePOItemDTO.logisticsChosenVendorId > 0) {
          if(updatePrePo.LogisticsChosenVendor != null)
          { prePoHistory.LogisticsChosenVendor = updatePrePo.LogisticsChosenVendor; }
          updatePrePo.LogisticsChosenVendor = await _kc.Vendors.Where(v => v.VendorId == prePOItemDTO.logisticsChosenVendorId)
          .Select(n => n.VendorName).FirstOrDefaultAsync();
          updatePrePo.LogisticsChosenVendorId = prePOItemDTO.logisticsChosenVendorId;
        }
        prePoHistory.LogisticsConfirmedQty = updatePrePo.LogisticsConfirmedQty;
        prePoHistory.LogisticsAcceptanceNote = updatePrePo.LogisticsAcceptanceNote;
        prePoHistory.LogisticsPonoNote = updatePrePo.LogisticsPonoNote;

        updatePrePo.LogisticsConfirmedQty = prePOItemDTO.logisticsConfirmedQty;
        updatePrePo.LogisticsAcceptanceNote = prePOItemDTO.logisticsAcceptanceNote;
        updatePrePo.LogisticsPonoNote = prePOItemDTO.logisticsPONoNote;
        //updatePrePo.PrePostatusTypeId = 5;//logisticsEtd_c
        //if(DateTime.Now.CompareTo(DateTime.Parse(prePOItemDTO.logisticsEtd_c)) != 0)
        if (prePOItemDTO.logisticsEtd_c != null)
        {
          if(updatePrePo.LogisticsEtdC.HasValue)
          { prePoHistory.LogisticsEtdC = updatePrePo.LogisticsEtdC; }
          updatePrePo.LogisticsEtdC = DateTime.Parse(prePOItemDTO.logisticsEtd_c);
        }
      }

      try 
      {
        _kc.PrePos.Update(updatePrePo);
        await _kc.PrePohistories.AddAsync(prePoHistory);
        await _kc.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }

      return true;
    }

    public async Task<bool> CreatePrePO(Employee emp, PrePOItemDTO prePOItemDTO)
    {
      CultureInfo myCI = new CultureInfo("en-us");
      Calendar myCal = myCI.Calendar;

      // Gets the DTFI properties required by GetWeekOfYear.
      CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
      DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

      string empName = (emp.EmployeeName != null ? emp.EmployeeName : (emp.LegalName != null ? emp.LegalName : emp.LoginId));
      DateTime todayDate = DateTime.Now;
      DateTime etaDate = new DateTime();
      BpmItem bpmItem = await _kc.BpmItems
        .Where(b => b.ItemName.ToUpper() == (ScrubHtml(prePOItemDTO.sku)).ToUpper())
        .FirstOrDefaultAsync();
      if (prePOItemDTO.mustETADate != "none") etaDate = DateTime.Parse(prePOItemDTO.mustETADate);
      PurchaseConfig pConfig = await _kc.PurchaseConfigs.FirstOrDefaultAsync();
      //List<ItemStatus> itemStatuses = await _kc.ItemStatuses.ToListAsync();
      //int curWeek = myCal.GetWeekOfYear(DateTime.Now, myCWR, myFirstDOW) - 1;
      int curWeek = myCal.GetWeekOfYear(DateTime.Now, myCWR, myFirstDOW); // Changed on 2/15/2024
      //if(pConfig.CurrentWeek != curWeek) pConfig.CurrentWeek = curWeek;
      int noLength = 4, noLengthApprvl = 3;
      string poChannel = prePOItemDTO.poChannel.ToUpper();
      int nextPoNo = 0, curApprvlNo = 0;

      if(pConfig.CurrentWeek != curWeek)
      {
        pConfig.CurrentWeek = curWeek;
        pConfig.CurWeekBpmpreNo = 1;
        pConfig.CurWeekCcguspreNo = 1;
        pConfig.CurWeekCgcanadaPreNo = 1;
        pConfig.CurWeekCgukpreNo = 1;
        pConfig.CurWeekWfspreNo = 1;
        pConfig.CurWeekFbacanadaPreNo = 1;
        if (pConfig.CurApprovalYear != (DateTime.Now.Year % 100))
        {
          pConfig.ApprovalNo = 1;
          pConfig.CurApprovalYear = DateTime.Now.Year % 100;//(int?)Int64.Parse(DateTime.Now.Year.ToString("yy"));
        }
      }

      if (poChannel == "BPM") { nextPoNo = (int)(pConfig.CurWeekBpmpreNo.HasValue ? pConfig.CurWeekBpmpreNo : (pConfig.CurWeekBpmpreNo = 1)); pConfig.CurWeekBpmpreNo++; }
      else if (poChannel == "CG_USA") { nextPoNo = (int)(pConfig.CurWeekCcguspreNo.HasValue ? pConfig.CurWeekCcguspreNo : (pConfig.CurWeekCcguspreNo = 1)); pConfig.CurWeekCcguspreNo++; }
      else if (poChannel == "CG_CANADA") { nextPoNo = (int)(pConfig.CurWeekCgcanadaPreNo.HasValue ? pConfig.CurWeekCgcanadaPreNo : (pConfig.CurWeekCgcanadaPreNo = 1)); pConfig.CurWeekCgcanadaPreNo++; }
      else if (poChannel == "CG_UK") { nextPoNo = (int)(pConfig.CurWeekCgukpreNo.HasValue ? pConfig.CurWeekCgukpreNo : (pConfig.CurWeekCgukpreNo = 1)); pConfig.CurWeekCgukpreNo++; }
      else if (poChannel == "WFS") { nextPoNo = (int)(pConfig.CurWeekWfspreNo.HasValue ? pConfig.CurWeekWfspreNo : (pConfig.CurWeekWfspreNo = 1)); pConfig.CurWeekWfspreNo++; }
      else if (poChannel == "FBA_CA") { nextPoNo = (int)(pConfig.CurWeekFbacanadaPreNo.HasValue ? pConfig.CurWeekFbacanadaPreNo : (pConfig.CurWeekFbacanadaPreNo = 1)); pConfig.CurWeekFbacanadaPreNo++; }
      curApprvlNo = (int)(pConfig.ApprovalNo.HasValue ? pConfig.ApprovalNo : (pConfig.ApprovalNo = 1));
      pConfig.ApprovalNo++;

      //string poNo = POChannelConverstion(poChannel) + "_" + "W" + curWeek.ToString("D" + 2) + "_" + nextPoNo.ToString("D" + noLength);
      string poNo = pConfig.CurApprovalYear.ToString()+ curApprvlNo.ToString("D" + noLengthApprvl) + "_" + POChannelConverstion(poChannel) + "_" + curWeek.ToString("D" + 2) + "_" + nextPoNo.ToString("D" + noLength);
      //DateTime date = DateTime.Parse((prePOItemDTO.mustETADate != null) ? ;

      if (prePOItemDTO == null) return false;
      PrePo newPrePO = new PrePo();
      try
      {
        if (prePOItemDTO.mustETADate != "none")
        {
          newPrePO = new PrePo()
          {
            InternalPono = poNo,
            Requestor = empName,
            RequestorId = emp.EmployeeId,
            CreatedBy = empName,
            CreatedById = emp.EmployeeId,
            CreatedDate = todayDate,
            Pochannel = prePOItemDTO.poChannel,
            PochannelId = prePOItemDTO.poChannelId,
            ItemName = prePOItemDTO.sku,
            ItemNoId = prePOItemDTO.itemNoId,
            ItemStatus = bpmItem.ItemStatusId,
            RequestedQty = prePOItemDTO.requestedQty,
            RequestorsNote = prePOItemDTO.requestorsNote,
            MustEtadate = etaDate,
						//ApprovalLevel = ScrubHtml(prePOItemDTO.approvalLevel).ToUpper(),
						PrePostatusTypeId = 1
          };
        }
        else
        {
          newPrePO = new PrePo()
          {
            InternalPono = poNo,
            Requestor = empName,
            RequestorId = emp.EmployeeId,
            CreatedBy = empName,
            CreatedById = emp.EmployeeId,
            CreatedDate = todayDate,
            Pochannel = prePOItemDTO.poChannel,
            PochannelId = prePOItemDTO.poChannelId,
            ItemName = prePOItemDTO.sku,
            ItemNoId = prePOItemDTO.itemNoId,
            ItemStatus = bpmItem.ItemStatusId,
            RequestedQty = prePOItemDTO.requestedQty,
            RequestorsNote = prePOItemDTO.requestorsNote,
						//ApprovalLevel = ScrubHtml(prePOItemDTO.approvalLevel).ToUpper(),
						PrePostatusTypeId = 1
          };
        }
        await _kc.PrePos.AddAsync(newPrePO);
        _kc.PurchaseConfigs.Update(pConfig);
        await _kc.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }
      return true;
    }

    public async Task<List<LogisticsVendorDTO>> GetVendorList()
    {
      List<LogisticsVendorDTO> serviceResponse = await _kc.Vendors
        .Where(v => v.VendCatId == 5)
        .Select(n => new LogisticsVendorDTO
        {
          vendorName = n.VendorName,
          vendorId = n.VendorId
        }).ToListAsync();

      return serviceResponse;

    }
    public async Task<List<PrePOSKUDTO>> GetPrePOBPMItemList()
    {
      List<PrePOSKUDTO> serviceResponse = await _kc.BpmItems
        .Where(b => b.ItemStatusId != 6)
        .Select(s => new PrePOSKUDTO
        {
          itemNoId = s.ItemNoId,
          itemName = s.ItemName,
          itemStatus = (int)s.ItemStatusId
        }).ToListAsync();
      return serviceResponse;
    }


    public async Task<List<string>> GetPrePOSKUList()
    {
      List<string> serviceResponse = await _kc.BpmItems
        .Where(b => b.ItemStatusId != 6)
        .Select(s => s.ItemName).ToListAsync();
      return serviceResponse;
    }

    public async Task<bool> GetAcceptApprovePrePOs(Employee emp, List<string> prePOList)
    {
      List<long> prePOIdList = prePOList.ConvertAll(s => Int64.Parse(s));
      List<PrePo> prePos = await _kc.PrePos.Where(p => prePOIdList.Contains(p.PrePoid)).ToListAsync();
      DateTime today = DateTime.Now;
      string empName = (emp.EmployeeName != null ? emp.EmployeeName : (emp.LegalName != null ? emp.LegalName : emp.LoginId));

      try 
      {
        foreach(PrePo tmpPrePo in prePos)
        {
          if (tmpPrePo.PrePostatusTypeId < 2)
          {
            tmpPrePo.PrePostatusTypeId = 2;
            tmpPrePo.HasInitialApproval = true;
            tmpPrePo.InitialApprovedById = emp.EmployeeId;
            tmpPrePo.InitialApprovedDate = today;
            tmpPrePo.InitialApprovedBy = empName;
            tmpPrePo.MgmtAdjustedQty = tmpPrePo.RequestedQty;
          } 
          else if (tmpPrePo.PrePostatusTypeId < 4)
          {
            tmpPrePo.PrePostatusTypeId = 4;
            tmpPrePo.HasMgmtApproved = true;
            tmpPrePo.MgmtApprovedById = emp.EmployeeId;
            tmpPrePo.MgmtApprovedDate = today;
            tmpPrePo.MgmtApprovedBy = empName;
            tmpPrePo.LogisticsConfirmedQty = tmpPrePo.MgmtAdjustedQty;
          }
          else if (tmpPrePo.PrePostatusTypeId < 5)
          {
            tmpPrePo.PrePostatusTypeId = 5;
            tmpPrePo.HasAcceptedByLogistics = true;
            tmpPrePo.LogisticsAcceptedById = emp.EmployeeId;
            tmpPrePo.AcceptedByLogisticsDate = today;
            tmpPrePo.LogisticsAcceptedBy = empName;
          }
          else if (tmpPrePo.PrePostatusTypeId < 6)
          {
            tmpPrePo.PrePostatusTypeId = 6;
            tmpPrePo.HasAcceptedByLogistics = true;
            tmpPrePo.HasLogisticsRegCompletion = true;
            tmpPrePo.LogisticsCompletedById = emp.EmployeeId;
            tmpPrePo.LogisticsCompletedDate = today;
            tmpPrePo.LogisticsCompletedBy = empName;
          }
        } // End of foreach

        await _kc.BulkUpdateAsync(prePos);
        await MEWS_Approval_Notification (emp, prePos); //Should Activate this!
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }
      return true;
    }

    // Delete(?) PrePOs
    // By Brian on 02/02/2022
    public async Task<bool> GetDeletedPrePOs(Employee emp, List<string> prePOList)
    {
      List<long> prePOIdList = prePOList.ConvertAll(s => Int64.Parse(s));
      List<PrePo> prePos = await _kc.PrePos.Where(p => prePOIdList.Contains(p.PrePoid)).ToListAsync();
      DateTime today = DateTime.Now;
      string empName = (emp.EmployeeName != null ? emp.EmployeeName : (emp.LegalName != null ? emp.LegalName : emp.LoginId));

      try
      {
        foreach (PrePo tmpPrePo in prePos)
        {
          tmpPrePo.HasDeleted = true;
          tmpPrePo.DeletedById = emp.EmployeeId;
        } // End of foreach

        await _kc.BulkUpdateAsync(prePos);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }
      return true;
    }



    // For closing or declining POs
    // By Brian Yi on 01/24/2022
    public async Task<bool> GetClosedDeclinedPrePOs(Employee emp, List<string> prePOList)
    {
      List<long> prePOIdList = prePOList.ConvertAll(s => Int64.Parse(s));
      List<PrePo> prePos = await _kc.PrePos.Where(p => prePOIdList.Contains(p.PrePoid)).ToListAsync();
      DateTime today = DateTime.Now;
      string empName = (emp.EmployeeName != null ? emp.EmployeeName : (emp.LegalName != null ? emp.LegalName : emp.LoginId));

      try
      {
        foreach (PrePo tmpPrePo in prePos)
        {
          if (tmpPrePo.PrePostatusTypeId >= 0 && tmpPrePo.PrePostatusTypeId < 2)
          {
            tmpPrePo.PrePostatusTypeId = -1;
            tmpPrePo.HasInitialApproval = false;
            tmpPrePo.InitialApprovedById = emp.EmployeeId;
            tmpPrePo.InitialApprovedDate = today;
            tmpPrePo.InitialApprovedBy = empName;

          }
          else if (tmpPrePo.PrePostatusTypeId >= 2 && tmpPrePo.PrePostatusTypeId < 4)
          {
            tmpPrePo.PrePostatusTypeId = -2;
            tmpPrePo.HasMgmtApproved = false;
            tmpPrePo.MgmtApprovedById = emp.EmployeeId;
            tmpPrePo.MgmtApprovedDate = today;
            tmpPrePo.MgmtApprovedBy = empName;

          }
          else if (tmpPrePo.PrePostatusTypeId >= 4 && tmpPrePo.PrePostatusTypeId < 5)
          {
            tmpPrePo.PrePostatusTypeId = -3;
            tmpPrePo.HasAcceptedByLogistics = false;
            tmpPrePo.LogisticsAcceptedById = emp.EmployeeId;
            tmpPrePo.AcceptedByLogisticsDate = today;
            tmpPrePo.LogisticsAcceptedBy = empName;
          }
          else if (tmpPrePo.PrePostatusTypeId >= 5 || tmpPrePo.PrePostatusTypeId < 6)
          {
            tmpPrePo.PrePostatusTypeId = -3;
            tmpPrePo.HasLogisticsRegCompletion = false;
            tmpPrePo.LogisticsCompletedById = emp.EmployeeId;
            tmpPrePo.LogisticsCompletedDate = today;
            tmpPrePo.LogisticsCompletedBy = empName;
          }
        } // End of foreach

        await _kc.BulkUpdateAsync(prePos);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }
      return true;
    }

    // For closing or declining POs
    // By Brian Yi on 01/22/2022
    // Modified by Brian Yi on 05/01/2024

    public async Task<PrePOLogisticsImportResponseDTO> ImportPrePOs(Employee emp, List<PrePOImportDTO> prePOList)
    {
      CultureInfo myCI = new CultureInfo("en-us");
      Calendar myCal = myCI.Calendar;

      List<PrePOSKUDTO> bpmItems = await GetPrePOBPMItemList();
      PrePOSKUDTO tmpSku = new PrePOSKUDTO();

      PrePOLogisticsImportResponseDTO serviceResponse = new PrePOLogisticsImportResponseDTO();
      serviceResponse.errorOnImport = false;
      string tmpErrorMessage;

      // Gets the DTFI properties required by GetWeekOfYear.
      CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
      DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

      DateTime todayDate = DateTime.Now;
      string empName = (emp.EmployeeName != null ? emp.EmployeeName : (emp.LegalName != null ? emp.LegalName : emp.LoginId));

      DateTime etaDate = new DateTime();
      PurchaseConfig pConfig = await _kc.PurchaseConfigs.FirstOrDefaultAsync();
      //int curWeek = myCal.GetWeekOfYear(DateTime.Now, myCWR, myFirstDOW) - 1;
      int curWeek = myCal.GetWeekOfYear(DateTime.Now, myCWR, myFirstDOW); // Changed on 2/15/2024
      if (pConfig.CurrentWeek != curWeek)
      {
        pConfig.CurrentWeek = curWeek;
        pConfig.CurWeekBpmpreNo = 1;
        pConfig.CurWeekCcguspreNo = 1;
        pConfig.CurWeekCgcanadaPreNo = 1;
        pConfig.CurWeekCgukpreNo = 1;
        pConfig.CurWeekWfspreNo = 1;
        pConfig.CurWeekWfspreNo = 1;
        if (pConfig.CurApprovalYear != (DateTime.Now.Year % 100))
        {
          pConfig.ApprovalNo = 1;
          pConfig.CurApprovalYear = DateTime.Now.Year % 100;//(int?)Int64.Parse(DateTime.Now.Year.ToString("yy"));
        }
      }

      int noLength = 4, noLengthApprvl = 3;
      int nextPoNo = 0, curApprvlNo = 0;
      string poChannel, poNo;
      curApprvlNo = (int)(pConfig.ApprovalNo.HasValue ? pConfig.ApprovalNo : (pConfig.ApprovalNo = 1));
      pConfig.ApprovalNo++;
      List<PrePo> newPrePoImportList = new List<PrePo>();
      PrePo newImport = new PrePo();

      foreach (PrePOImportDTO tmpDto in prePOList)
      {
        if (tmpDto.poChannel == null) 
          break;
        poChannel = (ScrubHtml(tmpDto.poChannel)).ToUpper();
        poChannel = poChannel.Replace(" ", "_");

        if (poChannel == "BPM") { nextPoNo = (int)(pConfig.CurWeekBpmpreNo.HasValue ? pConfig.CurWeekBpmpreNo : (pConfig.CurWeekBpmpreNo = 1)); pConfig.CurWeekBpmpreNo++; }
        else if (poChannel == "CG_USA") { nextPoNo = (int)(pConfig.CurWeekCcguspreNo.HasValue ? pConfig.CurWeekCcguspreNo : (pConfig.CurWeekCcguspreNo = 1)); pConfig.CurWeekCcguspreNo++; }
        else if (poChannel == "CG_CANADA") { nextPoNo = (int)(pConfig.CurWeekCgcanadaPreNo.HasValue ? pConfig.CurWeekCgcanadaPreNo : (pConfig.CurWeekCgcanadaPreNo = 1)); pConfig.CurWeekCgcanadaPreNo++; }
        else if (poChannel == "CG_UK") { nextPoNo = (int)(pConfig.CurWeekCgukpreNo.HasValue ? pConfig.CurWeekCgukpreNo : (pConfig.CurWeekCgukpreNo = 1)); pConfig.CurWeekCgukpreNo++; }
        else if (poChannel == "WFS") { nextPoNo = (int)(pConfig.CurWeekWfspreNo.HasValue ? pConfig.CurWeekWfspreNo : (pConfig.CurWeekWfspreNo = 1)); pConfig.CurWeekWfspreNo++; }
        else if (poChannel == "FBA_CA") { nextPoNo = (int)(pConfig.CurWeekFbacanadaPreNo.HasValue ? pConfig.CurWeekFbacanadaPreNo : (pConfig.CurWeekFbacanadaPreNo = 1)); pConfig.CurWeekFbacanadaPreNo++; }
        else
        {
          serviceResponse.errorOnImport = true;
          tmpErrorMessage = tmpDto.poChannel + ": No Matching PO Channel";
          if (serviceResponse.errorMessages == null) { serviceResponse.errorMessages = new List<string>(); }
          serviceResponse.errorMessages.Add(tmpErrorMessage);
          goto SkipThisImportLine;
        }

        //poNo = POChannelConverstion(poChannel) + "_" + "W" + curWeek.ToString("D" + 2) + "_" + nextPoNo.ToString("D" + noLength);

        //poNo = POChannelConverstion(poChannel) + "_" + curWeek.ToString("D" + 2) + "_" + nextPoNo.ToString("D" + noLength);
        poNo = pConfig.CurApprovalYear.ToString() + curApprvlNo.ToString("D" + noLengthApprvl) + "_" + POChannelConverstion(poChannel) + "_" + curWeek.ToString("D" + 2) + "_" + nextPoNo.ToString("D" + noLength);

        tmpSku = bpmItems.Where(s => s.itemName.ToUpper() == (ScrubHtml(tmpDto.sku)).ToUpper()).FirstOrDefault();

        if (tmpSku == null)
        {
          serviceResponse.errorOnImport = true;
          tmpErrorMessage = tmpDto.sku + ": No Matching PO SKU";
          if (serviceResponse.errorMessages == null) { serviceResponse.errorMessages = new List<string>(); }
          serviceResponse.errorMessages.Add(tmpErrorMessage);
          goto SkipThisImportLine; 
        }
        // PrepostatusTypeId changed value: from 1 to 4 for going straight to the logistics
        if (ScrubHtml(tmpDto.mustETADate) != "")
        {
          etaDate = DateTime.Parse(tmpDto.mustETADate);
          newImport = new PrePo()  
          {
            InternalPono = poNo,
            Requestor = empName,
            RequestorId = emp.EmployeeId,
            CreatedBy = empName,
            CreatedById = emp.EmployeeId,
            CreatedDate = todayDate,
            Pochannel = poChannel,
            ItemName = tmpDto.sku,
            ItemNoId = tmpSku.itemNoId,
            ItemStatus = tmpSku.itemStatus,
            RequestedQty = tmpDto.requestedQty,
            RequestorsNote = tmpDto.requestorsNote,
            MustEtadate = etaDate,
            //ApprovalLevel = ScrubHtml(tmpDto.approvalLevel).ToUpper(),
            PrePostatusTypeId = 4
          };
        }
        else
        {
          newImport = new PrePo()
          {
            InternalPono = poNo,
            Requestor = empName,
            RequestorId = emp.EmployeeId,
            CreatedBy = empName,
            CreatedById = emp.EmployeeId,
            CreatedDate = todayDate,
            Pochannel = poChannel,
            ItemName = tmpDto.sku,
            ItemNoId = tmpSku.itemNoId,
            ItemStatus = tmpSku.itemStatus,
            RequestedQty = tmpDto.requestedQty,
            RequestorsNote = tmpDto.requestorsNote,
            //ApprovalLevel = ScrubHtml(tmpDto.approvalLevel).ToUpper(),
            PrePostatusTypeId = 4
          };
        }
        newPrePoImportList.Add(newImport);
        SkipThisImportLine:;
      }

      try 
      {
        await _kc.BulkInsertAsync(newPrePoImportList);
        _kc.PurchaseConfigs.Update(pConfig);
        await _kc.SaveChangesAsync();
        await MEWS_Approval_Notification(emp, newPrePoImportList);
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex.Message);
        serviceResponse.errorOnImport = true;
        if (serviceResponse.errorMessages == null) { serviceResponse.errorMessages = new List<string>(); }
        serviceResponse.errorMessages.Add("Check with IT : " + ex.Message);
        return serviceResponse;
      }

      return serviceResponse;
    }

    public async Task<PrePOLogisticsImportResponseDTO> ImportPrePOLogistics(Employee emp, List<PrePOLogisticsImportDTO> prePOLogisticsList)
    {
      DateTime todayDate = DateTime.Now;
      string empName = (emp.EmployeeName != null ? emp.EmployeeName : (emp.LegalName != null ? emp.LegalName : emp.LoginId));
      PrePOLogisticsImportResponseDTO serviceResponse = new PrePOLogisticsImportResponseDTO();
      serviceResponse.errorOnImport = false;
      List<PrePohistory> prePohistories = new List<PrePohistory>();
      List<PrePo> prePoList = await _kc.PrePos
        .Where(p => p.PrePostatusTypeId >= 4 && p.PrePostatusTypeId < 6)
        .ToListAsync();
      List<LogisticsVendorDTO> vendorList = await GetVendorList();
      LogisticsVendorDTO tmpVendor = new LogisticsVendorDTO();
      PrePo tmpModel = new PrePo();
      PrePohistory tmpHistory = new PrePohistory();
      DateTime tmpDate = new DateTime();
      string tmpErrorMessage;

      foreach (PrePOLogisticsImportDTO tmpDto in prePOLogisticsList)
      {
        tmpModel = prePoList
          .Where(p => p.InternalPono == (ScrubHtml(tmpDto.internalPONo)).ToUpper() && p.ItemName == (ScrubHtml(tmpDto.sku)).ToUpper())
          .FirstOrDefault();
        if(tmpModel == null) 
        { 
          serviceResponse.errorOnImport = true;
          tmpErrorMessage = tmpDto.internalPONo + ": No Matching Internal PO No. or SKU";
          if(serviceResponse.errorMessages == null) { serviceResponse.errorMessages = new List<string>();}
          serviceResponse.errorMessages.Add(tmpErrorMessage);
        }
        else // Found the match and update
        {
          tmpHistory = new PrePohistory();
          tmpHistory.PrePoid = tmpModel.PrePoid;
          tmpHistory.ModifiedDate = todayDate;
          tmpHistory.ModifiedById = emp.EmployeeId;
          tmpHistory.ModifiedBy = empName;
          tmpHistory.ItemName = tmpModel.ItemName;
          tmpHistory.Pochannel = tmpModel.Pochannel;
          //tmpHistory.ApprovalLevel = tmpModel.ApprovalLevel;
          tmpHistory.RequestedQty = tmpModel.RequestedQty;
          tmpHistory.RequestorsNote = tmpModel.RequestorsNote;
          tmpHistory.MgmtAdjustedQty = tmpModel.MgmtAdjustedQty;
          tmpHistory.MgmtsNote = tmpModel.MgmtsNote;
          tmpHistory.RevNo = 1 + await _kc.PrePohistories
            .Where(p => p.PrePoid == tmpModel.PrePoid).CountAsync();

          // Make 'Accepted By Logistics"
          //tmpModel.PrePostatusTypeId = 5;

          // Checking whether accepted or not; if not, make it accepted
          if (tmpModel.HasAcceptedByLogistics.HasValue == true && tmpModel.HasAcceptedByLogistics == false)
          {
            //tmpModel.HasAcceptedByLogistics = true;
            tmpModel.LogisticsAcceptedBy = empName;
            tmpModel.LogisticsAcceptedById = emp.EmployeeId;
            tmpModel.AcceptedByLogisticsDate = todayDate;
          } else
          {
            //tmpModel.HasAcceptedByLogistics = true;
          }//QtyConfirmed

          // Confirmed Qty.
          if(tmpModel.LogisticsConfirmedQty.HasValue == true) 
          {
            tmpHistory.LogisticsConfirmedQty = tmpModel.LogisticsConfirmedQty;
            tmpModel.LogisticsConfirmedQty = tmpDto.QtyConfirmed;
          }
          else if (tmpDto.QtyConfirmed >= 0)
          {
            tmpModel.LogisticsConfirmedQty = tmpDto.QtyConfirmed;
          }

         
          // Chosen Vendor
          if (tmpModel.LogisticsChosenVendorId.HasValue == true && (tmpModel.LogisticsChosenVendor.ToUpper() != tmpDto.ChosenVendor.ToUpper())) 
          {
            tmpHistory.LogisticsChosenVendor = tmpModel.LogisticsChosenVendor;
            tmpVendor = vendorList.Where(v => v.vendorName.ToUpper() == tmpDto.ChosenVendor.ToUpper()).FirstOrDefault();
            if (tmpVendor != null)
            {
              tmpModel.LogisticsChosenVendor = tmpVendor.vendorName;
              tmpModel.LogisticsChosenVendorId = tmpVendor.vendorId;
            } 
            else
            {
//              serviceResponse.Add(tmpDto.internalPONo + ": No Matching Vendor Name");
              serviceResponse.errorOnImport = true;
              tmpErrorMessage = tmpDto.internalPONo + ": No Matching Vendor Name";
              if (serviceResponse.errorMessages == null) { serviceResponse.errorMessages = new List<string>(); }
              serviceResponse.errorMessages.Add(tmpErrorMessage);
              // We are not adding this!
              goto SkipToEnd;
            }
          } 
          else if ((tmpModel.LogisticsChosenVendorId.HasValue == false) && (tmpDto.ChosenVendor != null))
          {
            tmpVendor = vendorList.Where(v => v.vendorName.ToUpper() == tmpDto.ChosenVendor.ToUpper()).FirstOrDefault();
            if (tmpVendor != null)
            {
              tmpModel.LogisticsChosenVendor = tmpVendor.vendorName;
              tmpModel.LogisticsChosenVendorId = tmpVendor.vendorId;
            }
            //else
            //{
            //  //serviceResponse.Add(tmpDto.internalPONo + ": No Matching Vendor Name");
            //  serviceResponse.errorOnImport = true;
            //  tmpErrorMessage = tmpDto.internalPONo + ": No Matching Vendor Name";
            //  if (serviceResponse.errorMessages == null) { serviceResponse.errorMessages = new List<string>(); }
            //  serviceResponse.errorMessages.Add(tmpErrorMessage);
            //  // We are not adding this!
            //  goto SkipToEnd;
            //}
          }

          // Acceptance Note
          if (tmpModel.LogisticsAcceptanceNote != null)
          { tmpHistory.LogisticsAcceptanceNote = tmpModel.LogisticsAcceptanceNote; }
          if (tmpDto.AcceptanceNote != tmpModel.LogisticsAcceptanceNote)
          {
            tmpModel.LogisticsAcceptanceNote = tmpDto.AcceptanceNote;
          }

          // ETD-C
          if (tmpDto.ETD_C != "")
          {
             tmpDate = DateTime.Parse(ScrubHtml(tmpDto.ETD_C));
            if (tmpModel.LogisticsEtdC.HasValue)
            { 
              tmpHistory.LogisticsEtdC = tmpModel.LogisticsEtdC;
              if (tmpDate.Year != ((DateTime)tmpModel.LogisticsEtdC).Year || tmpDate.Month != ((DateTime)tmpModel.LogisticsEtdC).Month
                || tmpDate.Day != ((DateTime)tmpModel.LogisticsEtdC).Day)
              {
                tmpModel.LogisticsEtdC = tmpDate;
              }
            }
            else 
            {
              tmpModel.LogisticsEtdC = tmpDate;
            }
          }

          // Complete Note
          if (tmpModel.LogisticsPonoNote != null)
          { tmpHistory.LogisticsPonoNote = tmpModel.LogisticsPonoNote; }
          if (tmpDto.CompleteNote != tmpModel.LogisticsPonoNote)
          {
            tmpModel.LogisticsPonoNote = tmpDto.CompleteNote;
          }

          
          // Updated Must ETA Date
          if (ScrubHtml(tmpDto.MustETADate) != null)
          {
             tmpDate = DateTime.Parse(ScrubHtml(tmpDto.MustETADate));
            if (tmpModel.MustEtadateUpdtdByLogistics.HasValue)
            {
              tmpHistory.MustEtadateUpdtdByLogistics = tmpModel.MustEtadateUpdtdByLogistics;
              if (tmpDate.Year != ((DateTime)tmpModel.MustEtadateUpdtdByLogistics).Year || tmpDate.Month != ((DateTime)tmpModel.MustEtadateUpdtdByLogistics).Month
                || tmpDate.Day != ((DateTime)tmpModel.MustEtadateUpdtdByLogistics).Day)
              {
                tmpModel.MustEtadateUpdtdByLogistics = tmpDate;
              }
            }
            else 
            {
              tmpModel.MustEtadateUpdtdByLogistics = tmpDate;
            }
          }

          prePohistories.Add(tmpHistory);
          SkipToEnd:;
          // History
        }// End of If clause

      }// End of foreach
      // goto something; something:

      try
      {
        await _kc.BulkInsertAsync(prePohistories);
        await _kc.BulkUpdateAsync(prePoList);
        await _kc.SaveChangesAsync();

        //await MEWS_Approval_Notification(emp, prePoList);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        serviceResponse.errorOnImport = true;
        if (serviceResponse.errorMessages == null) { serviceResponse.errorMessages = new List<string>(); }
        serviceResponse.errorMessages.Add("Check with IT : "+ex.Message);
        return serviceResponse;
      }

      return serviceResponse;
    }

    public async Task<List<PrePOItemDTO>> GetPrePOHistory(long id) //
    { 
      List<PrePOItemDTO> serviceResponse = new List<PrePOItemDTO>();
      if (id == 0) return serviceResponse;
      int count = await _kc.PrePohistories
        .Where(p => p.PrePoid == id)
        .CountAsync();
      if (count == 0) return serviceResponse;
      try
      {
        serviceResponse = await _kc.PrePohistories
          .Where(p => p.PrePoid == id)
          .Select(s => new PrePOItemDTO
          {
            prePOHistoryId = s.PrePohistoryId,
            revNo = (int)s.RevNo,
            poChannel = s.Pochannel,
            //approvalLevel = s.ApprovalLevel,
            requestorsNote = s.RequestorsNote,
            requestedQty = (s.RequestedQty.HasValue ? (int)s.RequestedQty : 0),
            sku = s.ItemName,
            mustETADate = (s.MustEtadate.HasValue ? ((DateTime)s.MustEtadate).ToString("MM/dd/yyyy") : "-"),
            //mustETADate = (s.MustEtadate.HasValue ? (((DateTime)s.MustEtadate).ToString("MM") + "/"
            //  + ((DateTime)s.MustEtadate).ToString("yyyy")) : "-"),
            mgmtAdjQty = (s.MgmtAdjustedQty.HasValue ? (int)s.MgmtAdjustedQty : 0),
            mgmtsNote = s.MgmtsNote,
            logisticsPONoNote = s.LogisticsPonoNote,
            logisticsConfirmedQty = (s.LogisticsConfirmedQty.HasValue ? (int)s.LogisticsConfirmedQty : 0),
            logisticsChosenVendor = s.LogisticsChosenVendor,
            logisticsAcceptanceNote = s.LogisticsAcceptanceNote,
            logisticsEtd_c = (s.LogisticsEtdC.HasValue ? ((DateTime)s.LogisticsEtdC).ToString("MM/dd/yyyy") : "-"),
            prePOStatus = (s.PrePostatusTypeId.HasValue ? (int)s.PrePostatusTypeId : 0),
            modifiedDate = (s.ModifiedDate.HasValue ? ((DateTime)s.ModifiedDate).ToString("g") : "-"),
            modifiedBy = s.ModifiedBy,
            logisticsMustETADate = (s.MustEtadateUpdtdByLogistics.HasValue ? (((DateTime)s.MustEtadateUpdtdByLogistics).ToString("MM") + "/"
              + ((DateTime)s.MustEtadateUpdtdByLogistics).ToString("yyyy")) : "-"),
          }).ToListAsync();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return serviceResponse;
    }

    public async Task<PrePOItemDTO> GetPrePOHistoryDetail(long id)
    {
      PrePOItemDTO serviceResponse = new PrePOItemDTO();
      try
      {
        serviceResponse = await _kc.PrePohistories
        .Where(p => p.PrePohistoryId == id)
        .Select(s => new PrePOItemDTO
        {
          prePOHistoryId = s.PrePohistoryId,
          revNo = (int)s.RevNo,
          poChannel = s.Pochannel,
          //approvalLevel = s.ApprovalLevel,
          requestorsNote = s.RequestorsNote,
          requestedQty = (s.RequestedQty.HasValue ? (int)s.RequestedQty : 0),
          sku = s.ItemName,
          mustETADate = (s.MustEtadate.HasValue ? ((DateTime)s.MustEtadate).ToString("MM/dd/yyyy") : "-"),
          //mustETADate = (s.MustEtadate.HasValue ? (((DateTime)s.MustEtadate).ToString("MM") + "/"
          //  + ((DateTime)s.MustEtadate).ToString("yyyy")) : "-"),
          mgmtAdjQty = (s.MgmtAdjustedQty.HasValue ? (int)s.MgmtAdjustedQty : 0),
          mgmtsNote = s.MgmtsNote,
          logisticsPONoNote = s.LogisticsPonoNote,
          logisticsConfirmedQty = (s.LogisticsConfirmedQty.HasValue ? (int)s.LogisticsConfirmedQty : 0),
          logisticsChosenVendor = s.LogisticsChosenVendor,
          logisticsAcceptanceNote = s.LogisticsAcceptanceNote,
          logisticsEtd_c = (s.LogisticsEtdC.HasValue ? ((DateTime)s.LogisticsEtdC).ToString("MM/dd/yyyy") : "-"),
          logisticsMustETADate = (s.MustEtadateUpdtdByLogistics.HasValue ? (((DateTime)s.MustEtadateUpdtdByLogistics).ToString("MM") + "/"
            + ((DateTime)s.MustEtadateUpdtdByLogistics).ToString("yyyy")) : "-"),
          prePOStatus = (s.PrePostatusTypeId.HasValue ? (int)s.PrePostatusTypeId : 0)
        }).FirstOrDefaultAsync();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return serviceResponse;
    }
    public async Task<List<SKUDTO>> GetSKUList()
    {
      List<EmployeeInfo> employeeInfos = await _kc.Employees
        .Select( e => new EmployeeInfo()
        {
          EmployeeId = e.EmployeeId,
          LoginId = e.LoginId
        }).ToListAsync();
      List<SKUDTO> serviceResponse = new List<SKUDTO>();
      try
      {
        serviceResponse = await _kc.BpmItems
        .Select( i => new SKUDTO() 
        {
          itemNoId = i.ItemNoId,
          itemName = i.ItemName,
          description = (i.Description != null ? i.Description : "-"),
          category = (i.Category != null ? i.Category : "-"),
          itemStatus = i.ItemStatus.StatusItem,
          lastModifiedById = (i.LastModKoE != null ? (int)i.LastModKoE : -1),
          lastModifiedDate = (i.LastModTime != null ? ((DateTime)i.LastModTime).ToString("MM/dd/yyyy hh:mm") : "-")

        }).ToListAsync();

        foreach(SKUDTO tmpDto in serviceResponse)
        {
          if(tmpDto.lastModifiedById > 0)
          {
            tmpDto.lastModifiedBy = employeeInfos.Where(e => e.EmployeeId == tmpDto.lastModifiedById).FirstOrDefault().LoginId;
          } 
          else 
          {
            tmpDto.lastModifiedBy = "-";
          }
          
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

      return serviceResponse;
    }

    public async Task<PrePOLogisticsImportResponseDTO> ImportSKUStatus(Employee emp, List<SKUStatusImportDTO> skuStatusImportList)
    {
      DateTime todayDate = DateTime.Now;
      string empName = (emp.EmployeeName != null ? emp.EmployeeName : (emp.LegalName != null ? emp.LegalName : emp.LoginId));

      PrePOLogisticsImportResponseDTO serviceResponse = new PrePOLogisticsImportResponseDTO();
      serviceResponse.errorOnImport = false;
      string tmpErrorMessage;

      List<BpmItem> bpmItems = await _kc.BpmItems
        .ToListAsync();
      BpmItem bpmItem = new BpmItem();
      List<ItemStatus> itemStatuses = await _kc.ItemStatuses
        .ToListAsync();

      int tmpItemStatusId = 0;
      ItemStatus tmpStatus = new ItemStatus();

      foreach(SKUStatusImportDTO tmpDto in skuStatusImportList)
      {
        bpmItem = bpmItems
          .Where(b => b.ItemName == ScrubHtml(tmpDto.sku).ToUpper())
          .FirstOrDefault();
        if(bpmItem == null)
        {
          serviceResponse.errorOnImport = true;
          tmpErrorMessage = tmpDto.sku + ": No Matching SKU";
          if (serviceResponse.errorMessages == null) { serviceResponse.errorMessages = new List<string>(); }
          serviceResponse.errorMessages.Add(tmpErrorMessage);
        }
        else
        {
          tmpItemStatusId = 0;
          tmpStatus = new ItemStatus();
          tmpStatus = itemStatuses.Where(s => s.StatusItem == ScrubHtml(tmpDto.status)).FirstOrDefault();
          if(tmpStatus == null)
          {
            serviceResponse.errorOnImport = true;
            tmpErrorMessage = tmpDto.sku + ": No Matching Item Status";
            if (serviceResponse.errorMessages == null) { serviceResponse.errorMessages = new List<string>(); }
            serviceResponse.errorMessages.Add(tmpErrorMessage);
          }
          else
          {
            bpmItem.ItemStatusId = tmpStatus.ItemStatusId;
            bpmItem.LastModTime = todayDate;
            bpmItem.LastModKoE = emp.EmployeeId;
          }
          
        }

      }// End of foreach
      

      try
      {
        await _kc.BulkUpdateAsync(bpmItems);
        await _kc.SaveChangesAsync();
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



    // Checking current user's authorization level
    // By Brian Yi on 02/26/2022
    public int PrePODashboardAuthOld(Employee emp)
    {
      int serviceResponse;
      if (emp.EmployeeId == 68 || emp.EmployeeId == 246 || emp.EmployeeId == 247 || emp.EmployeeId == 272) serviceResponse = 1; // Associate Role(Blue)
      else if (emp.EmployeeId == 282) serviceResponse = 2; // Supervisor Role(Blue)
      else if (emp.EmployeeId == 80 || emp.EmployeeId == 231) serviceResponse = 3; // Management Role (Green)
      else if (emp.EmployeeId == 73 || emp.EmployeeId == 234 || emp.EmployeeId == 279) serviceResponse = 5; // Logistic (Yellow)
      else if (emp.EmployeeId == 210 || emp.EmployeeId == 233) serviceResponse = 7; // Superuser
      else serviceResponse = 0;
      return serviceResponse;
    }
    public int PrePODashboardAuth(Employee emp)
    {
      int serviceResponse = (int)(emp.PrePoauthorizationLevel.HasValue ? emp.PrePoauthorizationLevel : 0);
      //serviceResponse = 282;
      return serviceResponse;
    }

    //public string PrePOAuthLevel (Employee)
    //{
    //  return
    //}

    public static string ScrubHtml(string value)
    {
      if (value.HasValue())
      { 
        var step1 = Regex.Replace(value, @"<[^>]+>|&nbsp;", "").Trim();
        var step2 = Regex.Replace(step1, @"\s{2,}", " ");
        return step2;
      }
      else
      {
        return value;
      }
    }

		public static string POChannelConverstion(string poChannel)
		{
      
      string returnValue = poChannel.ToUpper();

      if (returnValue == "CG_USA")
      { returnValue = "CGUS"; }
			else if (returnValue == "CG_CANADA")
			{ returnValue = "CGCA"; }
			else if (returnValue == "CG_UK")
			{ returnValue = "CGUK"; }
			else if (returnValue == "FBA_CA")
			{ returnValue = "FBACA"; }

			return returnValue;
		}


		public async Task<bool> MEWS_Approval_Notification(Employee emp, List<PrePo> approvedPrePos)
    {
      List<PrePostatusType> prePostatusTypes = await _kc.PrePostatusTypes.ToListAsync();

      List<EmailAddressDTO> emailAddresses = await _kc.Employees
        .Where(i => i.IsUserOnPrePoNotif == true)
        .Select(n => new EmailAddressDTO
        {
          LoginID = n.LoginId
        }).ToListAsync();
      //List<EmailAddressDTO> emailAddresses = new List<EmailAddressDTO>();
      //emailAddresses.Add(new EmailAddressDTO { LoginID = "brian.yi@mellow-home.com" });
      List<int> rowSpan = new List<int>();
      int lastRow = 0;
      int authLevel = (int)emp.PrePoauthorizationLevel;
      string authLevelTxt = "";
      string tmpStr = "";
      switch (authLevel)
      {
        case 1:
          authLevelTxt = "(Associate)";
          break;
        case 2:
          authLevelTxt = "(Supervisor)";
          break;
        case 3:
          authLevelTxt = "(Management)";
          break;
        case 5:
          authLevelTxt = "(Logistics)";
          break;
        case 7:
          authLevelTxt = "(Superuser)";
          break;

      }
      string emailContents = "";
      string emailTitle = "";
      string poChannelWeek = "";
      string lastPoChannelWeek = "";
      string approver = emp.EmployeeName + " " + authLevelTxt;
      string tmpPreface = "&emsp;";
      string tableContent = "<table width=\"85%\" style=\"border: 1px solid CornflowerBlue;border-radius: 10px; border-collapse: separate;\">\r\n";
      string tableBody = "<tbody  style=\"border: 1px solid CornflowerBlue;border-radius: 10px;\">";
      string tableHeaders = "";
      int tableColspan = 3;
      int lastIdx = 3;
      int tmpCnt = 0;
      string prePoStatusForEamil = "";

      List<TotalApprovedPrePO> totalApprovedPrePOs = new List<TotalApprovedPrePO>();
      TotalApprovedPrePO tmpCategory = new TotalApprovedPrePO();
      foreach (PrePo tmpPrePo in approvedPrePos)
      {
        if(tmpPrePo.MgmtsNote.IsEmpty() != true)
        { if (tableColspan < 4)  tableColspan = 4; }
        if (tmpPrePo.LogisticsAcceptanceNote.IsEmpty() != true)
        { if (tableColspan < 5) tableColspan = 5; }
        if (tmpPrePo.LogisticsPonoNote.IsEmpty() != true)
        { if (tableColspan < 6) tableColspan = 6; }

        lastIdx = tmpPrePo.InternalPono.LastIndexOf("_");
       
        prePoStatusForEamil = prePostatusTypes.Where(t => t.TypeId == tmpPrePo.PrePostatusTypeId).FirstOrDefault().Description;
        if (totalApprovedPrePOs.Any() != true) // First; Nothing in the array
        {
          tmpCategory = new TotalApprovedPrePO(){ 
           currentStatus = prePostatusTypes.Where(t => t.TypeId == tmpPrePo.PrePostatusTypeId).FirstOrDefault().Description,
           currentStatusId = (int)tmpPrePo.PrePostatusTypeId,
           countOfPrePos = 1,
           poChannel = tmpPrePo.Pochannel,
           weekOfPrePO = tmpPrePo.InternalPono.Substring(lastIdx-3, 3),
           requestorsNote = tmpPrePo.RequestorsNote,
           mgmtsNote = tmpPrePo.MgmtsNote,
           logisticsAccptncNote = tmpPrePo.LogisticsAcceptanceNote,
           logisticsCompleteNote = tmpPrePo.LogisticsPonoNote,
           totalQty = (int)tmpPrePo.RequestedQty
          };
          lastRow++;
          totalApprovedPrePOs.Add(tmpCategory);
        } 
        else // There is a something - at least one element - in the array
        {
          tmpCategory = totalApprovedPrePOs.Where(t => t.poChannel == tmpPrePo.Pochannel 
                        && t.requestorsNote == tmpPrePo.RequestorsNote 
                        && t.weekOfPrePO == tmpPrePo.InternalPono.Substring(lastIdx - 3, 3))
                        .FirstOrDefault();
          tmpCnt = totalApprovedPrePOs.Where(t => t.poChannel == tmpPrePo.Pochannel
                        && t.weekOfPrePO == tmpPrePo.InternalPono.Substring(lastIdx - 3, 3))
                        .Count();
          if (tmpCategory == null && tmpCnt > 0)
          { lastRow++; }
          else if (tmpCategory == null && tmpCnt == 0)
          {
            rowSpan.Add(lastRow);
            lastRow = 1;
          }
          if (tmpCategory == null)
          {
            tmpCategory = new TotalApprovedPrePO()
            {
              currentStatus = prePostatusTypes.Where(t => t.TypeId == tmpPrePo.PrePostatusTypeId).FirstOrDefault().Description,
              currentStatusId = (int)tmpPrePo.PrePostatusTypeId,
              countOfPrePos = 1,
              poChannel = tmpPrePo.Pochannel,
              weekOfPrePO = tmpPrePo.InternalPono.Substring(lastIdx - 3, 3),
              requestorsNote = tmpPrePo.RequestorsNote,
              mgmtsNote = tmpPrePo.MgmtsNote,
              logisticsAccptncNote = tmpPrePo.LogisticsAcceptanceNote,
              logisticsCompleteNote = tmpPrePo.LogisticsPonoNote,
              totalQty = (int)tmpPrePo.RequestedQty
            };
            totalApprovedPrePOs.Add(tmpCategory);
          }
          else
          {
            tmpCategory.totalQty += (int)tmpPrePo.RequestedQty;
          }
        }
      } // End of foreach
      rowSpan.Add(lastRow);

      //lastPoChannelWeek; poChannelWeek
      poChannelWeek = totalApprovedPrePOs[0].poChannel + "_"+ totalApprovedPrePOs[0].weekOfPrePO;
      lastPoChannelWeek = poChannelWeek;
      // Headers
      switch (tableColspan)
      { 
        case 4: // Approved by Management
          tableHeaders = "\r\n  <thead>\r\n    <tr>\r\n      <th style=\"width:20%; border-radius: 10px; background-color:skyblue;\">\r\n        Week No.\r\n      </th>\r\n      <th style=\"border-radius: 10px; background-color:skyblue;\">\r\n        Requestor's Note\r\n      </th>\r\n      <th style=\"border-radius: 10px; background-color:skyblue;\">\r\n        Management Note\r\n      </th>\r\n      <th style=\"border-radius: 10px; background-color:skyblue;\">\r\n        Total Qty\r\n      </th>\r\n    </tr>\r\n  </thead>";
          break;
        case 5: // Accepted by Logistics
          tableHeaders = "\r\n  <thead>\r\n    <tr>\r\n      <th style=\"width:20%; border-radius: 10px; background-color:skyblue;\">\r\n        Week No.\r\n      </th>\r\n      <th style=\"border-radius: 10px; background-color:skyblue;\">\r\n        Requestor's Note\r\n      </th>\r\n      <th style=\"border-radius: 10px; background-color:skyblue;\">\r\n        Management Note\r\n      </th>\r\n      <th style=\"border-radius: 10px; background-color:skyblue;\">\r\n        Logistics Acceptance Note\r\n      </th>\r\n      <th style=\"border-radius: 10px; background-color:skyblue;\">\r\n        Total Qty\r\n      </th>\r\n    </tr>\r\n  </thead>\r\n";
          break;
        case 6: // Completed by Logistics
          tableHeaders = "\r\n  <thead>\r\n    <tr>\r\n      <th style=\"width:20%; border-radius: 10px; background-color:skyblue;\">\r\n        Week No.\r\n      </th>\r\n      <th style=\"border-radius: 10px; background-color:skyblue;\">\r\n        Requestor's Note\r\n      </th>\r\n      <th style=\"border-radius: 10px; background-color:skyblue;\">\r\n        Management Note\r\n      </th>\r\n      <th style=\"border-radius: 10px; background-color:skyblue;\">\r\n        Logistics Acceptance Note\r\n      </th>\r\n      <th style=\"border-radius: 10px; background-color:skyblue;\">\r\n        Logistics Complete Note\r\n      </th>\r\n      <th style=\"border-radius: 10px; background-color:skyblue;\">\r\n        Total Qty\r\n      </th>\r\n    </tr>\r\n  </thead>";
          break;
        default: // Approved by Supervisor
          tableHeaders = "\r\n  <thead>\r\n    <tr>\r\n      <th style=\"width:20%; border-radius: 10px; background-color:skyblue;\">\r\n        Week No.\r\n      </th>\r\n      <th style=\"border-radius: 10px; background-color:skyblue;\">\r\n        Requestor's Note\r\n      </th>\r\n      <th style=\"border-radius: 10px; background-color:skyblue;\">\r\n        Total Qty\r\n      </th>\r\n    </tr>\r\n  </thead>";
          break;
      }
      int arraySize = totalApprovedPrePOs.Count;
      lastRow = rowSpan[0];
      int idx = 0;
      bool isRowSpan = true;
      for (int i = 0 ; i < arraySize; i++)
      {
        tableBody += "<tr>";
        tmpStr = totalApprovedPrePOs[i].poChannel + "_" + totalApprovedPrePOs[i].weekOfPrePO;
        if (lastPoChannelWeek != tmpStr)
        { poChannelWeek += (" & " + tmpStr); lastPoChannelWeek = tmpStr; idx++; lastRow += rowSpan[idx]; isRowSpan = false;}
        if (i == 0 || isRowSpan == false)
        {
          tableBody += ("<td "+ (rowSpan[idx] <= 1 ? "":" rowspan =\"" + (rowSpan[idx])+ "\"") + "style=\"border: 1px solid CornflowerBlue;text-align: center;border-radius: 10px; background-color:azure;\">");
          tableBody += tmpStr;
          tableBody += "</td>";
          isRowSpan = true;
        }
        if(tableColspan >= 3)
        {
          tableBody += "<td style=\"border: 1px solid CornflowerBlue;text-align: center;border-radius: 10px; background-color:azure;\">";
          tableBody += totalApprovedPrePOs[i].requestorsNote;
          tableBody += "</td>";
        }
        if (tableColspan >= 4)
        {
          tableBody += "<td style=\"border: 1px solid CornflowerBlue;text-align: center;border-radius: 10px; background-color:azure;\">";
          tableBody += totalApprovedPrePOs[i].mgmtsNote;
          tableBody += "</td>";
        }
        if (tableColspan >= 5)
        {
          tableBody += "<td style=\"border: 1px solid CornflowerBlue;text-align: center;border-radius: 10px; background-color:azure;\">";
          tableBody += totalApprovedPrePOs[i].logisticsAccptncNote;
          tableBody += "</td>";
        }
        if (tableColspan >= 6)
        {
          tableBody += "<td style=\"border: 1px solid CornflowerBlue;text-align: center;border-radius: 10px; background-color:azure;\">";
          tableBody += totalApprovedPrePOs[i].logisticsCompleteNote;
          tableBody += "</td>";
        }
        tableBody += "<td style=\"border: 1px solid CornflowerBlue;text-align: center;border-radius: 10px; background-color:azure;\">";
        tableBody += totalApprovedPrePOs[i].totalQty;
        tableBody += "</td>";
        tableBody += "</tr>";
      }
      tableBody += "</tbody>";
      tableContent += (tableHeaders + tableBody);
      tableContent += "\r\n</table>";
      emailTitle = poChannelWeek + " POs have been approved!" + " ("+totalApprovedPrePOs[0].currentStatus + ")";
      // Preface
      tmpPreface += (poChannelWeek + " POs have been approved by " + approver + ".<br/><br/>");

      emailContents = tmpPreface + tableContent;

      bool isOkay = await _utilService.SendEmail(emailAddresses, emailTitle, emailContents);

      return isOkay;
    }

  }
}
