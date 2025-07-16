var dataTable;
var dataTable2;
var dataTable3;
var tmpDate = new Date();
var today = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();
var todayString = getFormattedDate(today);

var markets = ["None", "Amazon", "Wayfair", "Overstock", "eBay", "Home Depot", "Target", "BPM Web", "Mellow Home"];
var marketIds = [0, 1, 4, 12, 5, 340, 341, 3, 7];

const marketsIds = { 0: "None", 1: "Amazon", 4: "Wayfair", 12: "Overstock", 5: "eBay", 340: "Home Depot", 341: "Target", 3: "BPM Web", 7: "Mellow Home" };

$('#bttnUpdateInvRevised').one('click', (function () {
  var that = $('#updateModal');
  var myModal = new bootstrap.Modal(document.getElementById('updateModal'));


  myModal.show();
  that.find('button[id="updateWarehousesBtn"]').click(function () {
    var txt = that.find('select[id="modal_timeperiod"]').val();
    //console.log(txt);

    $.ajax({
      url: 'updateInventoryDefinedPeriod',
      type: "GET",
      contentType: "application/json charset=utf-8",
      dataType: 'json',
      data: { sel: txt },
      success: function () {
        console.log("Done!");
        document.getElementById('ImportFastMovingSkus').disabled = false;
        alert('Thank you for waiting!');
        location.reload(true);
        getLastUpdateInfo();
      }
    }); // End of ajax
  });
})
);

//filterForLeftOverBtn
$('#filterForLeftOverBtn').click(function () {
  var that = $('#filterForLeftOverModal');
  var myModal = new bootstrap.Modal(document.getElementById('filterForLeftOverModal'));


  myModal.show();
  //that.find('button[id="updateWarehousesBtn"]').click(function () {
  //  var txt = that.find('select[id="modal_timeperiod"]').val();
  //  //console.log(txt);

  //  $.ajax({
  //    url: 'updateInventoryDefinedPeriod',
  //    type: "GET",
  //    contentType: "application/json charset=utf-8",
  //    dataType: 'json',
  //    data: { sel: txt },
  //    success: function () {
  //      console.log("Done!");
  //      alert('Thank you for waiting!');
  //      location.reload(true);
  //      getLastUpdateInfo();
  //    }
  //  }); // End of ajax

  //});

})



