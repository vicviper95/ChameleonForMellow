var tmpDate = new Date();
var historyDate = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();
document.getElementById('historyDateHidden').value = historyDate;

$(document).ready(function () {
  historyDatePicker();
  $("#historyDatePicker").val(historyDate);
  getInvFeedsReportDate();

  //document.getElementById('historyDateHidden').value = historyDate;
  //invFeedsWalmartBancTable;
  //invFeedsWalmartBascTable;
  invFeedsWalmartMainslTable;
  //invFeedsWalmartSwcaftTable;
  //invFeedsWalmartPrismCastTable;
  invFeedsWalmartZinusTracyTable;
  invFeedsWalmartZinusChsTable;
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
    invFeedsWalmartMainslTable.columns.adjust();
    invFeedsWalmartZinusTracyTable.columns.adjust();
    invFeedsWalmartZinusChsTable.columns.adjust();
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
     // defaultDate: historyDate
    }
  );
  //console.log($("#historyDatePicker"));
}
//-----------------------------


$("#reloadWalmartFeedsHistory").click(function () {
  historyDate = $("#historyDatePicker").datepicker("getDate");
  historyDate = (historyDate.getMonth() + 1) + '/' + historyDate.getDate() + '/' + historyDate.getFullYear();
  document.getElementById('historyDateHidden').value = historyDate;
  console.log("Date is " + $('#historyDateHidden').val() );
  getInvFeedsReportDate();

  invFeedsWalmartBancTable.ajax.reload();
  invFeedsWalmartBascTable.ajax.reload();
  invFeedsWalmartMainslTable.ajax.reload();
  //invFeedsWalmartSwcaftTable.ajax.reload();
  //invFeedsWalmartPrismCastTable.ajax.reload();
  invFeedsWalmartZinusTracyTable.ajax.reload();
  invFeedsWalmartZinusChsTable.ajax.reload();

})

var invFeedsWalmartBancTable = $("#invFeedsWalmartBanc").DataTable({
  dom: 'Bfrtip',
  lengthMenu: [[15, 25, 50, 100], [15, 25, 50, 100]],
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
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'excelHtml5',
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        var loc = "BANC";
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetInvFeedsWlmrtBanc",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
        d.historyDate = $('#historyDateHidden').val();
    } 
  },
  "columns": [
    { "data": "sku", "width": "30%" },
    { "data": "availabilityCode", "width": "30%" },
    { "data": "qty", "width": "20%" },
    { "data": "fulfillmentLagTime", "width": "25%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});

var invFeedsWalmartBascTable = $("#invFeedsWalmartBasc").DataTable({
  dom: 'Bfrtip',
  lengthMenu: [[15, 25, 50, 100], [15, 25, 50, 100]],
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
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'excelHtml5',
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        var loc = "BASC";
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetInvFeedsWlmrtBasc",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    } 
  },
  "columns": [
    { "data": "sku", "width": "30%" },
    { "data": "availabilityCode", "width": "30%" },
    { "data": "qty", "width": "20%" },
    { "data": "fulfillmentLagTime", "width": "25%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});

var invFeedsWalmartMainslTable = $("#invFeedsWalmartMainsl").DataTable({
  dom: 'Bfrtip',
  lengthMenu: [[15, 25, 50, 100], [15, 25, 50, 100]],
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
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'excelHtml5',
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        var loc = "Mainsl";
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetInvFeedsWlmrtMainsl",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    } 
  },
  "columns": [
    { "data": "sku", "width": "30%" },
    { "data": "availabilityCode", "width": "30%" },
    { "data": "qty", "width": "20%" },
    { "data": "fulfillmentLagTime", "width": "25%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});
/*
var invFeedsWalmartSwcaftTable = $("#invFeedsWalmartSwcaft").DataTable({
  dom: 'Bfrtip',
  lengthMenu: [[15, 25, 50, 100], [15, 25, 50, 100]],
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
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'excelHtml5',
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        var loc = "SWCA-FT";
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetInvFeedsWlmrtSWCAFT",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    } 
  },
  "columns": [
    { "data": "sku", "width": "30%" },
    { "data": "availabilityCode", "width": "30%" },
    { "data": "qty", "width": "20%" },
    { "data": "fulfillmentLagTime", "width": "25%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});


var invFeedsWalmartPrismCastTable = $("#invFeedsWalmartPrismCast").DataTable({
  dom: 'Bfrtip',
  lengthMenu: [[15, 25, 50, 100], [15, 25, 50, 100]],
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
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'excelHtml5',
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        var loc = "PRISM-CAST";
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetInvFeedsWlmrtPrismCast",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "sku", "width": "30%" },
    { "data": "availabilityCode", "width": "30%" },
    { "data": "qty", "width": "20%" },
    { "data": "fulfillmentLagTime", "width": "25%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});
*/

var invFeedsWalmartZinusTracyTable = $("#invFeedsWalmartZinusTracy").DataTable({
  dom: 'Bfrtip',
  lengthMenu: [[15, 25, 50, 100], [15, 25, 50, 100]],
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
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'excelHtml5',
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        var loc = "ZINUS-TRACY";
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetInvFeedsWlmrtZinusTracy",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "sku", "width": "30%" },
    { "data": "availabilityCode", "width": "30%" },
    { "data": "qty", "width": "20%" },
    { "data": "fulfillmentLagTime", "width": "25%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});


var invFeedsWalmartZinusChsTable = $("#invFeedsWalmartZinusChs").DataTable({
  dom: 'Bfrtip',
  lengthMenu: [[15, 25, 50, 100], [15, 25, 50, 100]],
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
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'excelHtml5',
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        var loc = "ZINUS-CHS";
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Walmart_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetInvFeedsWlmrtZinusChs",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "sku", "width": "30%" },
    { "data": "availabilityCode", "width": "30%" },
    { "data": "qty", "width": "20%" },
    { "data": "fulfillmentLagTime", "width": "25%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});

