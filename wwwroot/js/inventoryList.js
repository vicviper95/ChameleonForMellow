var dataTable;

$(document).ready(function () {
  loadDataTable();
});


// For waiting indicator
$body = $("body");

$(document).on({
  ajaxStart: function () { $body.addClass("loading"); },
  ajaxStop: function () { $body.removeClass("loading"); }
});

function loadDataTable() {
  dataTable = $("#inventoryItems").DataTable({
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
      "url": "/Inventory/GetAllItems",
      "type": "GET",
      "datatype": "json",
      "dataSrc": ""
    },
    "columns": [
      { "data": "itemName", "width": "25%" },
      { "data": "qtyOnHand", "width": "25%" },
      { "data": "qtyAvail", "width": "25%" },
      { "data": "locName", "width": "25%" }
      //,
      //{
      //  "data": "itemNoId",
      //  "render": function (data) {
      //    return `<div class="text-center">
      //                  <a href="/Inventory/edit/${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
      //                      Edit
      //                  </a>
      //                  </div>`;
      //  }, "width": "20%"
      //}
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });
}