var dataTable;
var tmpDate = new Date();
var fourWeeksDate = new Date(new Date().setDate(tmpDate.getDate() - 28));
var eightWeeksDate = new Date(new Date().setDate(tmpDate.getDate() - 56));
var twelveWeeksDate = new Date(new Date().setDate(tmpDate.getDate() - 84));
var oneYearBeforeDate = new Date(new Date().setDate(tmpDate.getDate() - 365));
var threeYearsBeforeDate = new Date(new Date().setDate(tmpDate.getDate() - 1095));
var today = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();
var todayString = getFormattedDate(today);
var endDate = new Date();
endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
var startDate = threeYearsBeforeDate;
startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
document.getElementById('fromDateHidden').value = startDate;
document.getElementById('toDateHidden').value = endDate;
document.getElementById('todayHidden').value = today;

$(document).ready(function () {
  $("#approveModal").modal();
  fromDatePicker();
  toDatePicker();
  historyDatePicker();
  $('#fromDatePicker').val(startDate);
  $('#toDatePicker').val(endDate);
  $('#historyDatePicker').val(today);

  getInvFeedsReportDate();
  getLastUpdateInfo();
  invFeedsDataTable;
  //stagePOMargin
  document.getElementById('stagePOMargin').value = 0;
  document.getElementById('stagePOCurInvCheck').checked = false;
  $('#stagePOCurInvCheck').click(function () {
    invFeedsDataTable.draw();
  });
});


// Waiting Indicator
$body = $("body");

$(document).on({
  ajaxStart: function () { $body.addClass("loading"); },
  ajaxStop: function () { $body.removeClass("loading"); }
});

//-----------calender----------
var endDate = new Date();
//var startDate = new Date(new Date().getFullYear(), 0, 1);
// Using 12 weeks history 
var startDate = threeYearsBeforeDate;
endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
function fromDatePicker() {
  $("#fromDatePicker").datepicker(
    {
      //defaultDate: startDate
    }
  );
  console.log($("#fromDatePicker"));
}
function toDatePicker() {
  $("#toDatePicker").datepicker(
    {
      //defaultDate: endDate
    }
  );
}
function historyDatePicker() {
  $("#historyDatePicker").datepicker(
    {
      //defaultDate: today
    }
  );
  console.log($("#historyDatePicker"));
}
//-----------------------------

function getInvFeedsReportDate() {
  document.getElementById("invFeedsRepDate").innerHTML = "This report is for " + document.getElementById('todayHidden').value + ".<br />" + "Based on Sales History of : " + document.getElementById('fromDateHidden').value + " to " + document.getElementById('toDateHidden').value;
}


