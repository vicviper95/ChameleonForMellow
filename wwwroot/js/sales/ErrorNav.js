var navPopupFlag = false;
var errPoNoList = [];

$(document).ready(function () {
    errDataTable
});
$("#nav-button-errorDetect").click(function () {
     console.log("clicked")
    if (navPopupFlag) {
        navPopupFlag = false;
        $('#nav-popup-error').css({
            'display': 'none'
        });
    }
    else {
        $('#nav-popup-error').css({
            'display': 'block'
        });
        navPopupFlag = true;
    }

})

$("#nav-closePopup-error").click(function () {

    if (navPopupFlag) {
        navPopupFlag = false;
        $('#nav-popup-error').css({
            'display': 'none'
        });
    }
})
var errDataTable = $("#ErrTable-nav").DataTable({
    "order": [[6, "asc"]],
    dom: 'Bfrtip',
    lengthMenu: [[15, 25, 50], [15, 25, 50]],
    autoWidth: false,
    buttons: [
        'colvis', 'pageLength'
    ],
    "ajax": {
        "url": "/walmart/getAsnError",
        "type": "GET",
        "datatype": "json",
        "dataSrc": function (res) {
            res = res.filter(x => x.isReSolved == false)
            errorCount = res.length;
            $("#nav-errCount").html(errorCount);
            return res;
        },
        "error": function (re) {

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