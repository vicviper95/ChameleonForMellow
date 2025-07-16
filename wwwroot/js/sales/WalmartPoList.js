let tmpDate = new Date();
let fourDaysDate = new Date(new Date().setDate(tmpDate.getDate() - 2));
let fourWeeksDate = new Date(new Date().setDate(tmpDate.getDate() - 28));
let eightWeeksDate = new Date(new Date().setDate(tmpDate.getDate() - 56));
let twelveWeeksDate = new Date(new Date().setDate(tmpDate.getDate() - 84));
let oneYearBeforeDate = new Date(new Date().setDate(tmpDate.getDate() - 365));
let startDate = fourDaysDate;
let endDate = new Date();
let today = (tmpDate.getMonth() + 1) + '/' + tmpDate.getDate() + '/' + tmpDate.getFullYear();
let todayString = getFormattedDate(today);
endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
startDate = (startDate.getMonth() + 1) + '/' + startDate.getDate() + '/' + startDate.getFullYear();
let popupFlag = false;
let popupNSFlag = false;
let popupAckFlag = false;
let popupAsnFlag = false;
let popupCancelFlag = false;
let popupTaskFlag = false;
let popupResFlag = false;
let chartFlag = false;
let errorCount = 0;
let errPoNoLst = [];
let DS_lastSyncTime;
let asnLen;
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
//---------Chart-----------------------------------------------------------------------
//function chartSet(yMap) {
//    var title = Array.from(yMap.keys());
//    title.shift();
//    var dateList = Array.from(yMap.values());
//    dateList.shift();

//    var allDates = Array.from(yMap.get('allDateRange')).sort(function (a, b) {
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
//            backgroundColor: "rgba(66," + green + ",255,0.4)",
//            borderColor: "rgba(66," + green + ",255,0.4)",
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
//let chartData = function () {
//    var ctx_live = document.getElementById("chartData");

//    if (yData.size == 0) {
//        dateChart.destroy();
//        return;
//    }

//    if (dateChart != undefined) {
//        dateChart.destroy();
//    }


//    var data = chartSet(yData);
    
//    var options = {
//        maintainAspectRatio: false,
//        scales: {
//            y: {
//                stacked: false,
//                grid: {
//                    display: true,
//                    color: "rgba(255,99,132,0.2)"
//                }
//            },
//            x: {
//                grid: {
//                    display: false
//                }
//            }
//        }

//    };

//    dateChart = new Chart(ctx_live, {
//        type: 'bar',
//        options: options,
//        data: data
//    });

//}
//let chartPrice = function () {
//    $("#totalPrice").html(parseFloat(totalPrice).toFixed(2));
//    var ctx_live = document.getElementById("chartPrice");

//    if (yPrice.length == 0) {
//        priceChart.destroy();
//        return;
//    }

//    if (priceChart != undefined) {
//        priceChart.destroy();
//    }
//    var data = chartSet(yPrice);
//    var options = {
//        maintainAspectRatio: false,
//        scales: {
//            y: {
//                stacked: false,
//                grid: {
//                    display: true,
//                    color: "rgba(255,99,132,0.2)"
//                }
//            },
//            x: {
//                grid: {
//                    display: false
//                }
//            }
//        }

//    };


//    priceChart = new Chart(ctx_live, {
//        type: 'bar',
//        options: options,
//        data: data
//    });

//}
//--------------------------------------------------------------------------------

$('#Wmt_Order thead tr')
    .clone(true)
    .addClass('filters')
    .appendTo('#Wmt_Order thead');
