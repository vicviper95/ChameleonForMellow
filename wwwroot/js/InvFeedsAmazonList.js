var dataTable;
var dataTable2;
var dataTable3;
var tmpDate = new Date();
var historyDate = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();
document.getElementById('historyDateHidden').value = historyDate;

$(document).ready(function () {
  historyDatePicker();
  $("#historyDatePicker").val(historyDate);

  getInvFeedsReportDate();

  //invFeedsAmazonBancTable;
  //invFeedsAmazonBascTable;
  invFeedsAmazonMainslTable;
  //invFeedsAmazonSwcaftTable;
  //invFeedsAmazonPrismCastTable;
  invFeedsAmazonZinusTracyTable;
  invFeedsAmazonZinusChsTable;
  //loadDataTable();
});


// For waiting indicator
$body = $("body");

$(document).on({
  ajaxStart: function () { $body.addClass("loading"); },
  ajaxStop: function () { $body.removeClass("loading"); }
});

// Date Indicator
function getInvFeedsReportDate() {
  document.getElementById("invFeedsRepDate").innerHTML = "This report is for " + historyDate + ".";
}

//-----------calender----------
function historyDatePicker() {
  $("#historyDatePicker").datepicker(
    {
      //defaultDate: historyDate
    }
  );
}
//-----------------------------

window.addEventListener('resize', function (event) {
  // do stuff here
  setTimeout(function () {
    invFeedsAmazonMainslTable.columns.adjust();
    invFeedsAmazonZinusTracyTable.columns.adjust();
    invFeedsAmazonZinusChsTable.columns.adjust();
  }, 500);
});


$("#reloadAmazonFeedsHistory").click(function () {
  historyDate = $("#historyDatePicker").datepicker("getDate");
  historyDate = (historyDate.getMonth() + 1) + '/' + historyDate.getDate() + '/' + historyDate.getFullYear();
   document.getElementById('historyDateHidden').value = historyDate;
  getInvFeedsReportDate();
  //invFeedsAmazonBancTable.ajax.reload();
  //invFeedsAmazonBascTable.ajax.reload();
  invFeedsAmazonMainslTable.ajax.reload();
  //invFeedsAmazonSwcaftTable.ajax.reload();
  //invFeedsAmazonPrismCastTable.ajax.reload();
  invFeedsAmazonZinusTracyTable.ajax.reload();
  invFeedsAmazonZinusChsTable.ajax.reload();
})

var invFeedsAmazonMainslTable = $("#invFeedsAmazonMainslItems").DataTable({
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
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        var loc = "Mainsl";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "Mainsl";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "Mainsl";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetAmazonMainslInvFeeds",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "sku", "width": "11%" },
    { "data": "upc", "width": "11%" },
    { "data": "asin", "width": "11%" },
    { "data": "title", "width": "12" },
    { "data": "warehouseId", "width": "11%" },
    { "data": "warehouseName", "width": "11%" },
    { "data": "qtyAvail", "width": "11%" },
    { "data": "status", "width": "11%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});

/*
var invFeedsAmazonBancTable = $("#invFeedsAmazonBancItems").DataTable({
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
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        var loc = "BANC";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "BANC";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "BANC";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetAmazonBancInvFeeds",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "sku", "width": "11%" },
    { "data": "upc", "width": "11%" },
    { "data": "asin", "width": "11%" },
    { "data": "title", "width": "12" },
    { "data": "warehouseId", "width": "11%" },
    { "data": "warehouseName", "width": "11%" },
    { "data": "qtyAvail", "width": "11%" },
    { "data": "status", "width": "11%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});
*/
/*
var invFeedsAmazonBascTable = $("#invFeedsAmazonBascItems").DataTable({
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
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        var loc = "BASC";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "BASC";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "BASC";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetAmazonBascInvFeeds",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "sku", "width": "11%" },
    { "data": "upc", "width": "11%" },
    { "data": "asin", "width": "11%" },
    { "data": "title", "width": "12" },
    { "data": "warehouseId", "width": "11%" },
    { "data": "warehouseName", "width": "11%" },
    { "data": "qtyAvail", "width": "11%" },
    { "data": "status", "width": "11%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});
*/

/*
var invFeedsAmazonSwcaftTable = $("#invFeedsAmazonSWCAFTItems").DataTable({
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
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        var loc = "SWCA-FT";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "SWCA-FT";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "SWCA-FT";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetAmazonSWCAFTInvFeeds",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "sku", "width": "11%" },
    { "data": "upc", "width": "11%" },
    { "data": "asin", "width": "11%" },
    { "data": "title", "width": "12" },
    { "data": "warehouseId", "width": "11%" },
    { "data": "warehouseName", "width": "11%" },
    { "data": "qtyAvail", "width": "11%" },
    { "data": "status", "width": "11%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});
*/
/*
var invFeedsAmazonPrismCastTable = $("#invFeedsAmazonPrismCastItems").DataTable({
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
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        var loc = "PRISM-CAST";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "PRISM-CAST";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "PRISM-CAST";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetAmazonPrismCastInvFeeds",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "sku", "width": "11%" },
    { "data": "upc", "width": "11%" },
    { "data": "asin", "width": "11%" },
    { "data": "title", "width": "12" },
    { "data": "warehouseId", "width": "11%" },
    { "data": "warehouseName", "width": "11%" },
    { "data": "qtyAvail", "width": "11%" },
    { "data": "status", "width": "11%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});
*/
      
var invFeedsAmazonZinusTracyTable = $("#invFeedsAmazonZinusTracyItems").DataTable({
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
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        var loc = "ZINUS-TRACY";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "ZINUS-TRACY";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "ZINUS-TRACY";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetAmazonZinusTracyInvFeeds",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "sku", "width": "11%" },
    { "data": "upc", "width": "11%" },
    { "data": "asin", "width": "11%" },
    { "data": "title", "width": "12" },
    { "data": "warehouseId", "width": "11%" },
    { "data": "warehouseName", "width": "11%" },
    { "data": "qtyAvail", "width": "11%" },
    { "data": "status", "width": "11%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});


var invFeedsAmazonZinusChsTable = $("#invFeedsAmazonZinusChsItems").DataTable({
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
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        var loc = "ZINUS-CHS";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "ZINUS-CHS";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "ZINUS-CHS";
        return "Amazon_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetAmazonZinusChsInvFeeds",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "sku", "width": "11%" },
    { "data": "upc", "width": "11%" },
    { "data": "asin", "width": "11%" },
    { "data": "title", "width": "12" },
    { "data": "warehouseId", "width": "11%" },
    { "data": "warehouseName", "width": "11%" },
    { "data": "qtyAvail", "width": "11%" },
    { "data": "status", "width": "11%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});