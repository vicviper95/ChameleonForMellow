var dataTable;
var tmpDate = new Date();
var historyDate = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();
document.getElementById('historyDateHidden').value = historyDate;

$(document).ready(function () {
  historyDatePicker();
  $("#historyDatePicker").val(historyDate);
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
      //defaultDate: historyDate
    }
  );
  //console.log($("#historyDatePicker"));
}
//-----------------------------

$("#reloadWayfairFeedsHistory").click(function () {
  historyDate = $("#historyDatePicker").datepicker("getDate");
  historyDate = (historyDate.getMonth() + 1) + '/' + historyDate.getDate() + '/' + historyDate.getFullYear();

  document.getElementById('historyDateHidden').value = historyDate;
  getInvFeedsReportDate();
  dataTable = $("#invFeedsWayfairItems").DataTable({
    destroy: true,
    order: [[1, "asc"]],
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
          return "Wayfair_" + todayDate + "_" + todatyTime;
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
          return "Wayfair_" + todayDate + "_" + todatyTime;
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
          return "Wayfair_" + todayDate + "_" + todatyTime;
        },
        exportOptions: {
          columns: ':visible'
        }
      },
      'colvis', 'pageLength'
    ],
    "ajax": {
      "url": "/Inventory/GetInvFeedsWayfair",
      "type": "GET",
      "datatype": "json",
      "dataSrc": "",
      "data": function (d) {
        d.historyDate = $('#historyDateHidden').val();
      } 
    },
    "columns": [
      { "data": "supplierId", "width": "12%" },
      { "data": "supplierPartNo", "width": "13%" },
      { "data": "qtyOnHand", "width": "12%" },
      { "data": "qtyOnBackOrder", "width": "12%" },
      { "data": "qtyOnOrder", "width": "12%" },
      { "data": "itemNextAvailDate", "width": "12%" },
      { "data": "discountinued", "width": "12%" },
      { "data": "productNameOptions", "width": "15%" }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });


})






function loadDataTable() {
  dataTable = $("#invFeedsWayfairItems").DataTable({
    order: [[1, "asc"]],
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
          return "Wayfair_" + todayDate + "_" + todatyTime;
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
          return "Wayfair_" + todayDate + "_" + todatyTime;
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
          return "Wayfair_" + todayDate + "_" + todatyTime;
        },
        exportOptions: {
          columns: ':visible'
        }
      },
      'colvis', 'pageLength'
    ],
    "ajax": {
      "url": "/Inventory/GetInvFeedsWayfair",
      "type": "GET",
      "datatype": "json",
      "dataSrc": "",
      "data": function (d) {
        d.historyDate = $('#historyDateHidden').val();
      } 
    },
    "columns": [
      { "data": "supplierId", "width": "12%" },
      { "data": "supplierPartNo", "width": "13%" },
      { "data": "qtyOnHand", "width": "12%" },
      { "data": "qtyOnBackOrder", "width": "12%" },
      { "data": "qtyOnOrder", "width": "12%" },
      { "data": "itemNextAvailDate", "width": "12%" },
      { "data": "discountinued", "width": "12%" },
      { "data": "productNameOptions", "width": "15%" }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });
}