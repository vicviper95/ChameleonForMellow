var dataTable01;
var dataTable02;
var dataTable03;
var custId;
var custStr;
var warehouseLoc;
var result;
var tmpDate = new Date();
var today = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();

$(document).ready(function () {
  fromDatePicker();
  fromWayfairDatePicker();
  loadDataTable();
});

// Waiting Indicator
$body = $("body");

$(document).on({
  ajaxStart: function () { $body.addClass("loading"); },
  ajaxStop: function () { $body.removeClass("loading"); }
});

$(function () {
  $("#compareInvFeedsTabs").tabs();
});


function fromDatePicker() {
  $("#fromDatePicker").datepicker(
    {
      defaultDate: today // historyDate
    }
  );
  console.log($("#fromDatePicker"));
}

function fromWayfairDatePicker() {
  $("#fromWayfairDatePicker").datepicker(
    {
      defaultDate: today // historyDate
    }
  );
  console.log($("#fromWayfairDatePicker"));
}


function openFEEDSCSVAttachment() {
  var e = document.getElementById("customerId");
  today = $("#fromDatePicker").datepicker("getDate");
  var exit = false;
  if (e.value == '5') { custId = 5; custStr = "Amazon"; }
  else if (e.value == '21') { custId = 21; custStr = "Overstock"; }
  else if (e.value == '26') { custId = 26; custStr = "Walmart"; }
  else if (e.value == '51') { custId = 51; custStr = "Target"; }
  else {
    swal("Error:", "Choose a customer!");
    exit = true;
  }
  //if (exit == true) return false;
  var e = document.getElementById("warehouseId");
  if (e.value == '4') { warehouseLoc = 4; }
  else if (e.value == '25') { warehouseLoc = 25; }
  else if (e.value == '54') { warehouseLoc = 54; }
  else if (e.value == '62') { warehouseLoc = 62; }
  else {
    swal("Attention:", "Choose a warehouse!", "Error");
    return;
  }
  if (exit == true) return;
  document.getElementById('UserFeedsAttachment').addEventListener('change', csvJSON, false);

}


function openWFEEDSCSVAttachment() {
  today = $("#fromWayfairDatePicker").datepicker("getDate");
  custId = 29;
  custStr = "Wayfair";
  document.getElementById('UserFeedsWayfairAttachment').addEventListener('change', csvJSON, false);
}

// For Home Depot
function openHDFEEDSCSVAttachment() {
  today = $("#fromHomeDepotDatePicker").datepicker("getDate");
  custId = 40;
  custStr = "HomeDepot";
  document.getElementById('UserFeedsHomeDepotAttachment').addEventListener('change', csvJSON, false);
}


function csvJSON(e) {
  var file = e.target.files[0];
  if (!file) return;
  var reader = new FileReader();
  reader.onload = function (e) {
    var contents = e.target.result;
    getJSON(contents);
  };
  reader.readAsText(file);
}