$("#updateInvFeedsLeftOverBtn").click(function () {
  var table = $('#invFeedsLeftOverItems').DataTable();
  const jsonArray = [];

  var table_data = table.rows().data().toArray();
  var table_data_Nodes = table.rows().nodes().toArray();
  //var updatedData = [];
  //var test_data = table.buttons.exportData();
  for (i = 0; i < table_data.length; i++) {
    let selectedMarketText = $(table_data_Nodes[i]).find("select.market option:selected").text();
    let selectedMarketTextId = $(table_data_Nodes[i]).find("select.market option:selected").val();
    table_data[i].assignedMarket = selectedMarketText;
    table_data[i].assignedMarketId = selectedMarketTextId;
  }
  jsonArray.push(table_data);
  console.log(JSON.stringify(table_data));

  var returnResult = new Object();
  //returnResult.customerId = 0;
  returnResult.skuList = jsonArray;

  $.ajax({
    url: '../Inventory/UpdateInvFeedsLeftOverList',
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


// assgndMkAllFilterCB assgndMkNoneFilterCB assgndMkAmazonFilterCB assgndMkBpmWebFilterCB assgndMkeBayFilterCB assgndMkHomeDepotFilterCB
// assgndMkMellowHomeFilterCB assgndMkWalmartFilterCB assgndMkWayfairFilterCB assgndMkTargetFilterCB

// warehouseAllFilterCB warehouseBancFilterCB warehouseBascFilterCB warehouseMainSLFilterCB warehouseSwcaftFilterCB

// itemStatusAllFilterCB itemStatusNewFilterCB itemStatusActiveFilterCB itemStatusActiveDiscoFilterCB itemStatusDiscoFilterCB
// itemStatusInactiveFilterCB itemStatusObsoleteFilterCB


// For Checkbox Filters
// Assigned Market #06
$('#assgndMkAllFilterCB, #assgndMkNoneFilterCB, #assgndMkAmazonFilterCB, #assgndMkBpmWebFilterCB, #assgndMkeBayFilterCB, #assgndMkHomeDepotFilterCB, #assgndMkMellowHomeFilterCB, #assgndMkWalmartFilterCB, #assgndMkWayfairFilterCB, #assgndMkTargetFilterCB').click(function () {
  invFeedsLeftOverTable.draw();
});

// Warehouse #07
$('#warehouseAllFilterCB, #warehouseBancFilterCB, #warehouseBascFilterCB, #warehouseMainSLFilterCB, #warehouseSwcaftFilterCB').click(function () {
  invFeedsLeftOverTable.draw();
});

// Item Status #08
$('#itemStatusAllFilterCB, #itemStatusNewFilterCB, #itemStatusActiveFilterCB, #itemStatusActiveDiscoFilterCB, #itemStatusDiscoFilterCB, #itemStatusInactiveFilterCB, #itemStatusObsoleteFilterCB').click(function () {
  invFeedsLeftOverTable.draw();
});
/*
function clearFilterCBs() {

  //document.getElementById('assgndMkAllFilterCB').checked = true;
  document.getElementById('assgndMkNoneFilterCB').checked = true;
  document.getElementById('assgndMkAmazonFilterCB').checked = true;
  document.getElementById('assgndMkBpmWebFilterCB').checked = true;
  document.getElementById('assgndMkeBayFilterCB').checked = true;
  document.getElementById('assgndMkHomeDepotFilterCB').checked = true;
  document.getElementById('assgndMkMellowHomeFilterCB').checked = true;
  document.getElementById('assgndMkWayfairFilterCB').checked = true;
  document.getElementById('assgndMkTargetFilterCB').checked = true;

  //document.getElementById('warehouseAllFilterCB').checked = true;
  document.getElementById('warehouseBancFilterCB').checked = true;
  document.getElementById('warehouseBascFilterCB').checked = true;
  document.getElementById('warehouseMainSLFilterCB').checked = true;
  document.getElementById('warehouseSwcaftFilterCB').checked = true;
  document.getElementById('warehousePrismCastFilterCB').checked = true;
  document.getElementById('warehousePrismCaltFilterCB').checked = true;

  //document.getElementById('itemStatusAllFilterCB').checked = true;
  document.getElementById('itemStatusNewFilterCB').checked = true;
  document.getElementById('itemStatusActiveFilterCB').checked = true;
  document.getElementById('itemStatusActiveDiscoFilterCB').checked = true;
  document.getElementById('itemStatusDiscoFilterCB').checked = true;
  document.getElementById('itemStatusInactiveFilterCB').checked = true;
  document.getElementById('itemStatusObsoleteFilterCB').checked = true;
}*/

//For custom filter
$.fn.dataTable.ext.search.push(
  function (settings, data, dataIndex) {
    if (settings.nTable.id !== 'invFeedsLeftOverItems') {
      return true;
    }
    //var allMf = document.getElementById('assgndMkAllFilterCB').checked;
    var noneMf = document.getElementById('assgndMkNoneFilterCB').checked;
    var amazonMf = document.getElementById('assgndMkAmazonFilterCB').checked;
    var bpmMf = document.getElementById('assgndMkBpmWebFilterCB').checked;
    var eBayMf = document.getElementById('assgndMkeBayFilterCB').checked;
    var homeDepotMf = document.getElementById('assgndMkHomeDepotFilterCB').checked;
    var mellowMf = document.getElementById('assgndMkMellowHomeFilterCB').checked;
    var wayfairMf = document.getElementById('assgndMkWayfairFilterCB').checked;
    var targetMf = document.getElementById('assgndMkTargetFilterCB').checked;

    //var allWf = document.getElementById('warehouseAllFilterCB').checked;
    var bancWf = document.getElementById('warehouseBancFilterCB').checked;
    var bascWf = document.getElementById('warehouseBascFilterCB').checked;
    var mainslWf = document.getElementById('warehouseMainSLFilterCB').checked;
    var swcaftWf = document.getElementById('warehouseSwcaftFilterCB').checked;
    var prismCastWf = document.getElementById('warehousePrismCastFilterCB').checked;
    var prismCaltWf = document.getElementById('warehousePrismCaltFilterCB').checked;

    //var allIf = document.getElementById('itemStatusAllFilterCB').checked;
    var newIf = document.getElementById('itemStatusNewFilterCB').checked;
    var activeIf = document.getElementById('itemStatusActiveFilterCB').checked;
    var activeDiscoIf = document.getElementById('itemStatusActiveDiscoFilterCB').checked;
    var discoIf = document.getElementById('itemStatusDiscoFilterCB').checked;
    var inactiveIf = document.getElementById('itemStatusInactiveFilterCB').checked;
    var obsoleteIf = document.getElementById('itemStatusObsoleteFilterCB').checked;

    // Market
    var mkf = parseInt(data[6]);
    // Warehouse
    var pps = parseInt(data[7]);
    // Item Status
    var isf = parseInt(data[8]);

    if (
      (//(allMf ? (mkf >= 0) : "") ||
        (noneMf ? (mkf == 0) : "") ||
        (amazonMf ? (mkf == 1) : "") ||
        (bpmMf ? (mkf == 3) : "") ||
        (eBayMf ? (mkf == 5) : "") ||
        (homeDepotMf ? (mkf == 340) : "") ||
        (mellowMf ? (mkf == 7) : "") ||
        (wayfairMf ? (mkf == 4) : "") ||
        (targetMf ? (mkf == 341) : "")) &&

      (//(allWf ? (pps > 0) : "") ||
        (bancWf ? (pps == 4) : '') ||
        (bascWf ? (pps == 62) : '') ||
        (mainslWf ? (pps == 25) : '') ||
        (swcaftWf ? (pps == 54) : '') ||
        (prismCastWf ? (pps == 51) : '') ||
        (prismCaltWf ? (pps == 67) : '')) &&

      (//(allIf ? (isf > 0) : "") ||
        (newIf ? (isf == 1) : '') ||
        (activeIf ? (isf == 2) : '') ||
        (activeDiscoIf ? (isf == 3) : '') ||
        (discoIf ? (isf == 4) : '') ||
        (inactiveIf ? (isf == 5) : "") ||
        (obsoleteIf ? (isf == 6) : ''))
    ) { return true; }
    return false;
  }
);


// For waiting indicator
$body = $("body");

$(document).on({
  ajaxStart: function () { $body.addClass("loading"); },
  ajaxStop: function () { $body.removeClass("loading"); }
});

$.fn.dataTable.ext.search.push(
  function (settings, data, dataIndex) {
    if (settings.nTable.id !== 'invMainslBancItems') {
      return true;
    }
    var bancQty = parseInt($('#bancLessThanQty').val(), 10);
    var mainSLQty = parseInt($('#mainSLThanQty').val(), 10);
    var bascQty = parseInt($('#bascLessThanQty').val(), 10);
    var swcaftQty = parseInt($('#swcaftThanQty').val(), 10);
    var prismCastQty = parseInt($('#prismCastThanQty').val(), 10);
    var prismCaltQty = parseInt($('#prismCaltThanQty').val(), 10);
    var bancInv = parseFloat(data[3]) || 0; // use data for the qty column
    var bascInv = parseFloat(data[4]) || 0; // use data for the qty column
    var mainslInv = parseFloat(data[5]) || 0; // use data for the qty column
    var swcaftInv = parseFloat(data[6]) || 0; // use data for the qty column
    var prismCastInv = parseFloat(data[7]) || 0; // use data for the qty column
    var prismCaltInv = parseFloat(data[8]) || 0; // use data for the qty column


    if ((isNaN(bancQty) && isNaN(mainSLQty) && isNaN(bascQty) && isNaN(swcaftQty) && isNaN(prismCastQty) && isNaN(prismCaltQty))
      || (0 < bancInv && bancInv <= bancQty) || (0 < mainslInv && mainslInv <= mainSLQty)
      || (0 < bascInv && bascInv <= bascQty) || (0 < swcaftInv && swcaftInv <= swcaftQty)
      || (0 < prismCastInv && prismCastInv <= prismCastQty) || (0 < prismCaltInv && prismCaltInv <= prismCaltQty)) {
      return true;
    }
    return false;
  }

);



/*
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
*/
//resetToDefaultBtn
//ResetAllTheRulesOnSKUs
$('#resetToDefaultBtn').click(function () {
  if (confirm('Do you really want to reset everything to defatul?')) {
    $.ajax({
      url: '../Inventory/ResetAllTheRulesOnSKUs',
      type: "POST",
      contentType: "application/json charset=utf-8",
      dataType: 'json',
      data: '',
      success: function () {
        alert('Reset to default settings : Done!');
      }
    });
  } else {
    console.log('Reset Cancelled.');
  }
});

function getFormattedDate(yDate) {
  let date = new Date(yDate);
  let year = date.getFullYear();
  let month = (1 + date.getMonth()).toString().padStart(2, '0');
  let day = date.getDate().toString().padStart(2, '0');

  return month + "/" + day + "/" + year;
}

function getLastUpdateInfo() {
  //console.log(document.getElementById('hasUpdInventory').value);
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
      document.getElementById("lastUpdateDateInfo").innerHTML = response.customMessage;
      if (response.customMessage != "No update in today.") {
        document.getElementById('hasUpdInventory').value = 1;
      }
      //console.log(document.getElementById('hasUpdInventory').value);
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
  //var table = $('#invMainslBancItems').DataTable();
  $("#updateModal").modal();
  $("#filterForLeftOverModal").modal();
  document.getElementById('hasUpdInventory').value = 0;
  //clearFilterCBs();
  loadDataTable();
  getLastUpdateInfo();
  warehousesStatusTable;
  invFeedsLeftOverTable;

  // Event listener to the two filtering inputs to re-draw on input
  $('#bancLessThanQty, #mainSLThanQty, #bascLessThanQty, #swcaftLessThanQty').keyup(function () {
    warehousesStatusTable.draw();
  }
  );
  // Double Click
  $('#invMainslBancItems tbody').on('dblclick', 'tr', function () {
    //alert('I\'m here!');
    var data = warehousesStatusTable.row(this).data();
    //alert('You clicked on ' + data[0] + '\'s row');
    window.open("/Inventory/mainsl_banc_edit/" + data.inventoryItemId, "_self");
  });

  //$('#invFeedsLeftOverItems tbody').on('click', 'tr', function () {
  $('#invFeedsLeftOverItems tbody').on('change', function () {
    var dv = invFeedsLeftOverTable.row().data();
    var dv1 = invFeedsLeftOverTable.row();
    dv.isEdited = true;
    //var wh = $(this).find().text();//dv.assignedMarket;
    /*
    var wh = invFeedsLeftOverTable.row().find("select.market option:selected").text();
    if (wh == "Amazon") { dv.assignedMarketId = 1 }
    else if (wh == "Wayfair") { dv.assignedMarketId = 4 }
    else if (wh == "Overstock") { dv.assignedMarketId = 12 }
    else if (wh == "eBay") { dv.assignedMarketId = 5 }
    else if (wh == "Home Depot") { dv.assignedMarketId = 340 }
    else if (wh == "Target") { dv.assignedMarketId = 341 }
    else if (wh == "BPM Web") { dv.assignedMarketId = 3 }
    else if (wh == "Mellow Home") { dv.assignedMarketId = 7 }
    else if (wh == "None") { dv.assignedMarketId = 0 }
    */
  });

  // Single Click
  $('#invMainslBancItems tbody').on('click', 'tr', function () {
    //var tmpData = $('#invFeedsSKUFeedingStatusItems').DataTable.row('.selected').data();
    //var dv = warehousesStatusTable.row(this).data();
    //var data = table.row(this).data();
    var data = warehousesStatusTable.row(this).data();
    //$('#grid').load('../Inventory/GetInvFeedsSKUFeedingStatus',
    //  { "itemNoId": data.itemNoId });
    $("#doNotFeedFromBanc").removeAttr("disabled");
    $("#doNotFeedFromBancQtyOnHand").removeAttr("disabled");
    $("#doNotFeedFromBancQtyAvail").removeAttr("disabled");
    $("#doNotFeedFromMainsl").removeAttr("disabled");
    $("#doNotFeedFromMainslQtyOnHand").removeAttr("disabled");
    $("#doNotFeedFromMainslQtyAvail").removeAttr("disabled");
    $("#doNotFeedFromSwcaft").removeAttr("disabled");
    $("#doNotFeedFromSwcaftQtyOnHand").removeAttr("disabled");
    $("#doNotFeedFromSwcaftQtyAvail").removeAttr("disabled");
    $("#doNotFeedFromBasc").removeAttr("disabled");
    $("#doNotFeedFromBascQtyOnHand").removeAttr("disabled");
    $("#doNotFeedFromBascQtyAvail").removeAttr("disabled");
    $("#doNotFeedFromPrismCast").removeAttr("disabled");
    $("#doNotFeedFromPrismCastQtyOnHand").removeAttr("disabled");
    $("#doNotFeedFromPrismCastQtyAvail").removeAttr("disabled");
    $("#doNotFeedFromPrismCalt").removeAttr("disabled");
    $("#doNotFeedFromPrismCaltQtyOnHand").removeAttr("disabled");
    $("#doNotFeedFromPrismCaltQtyAvail").removeAttr("disabled");
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
    $("#doNotFeedFromSwcaft").prop('checked', false);
    document.getElementById('doNotFeedFromSwcaftQtyOnHand').value = 0;
    document.getElementById('doNotFeedFromSwcaftQtyAvail').value = 0;
    $("#doNotFeedFromBasc").prop('checked', false);
    document.getElementById('doNotFeedFromBascQtyOnHand').value = 0;
    document.getElementById('doNotFeedFromBascQtyAvail').value = 0;
    $("#doNotFeedFromPrismCast").prop('checked', false);
    document.getElementById('doNotFeedFromPrismCastQtyOnHand').value = 0;
    document.getElementById('doNotFeedFromPrismCastQtyAvail').value = 0;
    $("#doNotFeedFromPrismCalt").prop('checked', false);
    document.getElementById('doNotFeedFromPrismCaltQtyOnHand').value = 0;
    document.getElementById('doNotFeedFromPrismCaltQtyAvail').value = 0;
    $("#amazonDoNotFeed").prop('checked', false);
    $("#wayfairDoNotFeed").prop('checked', false);
    $("#walmartDoNotFeed").prop('checked', false);
    $("#overstockDoNotFeed").prop('checked', false);
    $("#eBayDoNotFeed").prop('checked', false);
    $("#bpmDoNotFeed").prop('checked', false);
    $("#mellowDoNotFeed").prop('checked', false);
    $("#houzzDoNotFeed").prop('checked', false);
    $("#homeDepotDoNotFeed").prop('checked', false);
    $("#targetDoNotFeed").prop('checked', false);
    document.getElementById('doNotFeedFromStagePOModBanc60').value = 0;
    document.getElementById('doNotFeedFromStagePOModBasc60').value = 0;
    document.getElementById('doNotFeedFromStagePOModMainsl60').value = 0;
    document.getElementById('doNotFeedFromStagePOModSwcaft60').value = 0;
    document.getElementById('doNotFeedFromStagePOModPrismCast60').value = 0;
    document.getElementById('doNotFeedFromStagePOModPrismCalt60').value = 0;
    document.getElementById('doNotFeedFromStagePOModBanc90').value = 0;
    document.getElementById('doNotFeedFromStagePOModBasc90').value = 0;
    document.getElementById('doNotFeedFromStagePOModMainsl90').value = 0;
    document.getElementById('doNotFeedFromStagePOModSwcaft90').value = 0;
    document.getElementById('doNotFeedFromStagePOModPrismCast90').value = 0;
    document.getElementById('doNotFeedFromStagePOModPrismCalt90').value = 0;
    document.getElementById('remarkText').innerHTML = "";

    $.ajax({
      url: '../Inventory/GetInvFeedsSKUStockRule',
      type: "GET",
      contentType: "application/json charset=utf-8",
      dataType: 'json',
      data: { inventoryItemId: data.inventoryItemId },
      success: function (data) {
        console.log(data.checkBackOrderLeadTimeBanc);
        $('#backOrderLeadTimeBanc').prop('selectedIndex', (data.checkBackOrderLeadTimeBanc - 2));
        $('#backOrderLeadTimeBasc').prop('selectedIndex', (data.checkBackOrderLeadTimeBasc - 2));
        $('#backOrderLeadTimeMainsl').prop('selectedIndex', (data.checkBackOrderLeadTimeMainsl - 2));
        $('#backOrderLeadTimeSwcaft').prop('selectedIndex', (data.checkBackOrderLeadTimeSwcaft - 2));
        $('#backOrderLeadTimePrismCast').prop('selectedIndex', (data.checkBackOrderLeadTimePrismCast - 2));
        $('#backOrderLeadTimePrismCalt').prop('selectedIndex', (data.checkBackOrderLeadTimePrismCalt - 2));
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
        $("#doNotFeedFromSwcaft").prop('checked', data.doNotFeedFromSwcaft);
        document.getElementById('doNotFeedFromSwcaftQtyOnHand').value = data.qtyOnHandSwcaft;
        document.getElementById('doNotFeedFromSwcaftQtyAvail').value = data.qtyAvailSwcaft;
        $("#doNotFeedFromBasc").prop('checked', data.doNotFeedFromBasc);
        document.getElementById('doNotFeedFromBascQtyOnHand').value = data.qtyOnHandBasc;
        document.getElementById('doNotFeedFromBascQtyAvail').value = data.qtyAvailBasc;
        $("#doNotFeedFromPrismCast").prop('checked', data.doNotFeedFromPrismCast);
        document.getElementById('doNotFeedFromPrismCastQtyOnHand').value = data.qtyOnHandPrismCast;
        document.getElementById('doNotFeedFromPrismCastQtyAvail').value = data.qtyAvailPrismCast;
        $("#doNotFeedFromPrismCalt").prop('checked', data.doNotFeedFromPrismCalt);
        document.getElementById('doNotFeedFromPrismCaltQtyOnHand').value = data.qtyOnHandPrismCalt;
        document.getElementById('doNotFeedFromPrismCaltQtyAvail').value = data.qtyAvailPrismCalt;
        $("#amazonDoNotFeed").prop('checked', data.amzDoNotFeed);
        $("#wayfairDoNotFeed").prop('checked', data.wyfrDoNotFeed);
        $("#walmartDoNotFeed").prop('checked', data.wlmrtDoNotFeed);
        $("#overstockDoNotFeed").prop('checked', data.ostDoNotFeed);
        $("#eBayDoNotFeed").prop('checked', data.eBayDoNotFeed);
        $("#bpmDoNotFeed").prop('checked', data.bpmDoNotFeed);
        $("#mellowDoNotFeed").prop('checked', data.mellowDoNotFeed);
        $("#houzzDoNotFeed").prop('checked', data.houzzDoNotFeed);
        $("#homeDepotDoNotFeed").prop('checked', data.homeDepotDoNotFeed);
        $("#targetDoNotFeed").prop('checked', data.homeDepotDoNotFeed);
        document.getElementById('doNotFeedFromStagePOModBanc60').value = data.stagePOModBanc60;
        document.getElementById('doNotFeedFromStagePOModBasc60').value = data.stagePOModBasc60;
        document.getElementById('doNotFeedFromStagePOModMainsl60').value = data.stagePOModMainsl60;
        document.getElementById('doNotFeedFromStagePOModSwcaft60').value = data.stagePOModSwcaft60;
        document.getElementById('doNotFeedFromStagePOModPrismCast60').value = data.stagePOModPrismCast60;
        document.getElementById('doNotFeedFromStagePOModPrismCalt60').value = data.stagePOModPrismCalt60;
        document.getElementById('doNotFeedFromStagePOModBanc90').value = data.stagePOModBanc90;
        document.getElementById('doNotFeedFromStagePOModBasc90').value = data.stagePOModBasc90;
        document.getElementById('doNotFeedFromStagePOModMainsl90').value = data.stagePOModMainsl90;
        document.getElementById('doNotFeedFromStagePOModSwcaft90').value = data.stagePOModSwcaft90;
        document.getElementById('doNotFeedFromStagePOModPrismCast90').value = data.stagePOModPrismCast90;
        document.getElementById('doNotFeedFromStagePOModPrismCalt90').value = data.stagePOModPrismCalt90;
        document.getElementById('remarkText').innerHTML = data.remark;
        if (data.doNotFeedFromBanc == true) {
          $("#doNotFeedFromBancQtyOnHand").attr("disabled", "disabled");
          $("#doNotFeedFromBancQtyAvail").attr("disabled", "disabled");
          $("#doNotFeedFromStagePOModBanc60").attr("disabled", "disabled");
          $("#doNotFeedFromStagePOModBanc90").attr("disabled", "disabled");
        }

        if (data.doNotFeedFromMainsl == true) {
          $("#doNotFeedFromMainslQtyOnHand").attr("disabled", "disabled");
          $("#doNotFeedFromMainslQtyAvail").attr("disabled", "disabled");
          $("#doNotFeedFromStagePOModMainsl60").attr("disabled", "disabled");
          $("#doNotFeedFromStagePOModMainsl90").attr("disabled", "disabled");
        }

        if (data.doNotFeedFromSwcaft == true) {
          $("#doNotFeedFromSwcaftQtyOnHand").attr("disabled", "disabled");
          $("#doNotFeedFromSwcaftQtyAvail").attr("disabled", "disabled");
          $("#doNotFeedFromStagePOModSwcaft60").attr("disabled", "disabled");
          $("#doNotFeedFromStagePOModSwcaft90").attr("disabled", "disabled");
        }

        if (data.doNotFeedFromBasc == true) {
          $("#doNotFeedFromBascQtyOnHand").attr("disabled", "disabled");
          $("#doNotFeedFromBascQtyAvail").attr("disabled", "disabled");
          $("#doNotFeedFromStagePOModBasc60").attr("disabled", "disabled");
          $("#doNotFeedFromStagePOModBasc90").attr("disabled", "disabled");
        }

        if (data.doNotFeedFromPrismCast == true) {
          $("#doNotFeedFromPrismCastQtyOnHand").attr("disabled", "disabled");
          $("#doNotFeedFromPrismCastQtyAvail").attr("disabled", "disabled");
          $("#doNotFeedFromStagePOModPrismCast60").attr("disabled", "disabled");
          $("#doNotFeedFromStagePOModPrismCast90").attr("disabled", "disabled");
        }

        if (data.doNotFeedFromPrismCalt == true) {
          $("#doNotFeedFromPrismCaltQtyOnHand").attr("disabled", "disabled");
          $("#doNotFeedFromPrismCaltQtyAvail").attr("disabled", "disabled");
          $("#doNotFeedFromStagePOModPrismCalt60").attr("disabled", "disabled");
          $("#doNotFeedFromStagePOModPrismCalt90").attr("disabled", "disabled");
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

      document.getElementById('doNotFeedFromSwcaft').checked = true;
      $("#doNotFeedFromSwcaft").attr("disabled", "disabled");
      $("#doNotFeedFromSwcaftQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromSwcaftQtyAvail").attr("disabled", "disabled");

      document.getElementById('doNotFeedFromBasc').checked = true;
      $("#doNotFeedFromBasc").attr("disabled", "disabled");
      $("#doNotFeedFromBascQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromBascQtyAvail").attr("disabled", "disabled");

      document.getElementById('doNotFeedFromPrismCast').checked = true;
      $("#doNotFeedFromPrismCast").attr("disabled", "disabled");
      $("#doNotFeedFromPrismCastQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromPrismCastQtyAvail").attr("disabled", "disabled");

      document.getElementById('doNotFeedFromPrismCalt').checked = true;
      $("#doNotFeedFromPrismCalt").attr("disabled", "disabled");
      $("#doNotFeedFromPrismCaltQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromPrismCaltQtyAvail").attr("disabled", "disabled");

      $("#doNotFeedFromStagePOModBanc60").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModBasc60").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModMainsl60").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModSwcaft60").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModPrismCast60").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModPrismCalt60").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModBanc90").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModBasc90").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModMainsl90").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModSwcaft90").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModPrismCast90").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModPrismCalt90").attr("disabled", "disabled");

      $("#amazonDoNotFeed").attr("disabled", "disabled");

      $("#wayfairDoNotFeed").attr("disabled", "disabled");

      $("#walmartDoNotFeed").attr("disabled", "disabled");

      $("#overstockDoNotFeed").attr("disabled", "disabled");

      $("#eBayDoNotFeed").attr("disabled", "disabled");

      $("#bpmDoNotFeed").attr("disabled", "disabled");

      $("#mellowDoNotFeed").attr("disabled", "disabled");

      $("#houzzDoNotFeed").attr("disabled", "disabled");

      $("#homeDepotDoNotFeed").attr("disabled", "disabled");

      $("#targetDoNotFeed").attr("disabled", "disabled");
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

      document.getElementById('doNotFeedFromSwcaft').checked = false;
      $("#doNotFeedFromSwcaft").removeAttr("disabled");
      $("#doNotFeedFromSwcaftQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromSwcaftQtyAvail").removeAttr("disabled");

      document.getElementById('doNotFeedFromBasc').checked = false;
      $("#doNotFeedFromBasc").removeAttr("disabled");
      $("#doNotFeedFromBascQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromBascQtyAvail").removeAttr("disabled");

      document.getElementById('doNotFeedFromPrismCast').checked = false;
      $("#doNotFeedFromPrismCast").removeAttr("disabled");
      $("#doNotFeedFromPrismCastQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromPrismCastQtyAvail").removeAttr("disabled");

      document.getElementById('doNotFeedFromPrismCalt').checked = false;
      $("#doNotFeedFromPrismCalt").removeAttr("disabled");
      $("#doNotFeedFromPrismCaltQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromPrismCaltQtyAvail").removeAttr("disabled");

      $("#doNotFeedFromStagePOModBanc60").removeAttr("disabled");
      $("#doNotFeedFromStagePOModBasc60").removeAttr("disabled");
      $("#doNotFeedFromStagePOModMainsl60").removeAttr("disabled");
      $("#doNotFeedFromStagePOModSwcaft60").removeAttr("disabled");
      $("#doNotFeedFromStagePOModPrismCast60").removeAttr("disabled");
      $("#doNotFeedFromStagePOModPrismCalt60").removeAttr("disabled");
      $("#doNotFeedFromStagePOModBanc90").removeAttr("disabled");
      $("#doNotFeedFromStagePOModBasc90").removeAttr("disabled");
      $("#doNotFeedFromStagePOModMainsl90").removeAttr("disabled");
      $("#doNotFeedFromStagePOModSwcaft90").removeAttr("disabled");
      $("#doNotFeedFromStagePOModPrismCast90").removeAttr("disabled");
      $("#doNotFeedFromStagePOModPrismCalt90").removeAttr("disabled");

      $("#amazonDoNotFeed").removeAttr("disabled");

      $("#wayfairDoNotFeed").removeAttr("disabled");

      $("#walmartDoNotFeed").removeAttr("disabled");

      $("#overstockDoNotFeed").removeAttr("disabled");

      $("#eBayDoNotFeed").removeAttr("disabled");

      $("#bpmDoNotFeed").removeAttr("disabled");

      $("#mellowDoNotFeed").removeAttr("disabled");

      $("#houzzDoNotFeed").removeAttr("disabled");

      $("#homeDepotDoNotFeed").removeAttr("disabled");

      $("#targetDoNotFeed").removeAttr("disabled");

    }
  });
});


$(function () {
  $("#doNotFeedFromMainsl").click(function () {
    if ($(this).is(":checked") && (document.getElementById('doNotFeedFromBanc').checked == false)) {
      $("#doNotFeedFromMainslQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromMainslQtyAvail").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModMainsl60").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModMainsl90").attr("disabled", "disabled");
    } else if ($(this).is(":checked") && (document.getElementById('doNotFeedFromBanc').checked == true)
      && (document.getElementById('doNotFeedFromSwcaft').checked == true) && (document.getElementById('doNotFeedFromBasc').checked == true)) {
      $("#doNotFeedFromAll").click();
    } else {
      $("#doNotFeedFromMainslQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromMainslQtyAvail").removeAttr("disabled");
      $("#doNotFeedFromStagePOModMainsl60").removeAttr("disabled");
      $("#doNotFeedFromStagePOModMainsl90").removeAttr("disabled");
      $("#doNotFeedFromMainsl").focus();
    }
  });
  /*
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
  */

  $("#doNotFeedFromBanc").click(function () {
    if ($(this).is(":checked") && (document.getElementById('doNotFeedFromMainsl').checked == false)) {
      $("#doNotFeedFromBancQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromBancQtyAvail").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModBanc60").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModBanc90").attr("disabled", "disabled");
    } else if ($(this).is(":checked") && (document.getElementById('doNotFeedFromMainsl').checked == true)
      && (document.getElementById('doNotFeedFromSwcaft').checked == true) && (document.getElementById('doNotFeedFromBasc').checked == true)
      && (document.getElementById('doNotFeedFromPrismCast').checked == true) && (document.getElementById('doNotFeedFromPrismCalt').checked == true)) {
      $("#doNotFeedFromAll").click();
    } else {
      $("#doNotFeedFromBancQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromBancQtyAvail").removeAttr("disabled");
      $("#doNotFeedFromStagePOModBanc60").removeAttr("disabled");
      $("#doNotFeedFromStagePOModBanc90").removeAttr("disabled");
      $("#doNotFeedFromBanc").focus();
    }
  });

  $("#doNotFeedFromSwcaft").click(function () {
    if ($(this).is(":checked") && (document.getElementById('doNotFeedFromMainsl').checked == false)) {
      $("#doNotFeedFromSwcaftQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromSwcaftQtyAvail").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModSwcaft60").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModSwcaft90").attr("disabled", "disabled");
    } else if ($(this).is(":checked") && (document.getElementById('doNotFeedFromMainsl').checked == true)
      && (document.getElementById('doNotFeedFromBanc').checked == true) && (document.getElementById('doNotFeedFromBasc').checked == true)
      && (document.getElementById('doNotFeedFromPrismCast').checked == true) && (document.getElementById('doNotFeedFromPrismCalt').checked == true)) {
      $("#doNotFeedFromAll").click();
    } else {
      $("#doNotFeedFromSwcaftQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromSwcaftQtyAvail").removeAttr("disabled");
      $("#doNotFeedFromStagePOModSwcaft60").removeAttr("disabled");
      $("#doNotFeedFromStagePOModSwcaft90").removeAttr("disabled");
      $("#doNotFeedFromSwcaft").focus();
    }
  });

  $("#doNotFeedFromBasc").click(function () {
    if ($(this).is(":checked") && (document.getElementById('doNotFeedFromMainsl').checked == false)) {
      $("#doNotFeedFromBascQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromBascQtyAvail").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModBasc60").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModBasc90").attr("disabled", "disabled");
    } else if ($(this).is(":checked") && (document.getElementById('doNotFeedFromMainsl').checked == true)
      && (document.getElementById('doNotFeedFromSwcaft').checked == true) && (document.getElementById('doNotFeedFromBanc').checked == true)
      && (document.getElementById('doNotFeedFromPrismCast').checked == true) && (document.getElementById('doNotFeedFromPrismCalt').checked == true)) {
      $("#doNotFeedFromAll").click();
    } else {
      $("#doNotFeedFromBascQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromBascQtyAvail").removeAttr("disabled");
      $("#doNotFeedFromStagePOModBasc60").removeAttr("disabled");
      $("#doNotFeedFromStagePOModBasc90").removeAttr("disabled");
      $("#doNotFeedFromBasc").focus();
    }
  });

  $("#doNotFeedFromPrismCast").click(function () {
    if ($(this).is(":checked") && (document.getElementById('doNotFeedFromPrismCast').checked == false)) {
      $("#doNotFeedFromPrismCastQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromPrismCastQtyAvail").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModPrismCast60").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModPrismCast90").attr("disabled", "disabled");
    } else if ($(this).is(":checked") && (document.getElementById('doNotFeedFromMainsl').checked == true)
      && (document.getElementById('doNotFeedFromSwcaft').checked == true) && (document.getElementById('doNotFeedFromBanc').checked == true)
      && (document.getElementById('doNotFeedFromPrismCast').checked == true) && (document.getElementById('doNotFeedFromPrismCalt').checked == true)) {
      $("#doNotFeedFromAll").click();
    } else {
      $("#doNotFeedFromPrismCastQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromPrismCastQtyAvail").removeAttr("disabled");
      $("#doNotFeedFromStagePOModPrismCast60").removeAttr("disabled");
      $("#doNotFeedFromStagePOModPrismCast90").removeAttr("disabled");
      $("#doNotFeedFromPrismCast").focus();
    }
  });

  $("#doNotFeedFromPrismCalt").click(function () {
    if ($(this).is(":checked") && (document.getElementById('doNotFeedFromPrismCalt').checked == false)) {
      $("#doNotFeedFromPrismCaltQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromPrismCaltQtyAvail").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModPrismCalt60").attr("disabled", "disabled");
      $("#doNotFeedFromStagePOModPrismCalt90").attr("disabled", "disabled");
    } else if ($(this).is(":checked") && (document.getElementById('doNotFeedFromMainsl').checked == true)
      && (document.getElementById('doNotFeedFromSwcaft').checked == true) && (document.getElementById('doNotFeedFromBanc').checked == true)
      && (document.getElementById('doNotFeedFromPrismCast').checked == true) && (document.getElementById('doNotFeedFromPrismCalt').checked == true)) {
      $("#doNotFeedFromAll").click();
    } else {
      $("#doNotFeedFromPrismCaltQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromPrismCaltQtyAvail").removeAttr("disabled");
      $("#doNotFeedFromStagePOModPrismCalt60").removeAttr("disabled");
      $("#doNotFeedFromStagePOModPrismCalt90").removeAttr("disabled");
      $("#doNotFeedFromPrismCalt").focus();
    }
  });

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
  returnResult.DoNotFeedFromAll = $('#doNotFeedFromAll').is(':checked');
  returnResult.DoNotFeedFromBanc = $('#doNotFeedFromBanc').is(':checked');
  returnResult.QtyOnHandBanc = $('#doNotFeedFromBancQtyOnHand').val();
  returnResult.QtyAvailBanc = $('#doNotFeedFromBancQtyAvail').val();
  returnResult.DoNotFeedFromMainsl = $('#doNotFeedFromMainsl').is(':checked');
  returnResult.QtyOnHandMainsl = $('#doNotFeedFromMainslQtyOnHand').val();
  returnResult.QtyAvailMainsl = $('#doNotFeedFromMainslQtyAvail').val();
  returnResult.DoNotFeedFromBasc = $('#doNotFeedFromBasc').is(':checked');
  returnResult.QtyOnHandBasc = $('#doNotFeedFromBascQtyOnHand').val();
  returnResult.QtyAvailBasc = $('#doNotFeedFromBascQtyAvail').val();
  returnResult.DoNotFeedFromSwcaft = $('#doNotFeedFromSwcaft').is(':checked');
  returnResult.QtyOnHandSwcaft = $('#doNotFeedFromSwcaftQtyOnHand').val();
  returnResult.QtyAvailSwcaft = $('#doNotFeedFromSwcaftQtyAvail').val();
  returnResult.DoNotFeedFromPrismCast = $('#doNotFeedFromPrismCast').is(':checked');
  returnResult.QtyOnHandPrismCast = $('#doNotFeedFromPrismCastQtyOnHand').val();
  returnResult.QtyAvailPrismCast = $('#doNotFeedFromPrismCastQtyAvail').val();
  returnResult.DoNotFeedFromPrismCalt = $('#doNotFeedFromPrismCalt').is(':checked');
  returnResult.QtyOnHandPrismCalt = $('#doNotFeedFromPrismCaltQtyOnHand').val();
  returnResult.QtyAvailPrismCalt = $('#doNotFeedFromPrismCaltQtyAvail').val();
  returnResult.AmzDoNotFeed = $('#amazonDoNotFeed').is(':checked');
  returnResult.BPMDoNotFeed = $('#bpmDoNotFeed').is(':checked');
  returnResult.eBayDoNotFeed = $('#eBayDoNotFeed').is(':checked');
  returnResult.HouzzDoNotFeed = $('#houzzDoNotFeed').is(':checked');
  returnResult.MellowDoNotFeed = $('#mellowDoNotFeed').is(':checked');
  returnResult.OstDoNotFeed = $('#overstockDoNotFeed').is(':checked');
  returnResult.WlmrtDoNotFeed = $('#walmartDoNotFeed').is(':checked');
  returnResult.WyfrDoNotFeed = $('#wayfairDoNotFeed').is(':checked');
  returnResult.HomeDepotDoNotFeed = $('#homeDepotDoNotFeed').is(':checked');
  returnResult.TargetDoNotFeed = $('#targetDoNotFeed').is(':checked');
  returnResult.StagePOModBanc60 = $("#doNotFeedFromStagePOModBanc60").val();
  returnResult.StagePOModBasc60 = $("#doNotFeedFromStagePOModBasc60").val();
  returnResult.StagePOModMainsl60 = $("#doNotFeedFromStagePOModMainsl60").val();
  returnResult.StagePOModSwcaft60 = $("#doNotFeedFromStagePOModSwcaft60").val();
  returnResult.StagePOModPrismCast60 = $("#doNotFeedFromStagePOModPrismCast60").val();
  returnResult.StagePOModPrismCalt60 = $("#doNotFeedFromStagePOModPrismCalt60").val();
  returnResult.StagePOModBanc90 = $("#doNotFeedFromStagePOModBanc90").val();
  returnResult.StagePOModBasc90 = $("#doNotFeedFromStagePOModBasc90").val();
  returnResult.StagePOModMainsl90 = $("#doNotFeedFromStagePOModMainsl90").val();
  returnResult.StagePOModSwcaft90 = $("#doNotFeedFromStagePOModSwcaft90").val();
  returnResult.StagePOModPrismCast90 = $("#doNotFeedFromStagePOModPrismCast90").val();
  returnResult.StagePOModPrismCalt90 = $("#doNotFeedFromStagePOModPrismCalt90").val();
  returnResult.checkBackOrderLeadTimeBanc = document.getElementById("backOrderLeadTimeBanc").value;
  returnResult.checkBackOrderLeadTimeBasc = document.getElementById("backOrderLeadTimeBasc").value;
  returnResult.checkBackOrderLeadTimeMainsl = document.getElementById("backOrderLeadTimeMainsl").value;
  returnResult.checkBackOrderLeadTimeSwcaft = document.getElementById("backOrderLeadTimeSwcaft").value;
  returnResult.checkBackOrderLeadTimePrismCast = document.getElementById("backOrderLeadTimePrismCast").value;
  returnResult.checkBackOrderLeadTimePrismCalt = document.getElementById("backOrderLeadTimePrismCalt").value;
  console.log(JSON.stringify(returnResult));

  $.ajax({
    url: '../Inventory/UpdateInvFeedsSKUStockRule',
    type: "POST",
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(returnResult),
    success: function () {
      warehousesStatusTable.ajax.reload();
      alert('The record was updated!');
    }
  });
})



