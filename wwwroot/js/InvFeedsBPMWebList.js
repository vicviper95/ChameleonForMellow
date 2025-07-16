var dataTable;
var tmpDate = new Date();
var historyDate = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();
document.getElementById('historyDateHidden').value = historyDate;


$(document).ready(function () {
  historyDatePicker();
  getInvFeedsReportDate();
  loadDataTable();
});


// For waiting indicator
$body = $("body");

$(document).on({
  ajaxStart: function () { $body.addClass("loading"); },
  ajaxStop: function () { $body.removeClass("loading"); }
});


window.addEventListener('resize', function (event) {
  // do stuff here
  setTimeout(function () {
    dataTable.columns.adjust();
  }, 500);
});

// Date Indicator
function getInvFeedsReportDate() {
  document.getElementById("invFeedsRepDate").innerHTML = "This report is for " + historyDate + ".";
}

//-----------calender----------
function historyDatePicker() {
  $("#historyDatePicker").datepicker(
    {
      defaultDate: historyDate
    }
  );
  console.log($("#historyDatePicker"));
}
//-----------------------------


$("#reloadBPMWebFeedsHistory").click(function () {
  historyDate = $("#historyDatePicker").datepicker("getDate");
  historyDate = (historyDate.getMonth() + 1) + '/' + historyDate.getDate() + '/' + historyDate.getFullYear();
  document.getElementById('historyDateHidden').value = historyDate;
  getInvFeedsReportDate();
  dataTable = $("#invFeedsBPMWebItems").DataTable({
    destroy: true,
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
        fieldBoundary: '',
        filename: function () {
          var tmpToday = new Date($('#historyDateHidden').val());
          var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
          var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
          //var loc = "Mainsl";
          return "BPM_Web_" + todayDate + "_" + todatyTime;
        },
        exportOptions: {
          columns: ':visible'
        }
      },
      {
        extend: 'excelHtml5',
        title: '',
        filename: function () {
          var tmpToday = new Date($('#historyDateHidden').val());
          var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
          var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
          //var loc = "Mainsl";
          return "BPM_Web_" + todayDate + "_" + todatyTime;
        },
        exportOptions: {
          columns: ':visible'
        }
      },
      {
        extend: 'pdfHtml5',
        filename: function () {
          var tmpToday = new Date($('#historyDateHidden').val());
          var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
          var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
          //var loc = "Mainsl";
          return "BPM_Web_" + todayDate + "_" + todatyTime;
        },
        exportOptions: {
          columns: ':visible'
        }
      },
      'colvis', 'pageLength'
    ],
    "ajax": {
      "url": "/Inventory/GetShopifyInvFeeds",
      "type": "GET",
      "datatype": "json",
      "dataSrc": "",
      "data": function (d) {
        d.customerId = 9,
        d.historyDate = $('#historyDateHidden').val();
      } 
    },
    "columns": [
      { "data": "handle", "width": "10%" },
      { "data": "title", "width": "10%" },
      { "data": "option1Name", "width": "5%" },
      { "data": "option1Value", "width": "7%" },
      { "data": "option2Name", "width": "5%" },
      { "data": "option2Value", "width": "7%" },
      { "data": "option3Name", "width": "5%" },
      { "data": "option3Value", "width": "7%" },
      { "data": "sku", "width": "10" },
      { "data": "hsCode", "width": "4%" },
      { "data": "coo", "width": "4%" },
      { "data": "location", "width": "10%" },
      { "data": "incoming", "width": "4%" },
      { "data": "unavailable", "width": "4%" },
      { "data": "committed", "width": "4%" },
      { "data": "qtyAvail", "width": "4%" },
      { "data": "qtyAvail", "width": "4%" }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "104%"
  });

})

function loadDataTable() {
  dataTable = $("#invFeedsBPMWebItems").DataTable({
    destroy: true,
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
        fieldBoundary: '',
        filename: function () {
          var tmpToday = new Date($('#historyDateHidden').val());
          var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
          var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
          //var loc = "Mainsl";
          return "BPM_Web_" + todayDate + "_" + todatyTime;
        },
        exportOptions: {
          columns: ':visible'
        }
      },
      {
        extend: 'excelHtml5',
        title: '',
        filename: function () {
          var tmpToday = new Date($('#historyDateHidden').val());
          var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
          var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
          //var loc = "Mainsl";
          return "BPM_Web_" + todayDate + "_" + todatyTime;
        },
        exportOptions: {
          columns: ':visible'
        }
      },
      {
        extend: 'pdfHtml5',
        filename: function () {
          var tmpToday = new Date($('#historyDateHidden').val());
          var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
          var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
          //var loc = "Mainsl";
          return "BPM_Web_" + todayDate + "_" + todatyTime;
        },
        exportOptions: {
          columns: ':visible'
        }
      },
      'colvis', 'pageLength'
    ],
    "ajax": {
      "url": "/Inventory/GetShopifyInvFeeds",
      "type": "GET",
      "datatype": "json",
      "dataSrc": "",
      "data": function (d) {
        d.customerId = 9,
        d.historyDate = $('#historyDateHidden').val();
      } 
    },
    "columns": [
      { "data": "handle", "width": "10%" },
      { "data": "title", "width": "10%" },
      { "data": "option1Name", "width": "5%" },
      { "data": "option1Value", "width": "7%" },
      { "data": "option2Name", "width": "5%" },
      { "data": "option2Value", "width": "7%" },
      { "data": "option3Name", "width": "5%" },
      { "data": "option3Value", "width": "7%" },
      { "data": "sku", "width": "10" },
      { "data": "hsCode", "width": "4%" },
      { "data": "coo", "width": "4%" },
      { "data": "location", "width": "10%" },
      { "data": "incoming", "width": "4%" },
      { "data": "unavailable", "width": "4%" },
      { "data": "committed", "width": "4%" },
      { "data": "qtyAvail", "width": "4%" },
      { "data": "qtyAvail", "width": "4%" }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "104%"
  });
}