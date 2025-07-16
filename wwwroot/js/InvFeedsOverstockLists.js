var tmpDate = new Date();
var historyDate = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();
document.getElementById('historyDateHidden').value = historyDate;

$(document).ready(function () {
  historyDatePicker();
  $("#historyDatePicker").val(historyDate);

  getInvFeedsReportDate();

  //invFeedsOstBascTable;
  //invFeedsOstBancTable;
  invFeedsOstMainslTable;
  //invFeedsOstSwcaftTable;
  //invFeedsOstPrismCastTable;
  invFeedsOstZinusTracyTable;
  invFeedsOstZinusChsTable;
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
    invFeedsOstMainslTable.columns.adjust();
    invFeedsOstZinusTracyTable.columns.adjust();
    invFeedsOstZinusChsTable.columns.adjust();
  }, 500);
});


// Date Indicator
function getInvFeedsReportDate() {
  document.getElementById("invFeedsRepDate").innerHTML = "This report is for " + historyDate + ".";
}


//-----------calender----------
var today = new Date();
function historyDatePicker() {
  $("#historyDatePicker").datepicker(
    {
      //defaultDate: historyDate
    }
  );
  //console.log($("#historyDatePicker"));
}
//-----------------------------


$("#reloadOverstockFeedsHistory").click(function () {
  historyDate = $("#historyDatePicker").datepicker("getDate");
  historyDate = (historyDate.getMonth() + 1) + '/' + historyDate.getDate() + '/' + historyDate.getFullYear();
  document.getElementById('historyDateHidden').value = historyDate;
  getInvFeedsReportDate();

  invFeedsOstBascTable.ajax.reload();
  invFeedsOstBancTable.ajax.reload();
  invFeedsOstMainslTable.ajax.reload();
  //invFeedsOstSwcaftTable.ajax.reload();
  //invFeedsOstPrismCastTable.ajax.reload();
  invFeedsOstZinusTracyTable.ajax.reload();
  invFeedsOstZinusChsTable.ajax.reload();
})


var invFeedsOstBancTable = $("#invFeedsOstBanc").DataTable({
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetInvFeedsOstBanc",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
        d.historyDate = $('#historyDateHidden').val();
    } 
  },
  "columns": [
    { "data": "supplierSKU", "width": "35%" },
    { "data": "qty", "width": "30%" },
    { "data": "warehouseName", "width": "35%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});


var invFeedsOstBascTable = $("#invFeedsOstBasc").DataTable({
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetInvFeedsOstBasc",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
        d.historyDate = $('#historyDateHidden').val();
    } 
  },
  "columns": [
    { "data": "supplierSKU", "width": "35%" },
    { "data": "qty", "width": "30%" },
    { "data": "warehouseName", "width": "35%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});

var invFeedsOstMainslTable = $("#invFeedsOstMainsl").DataTable({
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetInvFeedsOstMainsl",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    } 
  },
  "columns": [
    { "data": "supplierSKU", "width": "35%" },
    { "data": "qty", "width": "30%" },
    { "data": "warehouseName", "width": "35%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});
/*
var invFeedsOstSwcaftTable = $("#invFeedsOstSWCAFT").DataTable({
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
        var loc = "SWCAFT";
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "SWCAFT";
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
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
        var loc = "SWCAFT";
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetInvFeedsOstSWCAFT",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    } 
  },
  "columns": [
    { "data": "supplierSKU", "width": "35%" },
    { "data": "qty", "width": "30%" },
    { "data": "warehouseName", "width": "35%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});

var invFeedsOstPrismCastTable = $("#invFeedsOstPrismCast").DataTable({
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetInvFeedsOstPrismCast",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "supplierSKU", "width": "35%" },
    { "data": "qty", "width": "30%" },
    { "data": "warehouseName", "width": "35%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});
*/
var invFeedsOstZinusTracyTable = $("#invFeedsOstZinusTracy").DataTable({
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetInvFeedsOstZinusTracy",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "supplierSKU", "width": "35%" },
    { "data": "qty", "width": "30%" },
    { "data": "warehouseName", "width": "35%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});


var invFeedsOstZinusChsTable = $("#invFeedsOstZinusChs").DataTable({
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
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
        return "Overstock_" + loc + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetInvFeedsOstZinusChs",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "supplierSKU", "width": "35%" },
    { "data": "qty", "width": "30%" },
    { "data": "warehouseName", "width": "35%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});