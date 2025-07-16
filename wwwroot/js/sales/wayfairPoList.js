
let tmpDate = new Date();
let fourWeeksDate = new Date(new Date().setDate(tmpDate.getDate() - 28));
let eightWeeksDate = new Date(new Date().setDate(tmpDate.getDate() - 56));
let twelveWeeksDate = new Date(new Date().setDate(tmpDate.getDate() - 84));
let oneYearBeforeDate = new Date(new Date().setDate(tmpDate.getDate() - 365));
let startDate = fourWeeksDate;
let endDate = new Date();
let today = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();
let todayString = getFormattedDate(today);
endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
let popupFlag = false;
let errorCount = 0;
let errPoNoList = [];
let DS_lastSyncTime;
let yData_dir = [];
let yPrice = [];
let countDate = 0;
let countPrice = 0;
let resCount;
let chartFlag = false;
let dateChart;
let priceChart;
let totalPrice = 0;
$(function () {
    $("#WfGraphTabs").tabs();
});

var chartData = function () {
    var ctx_live = document.getElementById("chartData");

    if (yData_dir.length == 0) {
        dateChart.destroy();
        return;
    }

    if (dateChart != undefined) {
        dateChart.destroy();
    }
    var data = {
        labels: yData_dir.map(function (el) { return el.label }),
        datasets: [{
            label: "Sales Order Count",
            backgroundColor: "skyblue",
            borderColor: "skyblue",
            borderWidth: 2,
            hoverBackgroundColor: "rgba(255,99,132,0.4)",
            hoverBorderColor: "rgba(255,99,132,1)",
            data: yData_dir.map(function (el) { return el.value })
        }]
    };
    var options = {
        maintainAspectRatio: false,
        scales: {
            y: {
                stacked: true,
                grid: {
                    display: true,
                    color: "rgba(255,99,132,0.2)"
                }
            },
            x: {
                grid: {
                    display: false
                }
            }
        }

    };

    dateChart = new Chart(ctx_live, {
        type: 'bar',
        options: options,
        data: data
    });

}

var chartPrice = function () {
    $("#totalPrice").html(parseFloat(totalPrice).toFixed(2));
    var ctx_live = document.getElementById("chartPrice");

    if (yPrice.length == 0) {
        priceChart.destroy();
        return;
    }

    if (priceChart != undefined) {
        priceChart.destroy();
    }
    var data = {
        labels: yPrice.map(function (el) { return el.label }),
        datasets: [
            {
                label: "Sales Order Price",
                backgroundColor: "green",
                borderColor: "green",
                borderWidth: 2,
                hoverBackgroundColor: "rgba(255,99,132,0.4)",
                hoverBorderColor: "rgba(255,99,132,1)",
                data: yPrice.map(function (el) { return el.value }),
            }
        ]
    };
    var options = {
        maintainAspectRatio: false,
        scales: {
            y: {
                stacked: true,
                grid: {
                    display: true,
                    color: "rgba(255,99,132,0.2)"
                }
            },
            x: {
                grid: {
                    display: false
                }
            }
        }

    };


    priceChart = new Chart(ctx_live, {
        type: 'bar',
        options: options,
        data: data
    });

}