function getJSON(contents) {
  if (custId == 29) {
    const lines = contents.split('\n');
    const jsonArray = [];
    const headers = lines[0].split(',');
    let lengthLimit = 0;

    for (let k = 0; k < headers.length; k++) {
      headers[k] = headers[k].replace(/\s+/g, '');
    }

    for (let i = 1; i < lines.length; i++) {
      if (!lines[i])
        continue;
      const obj = {};
      const currentline = lines[i].split(',');
      lengthLimit = 3; // Supplier ID, Supplier Part#, Quantity On Hand
      for (let j = 0; j < lengthLimit; j++) {
        obj[headers[j]] = currentline[j];
      }
      jsonArray.push(obj);
    }

    var returnResult = new Object();
    returnResult.customerId = custId;
    returnResult.historyDate = today;
    returnResult.feedsList = jsonArray;
    result = JSON.stringify(returnResult);
    console.log(result);

    $("#invFeedsCompareWayfairUserAutoItems").DataTable({
      "destroy": true,
      "order": [[0, "asc"]],
      dom: 'Bfrtip',
      lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
      buttons: [
        {
          extend: 'copyHtml5',
          filename: function () {
            var tmpToday = new Date();
            var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
            // var loc = "Mainsl";
            return custStr + "_" + todayDate;
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
            // var loc = "Mainsl";
            return custStr + "_" + todayDate;
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
            // var loc = "Mainsl";
            return custStr + "_" + todayDate;
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
            // var loc = "Mainsl";
            return custStr + "_" + todayDate;
          },
          exportOptions: {
            columns: ':visible'
          }
        },
        'colvis', 'pageLength'
      ],
      ajax: {
        "url": "/Inventory/CompareWayfairInventoryFeeds",
        "type": 'POST',
        "dataType": 'json',
        "contentType": "application/json charset=utf-8",
        "dataSrc": "",
        "data": function (d) {
          return result;
        }
      },
      "columns": [
        { "data": "bpmSku", "width": "8%", "className": "text-right" },
        { "data": "itemStatus", "width": "6%", "className": "text-left" },
        { "data": "description", "width": "10%", "className": "text-left" },
        { "data": "totalQtyBanc", "width": "6%", "className": "text-right" },
        { "data": "totalQtyMainsl", "width": "6%", "className": "text-right" },
        { "data": "custSku", "width": "8%", "className": "text-left" },
        { "data": "manualFeedsQtyBanc", "width": "6%", "className": "text-left" },
        { "data": "chameleonFeedsQtyBanc", "width": "6%", "className": "text-left" },
        { "data": "appliedRuleBanc", "width": "10%", "className": "text-left" },
        { "data": "manualFeedsQtyMainsl", "width": "6%", "className": "text-left" },
        { "data": "chameleonFeedsQtyMainsl", "width": "6%", "className": "text-left" },
        { "data": "appliedRuleMainsl", "width": "10%", "className": "text-left" },
        { "data": "etc", "width": "10%", "className": "text-left" }
      ],
      "language": {
        "emptyTable": "no data found"
      },
      "width": "98%"
    });

  } else if (custId == 40) {
    const lines = contents.split('\n');
    const jsonArray = [];
    const headers = lines[0].split(',');
    let lengthLimit = 0;

    for (let k = 0; k < headers.length; k++) {
      headers[k] = headers[k].replace(/\s+/g, '');
    }

    for (let i = 1; i < lines.length; i++) {
      if (!lines[i])
        continue;
      const obj = {};
      const currentline = lines[i].split(',');
      lengthLimit = 11; // Supplier ID, Supplier Part#, Quantity On Hand
      for (let j = 0; j < lengthLimit; j++) {
        obj[headers[j]] = currentline[j];
      }
      jsonArray.push(obj);
    }

    var returnResult = new Object();
    returnResult.customerId = custId;
    returnResult.historyDate = today;
    returnResult.feedsList = jsonArray;
    result = JSON.stringify(returnResult);
    console.log(result);

    $("#invFeedsCompareHomeDepotUserAutoItems").DataTable({
      "destroy": true,
      "scrollX": true,
      "scrollCollapse": true,
      //"paging": false,
      "autoWidth": false,
      columnDefs: [
        {
          targets: -1,
          className: 'dt-body-right'
        }
      ],
      "order": [[1, "asc"]],
      dom: 'Bfrtip',
      lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
      buttons: [
        {
          extend: 'copyHtml5',
          exportOptions: {
            columns: ':visible'
          }
        },
        {
          extend: 'csvHtml5',
          exportOptions: {
            columns: ':visible'
          }
        },
        {
          extend: 'excelHtml5',
          exportOptions: {
            columns: ':visible'
          }
        },
        {
          extend: 'pdfHtml5',
          exportOptions: {
            columns: ':visible'
          }
        },
        'colvis', 'pageLength'
      ],
      ajax: {
        "url": "/Inventory/CompareHomeDepotInventoryFeeds",
        "type": 'POST',
        "dataType": 'json',
        "contentType": "application/json charset=utf-8",
        "dataSrc": "",
        "data": function (d) {
          return result;
        }
      },
      "columns": [
        { "data": "bpmSku", "width": "15%", "className": "text-right" },
        { "data": "itemStatus", "width": "10%", "className": "text-left" },
        { "data": "description", "width": "15%", "className": "text-left" },
        { "data": "totalQtyMainsl", "width": "10%", "className": "text-right" },
        { "data": "totalQtySwcaft", "width": "10%", "className": "text-right" },
        { "data": "totalQtyBanc", "width": "10%", "className": "text-right" },
        { "data": "totalQtyBasc", "width": "10%", "className": "text-right" },
        { "data": "custSku", "width": "15%", "className": "text-left" },
        { "data": "manualFeedsQtyMainsl", "width": "10%", "className": "text-left" },
        { "data": "chameleonFeedsQtyMainsl", "width": "10%", "className": "text-left" },
        { "data": "appliedRuleMainsl", "width": "10%", "className": "text-left" },
        { "data": "manualFeedsQtySwcaft", "width": "10%", "className": "text-left" },
        { "data": "chameleonFeedsQtySwcaft", "width": "10%", "className": "text-left" },
        { "data": "appliedRuleSwcaft", "width": "10%", "className": "text-left" },
        { "data": "manualFeedsQtyBanc", "width": "10%", "className": "text-left" },
        { "data": "chameleonFeedsQtyBanc", "width": "10%", "className": "text-left" },
        { "data": "appliedRuleBanc", "width": "10%", "className": "text-left" },
        { "data": "manualFeedsQtyBasc", "width": "10%", "className": "text-left" },
        { "data": "chameleonFeedsQtyBasc", "width": "10%", "className": "text-left" },
        { "data": "appliedRuleBasc", "width": "10%", "className": "text-left" },
        { "data": "etc", "width": "10%", "className": "text-left" }
      ],
      "language": {
        "emptyTable": "no data found"
      },
      "width": "225%"
    });

  } else {
    const lines = contents.split('\n');
    const jsonArray = [];
    const headers = lines[0].split(',');
    let lengthLimit = 0;

    for (let k = 0; k < headers.length; k++) {
      headers[k] = headers[k].replace(/\s+/g, '');
    }

    for (let i = 1; i < lines.length; i++) {
      if (!lines[i])
        continue;
      const obj = {};
      const currentline = lines[i].split(',');
      lengthLimit = 2;
      for (let j = 0; j < lengthLimit; j++) {
        obj[headers[j]] = currentline[j];
      }
      jsonArray.push(obj);
    }

    var returnResult = new Object();
    returnResult.customerId = custId;
    returnResult.historyDate = today;
    returnResult.BpmLocId = warehouseLoc;
    returnResult.feedsList = jsonArray;
    result = JSON.stringify(returnResult);
    console.log(result);

    //AmazonFeedsListImportDTO.push(returnResult);

    $("#invFeedsCompareUserAutoItems").DataTable({
      "destroy": true,
      "order": [[0, "asc"]],
      dom: 'Bfrtip',
      lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
      buttons: [
        {
          extend: 'copyHtml5',
          filename: function () {
            var tmpToday = new Date();
            var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
            // var loc = "Mainsl";
            return custStr + "_" + todayDate;
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
            // var loc = "Mainsl";
            return custStr + "_" + todayDate;
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
            // var loc = "Mainsl";
            return custStr + "_" + todayDate;
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
            // var loc = "Mainsl";
            return custStr + "_" + todayDate;
          },
          exportOptions: {
            columns: ':visible'
          }
        },
        'colvis', 'pageLength'
      ],
      ajax: {
        "url": "/Inventory/CompareInventoryFeeds",
        "type": 'POST',
        "dataType": 'json',
        "contentType": "application/json charset=utf-8",
        "dataSrc": "",
        "data": function (d) {
          return result;
        }
      },
      "columns": [
        { "data": "bpmSku", "width": "5%", "className": "text-right" },
        { "data": "itemStatus", "width": "5%", "className": "text-left" },
        { "data": "description", "width": "18%", "className": "text-left" },
        { "data": "totalQty", "width": "5%", "className": "text-right" },
        { "data": "custSku", "width": "5%", "className": "text-left" },
        { "data": "manualFeedsQty", "width": "5%", "className": "text-right" },
        { "data": "chameleonFeedsQty", "width": "5%", "className": "text-right" },
        { "data": "appliedRule", "width": "10%", "className": "text-left" },
        { "data": "etc", "width": "10%", "className": "text-left" }
      ],
      "language": {
        "emptyTable": "no data found"
      },
      "width": "68%"
    });
  } // the end of else

}



