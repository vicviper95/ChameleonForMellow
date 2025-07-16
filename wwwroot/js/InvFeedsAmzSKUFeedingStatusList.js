var dataTable;

$(document).ready(function () {
  loadDataTable();
});

// Waiting Indicator
$body = $("body");

$(document).on({
  ajaxStart: function () { $body.addClass("loading"); },
  ajaxStop: function () { $body.removeClass("loading"); }
});

$(function () {
  $("#amzFeedingStatusTabs").tabs();
});



$(document).ready(function () {
  var table = $('#invFeedsAmzSKUFeedingStatusItems').DataTable();

  $('#invFeedsAmzSKUFeedingStatusItems tbody').on('click', 'tr', function () {
    var d = table.row(this).data();
    //alert('You clicked on ' + d.feedsEnable + '\'s row');
    if (d.feedsEnable == true) d.feedsEnable = false;
    else d.feedsEnable = true;
    table.row(this).data(d).draw();
    //console.log(d);
  });

});

/* Create an array with the values of all the checkboxes in a column */
$.fn.dataTable.ext.order['dom-checkbox'] = function (settings, col) {
  return this.api()
    .column(col, { order: 'index' })
    .nodes()
    .map(function (td, i) {
      return $('input', td).prop('checked') ? '1' : '0';
    });
};


$("#updateInvFeedsAmzSKUStatusBtn").click(function () {
  var table = $('#invFeedsAmzSKUFeedingStatusItems').DataTable();
  const jsonArray = [];

  var table_data = table.rows().data().toArray();
  //var test_data = table.buttons.exportData();
  jsonArray.push(table_data);
  console.log(JSON.stringify(table_data));

  var returnResult = new Object();
  returnResult.customerId = 5;
  returnResult.skuList = jsonArray;

  $.ajax({
    url: '../Inventory/UpdateInvFeedsSKUFeedingStatusList',
    type: "POST",
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(returnResult),
    success: function () {
      alert('The list was updated!');
      //location.reload(true);
    }
  });
})


function loadDataTable() {
  dataTable = $("#invFeedsAmzSKUFeedingStatusItems").DataTable({
    "autoWidth": false,
    destroy: true,
    dom: 'Bfrtip',
    "order": [[3, "asc"]],
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
      "url": "/Inventory/GetInvFeedsSKUFeedingStatusList",
      "type": "GET",
      "datatype": "json",
      "dataSrc": "",
      "data": {
        "customerId": "5"
      }
    },
    "columns": [
      { "data": "itemNoId", "visible": false },
      { "data": "icrId", "visible": false },
      {
        "data": "feedsEnable",
        "orderDataType": 'dom-checkbox',
        "render": function (data, type, row) {
          if (data === true) {
            return '<input type="checkbox" class="editor-active" onclick="return false;" checked>';
          } else {
            return '<input type="checkbox" onclick="return false;" class="editor-active">';
          }
          return data;
        },
        className: "dt-body-center text-center",
        "width": "5%"
      },
      { "data": "itemName", "width": "8%" },
      { "data": "itemStatus", "width": "8%" },
      { "data": "custSKU", "width": "8%" },
      { "data": "custUPC", "width": "8%" },
      { "data": "asin", "width": "8%" },
      { "data": "description", "width": "25%" },
      { "data": "lastModifiedBy", "width": "18%" },
      { "data": "lastModifiedTime", "width": "12%" }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });


  //invFeedsAmzSKUFeedingConflictedItems
  dataTable = $("#invFeedsAmzSKUFeedingConflictedItems").DataTable({
    "autoWidth": false,
    destroy: true,
    dom: 'Bfrtip',
    "order": [[4, "asc"]],
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
      "url": "/Inventory/GetInvFeedsSKUFeedingStatusList",
      "type": "GET",
      "datatype": "json",
      "dataSrc": "",
      "data": {
        "customerId": "55"
      }
    },
    "columns": [
      {
        "data": "isResolved",
        "orderDataType": 'dom-checkbox',
        "render": function (data, type, row) {
          if (data === true) {
            return '<input type="checkbox" class="editor-active" onclick="return false;" checked>';
          } else {
            return '<input type="checkbox" onclick="return false;" class="editor-active">';
          }
          return data;
        },
        className: "dt-body-center text-center",
        "width": "5%"
      },
      { "data": "conflictType", "width": "15%" },
      { "data": "itemName", "width": "8%" },
      { "data": "itemStatus", "width": "8%" },
      { "data": "custSKU", "width": "8%" },
      { "data": "asin", "width": "8%" },
      { "data": "description", "width": "22%" },
      { "data": "lastModifiedBy", "width": "18%" },
      { "data": "lastModifiedTime", "width": "12%" }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });
}



// --- Import SKUs --- 
function openSKUCSVAttachment() {
  var fileInput = document.getElementById('SKUCSVAttachment');
  fileInput.addEventListener("click", function () {
    fileInput.value = null;
  });
  document.getElementById('SKUCSVAttachment').addEventListener('change', csvJSON, false);
}

function csvJSON(e) {
  var file = e.target.files[0];
  if (!file) return;
  var reader = new FileReader();
  reader.onload = function (e) {
    var contents = e.target.result;
    getJSON(contents);
  };
  reader.readAsText(file);
}

function getJSON(contents) {
  // const tmpCustId = $('#customerId').val();
  const custId = 5; // Amazon Drop-ship ID
  const lines = contents.split('\n');
  const jsonArray = [];
  //const AmazonFeedsListImportDTO = [];
  //const OverstockFeedsListImportDTO = [];
  const headers = lines[0].split(',');
  let lengthLimit = 0;

  for (let k = 0; k < headers.length; k++) {
    headers[k] = headers[k].replace(/\s+/g, '');
  }

  for (let i = 1; i < lines.length; i++) {
    if (!lines[i])
      continue;
    const obj = {};
    const currentline = lines[i].split(',');
    switch (custId) {
      case 5:
        lengthLimit = 3;
        break;
      case 21:
        lengthLimit = 1;
        break;
    }
    for (let j = 0; j < lengthLimit; j++) {
      obj[headers[j]] = currentline[j];
    }
    jsonArray.push(obj);
  }

  var returnResult = new Object();
  returnResult.customerId = custId;
  returnResult.skuList = jsonArray;
  //AmazonFeedsListImportDTO.push(returnResult);
  $.ajax({
    url: '/Inventory/UpdateMarketFeedsList',
    type: 'POST',
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(returnResult),
    success: function (response) {
      loadDataTable()
      //location.reload(true);
    }
  });
  //$('#resultJSON').val(JSON.stringify(returnResult));
}