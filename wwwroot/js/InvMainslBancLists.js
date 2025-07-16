var dataTable;
var dataTable2;
//var dataTable3;
var tmpDate = new Date();
var today = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();
var todayString = getFormattedDate(today);

$(document).ready(function () {
  loadDataTable();
  getLastUpdateInfo();
});


// For waiting indicator
$body = $("body");

$(document).on({
  ajaxStart: function () { $body.addClass("loading"); },
  ajaxStop: function () { $body.removeClass("loading"); }
});

$.fn.dataTable.ext.search.push(
  function (settings, data, dataIndex) {
    var bancQty = parseInt($('#bancLessThanQty').val(), 10);
    var mainSLQty = parseInt($('#mainSLThanQty').val(), 10);
    var bancInv = parseFloat(data[4]) || 0; // use data for the age column
    var mainslInv = parseFloat(data[3]) || 0; // use data for the age column


    if ((isNaN(bancQty) && isNaN(mainSLQty)) || (0 < bancInv && bancInv <= bancQty) || (0 < mainslInv && mainslInv <= mainSLQty) ) {
      return true;
    }
    return false;
  }
);




$(document).ready(function () {
  var table = $('#invMainslBancItems').DataTable();
  var invTable = $('#invMainslBancItems').DataTable();

  $('#invMainslBancItems tbody').on('dblclick', 'tr', function () {
    var data = table.row(this).data();
    window.open("/Inventory/mainsl_banc_edit/" + data.inventoryItemId, "_self");
    //<a href="/Inventory/mainsl_banc_edit/${row['inventoryItemId']}" >
    //${data}
    //</a>
    //alert('You clicked on ' + data[0] + '\'s row');
  });
  // Event listener to the two filtering inputs to re-draw on input
  $('#bancLessThanQty, #mainSLThanQty').keyup(function () {
    invTable.draw();
  }
  );
  
});

function getFormattedDate(yDate) {
  let date = new Date(yDate);
  let year = date.getFullYear();
  let month = (1 + date.getMonth()).toString().padStart(2, '0');
  let day = date.getDate().toString().padStart(2, '0');

  return month + "/" + day + "/" + year;
}

function getLastUpdateInfo() {
  $.ajax({
    url: 'getLastUpdateInfo',
    type: "GET",
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    dataSrc: "",
    data: {
      "sel": 1,
      "today": today
    },
    success: function (response) {
      document.getElementById("lastUpdateDateInfo").innerHTML = response;
    }
  });
}

$("#bttnUpdateInv").click(function () {
  $.ajax({
    url: 'updateInventory',
    type: "POST",
    success: function () {
      alert('Thank you for waiting!');
      location.reload(true);
      getLastUpdateInfo();
    }
  });
})



