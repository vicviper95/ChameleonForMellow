var dataTable;
var dataTable2;
var dataTable3;

$(document).ready(function () {
  loadDataTable();

});

function loadDataTable() {
  dataTable = $("#invMainslBancItems").DataTable({
    "order":[[3, "asc"]],
    dom: 'Bfrtip',
    lengthMenu: [[15, 25, 50, 100], [15, 25, 50, 100]],
    buttons: [
      {
        extend: 'copyHtml5',
        exportOptions: {
          columns: [2, 3, 4, 5]
        }
      },
      {
        extend: 'csvHtml5',
        exportOptions: {
          columns: [2, 3, 4, 5]
        }
      },
      {
        extend: 'excelHtml5',
        exportOptions: {
          columns: [2, 3, 4, 5]
        }
      },
      {
        extend: 'pdfHtml5',
        exportOptions: {
          columns: [2, 3, 4, 5]
        }
      },
      'colvis', 'pageLength'
    ],
    "ajax": {
      "url": "/Inventory/GetMainslBancInvItems",
      "type": "GET",
      "datatype": "json",
      "dataSrc": ""
    },
    "columns": [
      { "data": "invBANCItemId", "visible": false },
      { "data": "invMainslItemId", "visible": false },
      { "data": "remark", "width": "20%" },
      { "data": "itemName", "width": "40%" },
      {
        "data": "qtyAvailMainsl", 
        "width": "20%"
      },
      {
        "data": "qtyAvailBanc",
        "width": "20%"
      }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });

  dataTable2 = $("#invAvailNoteItems").DataTable({
    "ajax": {
      "url": "/Inventory/GetAllMainslBancInvNotes",
      "type": "GET",
      "datatype": "json",
      "dataSrc": ""
    },
    "columns": [
      { "data": "notesRulesId", "visible": false },
      {
        "data": "noteRule",
        "render": function (data, type, row, meta) {
          return `<div class="text-center">
                        <a href="/Inventory/edit/${row['notesRulesId']}">
                            ${data}
                        </a>
                        </div>`;
        },
        "width": "100%"
      }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });

  dataTable3 = $("#invMainslBancItems3").DataTable({
    "ajax": {
      "url": "/Inventory/GetAllMainslBancInvFeedRules",
      "type": "GET",
      "datatype": "json",
      "dataSrc": ""
    },
    "columns": [
      { "data": "notesRulesId", "visible": false },
      {
        "data": "noteRule",
        "render": function (data, type, row, meta) {
          return `<div class="text-center">
                        <a href="/Inventory/edit/${row['notesRulesId']}">
                            ${data}
                        </a>
                        </div>`;
        },
        "width": "100%"
      }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });
}