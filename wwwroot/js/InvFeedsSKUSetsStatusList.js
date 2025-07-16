$(document).ready(function () {
});

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
  invFeedsSetsSKUStatusTable;
  var table = $('#invFeedsSetsSKUStatusItems').DataTable();

  $('#invFeedsSetsSKUStatusItems tbody').on('click', 'tr', function () {
    var d = table.row(this).data();
    var itemNoId = parseInt(d.itemNoId);
    clearAllFields();

    $.ajax({
      url: '../Inventory/GetSetSKUDetail',
      type: "GET",
      contentType: "application/json charset=utf-8",
      dataType: 'json',
      data: { itemNoId: itemNoId },
      success: function (data) {
        document.getElementById('itemParentSku').innerHTML = data.parentItemSku;
        document.getElementById('itemParentDescription').innerHTML = data.parentItemDescrition;
        document.getElementById('childItemSku01').innerHTML = data.childItemSku01;
        document.getElementById('childItemDescription01').innerHTML = data.childItemDescription01;
        document.getElementById('childItemQty01').innerHTML = data.childItemKittingQty01;
        document.getElementById('childItemSku02').innerHTML = data.childItemSku02;
        document.getElementById('childItemDescription02').innerHTML = data.childItemDescription02;
        document.getElementById('childItemQty02').innerHTML = data.childItemKittingQty02;
        document.getElementById('childItemSku03').innerHTML = data.childItemSku03;
        document.getElementById('childItemDescription03').innerHTML = data.childItemDescription03;
        document.getElementById('childItemQty03').innerHTML = data.childItemKittingQty03;
        document.getElementById('childItemSku04').innerHTML = data.childItemSku04;
        document.getElementById('childItemDescription04').innerHTML = data.childItemDescription04;
        document.getElementById('childItemQty04').innerHTML = data.childItemKittingQty04;
        document.getElementById('childItemSku05').innerHTML = data.childItemSku05;
        document.getElementById('childItemDescription05').innerHTML = data.childItemDescription05;
        document.getElementById('childItemQty05').innerHTML = data.childItemKittingQty05;
      }
    });
    //alert('You clicked on ' + d.feedsEnable + '\'s row');
    //if (d.feedsEnable == true) d.feedsEnable = false;
    //else d.feedsEnable = true;
    //table.row(this).data(d).draw();
    //console.log(d);
  });

  $('#invFeedsSetsSKUStatusItems tbody').on('dblclick', 'tr', function () {
    var d = table.row(this).data();
    var itemNoId = parseInt(d.itemNoId);
    clearAllFields();

    $.ajax({
      url: '../Inventory/GetSetSKUDetail',
      type: "GET",
      contentType: "application/json charset=utf-8",
      dataType: 'json',
      data: { itemNoId: itemNoId },
      success: function (data) {
        document.getElementById('itemParentSku').innerHTML = data.parentItemSku;
        document.getElementById('itemParentDescription').innerHTML = data.parentItemDescrition;
        document.getElementById('childItemSku01').innerHTML = data.childItemSku01;
        document.getElementById('childItemDescription01').innerHTML = data.childItemDescription01;
        document.getElementById('childItemQty01').innerHTML = data.childItemKittingQty01;
        document.getElementById('childItemSku02').innerHTML = data.childItemSku02;
        document.getElementById('childItemDescription02').innerHTML = data.childItemDescription02;
        document.getElementById('childItemQty02').innerHTML = data.childItemKittingQty02;
        document.getElementById('childItemSku03').innerHTML = data.childItemSku03;
        document.getElementById('childItemDescription03').innerHTML = data.childItemDescription03;
        document.getElementById('childItemQty03').innerHTML = data.childItemKittingQty03;
        document.getElementById('childItemSku04').innerHTML = data.childItemSku04;
        document.getElementById('childItemDescription04').innerHTML = data.childItemDescription04;
        document.getElementById('childItemQty04').innerHTML = data.childItemKittingQty04;
        document.getElementById('childItemSku05').innerHTML = data.childItemSku05;
        document.getElementById('childItemDescription05').innerHTML = data.childItemDescription05;
        document.getElementById('childItemQty05').innerHTML = data.childItemKittingQty05;
      }
    });
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

$("#updateInvFeedsSetsSKUStatusBtn").click(function () {
  var table = $('#invFeedsSetsSKUStatusItems').DataTable();
  const jsonArray = [];
  var customerID = 10000;

  var table_data = table.rows().data().toArray();
  //var test_data = table.buttons.exportData();
  jsonArray.push(table_data);
  //console.log(JSON.stringify(table_data));

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
      invFeedsSetsSKUStatusTable.ajax.reload();
    }
  });
})


var invFeedsSetsSKUStatusTable = $("#invFeedsSetsSKUStatusItems").DataTable({
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
      "customerId": "10000"
    }
  },
  "columns": [
    { "data": "itemNoId", "visible": false },
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
    { "data": "description", "width": "25%" },
    { "data": "lastModifiedBy", "width": "22%" },
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
    url: '/Inventory/GetSetDetail',
    type: 'POST',
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(returnResult),
    success: function (response) {
      //loadDataTable()
      //location.reload(true);
    }
  });
  //$('#resultJSON').val(JSON.stringify(returnResult));
}

function clearAllFields() {
  document.getElementById('itemParentSku').innerHTML = '';
  document.getElementById('itemParentDescription').innerHTML = '';
  document.getElementById('childItemSku01').innerHTML = '';
  document.getElementById('childItemDescription01').innerHTML = '';
  document.getElementById('childItemQty01').innerHTML = '';
  document.getElementById('childItemSku02').innerHTML = '';
  document.getElementById('childItemDescription02').innerHTML = '';
  document.getElementById('childItemQty02').innerHTML = '';
  document.getElementById('childItemSku03').innerHTML = '';
  document.getElementById('childItemDescription03').innerHTML = '';
  document.getElementById('childItemQty03').innerHTML = '';
  document.getElementById('childItemSku04').innerHTML = '';
  document.getElementById('childItemDescription04').innerHTML = '';
  document.getElementById('childItemQty04').innerHTML = '';
  document.getElementById('childItemSku05').innerHTML = '';
  document.getElementById('childItemDescription05').innerHTML = '';
  document.getElementById('childItemQty05').innerHTML = '';
}