$(document).ready(function () {
  var table = $('#invMainslBancItems').DataTable();


  $('#invMainslBancItems tbody').on('click', 'tr', function () {
    //var tmpData = $('#invFeedsSKUFeedingStatusItems').DataTable.row('.selected').data();
    var data = table.row(this).data();
    //$('#grid').load('../Inventory/GetInvFeedsSKUFeedingStatus',
    //  { "itemNoId": data.itemNoId });
    $("#doNotFeedFromBanc").removeAttr("disabled");
    $("#doNotFeedFromBancQtyOnHand").removeAttr("disabled");
    $("#doNotFeedFromBancQtyAvail").removeAttr("disabled");
    $("#doNotFeedFromMainsl").removeAttr("disabled");
    $("#doNotFeedFromMainslQtyOnHand").removeAttr("disabled");
    $("#doNotFeedFromMainslQtyAvail").removeAttr("disabled");
    document.getElementById('inventoryItemId').value = 0;
    document.getElementById('itemName').value = "";
    document.getElementById('itemNoId').value = 0;
    $("#doNotFeedFromAll").prop('checked', false);
    $("#doNotFeedFromBanc").prop('checked', false);
    document.getElementById('doNotFeedFromBancQtyOnHand').value = 0;
    document.getElementById('doNotFeedFromBancQtyAvail').value = 0;
    $("#doNotFeedFromMainsl").prop('checked', false);
    document.getElementById('doNotFeedFromMainslQtyOnHand').value = 0;
    document.getElementById('doNotFeedFromMainslQtyAvail').value = 0;
    $("#amazonDoNotFeed").prop('checked', false);
    $("#wayfairDoNotFeed").prop('checked', false);
    $("#walmartDoNotFeed").prop('checked', false);
    $("#overstockDoNotFeed").prop('checked', false);
    $("#eBayDoNotFeed").prop('checked', false);
    $("#bpmDoNotFeed").prop('checked', false);
    $("#mellowDoNotFeed").prop('checked', false);
    $("#houzzDoNotFeed").prop('checked', false);
    document.getElementById('remarkText').innerHTML = "";

    $.ajax({
      url: '../Inventory/GetInvFeedsSKUStockRule',
      type: "GET",
      contentType: "application/json charset=utf-8",
      dataType: 'json',
      data: { inventoryItemId: data.inventoryItemId },
      success: function (data) {
        document.getElementById('inventoryItemId').value = data.inventoryItemId;
        document.getElementById('itemName').value = data.itemName;
        document.getElementById('itemNoId').value = data.itemNoId;
        $("#doNotFeedFromAll").prop('checked', data.doNotFeedFromAll);
        $("#doNotFeedFromBanc").prop('checked', data.doNotFeedFromBANC);
        document.getElementById('doNotFeedFromBancQtyOnHand').value = data.qtyOnHandBanc;
        document.getElementById('doNotFeedFromBancQtyAvail').value = data.qtyAvailBanc;
        $("#doNotFeedFromMainsl").prop('checked', data.doNotFeedFromMainsl);
        document.getElementById('doNotFeedFromMainslQtyOnHand').value = data.qtyOnHandMainsl;
        document.getElementById('doNotFeedFromMainslQtyAvail').value = data.qtyAvailMainsl;
        $("#amazonDoNotFeed").prop('checked', data.amzDoNotFeed);
        $("#wayfairDoNotFeed").prop('checked', data.wyfrDoNotFeed);
        $("#walmartDoNotFeed").prop('checked', data.wlmrtDoNotFeed);
        $("#overstockDoNotFeed").prop('checked', data.ostDoNotFeed);
        $("#eBayDoNotFeed").prop('checked', data.eBayDoNotFeed);
        $("#bpmDoNotFeed").prop('checked', data.bpmDoNotFeed);
        $("#mellowDoNotFeed").prop('checked', data.mellowDoNotFeed);
        $("#houzzDoNotFeed").prop('checked', data.houzzDoNotFeed);
        document.getElementById('remarkText').innerHTML = data.remark;
        if (data.doNotFeedFromBANC == true) {
          $("#doNotFeedFromBancQtyOnHand").attr("disabled", "disabled");
          $("#doNotFeedFromBancQtyAvail").attr("disabled", "disabled");
        }

        if (data.doNotFeedFromMainsl == true) {
          $("#doNotFeedFromMainslQtyOnHand").attr("disabled", "disabled");
          $("#doNotFeedFromMainslQtyAvail").attr("disabled", "disabled");
        }
        // alert("Yay!");
      }
    });
    // alert('You clicked on ' + data.itemNoId + '\'s row');
  });
});


$(function () {
  $("#doNotFeedFromAll").click(function () {
    if ($(this).is(":checked")) {
      document.getElementById('doNotFeedFromBanc').checked = true;
      $("#doNotFeedFromBanc").attr("disabled", "disabled");
      $("#doNotFeedFromBancQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromBancQtyAvail").attr("disabled", "disabled");

      document.getElementById('doNotFeedFromMainsl').checked = true;
      $("#doNotFeedFromMainsl").attr("disabled", "disabled");
      $("#doNotFeedFromMainslQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromMainslQtyAvail").attr("disabled", "disabled");

      $("#amazonDoNotFeed").attr("disabled", "disabled");

      $("#wayfairDoNotFeed").attr("disabled", "disabled");

      $("#walmartDoNotFeed").attr("disabled", "disabled");

      $("#overstockDoNotFeed").attr("disabled", "disabled");

      $("#eBayDoNotFeed").attr("disabled", "disabled");

      $("#bpmDoNotFeed").attr("disabled", "disabled");

      $("#mellowDoNotFeed").attr("disabled", "disabled");

      $("#houzzDoNotFeed").attr("disabled", "disabled");
    } else {
      document.getElementById('doNotFeedFromBanc').checked = false;
      $("#doNotFeedFromBanc").removeAttr("disabled");
      $("#doNotFeedFromBancQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromBancQtyAvail").removeAttr("disabled");
      $("#doNotFeedFromBanc").focus();

      document.getElementById('doNotFeedFromMainsl').checked = false;
      $("#doNotFeedFromMainsl").removeAttr("disabled");
      $("#doNotFeedFromMainslQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromMainslQtyAvail").removeAttr("disabled");

      $("#amazonDoNotFeed").removeAttr("disabled");

      $("#wayfairDoNotFeed").removeAttr("disabled");

      $("#walmartDoNotFeed").removeAttr("disabled");

      $("#overstockDoNotFeed").removeAttr("disabled");

      $("#eBayDoNotFeed").removeAttr("disabled");

      $("#bpmDoNotFeed").removeAttr("disabled");

      $("#mellowDoNotFeed").removeAttr("disabled");

      $("#houzzDoNotFeed").removeAttr("disabled");

    }
  });
});