function importInvFeedsFromUser() {
  var fileInput = document.getElementById('ImportInvFeedsFromUser');
  fileInput.addEventListener("click", function () {
    fileInput.value = null;
  });
  document.getElementById('ImportInvFeedsFromUser').addEventListener('change', csvJSON, false);
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
  const jsonArray01 = [];
  const jsonArray02 = [];
  const jsonArray03 = [];
  const jsonArray04 = [];
  const jsonArray05 = [];
  const headers = lines[0].split(',');
  // We will only import 40 columns
  let lengthLimit = 40;



  let firstCut = parseInt(lines.length / 5) + parseInt(lines.length % 5);
  let secondCut = parseInt(lines.length / 5);
  let thirdCut = parseInt(lines.length / 5);
  let fourthCut = parseInt(lines.length / 5);
  //let fifthCut = parseInt(lines.length / 5);
  let cutCnt = 0;
  let lineDone = false;

  for (let k = 0; k < headers.length; k++) {
    //headers[k] = headers[k].replace(/\s+/g, '');
    switch (k)
    {
      case 1:
        headers[k] = "qtyAvailMainsl";
        break;
      case 2:
        headers[k] = "qtyAvailZinusTracy";
        break;
      case 3:
        headers[k] = "qtyAvailZinusChs";
        break;
      case 4:
        headers[k] = "qtyAvailCastleGate";
        break;
      case 5:
        headers[k] = "totalStagePOQtyMainsl";
        break;
      case 6:
        headers[k] = "totalStagePOQtyZinusTracy";
        break;
      case 7:
        headers[k] = "totalStagePOQtyZinusChs";
        break;
      case 8:
        headers[k] = "amazonQtyMainsl";
        break;
      case 9:
        headers[k] = "amazonQtyZinusTracy";
        break;
      case 10:
        headers[k] = "amazonQtyZinusChs";
        break;
      case 11:
        headers[k] = "walmartQtyMainsl";
        break;
      case 12:
        headers[k] = "walmartQtyZinusTracy";
        break;
      case 13:
        headers[k] = "walmartQtyZinusChs";
        break;
      case 14:
        headers[k] = "wayfairQtyMainsl";
        break;
      case 15:
        headers[k] = "wayfairQtyZinusTracy";
        break;
      case 16:
        headers[k] = "wayfairQtyZinusChs";
        break;
      case 17:
        headers[k] = "overstockQtyMainsl";
        break;
      case 18:
        headers[k] = "overstockQtyZinusTracy";
        break;
      case 19:
        headers[k] = "overstockQtyZinusChs";
        break;
      case 20:
        headers[k] = "homeDepotQtyMainsl";
        break;
      case 21:
        headers[k] = "homeDepotQtyZinusTracy";
        break;
      case 22:
        headers[k] = "homeDepotQtyZinusChs";
        break;
      case 23:
        headers[k] = "targetQtyMainsl";
        break;
      case 24:
        headers[k] = "targetQtyZinusTracy";
        break;
      case 25:
        headers[k] = "targetQtyZinusChs";
        break;
      case 26:
        headers[k] = "eBayQtyMainsl";
        break;
      case 27:
        headers[k] = "eBayQtyZinusTracy";
        break;
      case 28:
        headers[k] = "eBayQtyZinusChs";
        break;
      case 29:
        headers[k] = "bpmQtyMainsl";
        break;
      case 30:
        headers[k] = "bpmQtyZinusTracy";
        break;
      case 31:
        headers[k] = "bpmQtyZinusChs";
        break;
      case 32:
        headers[k] = "mellowQtyMainsl";
        break;
      case 33:
        headers[k] = "mellowQtyZinusTracy";
        break;
      case 34:
        headers[k] = "mellowQtyZinusChs";
        break;
    }
  }
  //console.log(firstCut+", "+secondCut+", "+thirdCut+", "+fourthCut+"+\n");
  // First Set
  for (let i = 1; i < firstCut; i++) {
    if (!lines[i])
      continue;
    const obj = {};
    const currentline = lines[i].split(',');
    for (let j = 0; j < lengthLimit; j++) {
      obj[headers[j]] = currentline[j];
    }
    jsonArray01.push(obj);
  }
  //console.log(jsonArray01);

  // Second Set
  for (let i = firstCut; i < (firstCut + secondCut); i++) {
    if (!lines[i])
      continue;
    const obj = {};
    const currentline = lines[i].split(',');
    for (let j = 0; j < lengthLimit; j++) {
      obj[headers[j]] = currentline[j];
    }
    jsonArray02.push(obj);
  }
  //console.log(jsonArray02);

  // Third Set
  for (let i = (firstCut + secondCut); i < (firstCut + secondCut + thirdCut); i++) {
    if (!lines[i])
      continue;
    const obj = {};
    const currentline = lines[i].split(',');
    for (let j = 0; j < lengthLimit; j++) {
      obj[headers[j]] = currentline[j];
    }
    jsonArray03.push(obj);
  }
  //console.log(jsonArray03);

  // Fourth Set
  for (let i = (firstCut + secondCut + thirdCut); i < (firstCut + secondCut + thirdCut + fourthCut); i++) {
    if (!lines[i])
      continue;
    const obj = {};
    const currentline = lines[i].split(',');
    for (let j = 0; j < lengthLimit; j++) {
      obj[headers[j]] = currentline[j];
    }
    jsonArray04.push(obj);
  }
  //console.log(jsonArray04);

  // Fifth Set
  for (let i = (firstCut + secondCut + thirdCut + fourthCut); i < lines.length; i++) {
    if (!lines[i])
      continue;
    const obj = {};
    const currentline = lines[i].split(',');
    for (let j = 0; j < lengthLimit; j++) {
      obj[headers[j]] = currentline[j];
    }
    jsonArray05.push(obj);
  }
  //console.log(jsonArray05);

  let isOkay01, isOkay02, isOkay03, isOkay04, isOkay05 = new Boolean(false);

  var returnResult01, returnResult02, returnResult03, returnResult04, returnResult05 = new Object();
  returnResult01 = jsonArray01;
  returnResult02 = jsonArray02;
  returnResult03 = jsonArray03;
  returnResult04 = jsonArray04;
  returnResult05 = jsonArray05;

  $.when(
    $.ajax({
      url: '/Inventory/ImportInvFeeds',
      type: 'POST',
      contentType: "application/json charset=utf-8",
      dataType: 'json',
      data: JSON.stringify(returnResult01),
      success: function (response) {
        console.log($(response));
        if (response.isOkay == true) { isOkay01 = true; }
        else { isOkay01 = false; alert(response.errorMessages); }
      },
      error: function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.status == 500) {
          alert('Internal error: ' + jqXHR.responseText + '\n' + 'Check an import file.');
        } else {
          alert('Unexpected error.' + '\n' + 'Check an import file.');
        }
      }
    }),


    $.ajax({
      url: '/Inventory/ImportInvFeeds',
      type: 'POST',
      contentType: "application/json charset=utf-8",
      dataType: 'json',
      data: JSON.stringify(returnResult02),
      success: function (response) {
        console.log($(response));
        if (response.isOkay == true) { isOkay02 = true; }
        else { isOkay02 = false; alert(response.errorMessages); }
      },
      error: function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.status == 500) {
          alert('Internal error: ' + jqXHR.responseText + '\n' + 'Check an import file.');
        } else {
          alert('Unexpected error.' + '\n' + 'Check an import file.');
        }
      }
    }),


    $.ajax({
      url: '/Inventory/ImportInvFeeds',
      type: 'POST',
      contentType: "application/json charset=utf-8",
      dataType: 'json',
      data: JSON.stringify(returnResult03),
      success: function (response) {
        console.log($(response));
        if (response.isOkay == true) { isOkay03 = true; }
        else { isOkay03 = false; alert(response.errorMessages); }
      },
      error: function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.status == 500) {
          alert('Internal error: ' + jqXHR.responseText + '\n' + 'Check an import file.');
        } else {
          alert('Unexpected error.' + '\n' + 'Check an import file.');
        }
      }
    }),


    $.ajax({
      url: '/Inventory/ImportInvFeeds',
      type: 'POST',
      contentType: "application/json charset=utf-8",
      dataType: 'json',
      data: JSON.stringify(returnResult04),
      success: function (response) {
        console.log($(response));
        if (response.isOkay == true) { isOkay04 = true; }
        else { isOkay04 = false; alert(response.errorMessages); }
      },
      error: function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.status == 500) {
          alert('Internal error: ' + jqXHR.responseText + '\n' + 'Check an import file.');
        } else {
          alert('Unexpected error.' + '\n' + 'Check an import file.');
        }
      }
    }),


    $.ajax({
      url: '/Inventory/ImportInvFeeds',
      type: 'POST',
      contentType: "application/json charset=utf-8",
      dataType: 'json',
      data: JSON.stringify(returnResult05),
      success: function (response) {
        console.log($(response));
        if (response.isOkay == true) { isOkay05 = true; }
        else { isOkay05 = false; alert(response.errorMessages); }
      },
      error: function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.status == 500) {
          alert('Internal error: ' + jqXHR.responseText + '\n' + 'Check an import file.');
        } else {
          alert('Unexpected error.' + '\n' + 'Check an import file.');
        }
      }
    })



  ).then(function () {
    if (isOkay01 == true && isOkay02 == true && isOkay03 == true && isOkay04 == true && isOkay05 == true) {
      alert('The import process is done!');
      invFeedsDataTable.ajax.reload();
    }

  });
  /*
  $.ajax({
    url: '/Inventory/ImportInvFeeds',
    type: 'POST',
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(returnResult),
    success: function (response) {
      //console.log($(response));
      if (response.isOkay == true) { alert('The import process is done!'); }
      else { alert(response.errorMessages); }
      invFeedsDataTable.ajax.reload();
    },
    error: function (jqXHR, textStatus, errorThrown) {
      if (jqXHR.status == 500) {
        alert('Internal error: ' + jqXHR.responseText + '\n' + 'Check an import file.');
      } else {
        alert('Unexpected error.' + '\n' + 'Check an import file.');
      }
    }
  });*/
}
// End of Import Inventory


