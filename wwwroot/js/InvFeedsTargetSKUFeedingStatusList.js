const customerID = 51;
const custConflictId = 5151;

// Waiting Indicator
$body = $("body");

$(document).on({
  ajaxStart: function () { $body.addClass("loading"); },
  ajaxStop: function () { $body.removeClass("loading"); }
});

$(function () {
  $("#targetFeedingStatusTabs").tabs();
});



$(document).ready(function () {
  invFeedsTargetSKUFeedingStatusTable;
  invFeedseBaySKUFeedingConflictedTable;


  var table = $('#invFeedsTargetSKUFeedingStatusItems').DataTable();

  $('#invFeedsTargetSKUFeedingStatusItems tbody').on('click', 'tr', function () {
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

$("#updateInvFeedsTargetSKUStatusBtn").click(function () {
  var table = $('#invFeedsTargetSKUFeedingStatusItems').DataTable();
  const jsonArray = [];

  var table_data = table.rows().data().toArray();
  //var test_data = table.buttons.exportData();
  jsonArray.push(table_data);
  console.log(JSON.stringify(table_data));

  var returnResult = new Object();
  returnResult.customerId = customerID;
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


var invFeedsTargetSKUFeedingStatusTable = $("#invFeedsTargetSKUFeedingStatusItems").DataTable({
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
      "customerId": customerID
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
    { "data": "itemName", "width": "12%" },
    { "data": "itemStatus", "width": "12%" },
    { "data": "custSKU", "width": "10%" },
    { "data": "description", "width": "25%" },
    { "data": "lastModifiedBy", "width": "22%" },
    { "data": "lastModifiedTime", "width": "14%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});

var invFeedseBaySKUFeedingConflictedTable = $("#invFeedsTargetSKUFeedingConflictedItems").DataTable({
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
      "customerId": custConflictId
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
    { "data": "itemName", "width": "12%" },
    { "data": "itemStatus", "width": "8%" },
    { "data": "custSKU", "width": "12%" },
    { "data": "description", "width": "22%" },
    { "data": "lastModifiedBy", "width": "20%" },
    { "data": "lastModifiedTime", "width": "14%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});

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
  const custId = customerID; // Amazon Drop-ship ID
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
      case 5: // Amazon
        lengthLimit = 3;
        break;
      case 9: // BPM
        lengthLimit = 11;
        break;
      case 12:// eBay
        lengthLimit = 2;
        break;
      case 14:// Houzz
        lengthLimit = 2;
        break;
      case 18:// Mellow
        lengthLimit = 11;
        break;
      case 21: // Overstock
        lengthLimit = 2;
        break;
      case 26: // Walmart
        lengthLimit = 2;
        break;
      case 29: // Wayfair
        lengthLimit = 2;
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