var dataTable01;
var dataTable02;
var catNo;
var catName;

$(document).ready(function () {
  catNo = "";
  catName = "";
  loadDataTable();
  //For assigning group
  var table01 = $('#invFeedsRemarkGroupItems').DataTable();
  var table02 = $('#invFeedsSKURemarkGroupItems').DataTable();
  $('#invFeedsRemarkGroupItems tbody').on('click', 'tr', function () {
    var d = table01.row(this).data();
    catNo = d.invFeedsRmrkCtgryId;
    catName = d.categoryName;
    document.getElementById("invFeedsRemarkGroupSelected").innerHTML = catName;
    document.getElementById('doNotFeedFromMainsl').checked = d.doNotFeedFromMainsl;
    document.getElementById('doNotFeedFromSwcaft').checked = d.doNotFeedFromSwcaft;
    document.getElementById('doNotFeedFromBanc').checked = d.doNotFeedFromBanc;
    document.getElementById('doNotFeedFromBasc').checked = d.doNotFeedFromBasc;
    document.getElementById('doNotFeedToAmazon').checked = d.doNotFeedToAmazon;
    document.getElementById('doNotFeedToOverstock').checked = d.doNotFeedToOverstock;
    document.getElementById('doNotFeedToWalmart').checked = d.doNotFeedToWalmart;
    document.getElementById('doNotFeedToWayfair').checked = d.doNotFeedToWayfair;
    document.getElementById('doNotFeedToeBay').checked = d.doNotFeedToeBay;
    document.getElementById('doNotFeedToHouzz').checked = d.doNotFeedToHouzz;
    document.getElementById('doNotFeedToBPM').checked = d.doNotFeedToBpm;
    document.getElementById('doNotFeedToMellow').checked = d.doNotFeedToMellow;
    document.getElementById('doNotFeedToTarget').checked = d.doNotFeedToTarget;
    document.getElementById('doNotFeedToHomeDepot').checked = d.doNotFeedToHomeDepot;
  });

  $('#invFeedsSKURemarkGroupItems tbody').on('click', 'tr', function () {
    var dv = table02.row(this).data();
    dv.isEdited = true;
    if (dv.remarkGroup == null) {
      dv.remarkGroup = catName;
      dv.remarkGroupList = catNo;
    } else {
      var tmpStr01 = new String(dv.remarkGroupList);
      var tmpStr02 = new String(dv.remarkGroup);
      //console.log("start: "+ tmpStr01 + "\n");
      if (tmpStr01.indexOf(catNo) < 0) {
        dv.remarkGroup = dv.remarkGroup + " " + catName;
        dv.remarkGroupList = dv.remarkGroupList + " " + catNo;
      } else {
        dv.remarkGroupList = tmpStr01.replace(catNo, '');
        dv.remarkGroup = tmpStr02.replace(catName, '');
        //console.log(tmpStr01+"\n");
        //dv.remarkGroupList.replace(catNo, '');
        //dv.remarkGroup.replace(catName, '');
      }
    }
    table02.row(this).data(dv).draw();
  });


});


//updateInvFeedsRemarkGroupBtn
$("#updateInvFeedsRemarkGroupBtn").click(function () {
  var table = $('#invFeedsSKURemarkGroupItems').DataTable();
  const jsonArray = [];

  var table_data = table.rows().data().toArray();
  //var test_data = table.buttons.exportData();
  jsonArray.push(table_data);
  console.log(JSON.stringify(table_data));

  var returnResult = new Object();
  //returnResult.customerId = 0;
  returnResult.skuList = jsonArray;

  $.ajax({
    url: '../Inventory/UpdateInvFeedsRemarkGroupList',
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
  dataTable01 = $("#invFeedsRemarkGroupItems").DataTable({
    "autoWidth": false,
    dom: 'Bfrtip',
    "order": [[0, "asc"]],
    lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
    "ajax": {
      "url": "/Inventory/GetInvFeedsRemarkCategory",
      "type": "GET",
      "datatype": "json",
      "dataSrc": "",
      "data": {
        "option": "1"
      }
    },
    "columns": [
      { "data": "invFeedsRmrkCtgryId", "visible": false },
      { "data": "categoryName", "width": "10%" },
      { "data": "description", "width": "20%" },
      { "data": "doNotFeedFromMainsl", "visible": false },
      { "data": "doNotFeedFromSwcaft", "visible": false },
      { "data": "doNotFeedFromBanc", "visible": false },
      { "data": "doNotFeedFromBasc", "visible": false },
      { "data": "doNotFeedToAmazon", "visible": false },
      { "data": "doNotFeedToOverstock", "visible": false },
      { "data": "doNotFeedToWalmart", "visible": false },
      { "data": "doNotFeedToWayfair", "visible": false },
      { "data": "doNotFeedToTarget", "visible": false },
      { "data": "doNotFeedToHomeDepot", "visible": false },
      { "data": "doNotFeedToeBay", "visible": false },
      { "data": "doNotFeedToHouzz", "visible": false },
      { "data": "doNotFeedToBpm", "visible": false },
      { "data": "doNotFeedToMellow", "visible": false }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "30%"
  });




  dataTable02 = $("#invFeedsSKURemarkGroupItems").DataTable({
    "autoWidth": false,
    dom: 'Bfrtip',
    "order": [[4, "asc"]],
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
      { "data": "remarkGroupList", "visible": false },
      { "data": "isEdited", "visible": false },
      { "data": "remarkGroup", "width": "15%" },
      { "data": "bpmSKU", "width": "10%" },
      { "data": "description", "width": "25%" }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });
}
