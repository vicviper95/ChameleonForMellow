using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chameleon.DTOs.Purchase;
using Chameleon.Models;

namespace Chameleon.Services.PurchaseService
{
  public interface IPurchaseService
  {
    Task<List<PrePOItemDTO>> GetAllPrePOsForDashboard(DateTime startDate, DateTime endDate);
    Task<PrePOItemDTO> GetPrePODetail (long id);
    Task<bool> UpdatePrePO(Employee emp, PrePOItemDTO prePOItemDTO);
    Task<bool> CreatePrePO(Employee emp, PrePOItemDTO prePOItemDTO);
    Task<List<LogisticsVendorDTO>> GetVendorList();
    Task<List<PrePOSKUDTO>> GetPrePOBPMItemList();
    Task<List<string>> GetPrePOSKUList();
    Task<bool> GetAcceptApprovePrePOs (Employee emp, List<string> prePOList);
    Task<bool> GetClosedDeclinedPrePOs (Employee emp, List<string> prePOList);
    Task<PrePOLogisticsImportResponseDTO> ImportPrePOs (Employee emp, List<PrePOImportDTO> prePOList);
    Task<PrePOLogisticsImportResponseDTO> ImportPrePOLogistics(Employee emp, List<PrePOLogisticsImportDTO> prePOLogisticsList);
    Task<bool> GetDeletedPrePOs(Employee emp, List<string> prePOList);
    Task<List<PrePOItemDTO>> GetPrePOHistory (long id);
    Task<PrePOItemDTO> GetPrePOHistoryDetail (long id);
    Task<List<SKUDTO>> GetSKUList();
    Task<PrePOLogisticsImportResponseDTO> ImportSKUStatus(Employee emp, List<SKUStatusImportDTO> skuStatusImportList);
    int PrePODashboardAuth(Employee emp);
    Task<bool> MEWS_Approval_Notification(Employee emp, List<PrePo> approvedPrePos);
  }
}
