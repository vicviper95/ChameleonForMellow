var bpmItemList;
var authLevel;
var lastSelectedRow;
var lastSelectedRowHistory;
var lastSelectedClass;
var startDate;
var endDate;
endDate = new Date();
endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
startDate = new Date(new Date().setDate((new Date()).getDate() - 180));
startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
document.getElementById('fromDateHidden').value = startDate;
document.getElementById('toDateHidden').value = endDate;
//var prePOIdForHistory;

$(document).ready(function () {
  lastSelectedRow = '';
  lastSelectedClass = '';
  lastSelectedRowHistory = '';


  fromDatePicker();
  toDatePicker();
  $('#fromDatePicker').val(startDate);
  $('#toDatePicker').val(endDate);

  //prePOIdForHistory = 0;
  //document.getElementById('prePOId').value = 0;
  prePoDataTable;
  prePoHistoryDataTable;
  setMustEtaYears();

  initialStageEnable();
  mgmtStageDisable();
  logisticsStageDisable();

  etd_c_DatePicker();


  getAuthLevel(); //= localStorage.getItem("authLevel");


  //console.log(authLevel);

  document.getElementById('prePOStatus').value = 0;
  $('#internalPoNo').val('');
  $('#poChannel').prop('selectedIndex', 0);
  //$('approvalLevel').prop('selectedIndex', 0);
  $('#skuInput').val('');
  $('#requestedQty').val('');
  $('#mgmtAdjQty').val('');
  $('#logisticsConfirmedQty').val('');
  $('#HasInitialApproved').val('');
  $('#mgmtPrePOAccept').val('');
  $('#acceptedByLogistics').val('');
  $('#etaMustDateDropdownMonth').prop('selectedIndex', 0);
  $('#etaMustDateDropdownYear').prop('selectedIndex', 0);
  $('#logisticsEtaMustDateDropdownMonth').prop('selectedIndex', 0);
  $('#logisticsEtaMustDateDropdownYear').prop('selectedIndex', 0);
  $('#createdDate').val('');
  $('#mgmtDateExecuted').val('');
  $('#acceptedByLogisticsDate').val('');
  $('#requestorsNote').val('');
  $('#mgmtsNote').val('');
  $('#logisticsAcceptanceNote').val('');
  $('#logisticsRegCompletion').val('');
  $('#logisticsCompletedDate').val('');
  $('#logisticsPONoNote').val('');


  // For Vendor
  $.ajax({
    type: "GET",
    url: "/Purchase/GetPrePOVendorList",
    data: "{}",
    success: function (data) {
      var s = '<option value="-1">Please Select a Vendor</option>';
      for (var i = 0; i < data.length; i++) {
        s += '<option value="' + data[i].vendorId + '">' + data[i].vendorName + '</option>';
      }
      $("#vendorChosenDropdown").html(s);
    }
  });


  // For autocomplete
  getSkuList();
  var skuInput = document.getElementById("skuInput");
  bpmItemAutocomplete(skuInput);


  // For Search(Filter)
  $('#poAccptDashboardItems thead tr')
    .clone(true)
    .addClass('filters')
    .appendTo('#poAccptDashboardItems thead');

  // For Checkbox Filters
  $('#initialStageFilterCB, #mgmtStageFilterCB, #logisticsStageFilterCB, #completedStageFilterCB, #closedStageFilterCB').click( function () {
    prePoDataTable.draw();
  });

  
  $('#checkAll').click(function (e) {
    $('#poAccptDashboardItems tbody :checkbox').prop('checked', $(this).is(':checked'));

    var data = prePoDataTable.rows(function (idx, data, node) {
      var cells = $(node).find('input[type="checkbox"]');
      return checkedTargets(cells).length;
    }).data().toArray();

    for (var i = 0; i < data.length; i++) {
      data[i].isEdited = true;
      //console.log(data[i]);
    }
    e.stopImmediatePropagation();
  });
  function checkedTargets(checkboxes) {
    return checkboxes.filter(function (index) {
      return $(checkboxes[index]).prop('checked');
    });
  } 
  
 /*
  $('#checkAll').click(function () {
    if (prePoDataTable.rows({
      selected: true
    }).count() > 0) {
      prePoDataTable.rows().deselect();
      return;
    }

    prePoDataTable.rows().select();
  });
  */
 /*
  prePoDataTable.on('select deselect', function (e, dt, type, indexes) {
    if (type === 'row') {
      // We may use dt instead of myTable to have the freshest data.
      console.log("Here!@#!");
      if (dt.rows().count() === dt.rows({
        selected: true
      }).count()) {
        // Deselect all items button.
        $('#checkAll i').attr('class', 'far fa-check-square');
        return;
      }

      if (dt.rows({
        selected: true
      }).count() === 0) {
        // Select all items button.
        $('#checkAll i').attr('class', 'far fa-square');
        return;
      }

      // Deselect some items button.
      $('#checkAll i').attr('class', 'far fa-minus-square');
    }
  });
  */


  //dblclick
  //click

  $('#poAccptDashboardItems tbody').on('click', 'tr', function () {
    //var testDT = prePoDataTable;
    var dv = prePoDataTable.row(this).data();
    var prePoStatus = parseInt(dv.prePOStatus);
    //console.log(dv);
    //console.log(this);
    if (dv.isEdited == false) {
      if (prePoStatus >= 0) {
        if (prePoStatus < 2) {
          $(prePoDataTable.row(this).selector.rows).removeClass('table-purchase-forecasting');
          if (lastSelectedRow != '') {
            $(prePoDataTable.row(lastSelectedRow).selector.rows).removeClass('table-purchase-selected');
            $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass(lastSelectedClass);
          }
          if (authLevel == 1 || authLevel == 2 || authLevel == 3 || authLevel == 7) {
            dv.isEdited = true;
            lastSelectedClass = 'table-purchase-forecasting-approve';
          } else {
            //$(prePoDataTable.row(this).selectror.rows).addClass('table-purchase-forecasting');
            lastSelectedClass = 'table-purchase-forecasting';
          }
          $(prePoDataTable.row(this).selector.rows).addClass('table-purchase-selected');
          lastSelectedRow = this;

        } else if (prePoStatus >= 2 && prePoStatus < 4) {
          $(prePoDataTable.row(this).selector.rows).removeClass('table-purchase-management');
          if (lastSelectedRow != '') {
            $(prePoDataTable.row(lastSelectedRow).selector.rows).removeClass('table-purchase-selected');
            $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass(lastSelectedClass);
          }
          if (authLevel == 3 || authLevel == 7) {
            dv.isEdited = true;
            lastSelectedClass = 'table-purchase-management-approve';
          } else {
            lastSelectedClass = 'table-purchase-management';
          }
          $(prePoDataTable.row(this).selector.rows).addClass('table-purchase-selected');
          lastSelectedRow = this;

        } else if (prePoStatus >= 4 && prePoStatus < 5) {
          $(prePoDataTable.row(this).selector.rows).removeClass('table-purchase-logistics');
          if (lastSelectedRow != '') {
            $(prePoDataTable.row(lastSelectedRow).selector.rows).removeClass('table-purchase-selected');
            $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass(lastSelectedClass);
          }
          if (authLevel == 5 || authLevel == 7) {
            dv.isEdited = true;
            lastSelectedClass = 'table-purchase-logistics-accept';
          } else {
            lastSelectedClass = 'table-purchase-logistics';
          }
          $(prePoDataTable.row(this).selector.rows).addClass('table-purchase-selected');
          lastSelectedRow = this;

        } else if (prePoStatus < 6) {
          // HERE!!!!!
          $(prePoDataTable.row(this).selector.rows).removeClass('table-purchase-logistics-accept');
          if (lastSelectedRow != '') {
            $(prePoDataTable.row(lastSelectedRow).selector.rows).removeClass('table-purchase-selected');
            $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass(lastSelectedClass);
          }


          //if (dv.logisticsEtd_c != "-" && dv.logisticsChosenVendor != null) {
          if (authLevel == 5 || authLevel == 7) {
            dv.isEdited = true;
            lastSelectedClass = 'table-purchase-logistics-accept';
            //lastSelectedRow = this;
            //$(prePoDataTable.row(this).selector.rows).addClass('table-purchase-selected');
          }
          //} else {
          // alert("You need to choose ETA-C/Vendor!");
          // lastSelectedClass = 'table-purchase-logistics-accept';
          //}
          $(prePoDataTable.row(this).selector.rows).addClass('table-purchase-selected');
          lastSelectedRow = this;

        } else if (prePoStatus >= 6) {
          // HERE!!!!!
          $(prePoDataTable.row(this).selector.rows).removeClass('table-purchase-logistics-completed');
          if (lastSelectedRow != '') {
            $(prePoDataTable.row(lastSelectedRow).selector.rows).removeClass('table-purchase-selected');
            $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass(lastSelectedClass);
          }
          lastSelectedClass = 'table-purchase-logistics-completed';
          $(prePoDataTable.row(this).selector.rows).addClass('table-purchase-selected');
          lastSelectedRow = this;

        }
      } else {
        $(prePoDataTable.row(this).selector.rows).removeClass('table-closed-declined');
        if (lastSelectedRow != '') {
          $(prePoDataTable.row(lastSelectedRow).selector.rows).removeClass('table-purchase-selected');
          $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass(lastSelectedClass);
        }
        lastSelectedClass = 'table-closed-declined';
        $(prePoDataTable.row(this).selector.rows).addClass('table-purchase-selected');
        lastSelectedRow = this;
      }
      clearAllFields();
      $.ajax({
        url: '../Purchase/GetPrePODetail',
        type: "GET",
        contentType: "application/json charset=utf-8",
        dataType: 'json',
        data: { prePOId: dv.prePOId },
        success: function (data) {
          document.getElementById('prePOId').value = data.prePOId;
          document.getElementById('internalPoNo').innerHTML = data.internalPoNo;
          document.getElementById('prePOStatus').value = data.prePOStatus;
          document.getElementById('skuInput').value = data.sku;
          document.getElementById('requestorsNote').value = data.requestorsNote;

          document.getElementById('requestedQty').value = data.requestedQty;
          document.getElementById('mgmtAdjQty').value = data.mgmtAdjQty;
          document.getElementById('logisticsConfirmedQty').value = data.logisticsConfirmedQty;



          document.getElementById('hasInitialApproved').innerHTML = (data.hasInitialApproved === true ? 'Approved' :
            parseInt(data.prePOStatus) >= 0 ? 'Not Yet' : 'Declined');
          document.getElementById('mgmtPrePOAccept').innerHTML = (data.mgmtPrePOAccept === true ? 'Approved' :
            parseInt(data.prePOStatus) >= 0 ? 'Not Yet' : 'Declined');
          document.getElementById('acceptedByLogistics').innerHTML = (data.acceptedByLogistics === true ? 'Accepted' :
            parseInt(data.prePOStatus) >= 0 ? 'Not Yet' : 'Declined'); //acceptedByLogistics;acceptedByLogistics

          document.getElementById('mgmtApprovedBy').innerHTML = data.mgmtApprovedBy;

          document.getElementById('initialApprovedBy').innerHTML = data.initialApprovedBy;//logisticsAcceptedBy
          document.getElementById('logisticsAcceptedBy').innerHTML = data.logisticsAcceptedBy;
          document.getElementById('logisticsCompletedBy').innerHTML = data.logisticsCompletedBy;

          document.getElementById('createdDate').innerHTML = data.createdDate;
          document.getElementById('mgmtDateExecuted').innerHTML = data.mgmtDateExecuted;
          document.getElementById('acceptedByLogisticsDate').innerHTML = data.acceptedByLogisticsDate;

          document.getElementById('requestorsNote').value = data.requestorsNote;
          document.getElementById('mgmtsNote').value = data.mgmtsNote;
          document.getElementById('logisticsAcceptanceNote').value = data.logisticsAcceptanceNote;

          document.getElementById('logisticsRegCompletion').innerHTML = (data.logisticsRegCompletion === true ? 'Completed' :
            parseInt(data.prePOStatus) >= 0 ? 'Not Yet' : 'Declined');
          document.getElementById('logisticsCompletedDate').innerHTML = data.logisticsCompletedDate;
          document.getElementById('logisticsPONoNote').value = data.logisticsPONoNote;

          prePoHistoryDataTable.ajax.reload();


          if (data.logisticsEtd_c != "-") {
            $('#etdcDatePicker').val(data.logisticsEtd_c);
          } else {
            $('#etdcDatePicker').val('');
          }


          var mySelect01 = document.getElementById('poChannel');
          for (var i, j = 0; i = mySelect01.options[j]; j++) {
            if (i.value.toUpperCase() === data.poChannel.toUpperCase()) {
              mySelect01.selectedIndex = j;
              break;
            }
          }

          var mySelect02 = document.getElementById('vendorChosenDropdown');
          for (var i, j = 0; i = mySelect02.options[j]; j++) {
            if (parseInt(i.value) == parseInt(data.logisticsChosenVendorId)) {
              mySelect02.selectedIndex = j;
              break;
            }
          }

          //var mySelect03 = document.getElementById('approvalLevel');
          //for (var i, j = 0; i = mySelect03.options[j]; j++) {
          //  if (i.value.toUpperCase() === data.approvalLevel.toUpperCase()) {
          //    mySelect03.selectedIndex = j;
          //    break;
          //  }
          //}

          if (data.mustETADate != "-") {
            var etaMonth = (data.mustETADate.toString()).substring(0, 2);
            var etaYear = (data.mustETADate.toString()).substring(3);

            var myMonth = document.getElementById('etaMustDateDropdownMonth');
            for (var i, j = 0; i = myMonth.options[j]; j++) {
              if (parseInt(i.value) == parseInt(etaMonth)) {
                myMonth.selectedIndex = j;
                break;
              }
            }

            var myYear = document.getElementById('etaMustDateDropdownYear');
            var found = false;
            for (var i, j = 0; i = myYear.options[j]; j++) {
              if (parseInt(i.value) == parseInt(etaYear)) {
                myYear.selectedIndex = j;
                found = true;
                break;
              }
            }
            //if (found == false) {
            //  if (data.mustETADate != null) { document.getElementById('etaDate').innerHTML = data.mustETADate; }
            //}
          }


          if (data.logisticsMustETADate != "-") {
            var etaMonth = (data.logisticsMustETADate.toString()).substring(0, 2);
            var etaYear = (data.logisticsMustETADate.toString()).substring(3);

            var myMonth = document.getElementById('logisticsEtaMustDateDropdownMonth');
            for (var i, j = 0; i = myMonth.options[j]; j++) {
              if (parseInt(i.value) == parseInt(etaMonth)) {
                myMonth.selectedIndex = j;
                break;
              }
            }

            var myYear = document.getElementById('logisticsEtaMustDateDropdownYear');
            var found = false;
            for (var i, j = 0; i = myYear.options[j]; j++) {
              if (parseInt(i.value) == parseInt(etaYear)) {
                myYear.selectedIndex = j;
                found = true;
                break;
              }
            }
            //if (found == false) { document.getElementById('etaDate').innerHTML = data.mustETADate; }
          }


          // History Section
          document.getElementById('internalPoNoHistory').innerHTML = data.internalPoNo;
          document.getElementById('prePOStatusHistory').innerHTML = 0;
          document.getElementById('poChannelHistory').innerHTML = data.poChannel.toUpperCase();
          //document.getElementById('approvalLevelHistory').innerHTML = data.approvalLevel.toUpperCase();
          var logisticsChosenVendorForText = document.getElementById("vendorChosenDropdown");
          document.getElementById('logisticsChosenVendorHistory').innerHTML = logisticsChosenVendorForText.options[logisticsChosenVendorForText.selectedIndex].text;
          document.getElementById('skuHistory').innerHTML = data.sku;
          document.getElementById('logisticsEtd_cHistory').innerHTML = data.logisticsEtd_c;
          document.getElementById('requestedQtyHistory').innerHTML = data.requestedQty;
          document.getElementById('mgmtAdjQtyHistory').innerHTML = data.mgmtAdjQty;
          document.getElementById('logisticsConfirmedQtyHistory').innerHTML = data.logisticsConfirmedQty;
          document.getElementById('hasInitialApprovedHistory').innerHTML = (data.hasInitialApproved === true ? 'Approved' :
            parseInt(data.prePOStatus) >= 0 ? 'Not Yet' : 'Declined');
          document.getElementById('mgmtPrePOAcceptHistory').innerHTML = (data.mgmtPrePOAccept === true ? 'Approved' :
            parseInt(data.prePOStatus) >= 0 ? 'Not Yet' : 'Declined');
          document.getElementById('acceptedByLogisticsHistory').innerHTML = (data.acceptedByLogistics === true ? 'Accepted' :
            parseInt(data.prePOStatus) >= 0 ? 'Not Yet' : 'Declined');
          document.getElementById('initialApprovedByHistory').innerHTML = data.initialApprovedBy;
          document.getElementById('mgmtApprovedByHistory').innerHTML = data.mgmtApprovedBy;
          document.getElementById('logisticsAcceptedByHistory').innerHTML = data.logisticsAcceptedBy;
          document.getElementById('mustETADateHistory').innerHTML = data.mustETADate;
          document.getElementById('createdDateHistory').innerHTML = data.createdDate;
          document.getElementById('mgmtDateExecutedHistory').innerHTML = data.mgmtDateExecuted;
          document.getElementById('acceptedByLogisticsDateHistory').innerHTML = data.acceptedByLogisticsDate;
          document.getElementById('requestorsNoteHistory').innerHTML = data.requestorsNote;
          document.getElementById('mgmtsNoteHistory').innerHTML = data.mgmtsNote;
          document.getElementById('logisticsAcceptanceNoteHistory').innerHTML = data.logisticsAcceptanceNote;
          document.getElementById('logisticsRegCompletionHistory').innerHTML = (data.logisticsRegCompletion === true ? 'Completed' :
            parseInt(data.prePOStatus) >= 0 ? 'Not Yet' : 'Declined');
          document.getElementById('logisticsCompletedDateHistory').innerHTML = data.logisticsCompletedDate;
          document.getElementById('logisticsMustEtaDateHistory').innerHTML = data.logisticsMustETADate;
          document.getElementById('logisticsCompletedByHistory').innerHTML = data.logisticsCompletedBy;
          document.getElementById('logisticsPONoNoteHistory').innerHTML = data.logisticsPONoNote;


          if (parseInt(data.prePOStatus) < 0) {
            initialStageDisable();
            mgmtStageDisable();
            logisticsStageDisable();
          } else if (parseInt(data.prePOStatus) < 2) {
            initialStageEnable();
            mgmtStageDisable();
            logisticsStageDisable();
          } else if (parseInt(data.prePOStatus) < 4) {
            initialStageDisable();
            mgmtStageEnable();
            logisticsStageDisable();
          } else if (parseInt(data.prePOStatus) < 6) {
            initialStageDisable();
            mgmtStageDisable();
            logisticsStageEnable();
          } else if (parseInt(data.prePOStatus) == 6) {
            initialStageDisable();
            mgmtStageDisable();
            logisticsStageDisable();
          }


          if (authLevel == 1) { authLevelOne(); mgmtStageDisable(); logisticsStageDisable(); }
          else if (authLevel == 2) { authLevelOne(); mgmtStageDisable(); logisticsStageDisable(); authApproveAcceptButton(); }
          else if (authLevel == 3) { authLevelThree(); logisticsStageDisable(); authApproveAcceptButton();}
          else if (authLevel == 5) { authLevelFive(); initialStageDisable(); mgmtStageDisable(); authApproveAcceptButton();}
          else if (authLevel == 0) { authLevelZero(); initialStageDisable(); mgmtStageDisable(); logisticsStageDisable(); }

        }
      });

    } else {
      dv.isEdited = false;
      if (lastSelectedRow === this) {
        $(prePoDataTable.row(this).selector.rows).removeClass('table-purchase-selected');
        $(prePoDataTable.row(this).selector.rows).addClass(lastSelectedClass);
        lastSelectedRow = '';
        lastSelectedClass = '';
      }
      if (prePoStatus < 2) {
        dv.prePOStatus = 1;
        dv.hasInitialApproved = false;
        $(prePoDataTable.row(this).selector.rows).removeClass('table-purchase-forecasting-approve');
        $(prePoDataTable.row(this).selector.rows).addClass('table-purchase-forecasting');
        //console.log(prePoDataTable.row(this));
      } else if (prePoStatus < 4) {
        dv.prePOStatus = 2;
        //dv.mgmtPrePOAccept = false;
        $(prePoDataTable.row(this).selector.rows).removeClass('table-purchase-management-approve');
        $(prePoDataTable.row(this).selector.rows).addClass('table-purchase-management');
      } else if (prePoStatus < 5) {
        dv.prePOStatus = 4;
        //dv.acceptedByLogistics = false;
        $(prePoDataTable.row(this).selector.rows).removeClass('table-purchase-logistics-accept');
        $(prePoDataTable.row(this).selector.rows).addClass('table-purchase-logistics');
      } else if (prePoStatus > 5) {
        //dv.prePOStatus = 4;
        //dv.acceptedByLogistics = false;
        //$(prePoDataTable.row(this).selector.rows).removeClass('table-purchase-logistics-accept');
        $(prePoDataTable.row(this).selector.rows).addClass('table-purchase-logistics-complete');
      }
    }

    //$.ajax({
    //  url: '../Purchase/GetPrePOHistory',
    //  type: "GET",
    //  contentType: "application/json charset=utf-8",
    //  dataType: 'json',
    //  data: { prePOId: dv.prePOId },
    //  success: function (data) {
       

    //    prePoHistoryDataTable.ajax.reload();

    //  }
    //});
   // prePOIdForHistory.removeChild(0);
   // prePOIdForHistory.push(dv.prePOId);
    //prePoHistoryDataTable;
    //console.log(document.getElementById('prePOId').value);
    //prePoHistoryDataTable.ajax.reload();

    prePoDataTable.row(this).data(dv).draw(false);
  });

  // For History Table Action

  $('#poAccptDashboardHistoryItems tbody').on('click', 'tr', function () {
    var dv = prePoHistoryDataTable.row(this).data();
    var prePoStatus = parseInt(dv.prePOStatus);
    //console.log(this);
    if (dv.isEdited == false) {
      isEdited = true;
      this.isEdited = false;
      lastSelectedRowHistory = this;
      clearAllHistoryFields();
      $.ajax({
        url: '../Purchase/GetPrePOHistoryDetail',
        type: "GET",
        contentType: "application/json charset=utf-8",
        dataType: 'json',
        data: { prePOHistoryId: dv.prePOHistoryId },
        success: function (data) {

          document.getElementById('revNoNoHistory').innerHTML = data.revNo;
          document.getElementById('prePOStatusHistory').innerHTML = data.prePOStatus;
          document.getElementById('poChannelHistory').innerHTML = data.poChannel.toUpperCase();
          //document.getElementById('approvalLevelHistory').innerHTML = data.approvalLevel.toUpperCase();
          var logisticsChosenVendorForText = document.getElementById("vendorChosenDropdown");
          document.getElementById('logisticsChosenVendorHistory').innerHTML = logisticsChosenVendorForText.options[logisticsChosenVendorForText.selectedIndex].text;
          document.getElementById('skuHistory').innerHTML = data.sku;
          document.getElementById('logisticsEtd_cHistory').innerHTML = data.logisticsEtd_c;
          document.getElementById('requestedQtyHistory').innerHTML = data.requestedQty;
          document.getElementById('mgmtAdjQtyHistory').innerHTML = data.mgmtAdjQty;
          document.getElementById('logisticsConfirmedQtyHistory').innerHTML = data.logisticsConfirmedQty;
          //document.getElementById('hasInitialApprovedHistory').innerHTML = (data.hasInitialApproved === true ? 'Approved' :
           // parseInt(data.prePOStatus) >= 0 ? 'Not Yet' : 'Declined');
          //document.getElementById('mgmtPrePOAcceptHistory').innerHTML = (data.mgmtPrePOAccept === true ? 'Approved' :
           // parseInt(data.prePOStatus) >= 0 ? 'Not Yet' : 'Declined');
          //document.getElementById('acceptedByLogisticsHistory').innerHTML = (data.acceptedByLogistics === true ? 'Accepted' :
           // parseInt(data.prePOStatus) >= 0 ? 'Not Yet' : 'Declined');
          //document.getElementById('initialApprovedByHistory').innerHTML = data.initialApprovedBy;
          //document.getElementById('mgmtApprovedByHistory').innerHTML = data.mgmtApprovedBy;
          //document.getElementById('logisticsAcceptedByHistory').innerHTML = data.logisticsAcceptedBy;
          document.getElementById('mustETADateHistory').innerHTML = data.mustETADate;
          //document.getElementById('createdDateHistory').innerHTML = data.createdDate;
          //document.getElementById('mgmtDateExecutedHistory').innerHTML = data.mgmtDateExecuted;
          //document.getElementById('acceptedByLogisticsDateHistory').innerHTML = data.acceptedByLogisticsDate;
          document.getElementById('requestorsNoteHistory').innerHTML = data.requestorsNote;
          document.getElementById('mgmtsNoteHistory').innerHTML = data.mgmtsNote;
          document.getElementById('logisticsAcceptanceNoteHistory').innerHTML = data.logisticsAcceptanceNote;
          //document.getElementById('logisticsRegCompletionHistory').innerHTML = (data.logisticsRegCompletion === true ? 'Completed' :
           // parseInt(data.prePOStatus) >= 0 ? 'Not Yet' : 'Declined');
          //document.getElementById('logisticsCompletedDateHistory').innerHTML = data.logisticsCompletedDate;
          //document.getElementById('logisticsCompletedByHistory').innerHTML = data.logisticsCompletedBy;
          document.getElementById('logisticsPONoNoteHistory').innerHTML = data.logisticsPONoNote;

        }
      });

    } else {
      dv.isEdited = false;
      lastSelectedRowHistory = false;

      document.getElementById('revNoNoHistory').innerHTML = '';
      document.getElementById('prePOStatusHistory').innerHTML = '';
      document.getElementById('poChannelHistory').innerHTML = '';
      //document.getElementById('approvalLevelHistory').innerHTML = '';
      //var logisticsChosenVendorForText = document.getElementById("vendorChosenDropdown");
      document.getElementById('logisticsChosenVendorHistory').innerHTML = '';
      document.getElementById('skuHistory').innerHTML = '';
      document.getElementById('logisticsEtd_cHistory').innerHTML = '';
      document.getElementById('requestedQtyHistory').innerHTML = '';
      document.getElementById('mgmtAdjQtyHistory').innerHTML = '';
      document.getElementById('logisticsConfirmedQtyHistory').innerHTML = '';
      document.getElementById('mustETADateHistory').innerHTML = '';
      document.getElementById('requestorsNoteHistory').innerHTML = '';
      document.getElementById('mgmtsNoteHistory').innerHTML = '';
      document.getElementById('logisticsAcceptanceNoteHistory').innerHTML = '';
      document.getElementById('logisticsPONoNoteHistory').innerHTML = '';

    }
    prePoHistoryDataTable.row(this).data(dv).draw(false);
  });



});