$(function () {
  $("#doNotFeedFromBanc").click(function () {
    if ($(this).is(":checked") && (document.getElementById('doNotFeedFromMainsl').checked == false)) {
      $("#doNotFeedFromBancQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromBancQtyAvail").attr("disabled", "disabled");
    } else if ($(this).is(":checked") && (document.getElementById('doNotFeedFromMainsl').checked == true)) {
      $("#doNotFeedFromAll").click();
    } else {
      $("#doNotFeedFromBancQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromBancQtyAvail").removeAttr("disabled");
      $("#doNotFeedFromBanc").focus();
    }
  });
});

$(function () {
  $("#doNotFeedFromMainsl").click(function () {
    if ($(this).is(":checked") && (document.getElementById('doNotFeedFromBanc').checked == false)) {
      $("#doNotFeedFromMainslQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromMainslQtyAvail").attr("disabled", "disabled");
    } else if ($(this).is(":checked") && (document.getElementById('doNotFeedFromBanc').checked == true)) {
      $("#doNotFeedFromAll").click();
    } else {
      $("#doNotFeedFromMainslQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromMainslQtyAvail").removeAttr("disabled");
      $("#doNotFeedFromMainsl").focus();
    }
  });

  if ($("#doNotFeedFromMainsl").is(":checked") && (document.getElementById('doNotFeedFromBanc').checked == false)) {
    $("#doNotFeedFromMainslQtyOnHand").attr("disabled", "disabled");
    $("#doNotFeedFromMainslQtyAvail").attr("disabled", "disabled");
  } else if ($(this).is(":checked") && (document.getElementById('doNotFeedFromBanc').checked == true)) {
    $("#doNotFeedFromAll").click();
  } else {
    $("#doNotFeedFromMainslQtyOnHand").removeAttr("disabled");
    $("#doNotFeedFromMainslQtyAvail").removeAttr("disabled");
    $("#doNotFeedFromMainsl").focus();
  }

});




