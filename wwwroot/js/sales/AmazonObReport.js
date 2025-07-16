$(function () {
    $("#amz-ob-tab").tabs();
});


// --- Import JSON --- 

function openCSVAttachment() {
    document.getElementById('CSVAttachment').addEventListener('change', csvJSON, false);
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

    const lines = contents.split('\n');
    const jsonArray = [];

    for (let i = 1; i < lines.length; i++) {

    }
    var returnResult = new Object();
    returnResult.customerId = custId;
    returnResult.skuList = jsonArray;
    //AmazonFeedsListImportDTO.push(returnResult);

    //$.ajax({
    //    url: '/Inventory/UpdateMarketFeedsList',
    //    type: 'POST',
    //    contentType: "application/json charset=utf-8",
    //    dataType: 'json',
    //    data: JSON.stringify(returnResult),
    //    success: function (response) {
    //        loadDataTable()
    //        //location.reload(true);
    //    }
    //});
}