// Waiting Indicator
$body = $("body");

$(document).on({
  ajaxStart: function () { $body.addClass("loading"); },
  ajaxStop: function () { $body.removeClass("loading"); }
});



// Initialize UI
function initializeUI() {
  clearAllFields();
  //etd_c_DatePicker();
  if (authLevel == 1) { authLevelOne(); mgmtStageDisable(); logisticsStageDisable(); }
  else if (authLevel == 2) { authLevelOne(); mgmtStageDisable(); logisticsStageDisable(); authApproveAcceptButton(); }
  else if (authLevel == 3) { authLevelThree(); logisticsStageDisable(); mgmtStageDisable(); authApproveAcceptButton(); }
  else if (authLevel == 5) { authLevelFive(); initialStageDisable(); authApproveAcceptButton(); }
  else if (authLevel == 0) { authLevelZero(); initialStageDisable(); mgmtStageDisable(); logisticsStageDisable(); }
  else if (authLevel == 7) { initialStageEnable(); mgmtStageDisable(); logisticsStageDisable(); authApproveAcceptButton(); }
}


// Get BPM Item(SKU) List
async function getSkuList() {
  let result = await $.ajax({
    type: "GET",
    url: "/Purchase/GetPrePOSKUList",
    data: "{}",
    success: function (data) {
    }
  });
  bpmItemList = JSON.parse(JSON.stringify(result));
  return bpmItemList;
}