function loadDataTable() {
  dataTable01 = $("#invFeedsCompareUserAutoItems").DataTable({
    "destroy": true,
    columnDefs: [
      {
        targets: -1,
        className: 'dt-body-right'
      }
    ],
    "order": [[1, "asc"]],
    dom: 'Bfrtip',
    lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
    buttons: [
      {
        extend: 'copyHtml5',
        exportOptions: {
          columns: ':visible'
        }
      },
      {
        extend: 'csvHtml5',
        exportOptions: {
          columns: ':visible'
        }
      },
      {
        extend: 'excelHtml5',
        exportOptions: {
          columns: ':visible'
        }
      },
      {
        extend: 'pdfHtml5',
        exportOptions: {
          columns: ':visible'
        }
      },
      'colvis', 'pageLength'
    ],
    "columns": [
      { "data": "bpmSku", "width": "5%", "className": "text-right" },
      { "data": "itemStatus", "width": "5%", "className": "text-left" },
      { "data": "description", "width": "18%", "className": "text-left" },
      { "data": "totalQty", "width": "5%", "className": "text-right" },
      { "data": "custSku", "width": "5%", "className": "text-left" },
      { "data": "manualFeedsQty", "width": "5%", "className": "text-right" },
      { "data": "chameleonFeedsQty", "width": "5%", "className": "text-right" },
      { "data": "appliedRule", "width": "10%", "className": "text-left" },
      { "data": "etc", "width": "10%", "className": "text-left" }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "68%"
  });

  dataTable02 = $("#invFeedsCompareWayfairUserAutoItems").DataTable({
    "destroy": true,
    columnDefs: [
      {
        targets: -1,
        className: 'dt-body-right'
      }
    ],
    "order": [[1, "asc"]],
    dom: 'Bfrtip',
    lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
    buttons: [
      {
        extend: 'copyHtml5',
        exportOptions: {
          columns: ':visible'
        }
      },
      {
        extend: 'csvHtml5',
        exportOptions: {
          columns: ':visible'
        }
      },
      {
        extend: 'excelHtml5',
        exportOptions: {
          columns: ':visible'
        }
      },
      {
        extend: 'pdfHtml5',
        exportOptions: {
          columns: ':visible'
        }
      },
      'colvis', 'pageLength'
    ],
    "columns": [
      { "data": "bpmSku", "width": "8%", "className": "text-right" },
      { "data": "itemStatus", "width": "6%", "className": "text-left" },
      { "data": "description", "width": "10%", "className": "text-left" },
      { "data": "totalQtyBanc", "width": "6%", "className": "text-right" },
      { "data": "totalQtyMainsl", "width": "6%", "className": "text-right" },
      { "data": "custSku", "width": "8%", "className": "text-left" },
      { "data": "manualFeedsQtyBanc", "width": "6%", "className": "text-left" },
      { "data": "chameleonFeedsQtyBanc", "width": "6%", "className": "text-left" },
      { "data": "appliedRuleBanc", "width": "10%", "className": "text-left" },
      { "data": "manualFeedsQtyMainsl", "width": "6%", "className": "text-left" },
      { "data": "chameleonFeedsQtyMainsl", "width": "6%", "className": "text-left" },
      { "data": "appliedRuleMainsl", "width": "10%", "className": "text-left" },
      { "data": "etc", "width": "10%", "className": "text-left" }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "98%"
  });

  dataTable03 = $("#invFeedsCompareHomeDepotUserAutoItems").DataTable({
    "destroy": true,
    "scrollX": true,
    "scrollCollapse": true,
    //"paging": false,
    "autoWidth": false,
    columnDefs: [
      {
        targets: -1,
        className: 'dt-body-right'
      }
    ],
    "order": [[1, "asc"]],
    dom: 'Bfrtip',
    lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
    buttons: [
      {
        extend: 'copyHtml5',
        exportOptions: {
          columns: ':visible'
        }
      },
      {
        extend: 'csvHtml5',
        exportOptions: {
          columns: ':visible'
        }
      },
      {
        extend: 'excelHtml5',
        exportOptions: {
          columns: ':visible'
        }
      },
      {
        extend: 'pdfHtml5',
        exportOptions: {
          columns: ':visible'
        }
      },
      'colvis', 'pageLength'
    ],
    "columns": [
      { "data": "bpmSku", "width": "15%", "className": "text-right" },
      { "data": "itemStatus", "width": "10%", "className": "text-left" },
      { "data": "description", "width": "15%", "className": "text-left" },
      { "data": "totalQtyMainsl", "width": "10%", "className": "text-right" },
      { "data": "totalQtySwcaft", "width": "10%", "className": "text-right" },
      { "data": "totalQtyBanc", "width": "10%", "className": "text-right" },
      { "data": "totalQtyBasc", "width": "10%", "className": "text-right" },
      { "data": "custSku", "width": "15%", "className": "text-left" },
      { "data": "manualFeedsQtyMainsl", "width": "10%", "className": "text-left" },
      { "data": "chameleonFeedsQtyMainsl", "width": "10%", "className": "text-left" },
      { "data": "appliedRuleMainsl", "width": "10%", "className": "text-left" },
      { "data": "manualFeedsQtySwcaft", "width": "10%", "className": "text-left" },
      { "data": "chameleonFeedsQtySwcaft", "width": "10%", "className": "text-left" },
      { "data": "appliedRuleSwcaft", "width": "10%", "className": "text-left" },
      { "data": "manualFeedsQtyBanc", "width": "10%", "className": "text-left" },
      { "data": "chameleonFeedsQtyBanc", "width": "10%", "className": "text-left" },
      { "data": "appliedRuleBanc", "width": "10%", "className": "text-left" },
      { "data": "manualFeedsQtyBasc", "width": "10%", "className": "text-left" },
      { "data": "chameleonFeedsQtyBasc", "width": "10%", "className": "text-left" },
      { "data": "appliedRuleBasc", "width": "10%", "className": "text-left" },
      { "data": "etc", "width": "10%", "className": "text-left" }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "225%"
  });

}
//