//stagePOCurInvCheck
//For custom filter
$.fn.dataTable.ext.search.push(
  function (settings, data, dataIndex) {
    var unfeededSkus = document.getElementById('stagePOCurInvCheck').checked;
    var stagePOMarginQty = Math.abs((isNaN(document.getElementById('stagePOMargin').value) ? 0 : parseInt(document.getElementById('stagePOMargin').value)));
    // if (isNaN($('#stagePOMargin').val()) != true)
    // { stagePOMarginQty = - parseInt(document.getElementById('stagePOMargin').value); }
    //console.log(stagePOMarginQty);
    var iDs = parseInt(data[0]);
    //var qtyAvailBanc = parseInt(data[2]);
    //var qtyAvailBasc = parseInt(data[3]);
    var qtyAvailMainsl = parseInt(data[2]);
    //var qtyAvailSwcaft = parseInt(data[5]);
    //var qtyAvailPrismCast = parseInt(data[5]);
    //var qtyAvailPrismCalt = parseInt(data[6]);
    var qtyAvailZinusTracy = parseInt(data[3]);
    var qtyAvailZinusChs = parseInt(data[4]);

    //var stagePOBanc = parseInt(data[8]);
    //var stagePOBasc = parseInt(data[9]);
    var stagePOMainsl = parseInt(data[6]);
    //var stagePOSwcaft = parseInt(data[14]);
    //var stagePOPrismCast = parseInt(data[13]);
    //var stagePOPrismCalt = parseInt(data[14]);
    var stagePOZinusTracy = parseInt(data[7]);
    var stagePOZinusChs = parseInt(data[8]);

    //if (unfeededSkus ?
    // ((qtyAvailBanc <= stagePOBanc && stagePOBanc > 0) || (qtyAvailMainsl <= stagePOMainsl && stagePOMainsl > 0)
    //   || (qtyAvailSwcaft <= stagePOSwcaft && stagePOSwcaft > 0) || (qtyAvailBasc <= stagePOBasc && stagePOBasc > 0)) : '')
    /*
    if ((unfeededSkus ? (qtyAvailBanc < stagePOBanc) : '') ||
      (unfeededSkus ? (qtyAvailMainsl < stagePOMainsl) : '') ||
      (unfeededSkus ? (qtyAvailSwcaft < stagePOSwcaft) : '') ||
      (unfeededSkus ? (qtyAvailBasc < stagePOBasc) : '')
    ) {*/
    //if (unfeededSkus && ())
    //((unfeededSkus && (isNaN(document.getElementById('stagePOMargin').value) == false)) ? (qtyAvailSwcaft < (stagePOSwcaft > 0 ? (stagePOSwcaft + stagePOMarginQty) : 0)) : '') ||||
    // ((unfeededSkus && (isNaN(document.getElementById('stagePOMargin').value) == false)) ? (qtyAvailPrismCast < (stagePOPrismCast > 0 ? (stagePOPrismCast + stagePOMarginQty) : 0)) : '') ||
    // ((unfeededSkus && (isNaN(document.getElementById('stagePOMargin').value) == false)) ? (qtyAvailPrismCalt < (stagePOPrismCalt > 0 ? (stagePOPrismCalt + stagePOMarginQty) : 0)) : '')
    //((unfeededSkus && (isNaN(document.getElementById('stagePOMargin').value) == false)) ? (qtyAvailBanc < (stagePOBanc > 0 ? (stagePOBanc + stagePOMarginQty) : 0)) : '') ||

    if (
      ((unfeededSkus && (isNaN(document.getElementById('stagePOMargin').value) == false)) ? (qtyAvailMainsl < (stagePOMainsl > 0 ? (stagePOMainsl + stagePOMarginQty) : 0)) : '') ||
      ((unfeededSkus && (isNaN(document.getElementById('stagePOMargin').value) == false)) ? (qtyAvailZinusTracy < (stagePOZinusTracy > 0 ? (stagePOZinusTracy + stagePOMarginQty) : 0)) : '') ||
      ((unfeededSkus && (isNaN(document.getElementById('stagePOMargin').value) == false)) ? (qtyAvailZinusChs < (stagePOZinusChs > 0 ? (stagePOZinusChs + stagePOMarginQty) : 0)) : '')
    ) {
      console.log(stagePOMarginQty);
      console.log(qtyAvailBanc + " : " + stagePOBanc + " : " + (qtyAvailBanc + stagePOMarginQty) + " : " + stagePOMarginQty);
      //console.log("Start!");
      //console.log(qtyAvailBanc + ":" + stagePOBanc);
      //console.log(qtyAvailMainsl + ":" + stagePOMainsl);
      //console.log(qtyAvailSwcaft + ":" + stagePOSwcaft);
      //console.log(qtyAvailBasc + ":" + stagePOBasc);
      return true;
    } else if (unfeededSkus == false ? (iDs > -1) : '') {
      //console.log("Hey!");
      // console.log(iDs);
      return true;
    }

    //if (unfeededSkus == true) {
    //  //if ((stagePOBanc > 0 ? qtyAvailBanc <= stagePOBanc : '') ||
    //  //  (stagePOMainsl > 0 ? qtyAvailMainsl <= stagePOMainsl : '') ||
    //  //  (stagePOSwcaft > 0 ? qtyAvailSwcaft <= stagePOSwcaft : '') ||
    //  //  (stagePOBasc > 0 ? qtyAvailBasc <= stagePOBasc : ''))
    //  if ((qtyAvailBanc < stagePOBanc) ||
    //    (qtyAvailMainsl < stagePOMainsl) ||
    //    (qtyAvailSwcaft < stagePOSwcaft) ||
    //    (qtyAvailBasc < stagePOBasc)) {
    //    console.log("Start!");
    //    console.log(qtyAvailBanc + ":" + stagePOBanc);
    //    console.log(qtyAvailMainsl + ":" + stagePOMainsl);
    //    console.log(qtyAvailSwcaft + ":" + stagePOSwcaft);
    //    console.log(qtyAvailBasc + ":" + stagePOBasc);
    //    return true;
    //  } else {
    //    if (iDs > -1) {
    //      console.log("Hey!");
    //      console.log(iDs);
    //      return true;
    //    }
    //  }
    //}
    return false;
  }

);

