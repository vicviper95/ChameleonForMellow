
// For waiting indicator
$body = $("body");

$(document).on({
  ajaxStart: function () { $body.addClass("loading"); },
  ajaxStop: function () { $body.removeClass("loading"); }
});

$(document).ready(function () {
  skuStatusDataTable;
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
  const custId = 12; 
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
  returnResult = jsonArray;
  //AmazonFeedsListImportDTO.push(returnResult);
  $.ajax({
    url: '/Purchase/ImportSKUStatus',
    type: 'POST',
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(returnResult),
    success: function (response) {
      if (response.errorOnImport == false) { alert('The import process is done!'); }
      else { alert(response.errorMessages); }
      skuStatusDataTable.ajax.reload();
    },
    error: function (jqXHR, textStatus, errorThrown) {
      if (jqXHR.status == 500) {
        alert('Internal error: ' + jqXHR.responseText + '\n' + 'Check an import file.');
      } else {
        alert('Unexpected error.' + '\n' + 'Check an import file.');
      }
    }
  });
  //$('#resultJSON').val(JSON.stringify(returnResult));
}





var skuStatusDataTable = $("#skuStatusItems").DataTable({
  "scrollX": true,
  "scrollY": true,
  "destroy": true,
  "autoWidth": false,
  "order": [[1, "dsc"]],
  dom: 'Bfrtip',
  buttons: [
    {
      extend: 'copyHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "SKU_Status" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'csvHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "SKU_Status" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'excelHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "SKU_Status" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'pdfHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "SKU_Status" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Purchase/GetSKUList",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": {
    }
  },
  "columns": [
    { "data": "itemNoId", "visible": false },
    { "data": "category", "width": "15%", "className": "text-right" },
    { "data": "itemName", "width": "15%", "className": "text-right" },
    { "data": "description", "width": "25%", "className": "text-right" },
    { "data": "itemStatus", "width": "10%", "className": "text-right" },
    { "data": "lastModifiedBy", "width": "20%", "className": "text-right" },
    { "data": "lastModifiedDate", "width": "20%", "className": "text-right" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "105%"
});