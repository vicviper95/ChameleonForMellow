var tmpTotal = 0;
var dataTable3;

$(document).ready(function () {
  loadDataTable();

  var table = $('#invFeedRuleItems').DataTable();
  $('#invFeedRuleItems tbody').on('dblclick', 'tr', function () {
    var data = table.row(this).data();
    window.open("/Inventory/mainsl_banc_feeds_rules/" + data.invFeedRuleId, "_self");
  });


  if ($('#isAmazonLowStockOn').is(":checked")) {
    $("#amazonLowStockQty").removeAttr("disabled");
    $("#isAmazonLowStockOn").focus();
  } else {
    $("#amazonLowStockQty").attr("disabled", "disabled");
  }
});

// For waiting indicator
$body = $("body");

$(document).on({
  ajaxStart: function () { $body.addClass("loading"); },
  ajaxStop: function () { $body.removeClass("loading"); }
});

$(function () {
  $("#generalFeedSettingTabs").tabs();
});


$(function () {
  $('#ratiosOnLowData').click(function () {
    tmpTotal = 0;
    tmpTotal += parseInt($('#amazonRatioOnLowData').val());
    tmpTotal += parseInt($('#overstockRatioOnLowData').val());
    tmpTotal += parseInt($('#walmartRatioOnLowData').val());
    tmpTotal += parseInt($('#wayfairRatioOnLowData').val());
    tmpTotal += parseInt($('#eBayRatioOnLowData').val());
    tmpTotal += parseInt($('#bpmRatioOnLowData').val());
    tmpTotal += parseInt($('#mellowRatioOnLowData').val());
    tmpTotal += parseInt($('#houzzRatioOnLowData').val());
    //alert(tmpTotal);
    console.log(tmpTotal);
    $('#totalOfRatioOnLowData').val(tmpTotal);

    if (parseInt($('#totalOfRatioOnLowData').val()) != 100) {
      $('#totalOfRatioOnLowData').css({ 'color': '#C70039' });
      document.getElementById("invFeedsTotalMsg").innerHTML = "Total should be 100!";
    } else {
      $('#totalOfRatioOnLowData').css({ 'color': '#000000' });
      document.getElementById("invFeedsTotalMsg").innerHTML = "";

    }
  })
});


$(function () {
  $('#amazonLowStockQty').click(function () {

    if (parseInt($('#amazonLowStockQty').val()) > 30) {
      $('#totalOfRatioOnLowData').css({ 'color': '#C70039' });
      document.getElementById("invFeedsLowStockAmazonMsg").innerHTML = "This number cannot exceed 30!";
      document.getElementById("amazonLowStockQty").innerHTML = 30;
      //$('#amazonLowStockQty').val() = 30;
    } else {
      $('#amazonLowStockQty').css({ 'color': '#000000' });
      document.getElementById("invFeedsLowStockAmazonMsg").innerHTML = "";

    }
  })
});

$(function () {
  $('#isAmazonLowStockOn').click(function () {
    if ($(this).is(":checked")) {
      $("#amazonLowStockQty").removeAttr("disabled");
      $("#isAmazonLowStockOn").focus();
    } else {
      $("#amazonLowStockQty").attr("disabled", "disabled");
    }
  })
});




$("#updateInvFeedsGeneralSetting").click(function () {
  if (parseInt($('#totalOfRatioOnLowData').val()) == 100 && parseInt($('#amazonLowStockQty').val()) <= 30) {
    var returnResult = new Object();
    returnResult.SalesHistoryLowDataSwitchQty = $('#salesHistoryLowDataSwitchQty').val();
    returnResult.ZeroOutBufferMainSL = $('#zeroOutBufferMainSL').val();
    returnResult.ZeroOutBufferBANC = $('#zeroOutBufferBANC').val();
    returnResult.AmazonRatioOnLowData = $('#amazonRatioOnLowData').val();
    returnResult.eBayRatioOnLowData = $('#eBayRatioOnLowData').val();
    returnResult.OverstockRatioOnLowData = $('#overstockRatioOnLowData').val();
    returnResult.WalmartRatioOnLowData = $('#walmartRatioOnLowData').val();
    returnResult.WayfairRatioOnLowData = $('#wayfairRatioOnLowData').val();
    returnResult.BpmRatioOnLowData = $('#bpmRatioOnLowData').val();
    returnResult.MellowRatioOnLowData = $('#mellowRatioOnLowData').val();
    returnResult.HouzzRatioOnLowData = $('#houzzRatioOnLowData').val();
    returnResult.AmazonLowStockQty = $('#amazonLowStockQty').val();
    returnResult.IsAmazonLowStockOn = $('#isAmazonLowStockOn').is(':checked');

    console.log(JSON.stringify(returnResult));

    $.ajax({
      url: '../Inventory/UpdateInvFeedsSetting',
      type: "POST",
      contentType: "application/json charset=utf-8",
      dataType: 'json',
      data: JSON.stringify(returnResult),
      success: function () {
        alert('The Setting was updated!');
      }
    });
  }
  else {
    alert('Check the Total of Ratios or Low Stock Amazon Rule Quantity!');
  }
})



function loadDataTable() {
  dataTable3 = $("#invFeedRuleItems").DataTable({
    "autoWidth": false,
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
        "width": "40%"
      },
      {
        "data": "zeroOutAt",
        "width": "30%", "className": "text-right"
      },
      {
        "data": "customFeedRatioText",
        "width": "30%", "className": "text-right"
      }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });

}
