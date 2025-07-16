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
let popupNSFlag = false;
let popupTaskFlag = false;
let popupResFlag = false;
let chartFlag = false;
let errorCount = 0;
let errPoNoList = [];
let DS_lastSyncTime;
let yData = new Map();
let yPrice = new Map();
let yData_dir = [];
let yData_dirImp = [];
let countDate = 0;
let countPrice = 0;
let resCount;
let dateChart;
let priceChart;
let totalPrice = 0;

let taskCount = 0;
let taskData = [];
let resData = {};

$(function () {
    $("#amz-graphTabs").tabs();
});

//function chartSet() {
//    var title = Array.from(yData.keys());
//    title.shift();
//    var dateList = Array.from(yData.values());
//    dateList.shift();

//    var allDates = Array.from(yData.get('allDateRange')).sort(function (a, b) {
//        return new Date(a) - new Date(b);
//    })
//    var green = 0;
//    var finalData = [];
//    for (var x in dateList) {
//        for (var y in allDates) {
//            if (!dateList[x].has(allDates[y]))
//                dateList[x].set(allDates[y], 0);
//        }
//        var sortedDate = new Map([...dateList[x].entries()].sort());
//        var dataset = {
//            label: title[x],
//            backgroundColor: "rgba(66," + green +",255,0.4)",
//            borderColor: "rgba(66," + green +",255,0.4)",
//            borderWidth: 2,
//            hoverBackgroundColor: "rgba(255,99,132,0.4)",
//            hoverBorderColor: "rgba(255,99,132,1)",
//            data: Array.from(sortedDate.values()),
//        }
//        finalData.push(dataset);
//        green = green + 100;
//    }

  
   
//    return {
//        labels: allDates,
//        datasets: finalData,
//    };
//}

function chartSet(yMap) {
    var title = Array.from(yMap.keys());
    title.shift();
    var dateList = Array.from(yMap.values());
    dateList.shift();

    var allDates = Array.from(yMap.get('allDateRange')).sort(function (a, b) {
        return new Date(a) - new Date(b);
    })
    var green = 0;
    var finalData = [];
    for (var x in dateList) {
        for (var y in allDates) {
            if (!dateList[x].has(allDates[y]))
                dateList[x].set(allDates[y], 0);
        }
        var sortedDate = new Map([...dateList[x].entries()].sort());
        var dataset = {
            label: title[x],
            backgroundColor: "rgba(66," + green + ",255,0.4)",
            borderColor: "rgba(66," + green + ",255,0.4)",
            borderWidth: 2,
            hoverBackgroundColor: "rgba(255,99,132,0.4)",
            hoverBorderColor: "rgba(255,99,132,1)",
            data: Array.from(sortedDate.values()),
        }
        finalData.push(dataset);
        green = green + 100;
    }



    return {
        labels: allDates,
        datasets: finalData,
    };
}