function importWarehouseQtyFromUser() {
  var fileInput = document.getElementById('ImportWarehouseQtyFromUser');
  fileInput.addEventListener("click", function () {
    fileInput.value = null;
  });
  document.getElementById('ImportWarehouseQtyFromUser').addEventListener('change', csvJSON, false);
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
  //reader = new FileReader();
  //file = null;
}

function getJSON(contents) {
  const lines = contents.split('\n');
  const jsonArray = [];
  const headers = lines[0].split(',');
  // We will only import 10 columns
  let lengthLimit = 10;

  for (let k = 0; k < headers.length; k++) {
    headers[k] = headers[k].replace(/\s+/g, '');
  }

  for (let i = 1; i < lines.length; i++) {
    if (!lines[i])
      continue;
    const obj = {};
    const currentline = lines[i].split(',');
    for (let j = 0; j < lengthLimit; j++) {
      obj[headers[j]] = currentline[j];
    }
    jsonArray.push(obj);
  }

  var returnResult = new Object();
  returnResult = jsonArray;
  $.ajax({
    url: '/Inventory/ImportWarehouseQty',
    type: 'POST',
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(returnResult),
    success: function (response) {
      console.log($(response));
      if (response.isOkay == true) { alert('The import process is done!'); }
      else { alert(response.errorMessages); }
      warehousesStatusTable.ajax.reload();
    },
    error: function (jqXHR, textStatus, errorThrown) {
      if (jqXHR.status == 500) {
        alert('Internal error: ' + jqXHR.responseText + '\n' + 'Check the import file.');
      } else {
        alert('Unexpected error.' + '\n' + 'Check the import file.');
      }
    }
  });
}
// End of Import Warehouse Qty


