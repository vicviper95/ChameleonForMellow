var dataTable;
var tmpDate = new Date();
var fourWeeksDate = new Date(new Date().setDate(tmpDate.getDate() - 28));
var eightWeeksDate = new Date(new Date().setDate(tmpDate.getDate() - 56));
var twelveWeeksDate = new Date(new Date().setDate(tmpDate.getDate() - 84));
var today = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();

$(document).ready(function () {
  fromDatePicker();
  toDatePicker();
  loadDataTable();
  //reloadDataTables();//reloadInvSalesHistory
});

//function reloadDataTables() {
//  $("#reloadInvSalesHistory").click(function () {
//    location.reload(true);
//  });
//}


// For waiting indicator
$body = $("body");

$(document).on({
  ajaxStart: function () { $body.addClass("loading"); },
  ajaxStop: function () { $body.removeClass("loading"); }
});


//-----------calender----------
var endDate = new Date();
var startDate = new Date(new Date().getFullYear(), 0, 1);
endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
function fromDatePicker() {
  $("#fromDatePicker").datepicker(
    {
      defaultDate: startDate
    }
  );
  console.log($("#fromDatePicker"));
}
function toDatePicker() {
  $("#toDatePicker").datepicker(
    {
      defaultDate: endDate
    }
  );
}


$("#reloadInvSalesHistory").click(function () {
  var e = document.getElementById("timePeriodSalesHistory");
  if (e.value == '4weeks') {
    endDate = new Date();
    startDate = fourWeeksDate;
    endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
    startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
  } else if (e.value == '8weeks') {
    endDate = new Date();
    startDate = eightWeeksDate;
    endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
    startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
  } else if (e.value == '12weeks') {
    endDate = new Date();
    startDate = twelveWeeksDate;
    endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
    startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
  } else if (e.value == 'none') {
    endDate = $("#toDatePicker").datepicker("getDate");
    startDate = $("#fromDatePicker").datepicker("getDate");
    endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
    startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
  }

  $('#invSalesHistoryItems').DataTable({
    "destroy": true,
    dom: 'Bfrtip',
    lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
    buttons: [
      {
        extend: 'copyHtml5',
        exportOptions: {
          columns: [0, 1, 2]
        }
      },
      {
        extend: 'csvHtml5',
        exportOptions: {
          columns: [0, 1, 2]
        }
      },
      {
        extend: 'excelHtml5',
        exportOptions: {
          columns: [0, 1, 2]
        }
      },
      {
        extend: 'pdfHtml5',
        exportOptions: {
          columns: [0, 1, 2]
        }
      },
      'colvis', 'pageLength'
    ],
    "ajax": {
      "url": "/Inventory/GetInvSalesHistory",
      "type": "GET",
      "datatype": "json",
      "dataSrc": "",
      "data": {
        "startDate": startDate,
        "endDate": endDate
      }
    },
    "columns": [
      { "data": "itemName", "width": "8%" },
      { "data": "amazonCustSKU", "width": "9%" },
      { "data": "amazonDropShip", "width": "8%" },
      { "data": "wayfairCustSKU", "width": "9%" },
      { "data": "wayfairDropShip", "width": "8%" },
      { "data": "walmartCustSKU", "width": "9%" },
      { "data": "walmart", "width": "8%" },
      { "data": "overstockCustSKU", "width": "9%" },
      { "data": "overstockDropShip", "width": "8%" },
      { "data": "eBayCustSKU", "width": "8%" },
      { "data": "eBay", "width": "8%" },
      { "data": "etcMarket", "width": "8%" }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  })
})







function loadDataTable() {
  dataTable = $("#invSalesHistoryItems").DataTable({
    "destroy": true,
    dom: 'Bfrtip',
    lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
    buttons: [
      {
        extend: 'copyHtml5',
        exportOptions: {
          columns: [0, 1, 2]
        }
      },
      {
        extend: 'csvHtml5',
        exportOptions: {
          columns: [0, 1, 2]
        }
      },
      {
        extend: 'excelHtml5',
        exportOptions: {
          columns: [0, 1, 2]
        }
      },
      {
        extend: 'pdfHtml5',
        exportOptions: {
          columns: [0, 1, 2]
        }
      },
      'colvis', 'pageLength'
    ],
    "ajax": {
      "url": "/Inventory/GetInvSalesHistory",
      "type": "GET",
      "datatype": "json",
      "dataSrc": "",
      "data": {
        "startDate": startDate,
        "endDate" : endDate
      }
    },
    "columns": [
      { "data": "itemName", "width": "8%" },
      { "data": "amazonCustSKU", "width": "9%" },
      { "data": "amazonDropShip", "width": "8%" },
      { "data": "wayfairCustSKU", "width": "9%" },
      { "data": "wayfairDropShip", "width": "8%" },
      { "data": "walmartCustSKU", "width": "9%" },
      { "data": "walmart", "width": "8%" },
      { "data": "overstockCustSKU", "width": "9%" },
      { "data": "overstockDropShip", "width": "8%" },
      { "data": "eBayCustSKU", "width": "8%" },
      { "data": "eBay", "width": "8%" },
      { "data": "etcMarket", "width": "8%" }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  })
}