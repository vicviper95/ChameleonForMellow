

function importAmzPerfRepFromUser() {
    var fileInput = document.getElementById('ImportAmzPerfRep');
    fileInput.addEventListener("click", function () {
        fileInput.value = null;
    });
    document.getElementById('ImportAmzPerfRep').addEventListener('change', csvJSON, false);
}
//ImportAmzPerfRep
function csvJSON(e) {
    var file = e.target.files[0];
    if (!file) return;
    var reader = new FileReader();
    reader.onload = function (e) {
        var contents = e.target.result;
        getJSON(contents);
    };
    reader.readAsText(file);
    //reader = new FileReader();
    //file = null;
}

function getJSON(contents) {
    const lines = contents.split('\n');
    const jsonArray = [];
    const headers = lines[0].split(',');
    // We will only import 5 columns
    let lengthLimit = 18;
    /*
    for (let k = 0; k < headers.length; k++) {
        headers[k] = headers[k].replace(/\s+/g, '');
    }
    for (let k = 0; k < lengthLimit; k++) {
        headers[k]
    }*/
    headers[0] = "startDate";
    headers[1] = "endDate";
    headers[2] = "portfolioName";
    headers[3] = "currency";
    headers[4] = "campaignName";
    headers[5] = "adGroupName";
    headers[6] = "advertisedAsin";
    headers[7] = "impressions";
    headers[8] = "clicks";
    headers[9] = "clickThruRate";
    headers[10] = "costPerClick";
    headers[11] = "spend";
    headers[12] = "totalSalesIn14Day";
    headers[13] = "totalAdvertisingCostOfSales";
    headers[14] = "totalReturnOnAdvertisingSpend";
    headers[15] = "totalOrdersIn14Day";
    headers[16] = "totalUnitsIn14Day";
    headers[17] = "conversionRateIn14Day";

    for (let i = 1; i < lines.length; i++) {
        if (!lines[i])
            continue;
        const obj = {};
        //const currentline = lines[i].split(',');
        const currentline = CSVtoArray(lines[i]);
        for (let j = 0; j < lengthLimit; j++) {
            obj[headers[j]] = currentline[j];
        }
        jsonArray.push(obj);
    }

    var returnResult = new Object();
    returnResult = jsonArray;
    console.log(returnResult);
    //AmazonFeedsListImportDTO.push(returnResult);
    $.ajax({
        url: '/SalesReports/ImportAmzPerfMrktRep',
        type: 'POST',
        contentType: "application/json charset=utf-8",
        dataType: 'json',
        data: JSON.stringify(returnResult),
        success: function (response) {
            if (response.errorOnImport == false) { alert('The import process is done!'); }
            else { alert(response.errorMessages); }
            amzAdReportTable.ajax.reload();
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


function clearAllFields() {
  $('#amazonAdReportId').val('');
  $('#amazonAdReportDetailId').val('');
}

// Return array of string values, or NULL if CSV string not well formed.
function CSVtoArray(text) {
    var re_valid = /^\s*(?:'[^'\\]*(?:\\[\S\s][^'\\]*)*'|"[^"\\]*(?:\\[\S\s][^"\\]*)*"|[^,'"\s\\]*(?:\s+[^,'"\s\\]+)*)\s*(?:,\s*(?:'[^'\\]*(?:\\[\S\s][^'\\]*)*'|"[^"\\]*(?:\\[\S\s][^"\\]*)*"|[^,'"\s\\]*(?:\s+[^,'"\s\\]+)*)\s*)*$/;
    var re_value = /(?!\s*$)\s*(?:'([^'\\]*(?:\\[\S\s][^'\\]*)*)'|"([^"\\]*(?:\\[\S\s][^"\\]*)*)"|([^,'"\s\\]*(?:\s+[^,'"\s\\]+)*))\s*(?:,|$)/g;
    // Return NULL if input string is not well formed CSV string.
    if (!re_valid.test(text)) return null;
    var a = [];                     // Initialize array to receive values.
    text.replace(re_value, // "Walk" the string using replace with callback.
        function (m0, m1, m2, m3) {
            // Remove backslash from \' in single quoted values.
            if (m1 !== undefined) a.push(m1.replace(/\\'/g, "'"));
            // Remove backslash from \" in double quoted values.
            else if (m2 !== undefined) a.push(m2.replace(/\\"/g, '"'));
            else if (m3 !== undefined) a.push(m3);
            return ''; // Return empty string.
        });
    // Handle special case of empty last value.
    if (/,\s*$/.test(text)) a.push('');
    return a;
};


//amzAdReportItems
//amzAdRepSkuItems
//amzAdRepSkuHistoryItems


$(document).ready(function () {
  amzAdReportTable;
  amzAdRepSkuTable;
  amzAdRepSkuHistoryTable;

  clearAllFields();

  $('#amzAdReportItems tbody').on('click', 'tr', function () {
    var dv = amzAdReportTable.row(this).data();

    clearAllFields();

    document.getElementById('amazonAdReportId').value = dv.adId;
    console.log(dv.adId);
    amzAdRepSkuTable.ajax.reload();
  });

  $('#amzAdRepSkuItems tbody').on('click', 'tr', function () {
    var dv = amzAdRepSkuTable.row(this).data();

    clearAllFields();

    document.getElementById('amazonAdReportDetailId').value = dv.adDetailId;
    console.log(dv.adId);
    amzAdRepSkuHistoryTable.ajax.reload();
  });


});

var amzAdReportTable = $("#amzAdReportItems").DataTable({
  "scrollX": true,
  "scrollY": true,
  "scrollCollapse": true,
  "destroy": true,
  "autoWidth": false,
  //"paging": false,
  "order": [[0, "dsc"]],
  dom: 'Bfrtip',
  lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
  buttons: [
    {
      extend: 'copyHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "AmazonPerformanceMarketing" + "_" + todayDate + "_" + todatyTime;
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
        return "AmazonPerformanceMarketing" + "_" + todayDate + "_" + todatyTime;
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
        return "AmazonPerformanceMarketing" + "_" + todayDate + "_" + todatyTime;
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
        return "AmazonPerformanceMarketing" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/SalesReports/GetAmazonAdReports",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": ""
  },
  "columns": [
    { "data": "adId", "visible": false },
    { "data": "endDate", "width": "10%", "className": "text-right" },
    { "data": "campaignName", "width": "10%", "className": "text-right" },
    { "data": "adGroupName", "width": "10%", "className": "text-right" },
    { "data": "createdDate", "width": "10%", "className": "text-right" },
    { "data": "lastModifiedDate", "width": "10%", "className": "text-right" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "50%"
});

var amzAdRepSkuTable = $("#amzAdRepSkuItems").DataTable({
  "scrollX": true,
  "scrollY": true,
  "scrollCollapse": true,
  "destroy": true,
  "autoWidth": false,
  //"paging": false,
  "order": [[0, "dsc"]],
  dom: 'Bfrtip',
  lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
  buttons: [
    {
      extend: 'copyHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "AmazonPerformanceMarketing" + "_" + todayDate + "_" + todatyTime;
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
        return "AmazonPerformanceMarketing" + "_" + todayDate + "_" + todatyTime;
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
        return "AmazonPerformanceMarketing" + "_" + todayDate + "_" + todatyTime;
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
        return "AmazonPerformanceMarketing" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/SalesReports/GetAmzAdSkus",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.amzAdRepId = $('#amazonAdReportId').val();
    }
  },
  "columns": [
    { "data": "adDetailId", "visible": false },
    { "data": "startDate", "width": "10%", "className": "text-right" },
    { "data": "portfolioName", "width": "10%", "className": "text-right" },
    { "data": "advertisedAsin", "width": "20%", "className": "text-right" },
    { "data": "createdDate", "width": "10%", "className": "text-right" },
    { "data": "lastModifiedDate", "width": "10%", "className": "text-right" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "90%"
});


var amzAdRepSkuHistoryTable = $("#amzAdRepSkuHistoryItems").DataTable({
  "scrollX": true,
  "scrollY": true,
  "scrollCollapse": true,
  "destroy": true,
  "autoWidth": false,
  //"paging": false,
  "order": [[0, "dsc"]],
  dom: 'Bfrtip',
  lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
  buttons: [
    {
      extend: 'copyHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "AmazonPerformanceMarketing" + "_" + todayDate + "_" + todatyTime;
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
        return "AmazonPerformanceMarketing" + "_" + todayDate + "_" + todatyTime;
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
        return "AmazonPerformanceMarketing" + "_" + todayDate + "_" + todatyTime;
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
        return "AmazonPerformanceMarketing" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/SalesReports/GetAmzAdSkuHistory",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.amzAdSkuId = $('#amazonAdReportDetailId').val();
    }
  },
  "columns": [
    { "data": "adDetailHistoryId", "visible": false },
    { "data": "impressions", "width": "10%", "className": "text-right" },
    { "data": "clicks", "width": "10%", "className": "text-right" },
    {
      "data": "clickThruRateCtr",
      "render": function (data, type, row) {
        return data + '%';
      },
      "width": "10%", "className": "text-right"
    },
    {
      "data": "costPerClickCpc",
      "render": function (data, type, row) {
        return '$' + data;
      },
      "width": "10%", "className": "text-right"
    },
    {
      "data": "spend",
      "render": function (data, type, row) {
        return '$' + data;
      },
      "width": "10%", "className": "text-right"
    },
    {
      "data": "fourteenDayTotalSales",
      "render": function (data, type, row) {
        return '$' + data;
      },
      "width": "10%", "className": "text-right"
    },
    {
      "data": "totalAdvertisingCostOfSalesAcos",
      "render": function (data, type, row) {
        return data + '%';
      },
      "width": "10%", "className": "text-right"
    },
    { "data": "totalReturnOnAdvertisingSpendRoas", "width": "10%", "className": "text-right" },
    { "data": "fourteenDayTotalOrders", "width": "10%", "className": "text-right" },
    { "data": "fourteenDayTotalUnits", "width": "10%", "className": "text-right" },
    {
      "data": "fourteenDayConversionRate",
      "render": function (data, type, row) {
        return data + '%';
      },
      "width": "10%", "className": "text-right"
    },
    { "data": "createdDate", "width": "10%", "className": "text-right" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "120%"
});