let walmartPoTable = $("#Wmt_Order").DataTable({
    "order": [[6, "desc"]],
    //"scrollX": true,
    //"scrollCollapse": true,
    "autoWidth": false,
    orderCellsTop: true,
    fixedHeader: false,
    initComplete: function () {
        this.api().columns([3,4,10,11]).every(function () {
            var column = this;
            var select = $('<select style ="background-color: beige; width:100%;"><option value=""></option></select>')
                .appendTo($(column.footer()).empty())
                .on('change', function () {
                    var val = $.fn.dataTable.util.escapeRegex(
                        $(this).val()
                    );

                    column
                        .search(val ? '^' + val + '$' : '', true, false)
                        .draw();
                });

            column.data().unique().sort().each(function (d, j) {
                select.append('<option value="' + d + '">' + d + '</option>')
            });
        });
        var api2 = this.api();
        // For each column
        api2
            .columns()
            .eq(0)
            .each(function (colIdx) {
                // Set the header cell to contain the input element
                if (colIdx == 0 || colIdx == 11 || colIdx == 12 || colIdx == 13 || colIdx == 14 || colIdx == 15) {
                    var cell = $('.filters th').eq(
                        $(api2.column(colIdx).header()).index()
                    );
                    $(cell).html('');
                    return;
                }
                    
                var cell = $('.filters th').eq(
                    $(api2.column(colIdx).header()).index()
                );
                var title = $(cell).text();
                $(cell).html('<input type="text" placeholder="' + title + '" size = "10"/>');

                // On every keypress in this input
                $(
                    'input',
                    $('.filters th').eq($(api2.column(colIdx).header()).index())
                )
                    .off('keyup change')
                    .on('keyup change', function (e) {
                        e.stopPropagation();

                        // Get the search value
                        $(this).attr('title', $(this).val());
                        var regexr = '({search})'; //$(this).parents('th').find('select').val();

                        var cursorPosition = this.selectionStart;
                        // Search the column for that value
                        api2
                            .column(colIdx)
                            .search(
                                this.value != ''
                                    ? regexr.replace('{search}', '(((' + this.value + ')))')
                                    : '',
                                this.value != '',
                                this.value == ''
                            )
                            .draw();

                        $(this)
                            .focus()[0]
                            .setSelectionRange(cursorPosition, cursorPosition);
                    });
            });
    },
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
        "url": "/walmart/getPO",
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

            if (res.wmtLastSyncTime != null) {
                lastSyncTime = new Date(res.wmtLastSyncTime);
                $("#lastSyncTime").html("Last Walmart Sync Date: " + moment(lastSyncTime).format('MM/DD/YYYY hh:mm A'));
            }
            countDate = 0;
            countPrice = 0;
            resCount = res.data.length;

            return res.data;
        }
    },
    "columns": [
        { "data": "kodId","visible": false },
        { "data": "soId", },
        { "data": "orderNo",  },
        { "data": "sku",  },
        { "data": "orderStatus",  },
        {
            "data": "date", type: "date", render: function (data, type, row, meta) {
                return moment(data).format('YYYY/MM/DD');
            }
        },
        {
            "data": "shipDate",render: function (data) {
                return moment(data).format('YYYY/MM/DD');
            }
        },
        {
            "data": "ackedtime",render: function (data) {
                if (data != null)
                    return moment(data).format('YYYY/MM/DD hh:mm A');
                else
                    return "";
            }
        },
        {
            "data": "asnSentTime",render: function (data) {
                if (data != null)
                    return moment(data).format('YYYY/MM/DD hh:mm A');
                else
                    return "";
            }
        },
        {
            "data": "trackingNo", render: function (data) {
                if (data != null)
                    return data.split(',').join(", ");
                else
                    return "";
            }},
        { "data": "carrier" },
        { "data": "wareHouse"},
        { "data": "qty" },
        {
            "data": "unitePrice", render: function (data) {

                return "$" + data;
            }
            , "width": "1%"
        },
        {
            "data": "totalPrice", render: function (data, type, row, meta) {
                return "$" + data;
            }
            , "width": "2%"
        },
        {
            "data": "addedTime", render: function (data) {
                return moment(data).format('YYYY/MM/DD HH:mm A');
            }
        }
    ],
    "language": {
        "emptyTable": "no data found"
    },
    //"width": "100%"
});
let errWmtTable = $("#ErrTable").DataTable({
    "order": [[4, "asc"]],
    dom: 'Bfrtip',
    lengthMenu: [[15, 25, 50], [15, 25, 50]],
    autoWidth: false,
    buttons: [
        'colvis', 'pageLength'
    ],
    "ajax": {
        "url": "/walmart/getError",
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
                if (data != null && !errPoNoLst.includes(data)) {
                    errPoNoLst.push(data);
                }
                return data;
            }
        },
        { "data": "customer", "width": "5%" },
        {
            "data": "custSKU", "width": "10%"
        },
        { "data": "detail", "width": "50%" },
        {
            "data": "createdTime", "width": "5%", render: function (data) {
                return moment(data).format('MM/DD/YYYY hh:mm a');
            }
        },
    ],
    "language": {
        "emptyTable": "no data found"
    },
    "width": "120%"
});