// Get/Set MUST ETA years
function setMustEtaYears() {
  var s = '<option value="-1">Please Select a Year</option>';
  var curYear = new Date().getFullYear();
  for (var i = 0; i < 3; i++) {
    s += '<option value="' + curYear + '">' + curYear + '</option>';
    curYear++;
  }
  $("#etaMustDateDropdownYear").html(s);
  $("#logisticsEtaMustDateDropdownYear").html(s);
}




// Date Picker
var today = new Date();

function etd_c_DatePicker() {
  $("#etdcDatePicker").datepicker(
    {
      //defaultDate: today
    }
  );
}

// Date Picker
function fromDatePicker() {
  $("#fromDatePicker").datepicker(
    {
      //defaultDate: startDate
    }
  );
}
function toDatePicker() {
  $("#toDatePicker").datepicker(
    {
      //defaultDate: endDate
    }
  );
}


$("#updateTimePeriodBtn").click(function () {
  //if ($('#etdcDatePicker').datepicker("getDate") != null) {
 // tmpDate = $('#etdcDatePicker').datepicker("getDate");
 // returnResult.logisticsEtd_c = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();
  endDate = $('#toDatePicker').datepicker("getDate");
  endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
  startDate = $('#fromDatePicker').datepicker("getDate");
  startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
  document.getElementById('fromDateHidden').value = startDate;
  document.getElementById('toDateHidden').value = endDate;

  prePoDataTable.ajax.reload();
  //}
});



function bpmItemAutocomplete(inp) {
  var currentFocus;
  inp.addEventListener("input", function (e) {
    var a, b, i, val = this.value;
    closeAllLists();
    if (!val) { return false; }
    currentFocus = -1;
    a = document.createElement("DIV");
    a.setAttribute("id", this.id + "autocomplete-list");
    a.setAttribute("class", "autocomplete-items");
    this.parentNode.appendChild(a);
    for (i = 0; i < bpmItemList.length; i++) {
      if (bpmItemList[i].substr(0, val.length).toUpperCase() == val.toUpperCase()) {
        b = document.createElement("DIV");
        b.innerHTML = "<strong>" + bpmItemList[i].substr(0, val.length) + "</strong>";
        b.innerHTML += bpmItemList[i].substr(val.length);
        b.innerHTML += "<input type='hidden' value='" + bpmItemList[i] + "'>";
        b.addEventListener("click", function (e) {
          inp.value = this.getElementsByTagName("input")[0].value;
          closeAllLists();
        });
        a.appendChild(b);
      }
    }
  });

  inp.addEventListener("keydown", function (e) {
    var x = document.getElementById(this.id + "autocomplete-list");
    if (x) x = x.getElementsByTagName("div");
    if (e.keyCode == 40) {
      currentFocus++;
      addActive(x);
    } else if (e.keyCode == 38) {
      currentFocus--;
      addActive(x);
    } else if (e.keyCode == 13) {
      e.preventDefault();
      if (currentFocus > -1) {
        if (x) x[currentFocus].click();
      }
    }
  });
  function addActive(x) {
    if (!x) return false;
    removeActive(x);
    if (currentFocus >= x.length) currentFocus = 0;
    if (currentFocus < 0) currentFocus = (x.length - 1);
    x[currentFocus].classList.add("autocomplete-active");
  }
  function removeActive(x) {
    for (var i = 0; i < x.length; i++) {
      x[i].classList.remove("autocomplete-active");
    }
  }
  function closeAllLists(elmnt) {
    var x = document.getElementsByClassName("autocomplete-items");
    for (var i = 0; i < x.length; i++) {
      if (elmnt != x[i] && elmnt != inp) {
        x[i].parentNode.removeChild(x[i]);
      }
    }
  }
  document.addEventListener("click", function (e) {
    closeAllLists(e.target);
  });
};