function getFormattedDate(yDate) {
  let date = new Date(yDate);
  let year = date.getFullYear();
  let month = (1 + date.getMonth()).toString().padStart(2, '0');
  let day = date.getDate().toString().padStart(2, '0');

  return month + day + year;
}

function getLastUpdateInfo() {
  $.ajax({
    url: 'getLastUpdateInfo',
    type: "GET",
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    dataSrc: "",
    data: {
      "sel": 2,
      "today": $('#todayHidden').val()
    },
    success: function (response) {
      //console.log(response);
      document.getElementById("feedsStatusHidden").value = response.feedsStatus;
      document.getElementById("lastUpdateDateInfo").innerHTML = response.customMessage.replace(/\n/g, "<br />");
    }
  });//response.replace(/\n/g, "<br />")
}

//$('#my_modal').on('show.bs.modal', function (e) {
//  var id = $(e.relatedTarget).data('id');
//  var that = $(this);
//  $(this).find('button[id="save"]').click(function () {
//    var txt = that.find('input[id="txt"]').val();
//    alert(id);
//    alert(txt);
//  });

//});

//$('#approveModal').on('show.bs.modal', function (e) {
//  console.log("Here!Modal");
//  var id = $(e.relatedTarget).data('id');
//  var that = $(this);

//  $(this).find('button[id="approveEmail"]').click(function () {
//    console.log("Here!");
//    var txt = that.find('input[id="myMessageInput"]').val();
//    console.log(txt);

//    $.ajax({
//      url: 'approveInventoryWithMessage',
//      type: "POST",
//      contentType: "application/json charset=utf-8",
//      dataType: 'json',
//      data: txt,
//      success: function () {
//        alert('This feeds was approved!');
//        getLastUpdateInfo();
//        //location.reload(true);
//      }
//    }); // End of ajax

//  });

//})



$('#bttnForApproveEmail').click(function () {
  var that = $('#approveModal');
  var feedsStatus = parseInt(document.getElementById("feedsStatusHidden").value);
  var myModal = new bootstrap.Modal(document.getElementById('approveModal'))


  if (feedsStatus > 0) {
    alert("These feeds are already approved!");
  }
  else if (feedsStatus < 0) {
    alert("There is no feed to approve!");
  }
  else {
    myModal.show();
    that.find('button[id="approveEmail"]').click(function () {
      var txt = that.find('input[id="myMessageInput"]').val();
      console.log(txt);

      $.ajax({
        url: 'approveInventoryWithMessage',
        type: "POST",
        contentType: "application/json charset=utf-8",
        dataType: 'json',
        data: JSON.stringify(txt),
        success: function () {
          alert('This feeds was approved!');
          getLastUpdateInfo();
        }
      }); // End of ajax

    });
  }

})



