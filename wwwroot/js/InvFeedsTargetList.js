var dataTable;
var tmpDate = new Date();
var historyDate = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();
document.getElementById('historyDateHidden').value = historyDate;

$(document).ready(function () {
  historyDatePicker();
  $('#historyDatePicker').val(historyDate);

  document.getElementById('historyDateHidden').value = historyDate;
  getInvFeedsReportDate();
  invFeedsTargetTable;
  invFeedsTargetPastFeedTable;
  //loadDataTable();
});


// For waiting indicator
$body = $("body");

$(document).on({
  ajaxStart: function () { $body.addClass("loading"); },
  ajaxStop: function () { $body.removeClass("loading"); }
});

// Date Indicator
function getInvFeedsReportDate() {
  document.getElementById("invFeedsRepDate").innerHTML = "This report is for " + historyDate + ".";
}

//-----------calender----------
function historyDatePicker() {
  $("#historyDatePicker").datepicker(
    {
    }
  );
}
//-----------------------------


$("#reloadTargetFeedsHistory").click(function () {
  historyDate = $("#historyDatePicker").datepicker("getDate");
  historyDate = (historyDate.getMonth() + 1) + '/' + historyDate.getDate() + '/' + historyDate.getFullYear();
  document.getElementById('historyDateHidden').value = historyDate;
  getInvFeedsReportDate();
  invFeedsTargetTable.ajax.reload();
})


//
$("#bttnForSendingToEDI").click(function () {
  $.ajax({
    url: 'sendTargetFeedsToEDI',
    type: "POST",
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    success: function () {
      alert('This feeds was sent to EDI process!');
      invFeedsTargetTable;
      invFeedsTargetPastFeedTable;
      /*swal({
          title: "Thank you for waiting!",
          text: "This feeds was approved!",
          icon: "success",
      });*/
      //getLastUpdateInfo();
      //location.reload(true);

    }
  });
})



var invFeedsTargetTable = $("#invFeedsTargetItems").DataTable({
  destroy: true,
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
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "Target_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'excelHtml5',
      title: '',
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "Target_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'pdfHtml5',
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "Target_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetTargetInvFeeds",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "sku", "width": "17%" },
    { "data": "customerSku", "width": "17%" },
    { "data": "customerUpc", "width": "18%" },
    { "data": "mainslQty", "width": "16%" },
    //{ "data": "swcaftQty", "width": "10%" },
    //{ "data": "bancQty", "width": "12%" },
    //{ "data": "bascQty", "width": "12%" },
    //{ "data": "prsmCastQty", "width": "11%" },
    { "data": "zinusTracyQty", "width": "16%" },
    { "data": "zinusChsQty", "width": "16%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});


var invFeedsTargetPastFeedTable = $("#invFeedsTargetPastFeedsItems").DataTable({
  destroy: true,
  dom: 'Bfrtip',
  lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
  order: [[2, 'desc']],
  buttons: [
    {
      extend: 'copyHtml5',
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'csvHtml5',
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "Target_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'excelHtml5',
      title: '',
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "Target_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    {
      extend: 'pdfHtml5',
      filename: function () {
        var tmpToday = new Date($('#historyDateHidden').val());
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "Target_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetTargetPastInvFeeds",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.historyDate = $('#historyDateHidden').val();
    }
  },
  "columns": [
    { "data": "warehouse", "width": "25%" },
    { "data": "feedDate", "width": "25%" },
    { "data": "timeSent", "width": "25%" },
    { "data": "sentBy", "width": "25%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "100%"
});