// Enable/Disable input fields
function initialStageDisable() {
  var classToDisable = document.getElementsByClassName("initialStage");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].setAttribute("disabled", "disabled");
  }
  document.getElementById('skuInput').setAttribute("disabled", "disabled");
}

function initialStageEnable() {
  var classToDisable = document.getElementsByClassName("initialStage");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].removeAttribute("disabled");
  }
  document.getElementById('skuInput').removeAttribute("disabled");
}

function mgmtStageDisable() {
  var classToDisable = document.getElementsByClassName("mgmtStage");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].setAttribute("disabled", "disabled");
  }
}

function mgmtStageEnable() {
  var classToDisable = document.getElementsByClassName("mgmtStage");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].removeAttribute("disabled");
  }
}

function logisticsStageDisable() {
  var classToDisable = document.getElementsByClassName("logisticsStage");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].setAttribute("disabled", "disabled");
  }
}

function logisticsStageEnable() {
  var classToDisable = document.getElementsByClassName("logisticsStage");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].removeAttribute("disabled");
  }
}

function authLevelZero() {//authLevelReq
  var classToDisable = document.getElementsByClassName("authLevelReq");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].style.display = 'none';
  }
  var classToDisable = document.getElementsByClassName("authLevelOne");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].style.display = 'none';
  }
  var classToDisable = document.getElementsByClassName("authLevelThree");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].style.display = 'none';
  }
  var classToDisable = document.getElementsByClassName("authLevelFive");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].style.display = 'none';
  }
}

function authLevelOne() {
  var classToDisable = document.getElementsByClassName("authLevelThree");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].style.display = 'none';
  }
  var classToDisable = document.getElementsByClassName("authLevelFive");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].style.display = 'none';
  }
  var classToEnable = document.getElementsByClassName("authLevelOne");
  for (var i = 0; i < classToEnable.length; i++) {
    classToEnable[i].style.display = 'inline';
  }
  DisableCloseDeclineButton();
}

function authLevelThree() {
  var classToDisable = document.getElementsByClassName("authLevelFive");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].style.display = 'none';
  }
  authCloseDeclineButton();
}

function authLevelFive() {
  var classToDisable = document.getElementsByClassName("authLevelOne");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].style.display = 'none';
  }
  var classToDisable = document.getElementsByClassName("authLevelThree");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].style.display = 'none';
  }
  var classToDisable = document.getElementsByClassName("authLevelFive");
  for (var i = 0; i < classToDisable.length; i++) {
    classToDisable[i].style.display = 'inline';
  }
  authCloseDeclineButton();//
  document.getElementById('AddUpdate').innerText = "Update";
  document.getElementById('approvePrePoBtn').innerText = "Accept/Complete";
}

function authApproveAcceptButton() {
  var classForInputs = document.getElementsByClassName("approveThree");
  for (var i = 0; i < classForInputs.length; i++) {
    classForInputs[i].style.display = 'inline';
  }
}

function DisableApproveAcceptButton() {
  var classForInputs = document.getElementsByClassName("approveThree");
  for (var i = 0; i < classForInputs.length; i++) {
    classForInputs[i].style.display = 'none';
  }
}//closeDeclineAuth

function authCloseDeclineButton() {
  var classForInputs = document.getElementsByClassName("closeDeclineAuth");
  for (var i = 0; i < classForInputs.length; i++) {
    classForInputs[i].style.display = 'inline';
  }
}

function DisableCloseDeclineButton() {
  var classForInputs = document.getElementsByClassName("closeDeclineAuth");
  for (var i = 0; i < classForInputs.length; i++) {
    classForInputs[i].style.display = 'none';
  }
}



// Get Authorization Level
async function getAuthLevel() {
  await $.ajax({
    type: "GET",
    url: "/Purchase/PrePODashboardAuth",
    data: "{}",
    async: true,
    success: function (data) {
      authLevel = parseInt(JSON.parse(data));
      //authLevel = 5;
      //console.log(authLevel);
      if (authLevel == 1) {
        authLevelOne(); mgmtStageDisable(); logisticsStageDisable();
        document.getElementById('initialStageFilterCB').checked = true;
      }
      else if (authLevel == 2) {
        authLevelOne(); mgmtStageDisable(); logisticsStageDisable(); authApproveAcceptButton();
        document.getElementById('initialStageFilterCB').checked = true;
      }
      else if (authLevel == 3) {
        authLevelThree(); logisticsStageDisable(); authApproveAcceptButton(); mgmtStageDisable();
        document.getElementById('initialStageFilterCB').checked = true;
        document.getElementById('mgmtStageFilterCB').checked = true;
      }
      else if (authLevel == 5) {
        authLevelFive(); initialStageDisable(); authApproveAcceptButton();
        document.getElementById('logisticsStageFilterCB').checked = true;
      }
      else if (authLevel == 0) {
        authLevelZero(); initialStageDisable(); mgmtStageDisable(); logisticsStageDisable();
        document.getElementById('initialStageFilterCB').checked = true;
        document.getElementById('mgmtStageFilterCB').checked = true;
        document.getElementById('logisticsStageFilterCB').checked = true;
        document.getElementById('completedStageFilterCB').checked = true;
        document.getElementById('closedStageFilterCB').checked = true;
      }
      else if (authLevel == 7) {
        initialStageEnable(); mgmtStageDisable(); logisticsStageDisable(); authApproveAcceptButton();
        document.getElementById('initialStageFilterCB').checked = true;
        document.getElementById('mgmtStageFilterCB').checked = true;
        document.getElementById('logisticsStageFilterCB').checked = true;
        document.getElementById('completedStageFilterCB').checked = true;
        document.getElementById('closedStageFilterCB').checked = true;
      }
      
      prePoDataTable.draw();
      return authLevel;
      //return 1;
      //return parseInt(JSON.parse(data));
    }
  })
};

//selectAllBtn
$("#selectAllBtn").click(function () {
  var jsArray = prePoDataTable.rows({ filter: 'applied' }).data().toArray();
  var dvArray = prePoDataTable.rows({ filter: 'applied' });
  var dv;
  var prePoStatus;
  var thisRow;
  //console.log(jsArray);
  //console.log(dvArray);
  for (var i = 0; i < jsArray.length; i++) {
    //console.log("Here : " + dvArray[0][i]);
    prePoStatus = jsArray[i].prePOStatus
    if (prePoStatus > 0) {
      //jsArray[i].isEdited = true;

      dv = prePoDataTable.row(dvArray[0][i]).data();
      thisRow = dvArray[0][i];
      if (prePoStatus < 2) {
        $(prePoDataTable.row(dvArray[0][i]).selector.rows).removeClass('table-purchase-forecasting');
        if (lastSelectedRow != '') {
          $(prePoDataTable.row(lastSelectedRow).selector.rows).removeClass('table-purchase-selected');
          $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass(lastSelectedClass);
        }
        if (authLevel == 1 || authLevel == 2 || authLevel == 3 || authLevel == 7) {
          dv.isEdited = true;
          lastSelectedClass = 'table-purchase-forecasting-approve';
        } else {
          lastSelectedClass = 'table-purchase-forecasting';
        }
        $(prePoDataTable.row(dvArray[0][i]).selector.rows).addClass('table-purchase-selected');
        lastSelectedRow = dvArray[0][i];

      } else if (prePoStatus >= 2 && prePoStatus < 4) {
        $(prePoDataTable.row(dvArray[0][i]).selector.rows).removeClass('table-purchase-management');
        if (lastSelectedRow != '') {
          $(prePoDataTable.row(lastSelectedRow).selector.rows).removeClass('table-purchase-selected');
          $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass(lastSelectedClass);
        }
        if (authLevel == 3 || authLevel == 7) {
          dv.isEdited = true;
          lastSelectedClass = 'table-purchase-management-approve';
        } else {
          lastSelectedClass = 'table-purchase-management';
        }
        $(prePoDataTable.row(dvArray[0][i]).selector.rows).addClass('table-purchase-selected');
        lastSelectedRow = dvArray[0][i];

      } else if (prePoStatus >= 4 && prePoStatus < 5) {
        $(prePoDataTable.row(dvArray[0][i]).selector.rows).removeClass('table-purchase-logistics');
        if (lastSelectedRow != '') {
          $(prePoDataTable.row(lastSelectedRow).selector.rows).removeClass('table-purchase-selected');
          $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass(lastSelectedClass);
        }
        if (authLevel == 5 || authLevel == 7) {
          dv.isEdited = true;
          lastSelectedClass = 'table-purchase-logistics-accept';
        } else {
          lastSelectedClass = 'table-purchase-logistics';
        }
        $(prePoDataTable.row(dvArray[0][i]).selector.rows).addClass('table-purchase-selected');
        lastSelectedRow = dvArray[0][i];

      } else if (prePoStatus < 6) {
        $(prePoDataTable.row(dvArray[0][i]).selector.rows).removeClass('table-purchase-logistics-accept');
        if (lastSelectedRow != '') {
          $(prePoDataTable.row(lastSelectedRow).selector.rows).removeClass('table-purchase-selected');
          $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass(lastSelectedClass);
        }
        if (authLevel == 5 || authLevel == 7) {
          dv.isEdited = true;
          lastSelectedClass = 'table-purchase-logistics-accept';
        }
        $(prePoDataTable.row(dvArray[0][i]).selector.rows).addClass('table-purchase-selected');
        lastSelectedRow = dvArray[0][i];

      } else if (prePoStatus >= 6) {
        $(prePoDataTable.row(dvArray[0][i]).selector.rows).removeClass('table-purchase-logistics-completed');
        if (lastSelectedRow != '') {
          $(prePoDataTable.row(lastSelectedRow).selector.rows).removeClass('table-purchase-selected');
          $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass(lastSelectedClass);
        }
        lastSelectedClass = 'table-purchase-logistics-completed';
        $(prePoDataTable.row(dvArray[0][i]).selector.rows).addClass('table-purchase-selected');
        lastSelectedRow = dvArray[0][i];

      }
      prePoDataTable.row(dvArray[0][i]).data(dv).draw(false);
    }
    
  }
});