// updateInvFeedsSKUDetail
$("#updateInvFeedsSKUDetail").click(function () {
  var returnResult = new Object();
  /*
  document.getElementById('inventoryItemId').value = data.inventoryItemId;
  document.getElementById('itemName').value = data.itemName;
  document.getElementById('itemNoId').value = data.itemNoId;
  $("#doNotFeedFromAll").prop('checked', data.doNotFeedFromAll);
  $("#doNotFeedFromBanc").prop('checked', data.doNotFeedFromBanc);
  document.getElementById('doNotFeedFromBancQtyOnHand').value = data.qtyOnHandBanc;
  document.getElementById('doNotFeedFromBancQtyAvail').value = data.qtyAvailBanc;
  $("#doNotFeedFromMainsl").prop('checked', data.doNotFeedFromMainsl);
  document.getElementById('doNotFeedFromMainslQtyOnHand').value = data.qtyOnHandMainsl;
  document.getElementById('doNotFeedFromMainslQtyAvail').value = data.qtyAvailMainsl;
  $("#amazonDoNotFeed").prop('checked', data.amzDoNotFeed);
  $("#wayfairDoNotFeed").prop('checked', data.wyfrDoNotFeed);
  $("#walmartDoNotFeed").prop('checked', data.wlmrtDoNotFeed);
  $("#overstockDoNotFeed").prop('checked', data.ostDoNotFeed);
  $("#eBayDoNotFeed").prop('checked', data.eBayDoNotFeed);
  $("#bpmDoNotFeed").prop('checked', data.bpmDoNotFeed);
  $("#mellowDoNotFeed").prop('checked', data.mellowDoNotFeed);
  $("#houzzDoNotFeed").prop('checked', data.houzzDoNotFeed);
  */

  returnResult.InventoryItemId = $('#inventoryItemId').val();
  returnResult.ItemName = $('#itemName').val();
  returnResult.ItemNoId = $('#itemNoId').val();
  returnResult.DoNotFeedFromAll = $('#doNotFeedFromAll').val();
  returnResult.DoNotFeedFromBanc = $('#doNotFeedFromBanc').val();
  returnResult.QtyOnHandBanc = $('#doNotFeedFromBancQtyOnHand').val();
  returnResult.QtyAvailBanc = $('#doNotFeedFromBancQtyAvail').val();
  returnResult.DoNotFeedFromMainsl = $('#doNotFeedFromMainsl').val();
  returnResult.QtyOnHandMainsl = $('#doNotFeedFromMainslQtyOnHand').val();
  returnResult.QtyAvailMainsl = $('#doNotFeedFromMainslQtyAvail').val();
  returnResult.AmzDoNotFeed = $('#amazonDoNotFeed').is(':checked');
  returnResult.BPMDoNotFeed = $('#bpmDoNotFeed').is(':checked');
  returnResult.eBayDoNotFeed = $('#eBayDoNotFeed').is(':checked');
  returnResult.HouzzDoNotFeed = $('#houzzDoNotFeed').is(':checked');
  returnResult.MellowDoNotFeed = $('#mellowDoNotFeed').is(':checked');
  returnResult.OstDoNotFeed = $('#overstockDoNotFeed').is(':checked');
  returnResult.WlmrtDoNotFeed = $('#walmartDoNotFeed').is(':checked');
  returnResult.WyfrDoNotFeed = $('#wayfairDoNotFeed').is(':checked');
  console.log(JSON.stringify(returnResult));

  $.ajax({
    url: '../Inventory/UpdateInvFeedsSKUStockRule',
    type: "POST",
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(returnResult),
    success: function () {
      alert('The record was updated!');
    }
  });
})








function loadDataTable() {
  dataTable = $("#invMainslBancItems").DataTable({
    "order": [[2, "asc"]],
    dom: 'Bfrtip',
    lengthMenu: [[15, 25, 50, 100], [15, 25, 50, 100]],
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
      "url": "/Inventory/GetMainslBancInvItems",
      "type": "GET",
      "datatype": "json",
      "dataSrc": "",
      "data": {
        "today": today
      }
    },
    "columns": [
      { "data": "inventoryItemId", "visible": false },
      { "data": "remark", "width": "20%" },
      { "data": "itemName", "width": "40%" },
      { "data": "qtyAvailMainsl", "width": "20%" },
      { "data": "qtyAvailBanc", "width": "20%" }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });

  dataTable2 = $("#invAvailNoteItems").DataTable({
    "order": [[2, "asc"]],
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
          return `<div class="text-start">
                        <a href="/Inventory/mainsl_banc_feeds_note/${row['notesRulesId']}">
                            ${data}
                        </a>
                        </div>`;
        },
        "width": "80%"
      },
      {
        "data": "createdBy",
        "render": function (data, type, row, meta) {
          return `<div class="text-start">
                        <a href="/Inventory/mainsl_banc_feeds_note/${row['notesRulesId']}">
                            ${data}
                        </a>
                        </div>`;
        },
        "width": "8%"
      },
      {
        "data": "createdTime",
        "render": function (data, type, row, meta) {
          return `<div class="text-start">
                        <a href="/Inventory/mainsl_banc_feeds_note/${row['notesRulesId']}">
                            ${data}
                        </a>
                        </div>`;
        },
        "width": "12%"
      }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });
  /*
  dataTable3 = $("#invFeedRuleItems").DataTable({
    "ajax": {
      "url": "/Inventory/GetAllMainslBancInvFeedRules",
      "type": "GET",
      "datatype": "json",
      "dataSrc": ""
    }, "columnDefs": [
      {
        "targets": "-1",
        "className": "'dt-left'"
      }],
    "columns": [
      { "data": "invFeedRuleId", "visible": false },
      {
        "data": "customerName",
        "render": function (data, type, row, meta) {
          return `<div class="text-start">
                        <a href="/Inventory/mainsl_banc_feeds_rules/${row['invFeedRuleId']}">
                            ${data}
                        </a>
                        </div>`;
        },
        "width": "40%"
      },
      {
        "data": "zeroOutAt",
        "className": "text-end",
        "width": "30%"
      },
      {
        "data": "customFeedRatioText",
        "className": "text-end",
        "width": "30%"
      }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });*/
}