// Daily Zero Out SKUs
function importDailyZeroOutSkus() {
  var fileInput = document.getElementById('ImportDailyZeroOutSkus');
  fileInput.addEventListener("click", function () {
    fileInput.value = null;
  });
  document.getElementById('ImportDailyZeroOutSkus').addEventListener('change', csvJSON4ImportSkus, false);
}


function csvJSON4ImportSkus(e) {
  var file = e.target.files[0];
  if (!file) return;
  var reader = new FileReader();
  reader.onload = function (e) {
    var contents = e.target.result;
    getJSON4ImportSkus(contents);
  };
  reader.readAsText(file);
  //reader = new FileReader();
  //file = null;
}

function getJSON4ImportSkus(contents) {
  const lines = contents.split('\n');
  const jsonArray = [];
  const headers = lines[0].split(',');
  // We will only import 10 columns
  let lengthLimit = 3;

  for (let k = 0; k < headers.length; k++) {
    headers[k] = headers[k].replace(/\s+/g, '');
  }

  for (let i = 1; i < lines.length; i++) {
    if (!lines[i])
      continue;
    const obj = {};
    const currentline = lines[i].split(',');
    for (let j = 0; j < lengthLimit; j++) {
      obj[headers[j]] = currentline[j];
    }
    jsonArray.push(obj);
  }
  console.log(jsonArray);

  var returnResult = new Object();
  returnResult = jsonArray;
  $.ajax({
    url: '/Inventory/ProcessDailyZeroOutSkus',
    type: 'POST',
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(returnResult),
    success: function (response) {
      console.log($(response.errorMessages));
      if (response.isOkay == true) { alert('The import process is done!'); }
      else { alert(response.errorMessages); }
      //warehousesStatusTable.ajax.reload();
    },
    error: function (jqXHR, textStatus, errorThrown) {
      if (jqXHR.status == 500) {
        alert('Internal error: ' + jqXHR.responseText + '\n' + 'Check the import file.');
      } else {
        alert('Unexpected error.' + '\n' + 'Check the import file.');
      }
    }
  });
}
// End of Import Daily Zero Out SKUs