$("#newClearInputFields").click(function () {

  clearAllFields();
  clearSelection();

  $(prePoDataTable.row(lastSelectedRow).selector.rows).removeClass('table-purchase-selected');
  $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass(lastSelectedClass);
  var prePoStatus = prePoDataTable.row(lastSelectedRow).data().prePOStatus
  if (prePoStatus < 2) {
    $(prePoDataTable.row(lastSelectedRow).node()).removeClass('table-purchase-forecasting-approve');
    $(prePoDataTable.row(lastSelectedRow).node()).addClass('table-purchase-forecasting');
  } else if (prePoStatus < 4) {
    $(prePoDataTable.row(lastSelectedRow).node()).removeClass('table-purchase-management-approve');
    $(prePoDataTable.row(lastSelectedRow).node()).addClass('table-purchase-management');
  } else if (prePoStatus < 5) {
    $(prePoDataTable.row(lastSelectedRow).node()).removeClass('table-purchase-logistics-accept');
    $(prePoDataTable.row(lastSelectedRow).node()).addClass('table-purchase-logistics');
  } else if (prePoStatus > 5) {
    $(prePoDataTable.row(lastSelectedRow).node()).addClass('table-purchase-logistics-complete');
  }
  var dv = prePoDataTable.row(lastSelectedRow).data();
  prePoDataTable.row(lastSelectedRow).data(dv).draw(false);

  lastSelectedRow = '';
  lastSelectedClass = '';
  if (authLevel == 1) { initialStageEnable(); mgmtStageDisable(); logisticsStageDisable(); }
  else if (authLevel == 2) { initialStageEnable(); mgmtStageDisable(); logisticsStageDisable(); authApproveAcceptButton(); }
  else if (authLevel == 3) { initialStageEnable(); mgmtStageDisable(); logisticsStageDisable(); authApproveAcceptButton(); }
  else if (authLevel == 5) { initialStageDisable(); mgmtStageDisable(); logisticsStageDisable(); authApproveAcceptButton(); }
  else if (authLevel == 0) { initialStageDisable(); mgmtStageDisable(); logisticsStageDisable(); }
  else if (authLevel == 7) { initialStageEnable(); mgmtStageDisable(); logisticsStageDisable(); authApproveAcceptButton();  }

});

function clearSelection() {
  var jsArray = prePoDataTable.data().toArray();
  var arrayLength = jsArray.length;
  var dv;
  var prePoStatus;

  for (var i = 0; i < arrayLength; i++) {
    if (prePoDataTable.row(i).data().isEdited == true) {
      prePoDataTable.row(i).data().isEdited = false;
      prePoDataTable.row(i).data().prePOStatus = prePoDataTable.row(i).data().prePOStatus - 1;
      prePoStatus = prePoDataTable.row(i).data().prePOStatus;
      if (prePoStatus < 2) {
        $(prePoDataTable.row(i).node()).removeClass('table-purchase-forecasting-approve');
        $(prePoDataTable.row(i).node()).addClass('table-purchase-forecasting');
      } else if (prePoStatus < 4) {
        $(prePoDataTable.row(i).node()).removeClass('table-purchase-management-approve');
        $(prePoDataTable.row(i).node()).addClass('table-purchase-management');
      } else if (prePoStatus < 5) {
        $(prePoDataTable.row(i).node()).removeClass('table-purchase-logistics-accept');
        $(prePoDataTable.row(i).node()).addClass('table-purchase-logistics');
      } else if (prePoStatus > 5) {
        $(prePoDataTable.row(i).node()).addClass('table-purchase-logistics-complete');
      }
      dv = prePoDataTable.row(i).data();
      prePoDataTable.row(i).data(dv).draw(false);


    }
  }
}


function clearAllFields() {
  document.getElementById('prePOStatus').value = 0;
  document.getElementById('internalPoNo').innerHTML = '';
  document.getElementById('hasInitialApproved').innerHTML = '';
  document.getElementById('mgmtPrePOAccept').innerHTML = '';
  document.getElementById('acceptedByLogistics').innerHTML = '';
  document.getElementById('createdDate').innerHTML = '';
  document.getElementById('mgmtDateExecuted').innerHTML = '';
  document.getElementById('acceptedByLogisticsDate').innerHTML = '';
  document.getElementById('logisticsRegCompletion').innerHTML = '';
  document.getElementById('logisticsCompletedDate').innerHTML = '';
  document.getElementById('mustETADateHistory').innerHTML = '';
  document.getElementById('logisticsCompletedBy').innerHTML = '';
  document.getElementById('logisticsAcceptedBy').innerHTML = '';
  $('#poChannel').prop('selectedIndex', 0);
 // $('approvalLevel').prop('selectedIndex', 0);
  $('#vendorChosenDropdown').prop('selectedIndex', 0);
  $('#etaMustDateDropdownMonth').prop('selectedIndex', 0);
  $('#etaMustDateDropdownYear').prop('selectedIndex', 0);
  $('#logisticsEtaMustDateDropdownMonth').prop('selectedIndex', 0);
  $('#logisticsEtaMustDateDropdownYear').prop('selectedIndex', 0);
  $('#skuInput').val('');
  $('#requestedQty').val('');
  $('#prePOId').val('');
  $('#mgmtAdjQty').val('');
  $('#logisticsConfirmedQty').val('');
  $('#HasInitialApproved').val('');
  $('#mgmtPrePOAccept').val('');
  $('#acceptedByLogistics').val('');
  $('#createdDate').val('');
  $('#mgmtDateExecuted').val('');
  $('mgmtApprovedBy').val('');
  $('#acceptedByLogisticsDate').val('');
  $('#requestorsNote').val('');
  $('#mgmtsNote').val('');
  $('#logisticsAcceptanceNote').val('');
  $('#logisticsRegCompletion').val('');
  $('#logisticsCompletedDate').val('');
  $('#logisticsPONoNote').val('');
  $('#etdcDatePicker').val('');
  clearAllHistoryFields();
}

function clearAllHistoryFields() {
  // History Section
  $('internalPoNoHistory').val('');
  $('prePOStatusHistory').val('');
  $('poChannelHistory').val('');
  //$('approvalLevelHistory').val('');
  $('logisticsChosenVendorHistory').val('');
  $('skuHistory').val('');
  $('logisticsEtd_cHistory').val('');
  $('requestedQtyHistory').val('');
  $('mgmtAdjQtyHistory').val('');
  $('logisticsConfirmedQtyHistory').val('');
  $('hasInitialApprovedHistory').val('');
  $('mgmtPrePOAcceptHistory').val('');
  $('acceptedByLogisticsHistory').val('');
  $('initialApprovedByHistory').val('');
  $('mgmtApprovedByHistory').val('');
  $('logisticsAcceptedByHistory').val('');
  $('mustETADateHistory').val('');
  $('createdDateHistory').val('');
  $('mgmtDateExecutedHistory').val('');
  $('acceptedByLogisticsDateHistory').val('');
  $('requestorsNoteHistory').val('');
  $('mgmtsNoteHistory').val('');
  $('logisticsAcceptanceNoteHistory').val('');
  $('logisticsRegCompletionHistory').val('');
  $('logisticsCompletedDateHistory').val('');
  $('logisticsMustEtaDateHistory').val('');
  $('logisticsCompletedByHistory').val('');
  $('logisticsPONoNoteHistory').val('');
  $('revNoNoHistory').val('');
}



