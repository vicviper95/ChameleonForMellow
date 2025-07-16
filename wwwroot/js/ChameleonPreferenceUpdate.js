// For waiting indicator
$body = $("body");

$(document).on({
  ajaxStart: function () { $body.addClass("loading"); },
  ajaxStop: function () { $body.removeClass("loading"); }
});


$("#updateChameleonPreference").click(function () {
  var empChameleonConfig = new Object();
  empChameleonConfig.PrivilegeLevelInventory = $('#privilegeLevelInventory').val();
  empChameleonConfig.HasInventoryNotification = ($('#hasInventoryNotification').val() == 'on' ? "true":"false");
  empChameleonConfig.EmpChameleonConfigId = $('#empChameleonConfigId').val();
  empChameleonConfig.EmployeeId = "0";
  console.log(JSON.stringify(empChameleonConfig));

  $.ajax({
    url: '../Account/UpdatePersonalPreference',
    type: "POST",
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(empChameleonConfig),
    success: function () {
      alert('The Perference was updated!');
    }
  });
})