// Fast Moving SKUs
function importFastMovingSkus() {
  let hasUpd = document.getElementById('hasUpdInventory').value;
  if (hasUpd == 1) {
    var fileInput = document.getElementById('ImportFastMovingSkus');
    fileInput.addEventListener("click", function () {
      fileInput.value = null;
    });
    document.getElementById('ImportFastMovingSkus').addEventListener('change', csvJSON4FstMvSkus, false);
  }
  else if (hasUpd == 0) {
    alert('You need to get current inventory first!');
    document.getElementById('ImportFastMovingSkus').disabled = true;
  //  $("#impFastMov").load(window.location.href + "#impFastMov");
//    document.getElementById('ImportFastMovingSkus').reload(true);
//    window.reload();
    //setInterval((document.getElementById('ImportFastMovingSkus').disabled = true), 5000);
    //setTimeout((document.getElementById('ImportFastMovingSkus').disabled = false), 20000);
    //document.getElementById('ImportFastMovingSkus').disabled = false;
    
    //document.getElementById('ImportFastMovingSkus').window.close();
    //window.close();
    return false;
  }
}


function csvJSON4FstMvSkus(e) {
  var file = e.target.files[0];
  if (!file) return;
  var reader = new FileReader();
  reader.onload = function (e) {
    var contents = e.target.result;
    getJSON4FstMvSkus(contents);
  };
  reader.readAsText(file);
  //reader = new FileReader();
  //file = null;
}

