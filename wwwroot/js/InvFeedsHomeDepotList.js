var dataTable;
var tmpDate = new Date();
var historyDate = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();
document.getElementById('historyDateHidden').value = historyDate;

$(document).ready(function () {
  historyDatePicker();
  $('#historyDatePicker').val(historyDate);

  getInvFeedsReportDate();
  homeDepotFeedDataTable;
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
    homeDepotFeedDataTable.columns.adjust();
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
    }
  );
}
//-----------------------------


$("#reloadeBayFeedsHistory").click(function () {
  historyDate = $("#historyDatePicker").datepicker("getDate");
  historyDate = (historyDate.getMonth() + 1) + '/' + historyDate.getDate() + '/' + historyDate.getFullYear();
  document.getElementById('historyDateHidden').value = historyDate;
  getInvFeedsReportDate();
  homeDepotFeedDataTable.ajax.reload();
})

//var update_size = function () {
//  $(homeDepotFeedDataTable).css({ width: $(homeDepotFeedDataTable).parent().width() });
//  oTable.fnAdjustColumnSizing();
//}

//$(window).resize(function () {
//  clearTimeout(window.refresh_size);
//  window.refresh_size = setTimeout(function () { update_size(); }, 250);
//});



var homeDepotFeedDataTable = $("#invFeedsHomeDepotItems").DataTable({
  destroy: true,
  dom: 'Bfrtip',
  "scrollX": true,
  "scrollCollapse": true,
  //"paging": false,
  "autoWidth": false,
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
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "HomeDepot_" + todayDate + "_" + todatyTime;
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
        return "HomeDepot_" + todayDate + "_" + todatyTime;
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
        return "HomeDepot_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetHomeDepotInvFeeds",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "homeDepotSku", "width": "10%" },
    { "data": "sku", "width": "10%" },
    { "data": "availability", "width": "10%" },
    { "data": "totalQtyOnHand", "width": "10%" },
    { "data": "homeDepotAssignedSku", "width": "10%" },
    { "data": "homeDepotMerchantName", "width": "10%" },
    { "data": "upc", "width": "10%" },
    { "data": "warehouse01Id", "width": "10%" },
    { "data": "warehouse01Qty", "width": "10%" },
    { "data": "warehouse01NextAvailQty", "width": "10%" },
    { "data": "warehouse01NextAvailDate", "width": "10%" },
    { "data": "warehouse02Id", "width": "10%" }, 
    { "data": "warehouse02Qty", "width": "10%" },
    { "data": "warehouse02NextAvailQty", "width": "10%" },
    { "data": "warehouse02NextAvailDate", "width": "10%" },
    { "data": "warehouse03Id", "width": "10%" },
    { "data": "warehouse03Qty", "width": "10%" },
    { "data": "warehouse03NextAvailQty", "width": "10%" },
    { "data": "warehouse03NextAvailDate", "width": "10%" }//,
    //{ "data": "warehouse04Id", "width": "10%" },
    //{ "data": "warehouse04Qty", "width": "10%" },
    //{ "data": "warehouse04NextAvailQty", "width": "10%" },
    //{ "data": "warehouse04NextAvailDate", "width": "10%" },
    //{ "data": "warehouse05Id", "width": "10%" },
    //{ "data": "warehouse05Qty", "width": "10%" },
    //{ "data": "warehouse05NextAvailQty", "width": "10%" },
    //{ "data": "warehouse05NextAvailDate", "width": "10%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "200%"
});