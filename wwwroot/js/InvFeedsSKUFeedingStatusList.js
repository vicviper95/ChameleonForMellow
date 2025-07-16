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

$(document).ready(function () {
  var table = $('#invFeedsSKUFeedingStatusItems').DataTable();


  $('#invFeedsSKUFeedingStatusItems tbody').on('click', 'tr', function () {
    //var tmpData = $('#invFeedsSKUFeedingStatusItems').DataTable.row('.selected').data();
    var data = table.row(this).data();
    //$('#grid').load('../Inventory/GetInvFeedsSKUFeedingStatus',
    //  { "itemNoId": data.itemNoId });

    $.ajax({
      url: '../Inventory/GetInvFeedsSKUFeedingStatus',
      type: "GET",
      contentType: "application/json charset=utf-8",
      dataType: 'json',
      data: { itemNoId: data.itemNoId },
      success: function (data) {
        $("#itemNoId").val(data.itemNoId);
        $("#itemName").val(data.itemName);
        $("#description").val(data.description);
        $("#amazonIcrId").val(data.amazonIcrId);
        $("#amazonCustSKU").val(data.amazonCustSKU);
        $("#amazonUPC").val(data.amazonUPC);
        $("#asin").val(data.asin);
        $("#amazonLastModifiedBy").val(data.amazonLastModifiedBy);
        $("#amazonLastModifiedTime").val(data.amazonLastModifiedTime);
        $("#amazonFeedsEnable").prop('checked', data.amazonFeedsEnable);

        $("#ebayIcrId").val(data.eBayIcrId);
        $("#ebayCustSKU").val(data.ebayCustSKU);
        $("#ebayLastModifiedBy").val(data.ebayLastModifiedBy);
        $("#ebayLastModifiedTime").val(data.ebayLastModifiedTime);
        $("#ebayFeedsEnable").prop('checked', data.ebayFeedsEnable);

        $("#overstockIcrId").val(data.overstockIcrId);
        $("#overstockCustSKU").val(data.overstockCustSKU);
        $("#overstockUPC").val(data.overstockUPC);
        $("#overstockLastModifiedBy").val(data.overstockLastModifiedBy);
        $("#overstockLastModifiedTime").val(data.overstockLastModifiedTime);
        $("#overstockFeedsEnable").prop('checked', data.overstockFeedsEnable);

        $("#walmartIcrId").val(data.walmartIcrId);
        $("#walmartCustSKU").val(data.walmartCustSKU);
        $("#walmartUPC").val(data.walmartUPC);
        $("#walmartLastModifiedBy").val(data.walmartLastModifiedBy);
        $("#walmartLastModifiedTime").val(data.walmartLastModifiedTime);
        $("#walmartFeedsEnable").prop('checked', data.walmartFeedsEnable);

        $("#wayfairIcrId").val(data.wayfairIcrId);
        $("#wayfairCustSKU").val(data.wayfairCustSKU);
        $("#wayfairUPC").val(data.wayfairUPC);
        $("#wayfairLastModifiedBy").val(data.wayfairLastModifiedBy);
        $("#wayfairLastModifiedTime").val(data.wayfairLastModifiedTime);
        $("#wayfairFeedsEnable").prop('checked', data.wayfairFeedsEnable);


        $("#bpmIcrId").val(data.bpmIcrId);
        $("#bpmCustSKU").val(data.bpmCustSKU);
        $("#bpmLastModifiedBy").val(data.bpmLastModifiedBy);
        $("#bpmLastModifiedTime").val(data.bpmLastModifiedTime);
        $("#bpmFeedsEnable").prop('checked', data.bpmFeedsEnable);

        $("#mellowIcrId").val(data.mellowIcrId);
        $("#mellowCustSKU").val(data.mellowCustSKU);
        $("#mellowLastModifiedBy").val(data.mellowLastModifiedBy);
        $("#mellowLastModifiedTime").val(data.mellowLastModifiedTime);
        $("#mellowFeedsEnable").prop('checked', data.mellowFeedsEnable);

        $("#houzzIcrId").val(data.houzzIcrId);
        $("#houzzCustSKU").val(data.houzzCustSKU);
        $("#houzzLastModifiedBy").val(data.houzzLastModifiedBy);
        $("#houzzLastModifiedTime").val(data.houzzLastModifiedTime);
        $("#houzzFeedsEnable").prop('checked', data.houzzFeedsEnable);

        // alert("Yay!");
      }
    });
    // alert('You clicked on ' + data.itemNoId + '\'s row');
  });
});

$(function () {
  if ($("#itemNoId").val == null) {
    $("#grid").removeAttr("disabled");
  } else {
    $("#grid").attr("disabled", "disabled");
  }
});


function loadDataTable() {
  dataTable = $("#invFeedsSKUFeedingStatusItems").DataTable({
    "autoWidth": false,
    "order": [[1, "asc"]],
    lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
    "ajax": {
      "url": "/Inventory/GetInvFeedsSKUFeedingStatusList",
      "type": "GET",
      "datatype": "json",
      "dataSrc": "",
      "data": {
        "customerId": "0"
      }
    },
    "columns": [
      { "data": "itemNoId", "visible": false },
      { "data": "bpmSKU", "width": "5%" },
      { "data": "description", "width": "15%" }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "20%"
  });
}