function getJSON4FstMvSkus(contents) {
  const lines = contents.split('\n');
  const jsonArray = [];
  const headers = lines[0].split(',');
  // We will only import 10 columns
  let lengthLimit = 2;

  for (let k = 0; k < headers.length; k++) {
    headers[k] = headers[k].replace(/\s+/g, '');
  }

  for (let i = 1; i < lines.length; i++) {
    if (!lines[i])
      continue;
    const obj = {};
    const currentline = lines[i].split(',');
    for (let j = 0; j < lengthLimit; j++) {
      obj[headers[j]] = currentline[j];
    }
    jsonArray.push(obj);
  }
  console.log(jsonArray);

  var returnResult = new Object();
  returnResult = jsonArray;
  $.ajax({
    url: '/Inventory/FastMovingSKUsNotification',
    type: 'POST',
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(returnResult),
    success: function (response) {
      console.log($(response.errorMessages));
      if (response.isOkay == true) { alert('The notification was sent!'); }
      else { alert(response.errorMessages); }
      //warehousesStatusTable.ajax.reload();
    },
    error: function (jqXHR, textStatus, errorThrown) {
      if (jqXHR.status == 500) {
        alert('Internal error: ' + jqXHR.responseText + '\n' + 'Check the import file.');
      } else {
        alert('Unexpected error.' + '\n' + 'Check the import file.');
      }
    }
  });
}
// End of Import Fast Moving SKUs














