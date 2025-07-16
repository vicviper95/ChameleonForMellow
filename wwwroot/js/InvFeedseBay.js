var dataTable;

$(document).ready(function () {
  fromDatePicker();
  toDatePicker();
  loadDataTable();
});

//-----------calender----------
var toDate = new Date();
var fromDate = new Date(new Date().setDate(toDate.getDate() - 1));
function fromDatePicker() {
  $("#fromDatePicker").datepicker(
    {
      defaultDate: fromDate
    }
  );
  console.log($("#fromDatePicker"));
}
function toDatePicker() {
  $("#toDatePicker").datepicker(
    {
      defaultDate: toDate
    }
  );
}
//-----------------------------


function loadDataTable() {
  dataTable = $("#invFeedsItems").DataTable({
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
    "ajax": {
      "url": "/Inventory/GetInvFeedseBay",
      "type": "GET",
      "datatype": "json",
      "dataSrc": ""
    },
    "columns": [
      { "data": "itemNoId", "visible": false },
      {
        "data": "itemName",
        "render": function (data, type, row, meta) {
          return `<div class="text-center">
                        <a href="/Inventory/edit/${row['ItemNoId']}" >
                            ${data}
                        </a>
                        </div>`;
        }, "width": "6%"
      },
      { "data": "qtyAvail", "width": "5%" },
      { "data": "amazonCustSKU", "width": "6%" },
      { "data": "amazonPercentage", "width": "5%" },
      { "data": "amazonQty", "width": "5%" },
      { "data": "wayfairCustSKU", "width": "6%" },
      { "data": "wayfairPercentage", "width": "5%" },
      { "data": "wayfairQty", "width": "5%" },
      { "data": "walmartCustSKU", "width": "6%" },
      { "data": "walmartPercentage", "width": "5%" },
      { "data": "walmartQty", "width": "5%" },
      { "data": "overstockCustSKU", "width": "6%" },
      { "data": "overstockPercentage", "width": "5%" },
      { "data": "overstockQty", "width": "5%" },
      { "data": "eBayCustSKU", "width": "6%" },
      { "data": "eBayPercentage", "width": "5%" },
      { "data": "eBayQty", "width": "5%" },
      { "data": "etcMarketPercentage", "width": "5%" },
      { "data": "etcMarketQty", "width": "5%" }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });
}