$("#bttnForApprove").click(function () {
  $.ajax({
    url: 'approveInventory',
    type: "POST",
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    success: function () {
      alert('This feeds was approved!');
      /*swal({
          title: "Thank you for waiting!",
          text: "This feeds was approved!",
          icon: "success",
      });*/
      getLastUpdateInfo();
      //location.reload(true);
    }
  });
})


$("#reloadInvFeedsHistory").click(function () {
  //today = $("#historyDatePicker").datepicker("getDate");
  //startDate.setDate(today.getDate() - 1095);
  /*today = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
  console.log(today);
  todayString = getFormattedDate(today);
  endDate = today;
  console.log(startDate);*/
  today = $('#historyDatePicker').datepicker("getDate");
  tmpDate = new Date(today);
  threeYearsBeforeDate = new Date(tmpDate.setDate(tmpDate.getDate() - 1095));
  //console.log(today);
  today = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
  //console.log(today);
  //endDate = $('#toDatePicker').datepicker("getDate");
  endDate = new Date(today);//(endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
  endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
  startDate = threeYearsBeforeDate;
  startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
  document.getElementById('todayHidden').value = today;
  todayString = getFormattedDate(today);
  document.getElementById('fromDateHidden').value = startDate;
  document.getElementById('toDateHidden').value = endDate;
  //endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
  getInvFeedsReportDate();
  getLastUpdateInfo();
  invFeedsDataTable.ajax.reload();
})



//$("#reloadInvFeeds").click(function () {
//  var e = document.getElementById("timePeriodInvFeedsSalesHistory");
//  if (e.value == '4weeks') {
//    endDate = new Date();
//    startDate = fourWeeksDate;
//    endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
//    startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
//  } else if (e.value == '8weeks') {
//    endDate = new Date();
//    startDate = eightWeeksDate;
//    endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
//    startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
//  } else if (e.value == '12weeks') {
//    endDate = new Date();
//    startDate = twelveWeeksDate;
//    endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
//    startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
//  } else if (e.value == 'none') {
//    endDate = $("#toDatePicker").datepicker("getDate");
//    startDate = $("#fromDatePicker").datepicker("getDate");
//    endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
//    startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
//  }

//  getInvFeedsReportDate();