var warehousesStatusTable = $("#invMainslBancItems").DataTable({
  "destroy": true,
  "scrollX": true,
  "scrollCollapse": true,
  //"paging": false,
  "autoWidth": false,
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
        columns: ':visible',
        format: {
          header: function (data, columnIdx) {
            if (columnIdx == 1) {
              return 'remark';
            } else if (columnIdx == 2) {
              return 'sku';
            } else if (columnIdx == 3) {
              return 'qtyAvailBanc';
            } else if (columnIdx == 4) {
              return 'qtyStagePOBanc';
            } else if (columnIdx == 5) {
              return 'qtyAvailBasc';
            } else if (columnIdx == 6) {
              return 'qtyStagePOBasc';
            } else if (columnIdx == 7) {
              return 'qtyAvailMainsl';
            } else if (columnIdx == 8) {
              return 'qtyStagePOMainsl';
            } else if (columnIdx == 9) {
              return 'qtyAvailSwcaft';
            } else if (columnIdx == 10) {
              return 'qtyStagePOSwcaft';
            }
            else {
              return data;
            }
          }
        }
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
    { "data": "remark", "width": "6%" },
    { "data": "itemName", "width": "10%" },
    { "data": "qtyAvailBanc", "width": "7%" },
    { "data": "stagePOOrigBanc60", "width": "7%" },
    { "data": "stagePOOrigBanc90", "width": "7%" },
    { "data": "qtyAvailBasc", "width": "7%" },
    { "data": "stagePOOrigBasc60", "width": "7%" },
    { "data": "stagePOOrigBasc90", "width": "7%" },
    { "data": "qtyAvailMainsl", "width": "7%" },
    { "data": "stagePOOrigMainsl60", "width": "7%" },
    { "data": "stagePOOrigMainsl90", "width": "7%" },
    { "data": "qtyAvailSwcaft", "width": "7%" },
    { "data": "stagePOOrigSwcaft60", "width": "7%" },
    { "data": "stagePOOrigSwcaft90", "width": "7%" },
    { "data": "qtyAvailPrismCast", "width": "7%" },
    { "data": "stagePOOrigPrismCast60", "width": "7%" },
    { "data": "stagePOOrigPrismCast90", "width": "7%" },
    { "data": "qtyAvailPrismCalt", "width": "7%" },
    { "data": "stagePOOrigPrismCalt60", "width": "7%" },
    { "data": "stagePOOrigPrismCalt90", "width": "7%" }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "142%"
});

