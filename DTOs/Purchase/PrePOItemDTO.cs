using System;

namespace Chameleon.DTOs.Purchase
{
  public class PrePOItemDTO
  {
    public long prePOId { get; set; }
    public string internalPoNo { get; set; }
    public int requestorId { get; set; }
    public string requestor { get; set; }
    public int createdById { get; set; }
    public string createdBy { get; set; }
    public string createdDate { get; set; }
    public string poChannel { get; set; }
    public int poChannelId { get; set; }
    public string sku { get; set; }
    public string skuStatus { get; set; }
    public int itemNoId { get; set; }
    public int requestedQty { get; set; }
    public string requestorsNote { get; set; }
    public string mustETADate { get; set; }
    public bool hasInitialApproved { get; set; }
    public string initialApprovedBy { get; set; }
    public int initialApprovedById { get; set; }
    public string initialApprovedDate { get; set; }
    public int mgmtAdjQty { get; set;}
    public string mgmtsNote { get; set;}
    public int prePOStatus { get; set; }
    public bool mgmtPrePOAccept { get; set; }
    public string mgmtDateExecuted { get; set; }
    public string mgmtApprovedBy { get; set; }
    public int mgmtApprovedById { get; set; }
    public bool acceptedByLogistics { get; set; }
    public string acceptedByLogisticsDate { get; set; }
    public int logisticsConfirmedQty { get; set; }
    public string logisticsChosenVendor { get; set; }
    public int logisticsChosenVendorId { get; set; }
    public string logisticsAcceptanceNote { get; set; }
    public string logisticsEtd_c { get; set; }
    public bool logisticsRegCompletion { get; set; }
    public string logisticsPONoNote { get; set; }
    public string logisticsCompletedDate { get; set; }
    public string logisticsCompletedBy { get; set; }
    public string logisticsAcceptedBy { get; set;}
    public int logisticsAcceptedById { get; set;}
    public string logisticsMustETADate { get; set; }
    public bool isEdited { get; set; }
    public bool isCurSelected { get; set; }
    public long prePOHistoryId { get; set; }
    public int revNo { get; set; }
    public string modifiedDate { get; set; }
    public string modifiedBy { get; set; }
    public string approvalLevel { get; set; }
  }
}
