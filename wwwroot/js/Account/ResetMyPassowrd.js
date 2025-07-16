//$('#resetPasswordModal').on('show.bs.modal', function (e) {
//  var id = $(e.relatedTarget).data('id');
//  var that = $(this);
//  console.log("Here!1");

//  that.find('button[id="sendEmailPassword"]').click(function () {
//    console.log("Here!2");
//    var txt = that.find('input[id="myEmailInput"]').val();
//    console.log(txt);

//    $.ajax({
//      url: 'resetMyPassword',
//      type: "POST",
//      contentType: "application/json charset=utf-8",
//      dataType: 'json',
//      data: JSON.stringify(txt),
//      success: function () {
//        alert('This feeds was approved!');
//        getLastUpdateInfo();
//        //location.reload(true);
//      }
//    }); // End of ajax

//  });
//})

$('#sendEmailTmpPassword').click(function () {
  var loginEmail = document.getElementById('emailForTmpPwd').value;
  console.log(loginEmail);

  $.ajax({
    url: '/Account/sendTmpPassword',
    type: "POST",
    contentType: "application/json charset=utf-8",
    dataType: 'json',
    data: JSON.stringify(loginEmail),
    success: function () {
      document.getElementById("responseText").innerHTML = 'The temporary password was sent!';
      //location.reload(true);
    }
  }); // End of ajax



})