var dataTable =
    $("#WF_SO_Ordr").DataTable({
        "order": [[9, "dsc"]],
        columnDefs: [{
            orderable: false,
            className: 'select-checkbox',
            targets: 0
        }],
        select: {
            style: 'os',
            selector: 'td:first-child'
        },
        //columnDefs: [{
        //    orderable: false,
        //    className: 'select-checkbox',
        //    targets: 0
        //}],
        //select: {
        //    style: 'os',
        //    selector: 'td:first-child'
        //},

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
            "url": "/wayfair/getSO",
            "type": "GET",
            "datatype": "json",
            "data": function (d) {
                d.startDate = startDate;
                d.endDate = endDate;
            },
            "dataSrc": function (res) {
                yData_dir = [];
                yPrice = [];
                totalPrice = 0;
                totalCount = 0;
                if (res.data.length == 0 && dateChart != undefined)
                    chartData();
                if (res.lastSyncTime != null) {
                    DS_lastSyncTime = new Date(res.lastSyncTime);
                    $("#lastSyncTime").html("Last Sync Time: " + moment(DS_lastSyncTime).format('MM/DD/YYYY hh:mm a'));
                }
                countDate = 0;
                countPrice = 0;
                resCount = res.data.length;

                return res.data;
            }
        },
        "columns": [
            {
                "data": null, "defaultContent": '',
                "className": 'select-checkbox'
            },
            { "data": "kodId", "visible": false },
            { "data": "orderStatus", "width": "10%" },
            { "data": "orderNo", "width": "10%" },
            { "data": "name", "width": "10%" },
            { "data": "sku", "width": "10%" },
            {
                "data": "price", "width": "10%", render: function (data, type, row, meta) {
                    totalPrice = +totalPrice + +data;
                    //console.log(totalPrice);
                    var splitDate = row["date"].split('T');
                    var finalDate = splitDate[0]
                    var isFind = false;
                    if (countPrice < resCount) {
                        if (yPrice.length == 0) {
                            yPrice.push({ label: finalDate, value: data })
                        }
                        else {
                            for (let i = 0; i < yPrice.length; i++) {
                                if (yPrice[i]["label"] == finalDate) {
                                    yPrice[i]["value"] = +yPrice[i]["value"] + +data
                                    isFind = true;
                                }
                            }
                            if (!isFind) {
                                yPrice.push({ label: finalDate, value: data })
                                yPrice.sort(function (a, b) {
                                    return new Date(a.label) - new Date(b.label);
                                })
                            }
                        }
                        if (countDate == resCount - 1) {
                            chartPrice();
                        }
                        countPrice = countPrice + 1;
                    }
                    return "$" + data;
                }
            },
            { "data": "carrier", "width": "10%" },
            { "data": "wareHouse", "width": "10%" },
            {
                "data": "date", type: "date", "width": "15%", render: function (data) {
                    var splitDate = data.split('T');
                    var finalDate = splitDate[0]
                    var isFind = false;
                    if (countDate < resCount) {
                        if (yData_dir.length == 0) {
                            yData_dir.push({ label: finalDate, value: 1 })
                        }
                        else {
                            for (let i = 0; i < yData_dir.length; i++) {
                                if (yData_dir[i]["label"] == finalDate) {
                                    yData_dir[i]["value"] = yData_dir[i]["value"] + 1
                                    isFind = true;
                                }
                            }
                            if (!isFind) {
                                yData_dir.push({ label: finalDate, value: 1 })
                                yData_dir.sort(function (a, b) {
                                    return new Date(a.label) - new Date(b.label);
                                })
                            }
                        }
                        if (countDate == resCount - 1) {
                            chartData();
                        }
                        countDate = countDate + 1;
                    }
                    return moment(data).format('MM/DD/YYYY h:mm a');

                }
            },
            {
                "data": "shipDate", "width": "15%", render: function (data) {
                    return moment(data).format('MM/DD/YYYY');
                }
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });

dataTable.on("click", "th.select-checkbox", function () {
    if ($("th.select-checkbox").hasClass("selected")) {
        dataTable.rows().deselect();
        $("th.select-checkbox").removeClass("selected");
    } else {
        dataTable.rows().select();
        $("th.select-checkbox").addClass("selected");
    }
}).on("select deselect", function () {
    ("Some selection or deselection going on")
    if (dataTable.rows({
        selected: true
    }).count() !== dataTable.rows().count()) {
        $("th.select-checkbox").removeClass("selected");
    } else {
        $("th.select-checkbox").addClass("selected");
    }
});


var errDataTable =
    $("#ErrTable").DataTable({
        "order": [[6, "asc"]],
        dom: 'Bfrtip',
        lengthMenu: [[15, 25, 50], [15, 25, 50]],
        autoWidth: false,
        buttons: [
            'colvis', 'pageLength'
        ],
        "ajax": {
            "url": "/wayfair/getError",
            "type": "GET",
            "datatype": "json",
            "dataSrc": function (res) {
                res = res.filter(x => x.isReSolved == false)
                errorCount = res.length;
                $("#errCount").html(errorCount);
                return res;
            }
        },
        "columns": [
            { "data": "action", "width": "10%" },
            { "data": "errorCat", "width": "5%" },
            {
                "data": "poNo", "width": "5%", render: function (data) {
                    if (data != null && !errPoNoList.includes(data)) {
                        errPoNoList.push(data);
                    }
                    return data;
                }
            },
            { "data": "customer", "width": "5%" },
            {
                "data": "custSKU", "width": "10%"
            },
            { "data": "detail", "width": "50%" },
            //{
            //    "data": "isReSolved", "width": "5%", render: function (data) {
            //        if (data == false)
            //            return "No";
            //    }
            //},
            {
                "data": "createdTime", "width": "5%", render: function (data) {
                    return moment(data).format('MM/DD/YYYY hh:mm a');
                }
            },
            //{
            //    "data": "resolvedTime", "width": "5%", render: function (data) {
            //        if(data != null)
            //            return moment(data).format('MM/DD/YYYY hh:mm a');
            //        return data
            //    }
            //},
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "120%"
    });

//$("#reloadByDate").click(function () {
//    dataTable.ajax.reload();
//}
/*);*/

//Sync API
$("#syncAPI").click(function () {
    $.ajax({
        url: "/wayfair/syncWF",
        type: "GET",
        success: function (res) {
            alert(res);
            location.reload();
        }
    })

})
$("#retrySync").click(function () {
    dataToSend = JSON.stringify(errPoNoList);
    $.ajax({
        url: "/wayfair/retrySyncWF",
        type: "GET",
        datatype: "json",
        data: {
            SoNums: dataToSend

        },
        success: function (res) {
            alert(res);
            location.reload();
        }
    })

})
$("#errorDetect").click(function () {

    if (popupFlag) {
        popupFlag = false;
        $('#popup').css({
            'display': 'none'
        });
    }
    else {
        $('#popup').css({
            'display': 'block'
        });
        popupFlag = true;
    }

})
$("#closePopup").click(function () {

    if (popupFlag) {
        popupFlag = false;
        $('#popup').css({
            'display': 'none'
        });
    }

})

$("#errorDetect").hover(function (e) {
    $('.wf-api-error').css(
        "display", e.type === "mouseenter" ? "block" : "none"
    );
    console.log(true);
})
$("#syncAPI").hover(function (e) {
    $('.wf-sync-po').css(
        "display", e.type === "mouseenter" ? "block" : "none"
    );
    console.log(true);
})

$(document).ready(function () {
    dataTable;
    $('#frm-example').click(function (e) {
        var rows_selected = dataTable.rows({ selected: true }).data();
        console.log(rows_selected);
        // Iterate over all selected checkboxes
        //$.each(rows_selected, function (index, rowId) {
        //    // Create a hidden element
        //    $(form).append(
        //        $('<input>')
        //            .attr('type', 'hidden')
        //            .attr('name', 'id[]')
        //            .val(rowId)
        //    );
        //});
    });

    defaultDatePicker();
    fromDateChange();
    toDateChange();
});

//-----------calender----------
function getFormattedDate(yDate) {
    let date = new Date(yDate);
    let year = date.getFullYear();
    let month = (1 + date.getMonth()).toString().padStart(2, '0');
    let day = date.getDate().toString().padStart(2, '0');
    return month + day + year;
}

function defaultDatePicker() {
    $("#fromDate").datepicker(
        {
            dateFormat: 'mm/dd/yy',
            defaultDate: startDate
        }
    );
    $("#toDate").datepicker(
        {
            dateFormat: 'mm/dd/yy',
            defaultDate: endDate,
        }
    );
}

function fromDateChange() {
    $("#fromDate").change(function () {
        if ($(this).datepicker('getDate') <= $("#toDate").datepicker('getDate') || $("#toDate").datepicker('getDate') == null) {
            startDate = $(this).datepicker('getDate');
            startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
            dataTable.ajax.reload();
        }
        else {
            startDate = $(this).datepicker("setDate", endDate);
            startDate = endDate;
            alert("!!!INVALID!!! From Date is later than End Date");
            dataTable.ajax.reload();
        }
    }
    );

}
function toDateChange() {
    $("#toDate").change(function () {
        if ($(this).datepicker('getDate') >= $("#fromDate").datepicker('getDate') || $("#fromDate").datepicker('getDate') == null) {
            endDate = $(this).datepicker('getDate');
            endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
            dataTable.ajax.reload();

        }
        else {
            endDate = $(this).datepicker("setDate", startDate);
            endDate = startDate;
            alert("!!!INVALID!!! From Date is later than End Date");
            dataTable.ajax.reload();
        }
    }
    );
}
//-----------------------------------------------

//For waiting indicator
$body = $("body");
$(document).on({
    ajaxStart: function () { $body.addClass("loading"); },
    ajaxStop: function () { $body.removeClass("loading"); }
});

function loadDataTable() {
    dataTable;
}