$("#AddUpdate").click(function () {
  var returnResult = new Object();
  var addUpdate = "";
  var status = parseInt($('#prePOStatus').val());
  var startDate = new Date($('#fromDateHidden').val());
  var internPoNumber = $('internalPoNo').val();
  //console.log(status);
  if (status < 0) {
    swal({
      title: "Warning!",
      text: "This record was closed!",
      icon: "warning",
    });
    return false;
  } else if (status == 0) { // Adding
    // returnResult.poChannel = dropdown
    //returnResult.internalPoNo = -1;
    addUpdate = "added";
    if (authLevel == 5 || authLevel == 0) { alert("You cannot add a record(because of your authorization level)!"); return false; }
    var e = document.getElementById("poChannel");
    if (e.value == "none") {
      alert("You need to choose a PO Channel!");
      return false;
    }
    else {
      returnResult.poChannel = e.value;
    }
    //var e = document.getElementById("approvalLevel");
    //if (e.value == "none") {
    //  alert("You need to choose an Approval Level!");
    //  return false;
    //}
    //else {
    //  returnResult.approvalLevel = e.value;
    //}
    var e = document.getElementById("skuInput");
    if (e.value == "") {
      alert("You need to choose SKU!");
      return false;
    }
    var e = document.getElementById("requestedQty");
    if (e.value == 0) {
      alert("You need (Request) QTY.!");
      return false;
    }
    var etaMonth = document.getElementById("etaMustDateDropdownMonth");
    var etaYear = document.getElementById("etaMustDateDropdownYear");
    if ((etaMonth.value == "none") || (etaYear.value == "none")) {
      returnResult.mustETADate = "none";
    }
    else {
      if ((startDate.getMonth() > etaMonth.value)
        && (startDate.getFullYear() >= etaYear.value)) {
        alert('Check MUST ETA Month!');
        return null;
      }
      returnResult.mustETADate = etaMonth.value + '/01/' + etaYear.value;
    }
    returnResult.prePOStatus = status;
    returnResult.poChannel = document.getElementById("poChannel").value.toUpperCase();
    //returnResult.approvalLevel = document.getElementById("approvalLevel").value.toUpperCase();
    returnResult.sku = $('#skuInput').val();
    returnResult.requestedQty = $('#requestedQty').val();
    returnResult.requestorsNote = $('#requestorsNote').val();
  }
  else { // Updating
    addUpdate = "updated";
    returnResult.sku = $('#skuInput').val();
    returnResult.poChannel = document.getElementById("poChannel").value.toUpperCase();
    //returnResult.approvalLevel = document.getElementById("approvalLevel").value.toUpperCase();
    returnResult.prePOStatus = parseInt($('#prePOStatus').val());
    returnResult.requestedQty = $('#requestedQty').val();
    returnResult.requestorsNote = $('#requestorsNote').val();
    returnResult.prePOId = parseInt($('#prePOId').val());
    var tmpDate = new Date();
    if (status < 2) {
      var etaMonth = document.getElementById("etaMustDateDropdownMonth");
      var etaYear = document.getElementById("etaMustDateDropdownYear");
      if ((etaMonth.value == "none") || (etaYear.value == "none")) {
        returnResult.mustETADate = "none";
      }
      else {
        if ((startDate.getMonth() > etaMonth.value)
          && (startDate.getFullYear() >= etaYear.value)) {
          alert('Check MUST ETA Month!');
          return null;
        }
        returnResult.mustETADate = etaMonth.value + '/01/' + etaYear.value;
      }
      returnResult.sku = $('#skuInput').val();
      returnResult.requestedQty = $('#requestedQty').val();
      returnResult.requestorsNote = $('#requestorsNote').val();
      returnResult.poChannel = document.getElementById("poChannel").value.toUpperCase();
      //returnResult.approvalLevel = document.getElementById("approvalLevel").value.toUpperCase();
      //returnResult.mustETADate = $('#sku').val();
    } else if (status < 4) {
      returnResult.mgmtAdjQty = $('#mgmtAdjQty').val();
      returnResult.mgmtsNote = $('#mgmtsNote').val();
    } else if (status < 6) {
      var logEtaMonth = document.getElementById("logisticsEtaMustDateDropdownMonth");
      var logEtaYear = document.getElementById("logisticsEtaMustDateDropdownYear");
      if ((logEtaMonth.value == "none") || (logEtaYear.value == "none")) {
        returnResult.logisticsMustETADate = "none";
      }
      else {
        if ((startDate.getMonth() > logEtaMonth.value)
          && (startDate.getFullYear() >= logEtaYear.value)) {
          alert('Check Updated MUST ETA Date!');
          return null;
        }
        returnResult.logisticsMustETADate = logEtaMonth.value + '/01/' + logEtaYear.value;
      }
      returnResult.logisticsChosenVendorId = document.getElementById("vendorChosenDropdown").value;
      returnResult.logisticsAcceptanceNote = $('#logisticsAcceptanceNote').val();
      returnResult.logisticsConfirmedQty = $('#logisticsConfirmedQty').val();
      returnResult.logisticsPONoNote = $('#logisticsPONoNote').val();
      if ($('#etdcDatePicker').datepicker("getDate") != null) {
        tmpDate = $('#etdcDatePicker').datepicker("getDate");
        returnResult.logisticsEtd_c = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();
      }
    } else {
      console.log("Should not come here!");
      return false;
    }

  }
  //console.log(returnResult);

  $.ajax({
    url: '../Purchase/UpsertPrePO',
    type: "POST",
    async: false,
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(returnResult),
    success: function () {
      alert('The record was ' + addUpdate + '!');
      prePoDataTable.ajax.reload();

      //clearAllFields();
      if (status == 0) { initializeUI(); }
      else {
        if (status < 2) {
          $(prePoDataTable.row(lastSelectedRow).selector.rows).removeClass('table-purchase-forecasting');
          $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass('table-purchase-selected');
        } else if (status >= 2 && status < 4) {
          $(prePoDataTable.row(lastSelectedRow).selector.rows).removeClass('table-purchase-management');
          $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass('table-purchase-selected');
        } else if (status >= 4 && status < 5) {
          $(prePoDataTable.row(this).selector.rows).removeClass('table-purchase-logistics');
          $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass('table-purchase-selected');
          lastSelectedClass = 'table-purchase-logistics';
        } else if (prePoStatus < 6) {
          $(prePoDataTable.row(this).selector.rows).removeClass('table-purchase-logistics-accept');
          $(prePoDataTable.row(lastSelectedRow).selector.rows).addClass('table-purchase-selected');
          lastSelectedClass = 'table-purchase-logistics-accept';
        }
      }// End of if
    }
  });
});

// All Buttons
// Accept/Approve
$("#approvePrePoBtn").click(function () {
  const selectedIds = [];
  const invalidPONos = [];
  //var table_data = prePoDataTable.rows().data().toArray();
  //dv.logisticsEtd_c != "-" && dv.logisticsChosenVendor != null
  var jsArray = prePoDataTable.data().toArray();
  var arrayLength = jsArray.length;

  console.log(jsArray);
  // Need to fix this
  for (var i = 0; i < arrayLength; i++) {
    if (jsArray[i].isEdited == true) {
    //if (jsArray[i].isChecked == true) {
      selectedIds.push(jsArray[i].prePOId);
      if (parseInt(jsArray[i].prePOStatus) > 4 && (jsArray[i].logisticsEtd_c == "-" || jsArray[i].logisticsChosenVendor == null)) {
        invalidPONos.push(jsArray[i].internalPoNo);
      }
    }
  }

  if (invalidPONos.length == 0) {
    returnResult = selectedIds;
  } else {
    alert("These records are missing ETA-C/Vendor :\n" + invalidPONos)
    return false;
  }

  var textMsg = (authLevel == 5 ? 'accepted!' : 'approved!');

  //var dv = prePoDataTable.row(this).data();
  $.ajax({
    url: '../Purchase/GetAcceptApprovePrePOs',
    type: "POST",
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(returnResult),
    success: function () {
      alert('The records are ' + textMsg);
      prePoDataTable.ajax.reload();
      //prePoDataTable.row(this).data(dv).draw(false);

      lastSelectedRow = '';
      lastSelectedClass = '';
    }
  });
  // prePoDataTable;
});

// Close/Decline
$("#closeDeclinePrePoBtn").click(function () {
  const selectedId = [];
  //var table_data = prePoDataTable.rows().data().toArray();
  var jsArray = prePoDataTable.data().toArray();
  var arrayLength = jsArray.length;

  if (arrayLength > 0) {
    for (var i = 0; i < arrayLength; i++) {
      if (jsArray[i].isEdited == true) {
        selectedId.push(jsArray[i].prePOId);
      }
    }

    returnResult = selectedId;

    $.ajax({
      url: '../Purchase/GetClosedDeclinedPrePOs',
      type: "POST",
      contentType: "application/json charset=utf-8",
      dataType: 'json',
      data: JSON.stringify(returnResult),
      success: function () {
        alert('The records are closed/declined!');
        prePoDataTable.ajax.reload();
      }
    });
  }
  else {
    alert('Select record, first!');
  }
});
//deletePrePoBtn

$("#deletePrePoBtn").click(function () {
  const selectedIds = [];
  const invalidIds = [];
//  var table_data = prePoDataTable.rows().data().toArray();
  var jsArray = prePoDataTable.data().toArray();
  var arrayLength = jsArray.length;


  for (var i = 0; i < arrayLength; i++) {
    if (jsArray[i].isEdited == true && (parseInt(jsArray[i].prePOStatus) < 2 && parseInt(jsArray[i].prePOStatus) >= 0)) {
      selectedIds.push(jsArray[i].prePOId);
    } else if (jsArray[i].isEdited == true && (parseInt(jsArray[i].prePOStatus) < 0 || parseInt(jsArray[i].prePOStatus) >= 2))  {
      invalidIds.push(jsArray[i].internalPoNo);
    }
  }

  returnResult = selectedIds;

  //var textMsg = (authLevel == 5 ? 'accepted!' : 'approved!');
  if (selectedIds.length > 0) {
    $.ajax({
      url: '../Purchase/GetDeletedPrePOs',
      type: "POST",
      contentType: "application/json charset=utf-8",
      dataType: 'json',
      data: JSON.stringify(returnResult),
      success: function () {
        alert('The records are deleted!');
        prePoDataTable.ajax.reload();
        //prePoDataTable.row(this).data(dv).draw(false);

        lastSelectedRow = '';
        lastSelectedClass = '';
      }
    });
  }
  if (invalidIds.length > 0) {
    alert("Some of records you selected are not able to be deleted :\n" + invalidIds);
  }
  // prePoDataTable;
});


// For custom filter
$.fn.dataTable.ext.search.push(
  function (settings, data, dataIndex) {
    var isf = document.getElementById('initialStageFilterCB').checked;
    var msf = document.getElementById('mgmtStageFilterCB').checked;
    var lsf = document.getElementById('logisticsStageFilterCB').checked;
    var csf = document.getElementById('completedStageFilterCB').checked;
    var dsf = document.getElementById('closedStageFilterCB').checked;

    var pps = parseInt(data[26]);

    if (
      (dsf ? (pps < 0) : '') ||
      (isf ? (pps == 1) : '') ||
      (msf ? (pps == 2 || pps == 3) : '') ||
      (lsf ? (pps == 4 || pps == 5) : '') ||
      (csf ? (pps == 6) : '')
    )
    { return true; }
    return false;
  }
);







// Import Pre POs//importPrePOsFromUser

function importPrePOsFromUser() {
  var fileInput = document.getElementById('ImportPrePOs');
  fileInput.addEventListener("click", function () {
    fileInput.value = null;
  });
  document.getElementById('ImportPrePOs').addEventListener('change', csvJSON, false);
}


function importPrePOsLogisticsFromUser() {
  var fileInput = document.getElementById('ImportPrePOsLogistics');
  fileInput.addEventListener("click", function () {
    fileInput.value = null;
  });
  document.getElementById('ImportPrePOsLogistics').addEventListener('change', csvLGJSON, false);
}

function csvJSON(e) {
  var file = e.target.files[0];
  if (!file) return;
  var reader = new FileReader();
  reader.onload = function (e) {
    var contents = e.target.result;
    getJSON(contents);
    if (contents == null) return;
  };
  reader.readAsText(file);
  //reader = new FileReader();
  //file = null;
}

