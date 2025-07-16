function openSKUCSVAttachment() {
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
  const tmpCustId = $('#customerId').val();
  const custId = parseInt(tmpCustId);
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
      case 5:
        lengthLimit = 3;
        break;
      case 21:
        lengthLimit = 1;
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
    url: '../UpdateMarketFeedsList',
    type: 'POST',
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(returnResult)
  });
  $('#resultJSON').val(JSON.stringify(returnResult));
}