var invFeedsLeftOverTable = $("#invFeedsLeftOverItems").DataTable({
  "destroy": true,
  "scrollX": true,
  "scrollCollapse": true,
  //"paging": false,
  "autoWidth": false,
  "order": [[1, "asc"]],
  dom: 'Bfrtip',
  lengthMenu: [[15, 25, 50, 100], [15, 25, 50, 100]],
  buttons: [
    {
      extend: 'copyHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "Left_Over" + "_" + todayDate + "_" + todatyTime;
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
        return "Left_Over" + "_" + todayDate + "_" + todatyTime;
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
        return "Left_Over" + "_" + todayDate + "_" + todatyTime;
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
        return "Left_Over" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetLeftOverQty",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": {
      "today": today
    }
  },
  "columns": [
    { "data": "itemNoId", "visible": false },
    { "data": "itemName", "width": "15%", "className": "text-right" },
    { "data": "itemStatus", "width": "15%", "className": "text-right" },
    { "data": "warehouse", "width": "15%", "className": "text-right" },
    { "data": "qty", "width": "10%", "className": "text-right" },
    {
      "data": "assignedMarket", "width": "15%", "className": "text-right",
      "render": function (d, t, r) {
        var $select = $('<select class="market">', {
          "id": r[0] + "start",
          "value": d
        });
        $.each(marketsIds, function (k, v) {
          var $option = $("<option></option>", {
            "text": v,
            "value": k
          });
          if (d === v) {
            $option.attr("selected", "selected")
          }
          $select.append($option);
        });
        return $select.prop("outerHTML");
      }
    },
    { "data": "assignedMarketId", "visible": false },
    { "data": "warehouseId", "visible": false },
    { "data": "itemStatusId", "visible": false },
    { "data": "isEdited", "visible": false }
  ],
  "language": {
    "emptyTable": "no data found"
  },
  "width": "70%"

});


function loadDataTable() {

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