function getJSON(contents) {
  const lines = contents.split('\n');
  const jsonArray = [];
  const headers = lines[0].split(',');
  // We will only import 5 columns
  let lengthLimit = 5;
  var startDate = new Date($('#fromDateHidden').val());

  for (let k = 0; k < headers.length; k++) {
    headers[k] = headers[k].replace(/\s+/g, '');
  }
  for (let i = 1; i < lines.length; i++) {
    if (!lines[i])
      continue;
    const obj = {};
    var tmpStr = "";
    var idx = 0;
    var newCurLine = [];
    while (idx <= lines[i].length) {
//      console.log(idx + ", " + lines[i][idx]);
      tmpStr = "";
      if (lines[i][idx] === ',') {
  //      console.log("1, " + lines[i][idx]);
        idx++;
        if (lines[i][idx] === '\"') {
          var cnt = true;
          idx++;
          while (cnt) {
            if (lines[i][idx] === '\"') {
    //          console.log("5, " + tmpStr);
              if (newCurLine.length == 2) {
                tmpStr = tmpStr.replace(",","");
              } else if (newCurLine.length == 1) {
                tmpStr = tmpStr.replace(" ", "");
              }
              newCurLine.push(tmpStr);
              cnt = false;
            } else {
              tmpStr += lines[i][idx];
              idx++;
            }
          }
        } else if (lines[i][idx] === '\r' || lines[i][idx] === '\n') {
          idx = lines[i].length;
        } else {
         // console.log("11, " + lines[i][idx]);
          var cnt = true;
          while (cnt) {
            if (lines[i][idx] === ',') {
              //console.log("5, " + tmpStr);
              if (newCurLine.length == 2) {
                tmpStr = tmpStr.replace(",", "");
              } else if (newCurLine.length == 1) {
                tmpStr = tmpStr.replace(" ", "");
              }
              newCurLine.push(tmpStr);
              idx--;
              cnt = false;
            } else {
              if (lines[i][idx] === '\r' || lines[i][idx] === '\n') {
                //console.log("7, " + lines[i][idx]);
                if (newCurLine.length == 2) {
                  tmpStr = tmpStr.replace(",", "");
                } else if (newCurLine.length == 1) {
                  tmpStr = tmpStr.replace(" ", "");
                }
                newCurLine.push(tmpStr);
                idx = lines[i].length;
                cnt = false;
              } else {
               // console.log("8, " + lines[i][idx]);
              tmpStr += lines[i][idx];
                idx++;
              }
            }
          }
        }
      } else if (lines[i][idx] === '\"') {
        //console.log("2, " + lines[i][idx]);
        var cnt = true;
        idx++;
        while (cnt) {
          if (lines[i][idx] === '\"') {
           // console.log("5, " + tmpStr);
            if (newCurLine.length == 2) {
              tmpStr = tmpStr.replace(",", "");
            } else if (newCurLine.length == 1) {
              tmpStr = tmpStr.replace(" ", "");
            }
            newCurLine.push(tmpStr);
            cnt = false;
          } else {
            if (lines[i][idx] === '\r' || lines[i][idx] === '\n') {
              if (newCurLine.length == 2) {
                tmpStr = tmpStr.replace(",", "");
              } else if (newCurLine.length == 1) {
                tmpStr = tmpStr.replace(" ", "");
              }
              newCurLine.push(tmpStr);
              idx = lines[i].length;
              cnt = false;
            } else {
              tmpStr += lines[i][idx];
              idx++;
            }
          }
        }
      } else {
       // console.log("3, " + lines[i][idx]);
        var cnt = true;
        while (cnt) {
          if (lines[i][idx] === ',') {
           // console.log("5, " + tmpStr);
            if (newCurLine.length == 2) {
              tmpStr = tmpStr.replace(",", "");
            } else if (newCurLine.length == 1) {
              tmpStr = tmpStr.replace(" ", "");
            }
            newCurLine.push(tmpStr);
            idx--;
            cnt = false;
          } else {  
            if (lines[i][idx] === '\r' || lines[i][idx] === '\n') {
              if (newCurLine.length == 2) {
                tmpStr = tmpStr.replace(",", "");
              } else if (newCurLine.length == 1) {
                tmpStr = tmpStr.replace(" ", "");
              }
              newCurLine.push(tmpStr);
              idx = lines[i].length;
              cnt = false;
            } else {
              tmpStr += lines[i][idx];
              idx++;
            }
          }
        }
      }
      idx++;
    }// Adding to the array

    //const currentline = lines[i].split(',');
    const currentline = newCurLine;

    for (let j = 0; j < lengthLimit; j++) {
      if (j == 4) {
        if ((startDate.getMonth() > (new Date(currentline[j])).getMonth())
          && (startDate.getFullYear() >= (new Date(currentline[j])).getFullYear())) {
          alert('Check MUST ETA on file!');
          return null;
        }
      }
      obj[headers[j]] = currentline[j];
    }
    jsonArray.push(obj);
  }

  var returnResult = new Object();
  returnResult = jsonArray;
  //console.log(returnResult);
  //AmazonFeedsListImportDTO.push(returnResult);
  $.ajax({
    url: '/Purchase/ImportPrePOs',
    type: 'POST',
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(returnResult),
    success: function (response) {
      if (response.errorOnImport == false) { alert('The import process is done!'); }
      else { alert(response.errorMessages); }
      prePoDataTable.ajax.reload();
    },
    error: function (jqXHR, textStatus, errorThrown) {
      if (jqXHR.status == 500) {
        alert('Internal error: ' + jqXHR.responseText +'\n'+'Check an import file.');
      } else {
        alert('Unexpected error.' + '\n' + 'Check an import file.');
      }
    }
  });
  //$('#resultJSON').val(JSON.stringify(returnResult));
}
// End of Import POs

// Import for Logistics
function csvLGJSON(e) {
  var file = e.target.files[0];
  if (!file) return;
  var reader = new FileReader();
  reader.onload = function (e) {
    var contents = e.target.result;
    getLGJSON(contents);
  };
  reader.readAsText(file);
  //reader = new FileReader();
  //file = null;
}

function getLGJSON(contents) {
  const lines = contents.split('\n');
  const jsonArray = [];
  const headers = lines[0].split(',');
  // We will only import 8 columns
  let lengthLimit = 8;
 
  var startDate = new Date($('#fromDateHidden').val());

  for (let k = 0; k < headers.length; k++) {
    headers[k] = headers[k].replace(/\s+/g, '');
  }

  for (let i = 1; i < lines.length; i++) {
    if (!lines[i])
      continue;
    const obj = {};
    var tmpStr = "";
    var idx = 0;
    var newCurLine = [];
    while (idx <= lines[i].length) {
      //      console.log(idx + ", " + lines[i][idx]);
      tmpStr = "";
      if (lines[i][idx] === ',') {
        //      console.log("1, " + lines[i][idx]);
        idx++;
        if (lines[i][idx] === '\"') {
          var cnt = true;
          idx++;
          while (cnt) {
            if (lines[i][idx] === '\"') {
              //          console.log("5, " + tmpStr);
              if (newCurLine.length == 2) {
                tmpStr = tmpStr.replace(",", "");
              } else if (newCurLine.length == 1) {
                tmpStr = tmpStr.replace(" ", "");
              }
              newCurLine.push(tmpStr);
              cnt = false;
            } else {
              tmpStr += lines[i][idx];
              idx++;
            }
          }
        } else if (lines[i][idx] === '\r' || lines[i][idx] === '\n') {
          idx = lines[i].length;
        } else {
          // console.log("11, " + lines[i][idx]);
          var cnt = true;
          while (cnt) {
            if (lines[i][idx] === ',') {
              //console.log("5, " + tmpStr);
              if (newCurLine.length == 2) {
                tmpStr = tmpStr.replace(",", "");
              } else if (newCurLine.length == 1) {
                tmpStr = tmpStr.replace(" ", "");
              }
              newCurLine.push(tmpStr);
              idx--;
              cnt = false;
            } else {
              if (lines[i][idx] === '\r' || lines[i][idx] === '\n') {
                //console.log("7, " + lines[i][idx]);
                if (newCurLine.length == 2) {
                  tmpStr = tmpStr.replace(",", "");
                } else if (newCurLine.length == 1) {
                  tmpStr = tmpStr.replace(" ", "");
                }
                newCurLine.push(tmpStr);
                idx = lines[i].length;
                cnt = false;
              } else {
                // console.log("8, " + lines[i][idx]);
                tmpStr += lines[i][idx];
                idx++;
              }
            }
          }
        }
      } else if (lines[i][idx] === '\"') {
        //console.log("2, " + lines[i][idx]);
        var cnt = true;
        idx++;
        while (cnt) {
          if (lines[i][idx] === '\"') {
            // console.log("5, " + tmpStr);
            if (newCurLine.length == 2) {
              tmpStr = tmpStr.replace(",", "");
            } else if (newCurLine.length == 1) {
              tmpStr = tmpStr.replace(" ", "");
            }
            newCurLine.push(tmpStr);
            cnt = false;
          } else {
            if (lines[i][idx] === '\r' || lines[i][idx] === '\n') {
              if (newCurLine.length == 2) {
                tmpStr = tmpStr.replace(",", "");
              } else if (newCurLine.length == 1) {
                tmpStr = tmpStr.replace(" ", "");
              }
              newCurLine.push(tmpStr);
              idx = lines[i].length;
              cnt = false;
            } else {
              tmpStr += lines[i][idx];
              idx++;
            }
          }
        }
      } else {
        // console.log("3, " + lines[i][idx]);
        var cnt = true;
        while (cnt) {
          if (lines[i][idx] === ',') {
            // console.log("5, " + tmpStr);
            if (newCurLine.length == 2) {
              tmpStr = tmpStr.replace(",", "");
            } else if (newCurLine.length == 1) {
              tmpStr = tmpStr.replace(" ", "");
            }
            newCurLine.push(tmpStr);
            idx--;
            cnt = false;
          } else {
            if (lines[i][idx] === '\r' || lines[i][idx] === '\n') {
              if (newCurLine.length == 2) {
                tmpStr = tmpStr.replace(",", "");
              } else if (newCurLine.length == 1) {
                tmpStr = tmpStr.replace(" ", "");
              }
              newCurLine.push(tmpStr);
              idx = lines[i].length;
              cnt = false;
            } else {
              tmpStr += lines[i][idx];
              idx++;
            }
          }
        }
      }
      idx++;
    }// Adding to the array

    //const currentline = lines[i].split(',');
    const currentline = newCurLine;
    console.log(currentline);

    for (let j = 0; j < lengthLimit; j++) {
      if (j == 7) {
        if ((startDate.getMonth() > (new Date(currentline[j])).getMonth())
          && (startDate.getFullYear() >= (new Date(currentline[j])).getFullYear())) {
          alert('Check MUST ETA on file!');
          return null;
        }
      }
      obj[headers[j]] = currentline[j];
    }
    jsonArray.push(obj);
  }

  var returnResult = new Object();
  returnResult = jsonArray;
  //console.log(returnResult);
  //AmazonFeedsListImportDTO.push(returnResult);
  $.ajax({
    url: '/Purchase/ImportPrePOLogistics',
    type: 'POST',
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(returnResult),
    success: function (response) {
      if (response.errorOnImport == false) { alert('The import process is done!'); }
      else { alert(response.errorMessages); }

      prePoDataTable.ajax.reload();
    },
    error: function (jqXHR, textStatus, errorThrown) {
      if (jqXHR.status == 500) {
        alert('Internal error: ' + jqXHR.responseText + '\n' + 'Check an import file.');
      } else {
        alert('Unexpected error.' + '\n' + 'Check an import file.');
      }
    }
  });
  //$('#resultJSON').val(JSON.stringify(returnResult));
}
// End of Import Logistics 