//  $('#invFeedsItems').DataTable({
//    "scrollX": true,
//    "scrollCollapse": true,
//    //"paging": false,
//    "destroy": true,
//    "autoWidth": false,
//    columnDefs: [
//      {
//        targets: -1,
//        className: 'dt-body-right'
//      }
//    ],
//    order: [[1, "asc"]],
//    dom: 'Bfrtip',
//    lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
//    buttons: [
//      {
//        extend: 'copyHtml5',
//        filename: function () {
//          var tmpToday = new Date();
//          var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
//          var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
//          return "InventoryFeeds_" + "_" + todayDate + "_" + todatyTime;
//        },
//        exportOptions: {
//          columns: ':visible'
//        }
//      },
//      {
//        extend: 'csvHtml5',
//        filename: function () {
//          var tmpToday = new Date();
//          var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
//          var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
//          return "InventoryFeeds_" + "_" + todayDate + "_" + todatyTime;
//        },
//        exportOptions: {
//          columns: ':visible'
//        }
//      },
//      {
//        extend: 'excelHtml5',
//        filename: function () {
//          var tmpToday = new Date();
//          var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
//          var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
//          return "InventoryFeeds_" + "_" + todayDate + "_" + todatyTime;
//        },
//        exportOptions: {
//          columns: ':visible'
//        }
//      },
//      {
//        extend: 'pdfHtml5',
//        filename: function () {
//          var tmpToday = new Date();
//          var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
//          var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
//          return "InventoryFeeds_" + "_" + todayDate + "_" + todatyTime;
//        },
//        exportOptions: {
//          columns: ':visible'
//        }
//      },
//      'colvis', 'pageLength'
//    ],
//    ajax: {
//      "url": "/Inventory/GetInvFeeds",
//      "type": "GET",
//      "datatype": "json",
//      "dataSrc": "",
//      "data": {
//        "today": today,
//        "startDate": startDate,
//        "endDate": endDate
//      }
//    },
//    "columns": [
//      { "data": "itemNoId", "visible": false },
//      {
//        "data": "itemName",
//        "render": function (data, type, row, meta) {
//          return `<div class="text-center">
//                        <a href="/Inventory/inv_feeds_edit/${todayString}/${row['itemNoId']}" >
//                            ${data}
//                        </a>
//                        </div>`;
//        }, "width": "7%"
//      },
//      { "data": "qtyAvailBanc", "width": "5%", "className": "text-left" },
//      { "data": "qtyAvailMainsl", "width": "5%", "className": "text-left" },
//      { "data": "qtyAvailSWCAFT", "width": "5%", "className": "text-left" },
//      { "data": "qtyAvailBasc", "width": "5%", "className": "text-left" },
//      { "data": "qtyAvailGCInv", "width": "5%", "className": "text-left" },
//      { "data": "totalStagePOQtyBanc", "width": "5%", "className": "text-left" },
//      { "data": "totalStagePOQtyMainsl", "width": "5%", "className": "text-left" },
//      { "data": "totalStagePOQtySWCAFT", "width": "5%", "className": "text-left" },
//      { "data": "totalStagePOQtyBasc", "width": "5%", "className": "text-left" },
//      //{ "data": "amazonPercentage", "width": "4%" },
//      { "data": "amazonQtyBanc", "width": "5%", "className": "text-left" },
//      { "data": "amazonQtyMainsl", "width": "5%", "className": "text-left" },
//      { "data": "amazonQtySWCAFT", "width": "5%", "className": "text-left" },
//      { "data": "amazonQtyBasc", "width": "5%", "className": "text-left" },
//      //{ "data": "overstockPercentage", "width": "4%" },
//      { "data": "overstockQtyBanc", "width": "5%", "className": "text-left" },
//      { "data": "overstockQtyMainsl", "width": "5%", "className": "text-left" },
//      { "data": "overstockQtySWCAFT", "width": "5%", "className": "text-left" },
//      { "data": "overstockQtyBasc", "width": "5%", "className": "text-left" },
//      //{ "data": "walmartPercentage", "width": "4%" },
//      { "data": "walmartQtyBanc", "width": "5%", "className": "text-left" },
//      { "data": "walmartQtyMainsl", "width": "5%", "className": "text-left" },
//      { "data": "walmartQtySWCAFT", "width": "5%", "className": "text-left" },
//      { "data": "walmartQtyBasc", "width": "5%", "className": "text-left" },
//      //{ "data": "wayfairPercentage", "width": "4%" },
//      { "data": "wayfairQtyBanc", "width": "5%", "className": "text-left" },
//      { "data": "wayfairQtyMainsl", "width": "5%", "className": "text-left" },
//      { "data": "wayfairQtySWCAFT", "width": "5%", "className": "text-left" },
//      { "data": "wayfairQtyBasc", "width": "5%", "className": "text-left" },
//      //{ "data": "eBayPercentage", "width": "4%" },
//      { "data": "eBayQtyBanc", "width": "5%", "className": "text-left" },
//      { "data": "eBayQtyMainsl", "width": "5%", "className": "text-left" },
//      { "data": "eBayQtySWCAFT", "width": "5%", "className": "text-left" },
//      { "data": "eBayQtyBasc", "width": "5%", "className": "text-left" },
//      //{ "data": "bpmWebPercentage", "width": "4%" },
//      { "data": "bpmWebQtyBanc", "width": "5%", "className": "text-left" },
//      { "data": "bpmWebQtyMainsl", "width": "5%", "className": "text-left" },
//      { "data": "bpmWebQtySWCAFT", "width": "5%", "className": "text-left" },
//      { "data": "bpmWebQtyBasc", "width": "5%", "className": "text-left" },
//      //{ "data": "mellowWebPercentage", "width": "4%" },
//      { "data": "mellowWebQtyBanc", "width": "5%", "className": "text-left" },
//      { "data": "mellowWebQtyMainsl", "width": "5%", "className": "text-left" },
//      { "data": "mellowWebQtySWCAFT", "width": "5%", "className": "text-left" },
//      { "data": "mellowWebQtyBasc", "width": "5%", "className": "text-left" },
//      //{ "data": "houzzPercentage", "width": "4%" },
//      { "data": "houzzQtyBanc", "width": "5%", "className": "text-left" },
//      { "data": "houzzQtyMainsl", "width": "5%", "className": "text-left" },
//      { "data": "houzzQtySWCAFT", "width": "5%", "className": "text-left" },
//      { "data": "houzzQtyBasc", "width": "5%", "className": "text-left" },
//      { "data": "homeDepotQtyBanc", "width": "5%", "className": "text-left" },
//      { "data": "homeDepotQtyMainsl", "width": "5%", "className": "text-left" },
//      { "data": "homeDepotQtySWCAFT", "width": "5%", "className": "text-left" },
//      { "data": "homeDepotQtyBasc", "width": "5%", "className": "text-left" }
//    ],
//    "language": {
//      "emptyTable": "no data found"
//    },
//    "width": "237%"
//  });
//  //  $('#invFeedsItems').DataTable().ajax.reload();
//  /*
//  var table = $('#invFeedsItems').DataTable({
//    retrieve: true,
//    paging: false
//  });

//  table = $('#invFeedsItems').DataTable({
//    ajax: {
//      url: "/Inventory/GetInvFeeds",
//      data: function (d) {
//        d.today = today;
//        d.startDate = startDate;
//        d.endDateDate = endDate;
//      }
//    }
//  });
//  //  table.reload();
//  table.ajax.reload();*/
//  //$('#invFeedsItems').DataTable.ajax.reload();
//  //location.reload();
//  /*
//  $.ajax({
//    url: 'approveInventory',
//    type: "POST",
//    data: {
//      "today": today
//    }
//    success: function () {
//      alert('Thank you for waiting!');
//      location.reload(true);
//    }
//  });*/
//})


