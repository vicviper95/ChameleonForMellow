var dataTable;

$(document).ready(function () {
  loadDataTable();
});

function loadDataTable() {
  dataTable = $("#inventoryItems").DataTable({
    dom: 'Bfrtip',
    lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
    buttons: [
      {
        extend: 'copyHtml5',
        exportOptions: {
          columns: [0, 1, 2, 3]
        }
      },
      {
        extend: 'csvHtml5',
        exportOptions: {
          columns: [0, 1, 2, 3]
        }
      },
      {
        extend: 'excelHtml5',
        exportOptions: {
          columns: [0, 1, 2, 3]
        }
      },
      {
        extend: 'pdfHtml5',
        exportOptions: {
          columns: [0, 1, 2, 3]
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