// BPM Item(SKU) List for autocomplete
//var skuList = async function () {
//  await $.ajax({
//    type: "GET",
//    url: "/Purchase/GetPrePOSKUList",
//    data: "{}",
//    async: true,
//    success: function (data) {
//      return JSON.stringify(data);
//    }
//  }).responseText
//};

//function loadDataTable() {
var prePoDataTable = $("#poAccptDashboardItems").DataTable({
  "scrollX": true,
  "scrollCollapse": true,
  //"paging": false,
  "destroy": true,
  "autoWidth": false,
  "rowCallback": function (row, data, index) {
    if (parseInt(data.requestedQty) != parseInt(data.mgmtAdjQty)) {
      $(row).find('td:eq(10)').css('color', 'red');
      $(row).find('td:eq(10)').css('font-weight', 'bold');
    }
    if (parseInt(data.logisticsConfirmedQty) != parseInt(data.mgmtAdjQty)) {
      $(row).find('td:eq(16)').css('color', 'red');
      $(row).find('td:eq(10)').css('font-weight', 'bold');
    }
  },
  "fixedColumns": {
    left: 3
  },
    
  "initComplete": function () {
    this.api().columns([3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25]).every(function () {
      var column = this;
      var select = $('<select><option value=""></option></select>')
        .appendTo($(column.footer()).empty())
        .on('change', function () {
          var val = $.fn.dataTable.util.escapeRegex(
            $(this).val()
          );

          column
            .search(val ? '^' + val + '$' : '', true, false)
            .draw();
        });

      column.data().unique().sort().each(function (d, j) {
        select.append('<option value="' + d + '">' + d + '</option>')
      });
    });
    var api2 = this.api();

    // For each column
    api2
      .columns()
      .eq(0)
      .each(function (colIdx) {


        var cell = $('.filters th').eq(
          $(api2.column().header()).index()
        );
        var title = $(cell).text();
        $(cell).html('<input type="text" placeholder="' + title + '" size = "10"/>');

        // On every keypress in this input
        $(
          'input',
          $('.filters th').eq($(api2.column(colIdx).header()).index())
        )
          .off('keyup change')
          .on('keyup change', function (e) {
            e.stopPropagation();

            // Get the search value
            $(this).attr('title', $(this).val());
            var regexr = '({search})'; //$(this).parents('th').find('select').val();

            var cursorPosition = this.selectionStart;
            // Search the column for that value
            api2
              .column(colIdx)
              .search(
                this.value != ''
                  ? regexr.replace('{search}', '(((' + this.value + ')))')
                  : '',
                this.value != '',
                this.value == ''
              )
              .draw();

            $(this)
              .focus()[0]
              .setSelectionRange(cursorPosition, cursorPosition);
          });
      });

  },
  "createdRow": function (row, data, dataIndex) {
    var ppStatusForCss = parseInt(data.prePOStatus);
    if (ppStatusForCss < 0) { $(row).addClass('table-closed-declined'); }
    else if (ppStatusForCss < 2) { $(row).addClass('table-purchase-forecasting'); }
    else if (ppStatusForCss < 4) { $(row).addClass('table-purchase-management'); }
    else if (ppStatusForCss < 5) { $(row).addClass('table-purchase-logistics'); }
    else if (ppStatusForCss < 6) { $(row).addClass('table-purchase-logistics-accept'); }
    else if (ppStatusForCss >= 6) { $(row).addClass('table-purchase-logistics-completed'); }
    if (row.isEdited == true) { $(row).addClass('table-purchase-edited'); }
  },
  "columnDefs": [
    {
      targets: -1,
      className: 'dt-body-right'
    },
    {
      targets: 10,
      render: function (data, type, row) {
        var ppStatus = parseInt(row.prePOStatus);
        if (row.hasInitialApproved == true) {
          return 'Approved';
        } else {
          if (ppStatus >= 0) {
            return 'Waiting for Approval';
          } else {
            return 'Declined';
          }
        }
        return data;
      }
    },
    {
      targets: 14,
      render: function (data, type, row) {
        var ppStatus = parseInt(row.prePOStatus);
        if (row.mgmtPrePOAccept == true) {
          return 'Approved';
        } else {
          if (ppStatus == -2) {
            return 'Declined';
          } else if (ppStatus < 4 && ppStatus >= 2) {
            return 'Waiting for Approval'
          } else if (ppStatus > -2 || ppStatus <= 1) {
            return '';
          } else {
            return 'Error!';
          }
        }
        return data;
      }
    },
    {
      targets: 16,
      render: function (data, type, row) {
        var ppStatus = parseInt(row.prePOStatus);
        if (row.acceptedByLogistics == true) {
          return 'Accepted';
        } else {
          if (ppStatus == -3) {
            return 'Declined';
          } else if (ppStatus >= 4 && ppStatus < 5) {
            return 'Waiting for Acceptance'
          } else if (ppStatus < 4 || ppStatus > -3) {
            return '';
          } else {
            return 'Error!';
          }
        }
        return data;
      }
    },
    {
      targets: 23,
      render: function (data, type, row) {
        var ppStatus = parseInt(row.prePOStatus);
        if (row.logisticsRegCompletion == true) {
          return 'Yes';
        } else {
          return '';
        }
        return data;
      }
    }
  ],
  "order": [[0, "dsc"]],
  dom: 'Bfrtip',
  lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
  buttons: [
    {
      extend: 'copyHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "PrePO" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'csvHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "PrePO" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'excelHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "PrePO" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'pdfHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "PrePO" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Purchase/GetPOAccptDB",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.startDate = $('#fromDateHidden').val();
      d.endDate = $('#toDateHidden').val();
      //d.startDate = (tmpDate01.getMonth() + 1) + '/' + tmpDate01.getDate() + '/' + tmpDate01.getFullYear();
     // d.endDate = (tmpDate02.getMonth() + 1) + '/' + tmpDate02.getDate() + '/' + tmpDate02.getFullYear();
    }
  },
  "columns": [
    { "data": "prePOId", "visible": false },
    {
      "data": "isEdited",
      "render": function (data, type, row) {
        if (data === true) {
          return '<input type="checkbox" class="editor-active" onclick="return false;" checked>';
        } else {
          return '<input type="checkbox" onclick="return false;" class="editor-active">';
        }
        return data;
      },
      className: "dt-body-center text-center",
      "width": "5%"
    },
    { "data": "internalPoNo", "width": "10%", "className": "text-right" },
    { "data": "sku", "width": "20%", "className": "text-right" },
    { "data": "skuStatus", "width": "20%", "className": "text-right" },
    { "data": "requestor", "width": "20%", "className": "text-right" },
    { "data": "poChannel", "width": "10%", "className": "text-right" },
    { "data": "requestedQty", "width": "10%", "className": "text-right" },
    { "data": "requestorsNote", "width": "10%", "className": "text-right" },
    { "data": "mustETADate", "width": "20%", "className": "text-right" },
    {
      "data": "hasInitialApproved",
      "width": "10%", "className": "text-right"
    },
    { "data": "initialApprovedDate", "width": "10%", "className": "text-right" },
    { "data": "mgmtAdjQty", "width": "10%", "className": "text-right" },
    { "data": "mgmtsNote", "width": "10%", "className": "text-right" },
    {
      "data": "mgmtPrePOAccept",
      "width": "10%", "className": "text-right"
    },
    {
      "data": "mgmtDateExecuted",
      "width": "20%", "className": "text-right"
    },
    {
      "data": "acceptedByLogistics",
      "width": "10%", "className": "text-right"
    },
    { "data": "acceptedByLogisticsDate", "width": "20%", "className": "text-right" },
    { "data": "logisticsConfirmedQty", "width": "10%", "className": "text-right" },
    { "data": "logisticsChosenVendor", "width": "10%", "className": "text-right" },
    { "data": "logisticsAcceptanceNote", "width": "10%", "className": "text-right" },
    { "data": "logisticsEtd_c", "width": "10%", "className": "text-right" },
    { "data": "logisticsMustETADate", "width": "10%", "className": "text-right" },
    {
      "data": "logisticsRegCompletion",
      "width": "10%", "className": "text-right"
    },
    { "data": "logisticsPONoNote", "width": "10%", "className": "text-right" },
    { "data": "logisticsCompletedDate", "width": "20%", "className": "text-right" },
    { "data": "prePOStatus", "visible": false }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "315%"
});

var prePoHistoryDataTable = $("#poAccptDashboardHistoryItems").DataTable({
  "scrollX": true,
  "scrollY": true,
  "scrollCollapse": true,
  "destroy": true,
  "autoWidth": false,
  //"paging": false,
  "order": [[0, "dsc"]],
  "fixedColumns": {
    leftColumns: 5
  },
  dom: 'Bfrtip',
  lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
  buttons: [
    {
      extend: 'copyHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "PrePO_History" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'csvHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "PrePO_History" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'excelHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "PrePO_History" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'pdfHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "PrePO_History" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Purchase/GetPrePOHistory",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.prePOId = $('#prePOId').val();
    }
  },
  "columns": [
    { "data": "prePOHistoryId", "visible": false },
    {
      "data": "isEdited",
      "render": function (data, type, row) {
        if (data === true) {
          return '<input type="checkbox" class="editor-active" onclick="return false;" checked>';
        } else {
          return '<input type="checkbox" onclick="return false;" class="editor-active">';
        }
        return data;
      },
      className: "dt-body-center text-center",
      "width": "5%"
    },
    { "data": "revNo", "width": "10%", "className": "text-right" },
    { "data": "modifiedBy", "width": "10%", "className": "text-right" },
    { "data": "modifiedDate", "width": "10%", "className": "text-right" },
    { "data": "sku", "width": "20%", "className": "text-right" },
    { "data": "poChannel", "width": "10%", "className": "text-right" },
    { "data": "requestedQty", "width": "10%", "className": "text-right" },
    { "data": "requestorsNote", "width": "10%", "className": "text-right" },
    { "data": "mustETADate", "width": "20%", "className": "text-right" },
    { "data": "mgmtAdjQty", "width": "10%", "className": "text-right" },
    { "data": "mgmtsNote", "width": "10%", "className": "text-right" },
    { "data": "logisticsConfirmedQty", "width": "10%", "className": "text-right" },
    { "data": "logisticsChosenVendor", "width": "10%", "className": "text-right" },
    { "data": "logisticsAcceptanceNote", "width": "10%", "className": "text-right" },
    { "data": "logisticsMustETADate", "width": "10%", "className": "text-right" },
    { "data": "logisticsEtd_c", "width": "10%", "className": "text-right" },
    { "data": "logisticsPONoNote", "width": "10%", "className": "text-right" },
    { "data": "prePOStatus", "visible": false }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "185%"
});
//}

//poAccptDashboardHistoryItems