//function loadDataTable() {
var invFeedsDataTable = $("#invFeedsItems").DataTable({
  "destroy": true,
  "scrollX": true,
  "scrollCollapse": true,
  //"paging": false,
  "autoWidth": false,
  "fixedColumns": {
    left: 12
  },
  columnDefs: [
    {
      targets: -1,
      className: 'dt-body-right'
    }
  ],
  "order": [[1, "asc"]],
  dom: 'Bfrtip',
  lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
  buttons: [
    {
      extend: 'copyHtml5',
      filename: function () {
        var tmpToday = new Date();
        var todayDate = (tmpToday.getMonth() + 1).toString().padStart(2, '0') + '/' + tmpToday.getDate().toString().padStart(2, '0') + '/' + tmpToday.getFullYear();
        var todatyTime = tmpToday.getHours().toString().padStart(2, '0') + tmpToday.getMinutes().toString().padStart(2, '0') + tmpToday.getSeconds().toString().padStart(2, '0');
        return "InventoryFeeds_" + "_" + todayDate + "_" + todatyTime;
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
        return "InventoryFeeds_" + "_" + todayDate + "_" + todatyTime;
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
        return "InventoryFeeds_" + "_" + todayDate + "_" + todatyTime;
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
        return "InventoryFeeds_" + "_" + todayDate + "_" + todatyTime;
      },
      exportOptions: {
        columns: ':visible'
      }
    },
    'colvis', 'pageLength'
  ],
  "ajax": {
    "url": "/Inventory/GetInvFeeds",
    "type": "GET",
    "datatype": "json",
    "dataSrc": "",
    "data": function (d) {
      d.today = $('#todayHidden').val();
      d.startDate = $('#fromDateHidden').val();
      d.endDate = $('#toDateHidden').val();
      //d.startDate = (tmpDate01.getMonth() + 1) + '/' + tmpDate01.getDate() + '/' + tmpDate01.getFullYear();
      // d.endDate = (tmpDate02.getMonth() + 1) + '/' + tmpDate02.getDate() + '/' + tmpDate02.getFullYear();
    }
  },
  "columns": [
    { "data": "itemNoId", "visible": false },
    {
      "data": "itemName",
      "render": function (data, type, row, meta) {
        return `<div class="text-center">
                        <a href="/Inventory/inv_feeds_edit/${todayString}/${row['itemNoId']}" >
                            ${data}
                        </a>
                        </div>`;
      }, "width": "100%"
    },
    //{ "data": "qtyAvailBanc", "width": "20%", "className": "text-left" },
    //{ "data": "qtyAvailBasc", "width": "20%", "className": "text-left" },
    { "data": "qtyAvailMainsl", "width": "20%", "className": "text-left" },
    //{ "data": "qtyAvailSWCAFT", "width": "20%", "className": "text-left" },
    //{ "data": "qtyAvailPrismCast", "width": "20%", "className": "text-left" },
    //{ "data": "qtyAvailPrismCalt", "width": "20%", "className": "text-left" },
    { "data": "qtyAvailZinusTracy", "width": "20%", "className": "text-left" },
    { "data": "qtyAvailZinusChs", "width": "20%", "className": "text-left" },
    { "data": "qtyAvailCGInv", "width": "20%", "className": "text-left" },
    //{ "data": "totalStagePOQtyBanc", "width": "20%", "className": "text-left" },
    //{ "data": "totalStagePOQtyBasc", "width": "20%", "className": "text-left" },
    { "data": "totalStagePOQtyMainsl", "width": "20%", "className": "text-left" },
    //{ "data": "totalStagePOQtySWCAFT", "width": "20%", "className": "text-left" },
    //{ "data": "totalStagePOQtyPrismCast", "width": "20%", "className": "text-left" },
    //{ "data": "totalStagePOQtyPrismCalt", "width": "20%", "className": "text-left" },
    { "data": "totalStagePOQtyZinusTracy", "width": "20%", "className": "text-left" },
    { "data": "totalStagePOQtyZinusChs", "width": "20%", "className": "text-left" },
    //{ "data": "amazonQtyBanc", "width": "20%", "className": "text-left" },
    //{ "data": "amazonQtyBasc", "width": "20%", "className": "text-left" },
    { "data": "amazonQtyMainsl", "width": "20%", "className": "text-left" },
    //{ "data": "amazonQtySWCAFT", "width": "20%", "className": "text-left" },
    //{ "data": "amazonQtyPrismCast", "width": "20%", "className": "text-left" },
    //{ "data": "amazonQtyPrismCalt", "width": "20%", "className": "text-left" },
    { "data": "amazonQtyZinusTracy", "width": "20%", "className": "text-left" },
    { "data": "amazonQtyZinusChs", "width": "20%", "className": "text-left" },
    //{ "data": "walmartQtyBanc", "width": "20%", "className": "text-left" },
    //{ "data": "walmartQtyBasc", "width": "20%", "className": "text-left" },
    { "data": "walmartQtyMainsl", "width": "20%", "className": "text-left" },
    //{ "data": "walmartQtySWCAFT", "width": "20%", "className": "text-left" },
    //{ "data": "walmartQtyPrismCast", "width": "20%", "className": "text-left" },
    //{ "data": "walmartQtyPrismCalt", "width": "20%", "className": "text-left" },
    { "data": "walmartQtyZinusTracy", "width": "20%", "className": "text-left" },
    { "data": "walmartQtyZinusChs", "width": "20%", "className": "text-left" },
    //{ "data": "wayfairQtyBanc", "width": "20%", "className": "text-left" },
    //{ "data": "wayfairQtyBasc", "width": "20%", "className": "text-left" },
    { "data": "wayfairQtyMainsl", "width": "20%", "className": "text-left" },
    //{ "data": "wayfairQtySWCAFT", "width": "20%", "className": "text-left" },
    //{ "data": "wayfairQtyPrismCast", "width": "20%", "className": "text-left" },
    //{ "data": "wayfairQtyPrismCalt", "width": "20%", "className": "text-left" },
    { "data": "wayfairQtyZinusTracy", "width": "20%", "className": "text-left" },
    { "data": "wayfairQtyZinusChs", "width": "20%", "className": "text-left" },
    //{ "data": "overstockQtyBanc", "width": "20%", "className": "text-left" },
    //{ "data": "overstockQtyBasc", "width": "20%", "className": "text-left" },
    { "data": "overstockQtyMainsl", "width": "20%", "className": "text-left" },
    //{ "data": "overstockQtySWCAFT", "width": "20%", "className": "text-left" },
    //{ "data": "overstockQtyPrismCast", "width": "20%", "className": "text-left" },
    //{ "data": "overstockQtyPrismCalt", "width": "20%", "className": "text-left" },
    { "data": "overstockQtyZinusTracy", "width": "20%", "className": "text-left" },
    { "data": "overstockQtyZinusChs", "width": "20%", "className": "text-left" },
    //{ "data": "homeDepotQtyBanc", "width": "20%", "className": "text-left" },
    //{ "data": "homeDepotQtyBasc", "width": "20%", "className": "text-left" },
    { "data": "homeDepotQtyMainsl", "width": "20%", "className": "text-left" },
    //{ "data": "homeDepotQtySWCAFT", "width": "20%", "className": "text-left" },
    //{ "data": "homeDepotQtyPrismCast", "width": "20%", "className": "text-left" },
    //{ "data": "homeDepotQtyPrismCalt", "width": "20%", "className": "text-left" },
    { "data": "homeDepotQtyZinusTracy", "width": "20%", "className": "text-left" },
    { "data": "homeDepotQtyZinusChs", "width": "20%", "className": "text-left" },
    //{ "data": "targetQtyBanc", "width": "20%", "className": "text-left" },
    //{ "data": "targetQtyBasc", "width": "20%", "className": "text-left" },
    { "data": "targetQtyMainsl", "width": "20%", "className": "text-left" },
    //{ "data": "targetQtySWCAFT", "width": "20%", "className": "text-left" },
    //{ "data": "targetQtyPrismCast", "width": "20%", "className": "text-left" },
    //{ "data": "targetQtyPrismCalt", "width": "20%", "className": "text-left" },
    { "data": "targetQtyZinusTracy", "width": "20%", "className": "text-left" },
    { "data": "targetQtyZinusChs", "width": "20%", "className": "text-left" },
    //{ "data": "eBayQtyBanc", "width": "20%", "className": "text-left" },
    //{ "data": "eBayQtyBasc", "width": "20%", "className": "text-left" },
    { "data": "eBayQtyMainsl", "width": "20%", "className": "text-left" },
    //{ "data": "eBayQtySWCAFT", "width": "20%", "className": "text-left" },
    //{ "data": "eBayQtyPrismCast", "width": "20%", "className": "text-left" },
    //{ "data": "eBayQtyPrismCalt", "width": "20%", "className": "text-left" },
    { "data": "eBayQtyZinusTracy", "width": "20%", "className": "text-left" },
    { "data": "eBayQtyZinusChs", "width": "20%", "className": "text-left" },
    //{ "data": "bpmWebQtyBanc", "width": "20%", "className": "text-left" },
    //{ "data": "bpmWebQtyBasc", "width": "20%", "className": "text-left" },
    { "data": "bpmWebQtyMainsl", "width": "20%", "className": "text-left" },
    //{ "data": "bpmWebQtySWCAFT", "width": "20%", "className": "text-left" },
    //{ "data": "bpmWebQtyPrismCast", "width": "20%", "className": "text-left" },
    //{ "data": "bpmWebQtyPrismCalt", "width": "20%", "className": "text-left" },
    { "data": "bpmWebQtyZinusTracy", "width": "20%", "className": "text-left" },
    { "data": "bpmWebQtyZinusChs", "width": "20%", "className": "text-left" },
    //{ "data": "mellowWebQtyBanc", "width": "20%", "className": "text-left" },
    //{ "data": "mellowWebQtyBasc", "width": "20%", "className": "text-left" },
    { "data": "mellowWebQtyMainsl", "width": "20%", "className": "text-left" },
    //{ "data": "mellowWebQtySWCAFT", "width": "20%", "className": "text-left" },
    //{ "data": "mellowWebQtyPrismCast", "width": "20%", "className": "text-left" },
    //{ "data": "mellowWebQtyPrismCalt", "width": "20%", "className": "text-left" },
    { "data": "mellowWebQtyZinusTracy", "width": "20%", "className": "text-left" },
    { "data": "mellowWebQtyZinusChs", "width": "20%", "className": "text-left" }
    //{ "data": "houzzQtyBanc", "width": "20%", "className": "text-left" },
    //{ "data": "houzzQtyBasc", "width": "20%", "className": "text-left" },
    //{ "data": "houzzQtyMainsl", "width": "20%", "className": "text-left" },
    //{ "data": "houzzQtySWCAFT", "width": "20%", "className": "text-left" }
  ],
  "language": {
    "emptyTable": "no data found"
  }
});
//}