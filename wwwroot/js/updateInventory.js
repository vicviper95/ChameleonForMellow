
  $("#bttnUpdateInv").click(function () {
    $.ajax({
      url: 'updateInventory',
      type: "POST",
      success: function () {
        alert('Thank you for waiting!');
        location.reload(true);
      }
    });
  })