walmartPoTable.on("click", "th.select-checkbox", function () {
    if ($("th.select-checkbox").hasClass("selected")) {
        walmartPoTable.rows().deselect();
        $("th.select-checkbox").removeClass("selected");
    } else {
        walmartPoTable.rows().select();
        $("th.select-checkbox").addClass("selected");
    }
}).on("select deselect", function () {
    ("Some selection or deselection going on")
    if (walmartPoTable.rows({
        selected: true
    }).count() !== walmartPoTable.rows().count()) {
        $("th.select-checkbox").removeClass("selected");
    } else {
        $("th.select-checkbox").addClass("selected");
    }
});

let missPoDataTable = $("#MissPoTable").DataTable({
    "order": [[2, "asc"]],
    dom: 'Bfrtip',
    lengthMenu: [[15, 25, 50], [15, 25, 50]],
    autoWidth: false,
    buttons: [
        'colvis', 'pageLength'
    ],
    "ajax": {
        "url": "/walmart/getMiss",
        "type": "GET",
        "datatype": "json",
        "dataSrc": function (res) {
            errorCount = res.length;
            asnLen = res.length;
            $("#MissingNSCount").html(errorCount);
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

//ackTable----------------------------------------------------------------------------------------------
function formatAck(d) {
    let childRows = '<div class="child-table"><table cellpadding="5" cellspacing="1" style="margin-left:10%;padding-left:100px; border-collapse:collase; width :70%">' +
        '<tr style = "background-color:skyblue">' +
            '<th>Item Name</th>' +
            '<th>QTY</th>' +
            '<th>Unite Price</th>' +
            '<th>Status</th>' +
        '</tr>';
    for (let i = 0; i < d.length; i++) {
        let tr = '<tr stlye= "border:2px solid #dddddd; text-align: left; pedding= 8px">' +
            '<td>' + d[i].itemName + '</td>' +
            '<td>' + d[i].qtyOrdered + '</td>' +
            '<td>' + d[i].unitPrice + '</td>' +
            '<td>' + d[i].statusKo + '</td>' +
            '</tr>'
        childRows += tr  
    }
    childRows += '</table><div>';
    return childRows;
}
let ackTable = $("#ackTable").DataTable({
    "order": [[2, "asc"]],
    dom: 'Bfrtip',
    lengthMenu: [[15, 25, 50], [15, 25, 50]],
    autoWidth: false,
    buttons: [
        'colvis', 'pageLength'
    ],
    "ajax": {
        "url": "/walmart/getPendingAck",
        "type": "GET",
        "datatype": "json",
        "data": function (d) {
            d.startDate = startDate;
            d.endDate = endDate;
        },
        "dataSrc": function (res) {
            errorCount = res.length;
            $("#ackCount").html(errorCount);
            return res;
        }
    },
    "columns": [
        {
            "className": 'dt-control',
            "orderable": false,
            "data": null,
            "defaultContent": ''
        },

        { "data": "poNo", "width": "33%" },
        { "data": "locName", "width": "33%" },
        { "data": "soTotal", "width": "33%" },
        { "data": "count", "width": "33%" },
        { "data": "committedCount", "width": "33%" },
        {
            "data": "soDate", "width": "33%", render: function (data) {
                return moment(data).format('MM/DD/YYYY');
            }
        },
    ],
    "language": {
        "emptyTable": "no data found"
    },
    "width": "120%"
});
$('#ackTable tbody').on('click', 'td.dt-control', function () {
    var tr = $(this).closest('tr');
    var row = ackTable.row(tr);

    if (row.child.isShown()) {
        // This row is already open - close it
        row.child.hide();
        tr.removeClass('shown');
    }
    else {
        // Open this row
        row.child(formatAck(row.data().sod)).show();
        tr.addClass('shown');
    }
});
//----------------------------------------------------------------------------------------------

//cancelTable---------------------------------------------------------------------------------------------
function formatCancel(d) {
    let childRows = '<div class="child-table"><table cellpadding="5" cellspacing="1" style="margin-left:10%;padding-left:100px; border-collapse:collase; width :70%">' +
        '<tr style = "background-color:skyblue">' +
        '<th>Item Name</th>' +
        '<th>QTY</th>' +
        '<th>Unite Price</th>' +
        '<th>Status</th>' +
        '</tr>';
    for (let i = 0; i < d.length; i++) {
        let tr = '<tr stlye= "border:2px solid #dddddd; text-align: left; pedding= 8px">' +
            '<td>' + d[i].itemName + '</td>' +
            '<td>' + d[i].qtyOrdered + '</td>' +
            '<td>' + d[i].unitPrice + '</td>' +
            '<td>' + d[i].statusKo + '</td>' +
            '</tr>'
        childRows += tr
    }
    childRows += '</table><div>';
    return childRows;
}
let cancelTable = $("#cancelTable").DataTable({
    "order": [[2, "asc"]],
    dom: 'Bfrtip',
    lengthMenu: [[15, 25, 50], [15, 25, 50]],
    autoWidth: false,
    buttons: [
        'colvis', 'pageLength'
    ],
    "ajax": {
        "url": "/walmart/getPendingCancel",
        "type": "GET",
        "datatype": "json",
        "data": function (d) {
            d.startDate = startDate;
            d.endDate = endDate;
        },
        "dataSrc": function (res) {
            errorCount = res.length;
            $("#cancelCount").html(errorCount);
            return res;
        }
    },
    "columns": [
        {
            "className": 'dt-control',
            "orderable": false,
            "data": null,
            "defaultContent": ''
        },
        { "data": "poNo", "width": "33%" },
        { "data": "soTotal", "width": "33%" },
        { "data": "count", "width": "33%" },
        {
            "data": "soDate", "width": "33%", render: function (data) {
                return moment(data).format('MM/DD/YYYY');
            }
        },
    ],
    "language": {
        "emptyTable": "no data found"
    },
    "width": "120%"
});
$('#cancelTable tbody').on('click', 'td.dt-control', function () {
    var tr = $(this).closest('tr');
    var row = cancelTable.row(tr);

    if (row.child.isShown()) {
        // This row is already open - close it
        row.child.hide();
        tr.removeClass('shown');
    }
    else {
        // Open this row
        row.child(formatAck(row.data().sod)).show();
        tr.addClass('shown');
    }
});
//----------------------------------------------------------------------------------------------



//asnTable---------------------------------------------------------------------------------------------
function formatAsn(d) {
    let childRows = '<div class="child-table"><table cellpadding="5" cellspacing="1" style="margin-left:10%;padding-left:100px; border-collapse:collase; width :70%">' +
        '<tr style = "background-color:skyblue">' +
        '<th>Item Name</th>' +
        '<th>QTY</th>' +
        '<th>Unite Price</th>' +
        '<th>Tracking#</th>' +
        '</tr>';
    for (let i = 0; i < d.length; i++) {
        let tr = '<tr stlye= "border:2px solid #dddddd; text-align: left; pedding= 8px">' +
            '<td>' + d[i].itemName + '</td>' +
            '<td>' + d[i].qtyOrdered + '</td>' +
            '<td>' + d[i].unitPrice + '</td>' +
            '<td>' + '</td>' +
            '</tr>'
        childRows += tr
    }
    childRows += '</table><div>';
    return childRows;
}
let asnTable = $("#asnTable").DataTable({
    "order": [[2, "asc"]],
    dom: 'Bfrtip',
    lengthMenu: [[15, 25, 50], [15, 25, 50]],
    autoWidth: false,
    buttons: [
        'colvis', 'pageLength'
    ],
    "ajax": {
        "url": "/walmart/getPendingAsn",
        "type": "GET",
        "datatype": "json",
        "data": function (d) {
            d.startDate = startDate;
            d.endDate = endDate;
        },
        "dataSrc": function (res) {
            errorCount = res.length;
            $("#asnCount").html(errorCount);
            return res;
        }
    },
    "columns": [
        {
            "className": 'dt-control',
            "orderable": false,
            "data": null,
            "defaultContent": ''
        },
        { "data": "poNo", "width": "23%" },
        { "data": "locName", "width": "33%" },
        { "data": "soTotal", "width": "23%" },
        { "data": "count", "width": "23%" },
        {
            "data": "soDate", "width": "23%", render: function (data) {
                return moment(data).format('MM/DD/YYYY');
            }
        },
        {
            "data": "expShipDate", "width": "23%", render: function (data) {
                return moment(data).format('MM/DD/YYYY');
            }
        },
    ],
    "language": {
        "emptyTable": "no data found"
    },
    "width": "120%"
});
$('#asnTable tbody').on('click', 'td.dt-control', function () {
    var tr = $(this).closest('tr');
    var row = asnTable.row(tr);

    if (row.child.isShown()) {
        // This row is already open - close it
        row.child.hide();
        tr.removeClass('shown');
    }
    else {
        // Open this row
        row.child(formatAsn(row.data().sod)).show();
        tr.addClass('shown');
    }
});
//----------------------------------------------------------------------------------------------

let taskTable = $("#task-table").DataTable({
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
                else if (data == "Failed")
                    return "failed!"
                else
                    return "Nothing Changed"
            }
        },

    ]
});
let succeedTable = $("#succeed-table").DataTable({
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
let failTable = $("#fail-table").DataTable({
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
//    walmartPoTable.ajax.reload();
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
            url: "/walmart/syncWmt",
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
                    walmartPoTable.ajax.reload();
                    taskTable.clear().draw();
                    taskTable.rows.add(taskData); // Add new data
                    taskTable.columns.adjust().draw(); // Redraw the DataTable

                    errWmtTable.ajax.reload();
                    missPoDataTable.ajax.reload();

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
            url: "/walmart/syncToNs",
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
                    walmartPoTable.ajax.reload();

                    errWmtTable.ajax.reload();
                    missPoDataTable.ajax.reload();
                    //missPoDataTable.ajax.reload();

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
    dataToSend = JSON.stringify(errPoNoLst);
    //create task
    taskData.push({ "order": taskCount, "task": "resend", "status": null });
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
            url: "/walmart/retrySyncWmt",
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

                    //version2
                    //if ("error response" in data)
                    //    taskData[temCount]["status"] = "Error";
                    //else if ("Fail" in data)
                    //    taskData[temCount]["status"] = "Failed";
                    //else if ("Fail" in data && data["Succeed"].length > 0)
                    //    taskData[temCount]["status"] = "Partially"
                    //else
                    //    taskData[temCount]["status"] = "Succeed";

                    /*resolve(data);*/
                    /*alert(data);*/

                    //reload Datatable and task table
                    errWmtTable.ajax.reload();

                    walmartPoTable.ajax.reload();
                    //missPoDataTable.ajax.reload();

                    taskTable.clear().draw();
                    taskTable.rows.add(taskData); // Add new data
                    taskTable.columns.adjust().draw(); // Redraw the DataTable

                    console.log(data);
                    resData = data;
                    succeedTable.clear().draw();
                    succeedTable.rows.add(resData["succeed"]); // Add new data
                    succeedTable.columns.adjust().draw();// Redraw the DataTable
                   
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
$("#send-ack").click(function () {

    //create task
    taskData.push({ "order": taskCount, "task": "Send Ack to Walmart", "status": null });
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
            url: "/walmart/sendAck",
            type: "GET",
            success:
                function (data) {
                    if ("error response" in data)
                        taskData[temCount]["status"] = "Error";
                    else if ("True" in data && "False" in data)
                        taskData[temCount]["status"] = "Partially";
                    else if ("True" in data && !("False" in data))
                        taskData[temCount]["status"] = "Succeed"
                    else if (!("True" in data) && "False" in data)
                        taskData[temCount]["status"] = "Failed"
                    else
                        taskData[temCount]["status"] = "Nothing";

                    //reload Datatable and task table
                    errWmtTable.ajax.reload();
                    ackTable.ajax.reload();

                    taskTable.clear().draw();
                    taskTable.rows.add(taskData); // Add new data
                    taskTable.columns.adjust().draw(); // Redraw the DataTable

                    resData = data;
                    succeedTable.clear().draw();
                    failTable.clear().draw();

                    if ("True" in resData) {
                        res = []
                        resData["True"].forEach(x => {
                            elem = [x]
                            res.push(elem)
                        })
                        succeedTable.rows.add(res); // Add new data
                        succeedTable.columns.adjust().draw(); // Redraw the DataTable
                    }
                    if ("False" in resData) {
                        res = []
                        resData["False"].forEach(x => {
                            elem = [x]
                            res.push(elem)
                        })
                        failTable.rows.add(res); // Add new data
                        failTable.columns.adjust().draw(); // Redraw the DataTable
                    } 
                    popupResFlag = true;
                    $('#popup-reponse').css({
                        'display': 'block'
                    });

                }
        })
    })
})
$("#try-send-ASN").click(function () {

    //create task
    taskData.push({ "order": taskCount, "task": "Send ASN to Walmart", "status": null });
    var temCount = taskCount;
    taskCount = taskCount + 1;
    taskTable.clear().draw();
    taskTable.rows.add(taskData); // Add new data
    taskTable.columns.adjust().draw(); // Redraw the DataTable
    var succeedLst = []
    var failedLst = []
    $('#popup-task').css({
        'display': 'block'
    });
    popupTaskFlag = true;

    return new Promise(function (resolve, reject) {
        $.ajax({
            url: "/walmart/sendASN",
            type: "GET",
            success:
                function (data) {
                    if ("error response" in data)
                        taskData[temCount]["status"] = "Error";
                    else if ("True" in data && "False" in data)
                        taskData[temCount]["status"] = "Partially";
                    else if ("True" in data && !("False" in data))
                        taskData[temCount]["status"] = "Succeed"
                    else if (!("True" in data) && "False" in data)
                        taskData[temCount]["status"] = "Failed"
                    else
                        taskData[temCount]["status"] = "Nothing";
                    
                    if ("True" in data) {
                        data["True"].forEach(function (x) {
                            succeedLst.push([x])
                        }
                        )
                        data["True"] = succeedLst
                    }
                    if ("False" in data) {
                        data["False"].forEach(function (x) {
                            failedLst.push([x])
                        }
                        )
                        data["False"] = failedLst
                    }
                    //reload Datatable and task table
                    errWmtTable.ajax.reload();
                    ackTable.ajax.reload();

                    taskTable.clear().draw();
                    taskTable.rows.add(taskData); // Add new data
                    taskTable.columns.adjust().draw(); // Redraw the DataTable

                    resData = data;
                    succeedTable.clear().draw();
                    failTable.clear().draw();

                    if ("True" in resData) {
                        res = []
                        resData["True"].forEach(x => {
                            elem = [x]
                            res.push(elem)
                        })
                        succeedTable.rows.add(res); // Add new data
                        succeedTable.columns.adjust().draw(); // Redraw the DataTable
                    }
                    if ("False" in resData) {
                        res = []
                        resData["False"].forEach(x => {
                            elem = [x]
                            res.push(elem)
                        })
                        failTable.rows.add(res); // Add new data
                        failTable.columns.adjust().draw(); // Redraw the DataTable
                    }
                    popupResFlag = true;
                    $('#popup-reponse').css({
                        'display': 'block'
                    });
                }
        })
    })
})
//popupAckFlag
//popupAsnFlag
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
$("#button-ackCount").click(function () {
    if (popupAckFlag) {
        popupAckFlag = false;
        $('#popupAck').css({
            'display': 'none'
        });
    }
    else {
        $('#popupAck').css({
            'display': 'block'
        });
        popupAckFlag = true;
    }
})
$("#button-asnCount").click(function () {
    if (popupAsnFlag) {
        popupAsnFlag = false;
        $('#popupAsn').css({
            'display': 'none'
        });
    }
    else {
        $('#popupAsn').css({
            'display': 'block'
        });
        popupAsnFlag = true;
    }
})
$("#button-popupCancel").click(function () {
    if (popupCancelFlag) {
        popupCancelFlag = false;
        $('#popupCancel').css({
            'display': 'none'
        });
    }
    else {
        $('#popupCancel').css({
            'display': 'block'
        });
        popupCancelFlag = true;
    }
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

$("#closeNS").click(function () {

    if (popupNSFlag) {
        popupNSFlag = false;
        $('#popupNS').css({
            'display': 'none'
        });
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
$("#closeAck").click(function () {

    if (popupAckFlag) {
        popupAckFlag = false;
        $('#popupAck').css({
            'display': 'none'
        });
    }
})
$("#closeAsn").click(function () {

    if (popupAsnFlag) {
        popupAsnFlag = false;
        $('#popupAsn').css({
            'display': 'none'
        });
    }
})
$("#closeCancel").click(function () {

    if (popupCancelFlag) {
        popupCancelFlag = false;
        $('#popupCancel').css({
            'display': 'none'
        });
    }
})
$("#button-ackCount").hover(function (e) {
    $('.wmt-ack').css(
        "display", e.type === "mouseenter" ? "block" : "none"
    );
})
$("#button-asnCount").hover(function (e) {
    $('.wmt-asn').css(
        "display", e.type === "mouseenter" ? "block" : "none"
    );
})
$("#button-errorDetect").hover(function (e) {
    $('.wmt-api-error').css(
        "display", e.type === "mouseenter" ? "block" : "none"
    );
})
$("#button-popupCancel").hover(function (e) {
    $('.wmt-desc-cancel').css(
        "display", e.type === "mouseenter" ? "block" : "none"
    );
})
$("#button-errorNS").hover(function (e) {
    $('.wmt-ns-monitor').css(
        "display", e.type === "mouseenter" ? "block" : "none"
    );
})
$("#syncAPI").hover(function (e) {
    $('.wmt-sync-po').css(
        "display", e.type === "mouseenter" ? "block" : "none"
    );
})

$(document).ready(function () {
    //selected check box
    $('#frm-example').click(function (e) {
        var rows_selected = walmartPoTable.rows({ selected: true }).data();
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
$('#fromDate').val(startDate);
$('#toDate').val(endDate);


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
            walmartPoTable.ajax.reload();
            ackTable.ajax.reload();
            asnTable.ajax.reload();
        }
        else {
            startDate = $(this).datepicker("setDate", endDate);
            startDate = endDate;
            alert("!!!INVALID!!! From Date is later than End Date");
            //walmartPoTable.ajax.reload();

        }
    }
    );
}
function toDateChange() {
    $("#toDate").change(function () {
        if ($(this).datepicker('getDate') >= $("#fromDate").datepicker('getDate') || $("#fromDate").datepicker('getDate') == null) {
            endDate = $(this).datepicker('getDate');
            endDate = (endDate.getMonth() + 1) + '/' + endDate.getDate() + '/' + endDate.getFullYear();
            walmartPoTable.ajax.reload();
            ackTable.ajax.reload();
            asnTable.ajax.reload();
        }
        else {
            endDate = $(this).datepicker("setDate", startDate);
            endDate = startDate;
            alert("!!!INVALID!!! From Date is later than End Date");
            //walmartPoTable.ajax.reload();
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