var chartData = function () {
    var ctx_live = document.getElementById("chartData");

    if (yData.size == 0) {
        dateChart.destroy();
        return;
    }

    if (dateChart != undefined) {
        dateChart.destroy();
    }


    var data = chartSet(yData);
    
    var options = {
        maintainAspectRatio: false,
        scales: {
            y: {
                stacked: false,
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
    var data = chartSet(yPrice);
    var options = {
        maintainAspectRatio: false,
        scales: {
            y: {
                stacked: false,
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

var dataTable = $("#amz_SO_Ordr").DataTable({
    "order": [[5, "desc"]],
    columnDefs: [{
        orderable: false,
        className: 'select-checkbox',
        targets: 0
    }],
    select: {
        style: 'os',
        selector: 'td:first-child'
    },
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
        "url": "/amazon/getPO",
        "type": "GET",
        "datatype": "json",
        "data": function (d) {
            d.startDate = startDate;
            d.endDate = endDate;
        },
        "dataSrc": function (res) {
            yData = new Map();
            yPrice = new Map();
            yData_dir = [];
            yData_dirImp = [];
            totalPrice = 0;
            totalCount = 0;
            if (res.data.length == 0 && dateChart != undefined)
                chartData();
            //if (res.dropShipLastSyncTime != null) {
            //    DS_lastSyncTime = new Date(res.dropShipLastSyncTime);
            //    $("#ds_lastSyncTime").html("Last Dropship Sync Time: " + moment(DS_lastSyncTime).format('MM/DD/YYYY hh:mm a'));
            //}
            if (res.dirLastSyncTime != null) {
                dir_lastSyncTime = new Date(res.dirLastSyncTime);
                $("#dir_lastSyncTime").html("Last Dirct & DI Sync Date: " + moment(dir_lastSyncTime).format('MM/DD/YYYY'));
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
        { "data": "customer", "width": "10%" },
        { "data": "orderNo", "width": "10%" },
        { "data": "sku", "width": "10%" },
        {
            "data": "date", type: "date", "width": "10%", render: function (data, type, row, meta) {
                var splitDate = data.split('T');
                var finalDate = splitDate[0]

                if (!yData.has('allDateRange'))
                    yData.set('allDateRange', new Set());
                else if (!yData.get('allDateRange').has(finalDate))
                    yData.get('allDateRange').add(finalDate);

                if (countDate < resCount) {
                    if (!yData.has(row['customer'])) {
                        yData.set(row['customer'], new Map())
                        yData.get(row['customer']).set(finalDate, 1)
                    }
                    else {
                        if (yData.get(row['customer']).has(finalDate)) {
                            yData.get(row['customer']).set(finalDate, yData.get(row['customer']).get(finalDate) + 1);
                        }
                        else {
                            yData.get(row['customer']).set(finalDate, 1);
                        }
                    }

                    if (countDate == resCount - 1) {
                        chartData();
                    }
                    countDate = countDate + 1;
                }
                /*return moment(data).format('MM/DD/YY h:mm a');*/
                return moment(data).format('MM/DD/YY');
            }
        },
        {
            "data": "shipWindowStart", "width": "10%", render: function (data) {
                return moment(data).format('MM/DD/YY');
            }
        },
        {
            "data": "shipWindowEnd", "width": "10%", render: function (data) {
                return moment(data).format('MM/DD/YY');
            }
        },
        {
            "data": "shipDate", "width": "10%", render: function (data) {
                return moment(data).format('MM/DD/YY');
            }
        },
        { "data": "carrier", "width": "10%" },
        { "data": "wareHouse", "width": "10%" },
        { "data": "fcaId", "width": "10%" },
        { "data": "qty", "width": "10%" },
        {
            "data": "unitePrice", "width": "10%", render: function (data) {

                return "$" + data;
            }
        },
        {
            "data": "totalPrice", "width": "10%", render: function (data, type, row, meta) {
                totalPrice = +totalPrice + +data;
                //console.log(totalPrice);
                var splitDate = row["date"].split('T');
                var finalDate = splitDate[0]

                if (!yPrice.has('allDateRange'))
                    yPrice.set('allDateRange', new Set());
                else if (!yPrice.get('allDateRange').has(finalDate))
                    yPrice.get('allDateRange').add(finalDate);

                if (countPrice < resCount) {

                    if (!yPrice.has(row['customer'])) {
                        yPrice.set(row['customer'], new Map())
                        yPrice.get(row['customer']).set(finalDate, data)
                    }
                    else {
                        if (yPrice.get(row['customer']).has(finalDate)) {
                            yPrice.get(row['customer']).set(finalDate, +yPrice.get(row['customer']).get(finalDate) + +data);
                        }
                        else {
                            yPrice.get(row['customer']).set(finalDate, data);
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
        { "data": "sorce", "width": "10%" },
       

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
var errDataTable = $("#ErrTable").DataTable({
    "order": [[6, "asc"]],
    dom: 'Bfrtip',
    lengthMenu: [[15, 25, 50], [15, 25, 50]],
    autoWidth: false,
    buttons: [
        'colvis', 'pageLength'
    ],
    "ajax": {
        "url": "/amazon/getError",
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
var missPoDataTable = $("#MissPoTable").DataTable({
    "order": [[2, "asc"]],
    dom: 'Bfrtip',
    lengthMenu: [[15, 25, 50], [15, 25, 50]],
    autoWidth: false,
    buttons: [
        'colvis', 'pageLength'
    ],
    "ajax": {
        "url": "/amazon/getMiss",
        "type": "GET",
        "datatype": "json",
        "dataSrc": function (res) {
            errorCount = res.length;
            return res;
        }
    },
    "columns": [
        { "data": "customer", "width": "10%" },
        { "data": "poNo", "width": "5%" },
        {
            "data": "custOrdTime", "width": "5%", render: function (data) {
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
var taskTable = $("#task-table").DataTable({
    searching: false,
    paging: false,
    footer: false,
    info: false,
    ordering: false,
    data: taskData,

    columns: [
        { data: "task", title: "Task" },
        {
            data: "status", title: "Status", render: function (data) {

                if (data == null)
                    return "Running...";
                else if (data == "Error")
                    return "API Response Error"
                else if (data == "Succeed")
                    return "Succeed!"
                else if (data == "Partially")
                    return "Partially Succeed!"
                else
                    return "failed!"
            }
        },

    ]
});
var succeedTable = $("#succeed-table").DataTable({
    searching: false,
    paging: false,
    footer: false,
    scrollY: "500px",
    scrollCollapse: true,
    //info: false,
    ordering: false,
    data: resData,
    columns: [
        {
            title: "Succeed",
            class: "succeed-header-table"
        },
    ]
});
var failTable = $("#fail-table").DataTable({
    searching: false,
    paging: false,
    footer: false,
    scrollY: "500px",
    scrollCollapse: true,
    //info: false,
    ordering: false,
    data: resData,
    columns: [
        {
            title: "Warning",
            class: "fail-header-table",
        },
    ]
});

//$("#reloadByDate").click(function () {
//    dataTable.ajax.reload();
//}
/*);*/

//Sync API
$("#syncAPI").click(function () {

    //create task
    taskData.push({ "order": taskCount, "task": "Sync purchase order with DB", "status": null });
    var temCount = taskCount;
    taskCount = taskCount + 1;
    taskTable.clear().draw();
    taskTable.rows.add(taskData); // Add new data
    taskTable.columns.adjust().draw(); // Redraw the DataTable


    $('#popup-task').css({
        'display': 'block'
    });
    popupTaskFlag = true;

    return new Promise(function (resolve, reject) {
        $.ajax({
            url: "/amazon/syncAmz",
            type: "GET",
            success:
                function (data) {
                    if ("error response" in data)
                        taskData[temCount]["status"] = "Error";
                    else if ((data["fail"].length > 0 || "error" in data) && data["succeed"].length == 0)
                        taskData[temCount]["status"] = "Failed";
                    else if ((data["fail"].length > 0 || "error" in data) && data["succeed"].length > 0)
                        taskData[temCount]["status"] = "Partially"
                    else
                        taskData[temCount]["status"] = "Succeed";
                    /*resolve(data);*/
                    /*alert(data);*/

                    //reload Datatable and task table
                    dataTable.ajax.reload();
                    taskTable.clear().draw();
                    taskTable.rows.add(taskData); // Add new data
                    taskTable.columns.adjust().draw(); // Redraw the DataTable

                    errDataTable.ajax.reload();

                    resData = data;
                    succeedTable.clear().draw();
                    succeedTable.rows.add(resData["succeed"]); // Add new data
                    succeedTable.columns.adjust().draw(); // Redraw the DataTable

                    failTable.clear().draw();
                    failTable.rows.add(resData["fail"]); // Add new data
                    failTable.columns.adjust().draw(); // Redraw the DataTable
                    popupResFlag = true;
                    $('#popup-reponse').css({
                        'display': 'block'
                    });

                }
        })
    })
})

$("#sync-to-ns").click(function () {

    //create task
    taskData.push({ "order": taskCount, "task": "Send purchase order to NetSuite", "status": null });
    var temCount = taskCount;
    taskCount = taskCount + 1;
    taskTable.clear().draw();
    taskTable.rows.add(taskData); // Add new data
    taskTable.columns.adjust().draw(); // Redraw the DataTable

    $('#popup-task').css({
        'display': 'block'
    });
    popupTaskFlag = true;

    return new Promise(function (resolve, reject) {
        $.ajax({
            url: "/amazon/syncToNs",
            type: "GET",
            success:
                function (data) {
                    if ("error response" in data)
                        taskData[temCount]["status"] = "Error";
                    else if ((data["fail"].length > 0 || "error" in data) && data["succeed"].length == 0)
                        taskData[temCount]["status"] = "Failed";
                    else if ((data["fail"].length > 0 || "error" in data) && data["succeed"].length > 0)
                        taskData[temCount]["status"] = "Partially"
                    else
                        taskData[temCount]["status"] = "Succeed";

                    //reload Datatable and task table
                    dataTable.ajax.reload();
                    errDataTable.ajax.reload();
                    missPoDataTable.ajax.reload();

                    taskTable.clear().draw();
                    taskTable.rows.add(taskData); // Add new data
                    taskTable.columns.adjust().draw(); // Redraw the DataTable

                    resData = data;
                    succeedTable.clear().draw();
                    succeedTable.rows.add(resData["succeed"]); // Add new data
                    succeedTable.columns.adjust().draw(); // Redraw the DataTable

                    failTable.clear().draw();
                    failTable.rows.add(resData["fail"]); // Add new data
                    failTable.columns.adjust().draw(); // Redraw the DataTable

                    popupResFlag = true;
                    $('#popup-reponse').css({
                        'display': 'block'
                    });

                }
        })
    })
})


$("#retrySync").click(function () {
    dataToSend = JSON.stringify(errPoNoList);
    //create task
    taskData.push({ "order": taskCount, "task": "Send purchase order to NetSuite", "status": null });
    var temCount = taskCount;
    taskCount = taskCount + 1;
    taskTable.clear().draw();
    taskTable.rows.add(taskData); // Add new data
    taskTable.columns.adjust().draw(); // Redraw the DataTable

    $('#popup-task').css({
        'display': 'block'
    });
    popupTaskFlag = true;

    return new Promise(function (resolve, reject) {
        $.ajax({
            url: "/amazon/retrySyncAmz",
            type: "GET",
            datatype: "json",
            data: {
                SoNums: dataToSend

            },
            success:
                function (data) {
                    if ("error response" in data)
                        taskData[temCount]["status"] = "Error";
                    else if ((data["fail"].length > 0 || "error" in data) && data["succeed"].length == 0)
                        taskData[temCount]["status"] = "Failed";
                    else if ((data["fail"].length > 0 || "error" in data) && data["succeed"].length > 0)
                        taskData[temCount]["status"] = "Partially"
                    else
                        taskData[temCount]["status"] = "Succeed";
                    /*resolve(data);*/
                    /*alert(data);*/

                    //reload Datatable and task table
                    dataTable.ajax.reload();
                    missPoDataTable.ajax.reload();

                    taskTable.clear().draw();
                    taskTable.rows.add(taskData); // Add new data
                    taskTable.columns.adjust().draw(); // Redraw the DataTable

                    resData = data;
                    succeedTable.clear().draw();
                    succeedTable.rows.add(resData["succeed"]); // Add new data
                    succeedTable.columns.adjust().draw(); // Redraw the DataTable

                    failTable.clear().draw();
                    failTable.rows.add(resData["fail"]); // Add new data
                    failTable.columns.adjust().draw(); // Redraw the DataTable

                    popupResFlag = true;
                    $('#popup-reponse').css({
                        'display': 'block'
                    });

                }
        })
    })

})

$("#button-errorDetect").click(function () {

    if (popupFlag) {
        popupFlag = false;
        $('#popup-error').css({
            'display': 'none'
        });
    }
    else {
        $('#popup-error').css({
            'display': 'block'
        });
        popupFlag = true;
    }

})
$("#closePopup-error").click(function () {

    if (popupFlag) {
        popupFlag = false;
        $('#popup-error').css({
            'display': 'none'
        });
    }
})

$("#button-errorNS").click(function () {
    if (popupNSFlag) {
        popupNSFlag = false;
        $('#popupNS').css({
            'display': 'none'
        });
    }
    else {
        $('#popupNS').css({
            'display': 'block'
        });
        popupNSFlag = true;
    }
})
$("#closeNS").click(function () {

    if (popupNSFlag) {
        popupNSFlag = false;
        $('#popupNS').css({
            'display': 'none'
        });
    }
    console.log(popupNSFlag);
})

$("#buttom-task").click(function () {
    if (popupTaskFlag) {
        popupTaskFlag = false;
        $('#popup-task').css({
            'display': 'none'
        });
    }
    else {
        $('#popup-task').css({
            'display': 'block'
        });
        popupTaskFlag = true;
    }
})
$("#close-task").click(function () {

    if (popupTaskFlag) {
        popupTaskFlag = false;
        $('#popup-task').css({
            'display': 'none'
        });
    }
})

$("#close-response").click(function () {

    if (popupResFlag) {
        popupResFlag = false;
        $('#popup-reponse').css({
            'display': 'none'
        });
    }
})

$("#button-errorDetect").hover(function (e) {
    $('.amz-api-error').css(
        "display", e.type === "mouseenter" ? "block" : "none"
    );
})
$("#button-errorNS").hover(function (e) {
    $('.amz-ns-monitor').css(
        "display", e.type === "mouseenter" ? "block" : "none"
    );
})
$("#syncAPI").hover(function (e) {
    $('.amz-sync-po').css(
        "display", e.type === "mouseenter" ? "block" : "none"
    );
})

$(document).ready(function () {
    dataTable;
    //selected check box
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
//$body = $("body");
//$(document).on({
//    ajaxStart: function () { $body.addClass("loading"); },
//    ajaxStop: function () { $body.removeClass("loading"); }
//});

function loadDataTable() {
    dataTable;
}

