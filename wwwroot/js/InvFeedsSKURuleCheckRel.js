$(function () {
  $("#doNotFeedFromAll").click(function () {
    if ($(this).is(":checked")) {
      document.getElementById('doNotFeedFromBanc').checked = true;
      $("#doNotFeedFromBanc").attr("disabled", "disabled");
      $("#doNotFeedFromBancQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromBancQtyAvail").attr("disabled", "disabled");

      document.getElementById('doNotFeedFromMainsl').checked = true;
      $("#doNotFeedFromMainsl").attr("disabled", "disabled");
      $("#doNotFeedFromMainslQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromMainslQtyAvail").attr("disabled", "disabled");

      $("#amazonDoNotFeed").attr("disabled", "disabled");
      $("#amazonRatio").attr("disabled", "disabled");
      $("#amazonZeroOut").attr("disabled", "disabled");

      $("#wayfairDoNotFeed").attr("disabled", "disabled");
      $("#wayfairRatio").attr("disabled", "disabled");
      $("#wayfairZeroOut").attr("disabled", "disabled");

      $("#walmartDoNotFeed").attr("disabled", "disabled");
      $("#walmartRatio").attr("disabled", "disabled");
      $("#walmartZeroOut").attr("disabled", "disabled");

      $("#overstockDoNotFeed").attr("disabled", "disabled");
      $("#overstockRatio").attr("disabled", "disabled");
      $("#overstockZeroOut").attr("disabled", "disabled");

      $("#eBayDoNotFeed").attr("disabled", "disabled");
      $("#eBayRatio").attr("disabled", "disabled");
      $("#eBayZeroOut").attr("disabled", "disabled");

      $("#bpmDoNotFeed").attr("disabled", "disabled");
      $("#bpmRatio").attr("disabled", "disabled");
      $("#bpmZeroOut").attr("disabled", "disabled");

      $("#mellowDoNotFeed").attr("disabled", "disabled");
      $("#mellowRatio").attr("disabled", "disabled");
      $("#mellowZeroOut").attr("disabled", "disabled");

      $("#houzzDoNotFeed").attr("disabled", "disabled");
      $("#houzzRatio").attr("disabled", "disabled");
      $("#houzzZeroOut").attr("disabled", "disabled");
    } else {
      document.getElementById('doNotFeedFromBanc').checked = false;
      $("#doNotFeedFromBanc").removeAttr("disabled");
      $("#doNotFeedFromBancQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromBancQtyAvail").removeAttr("disabled");
      $("#doNotFeedFromBanc").focus();

      document.getElementById('doNotFeedFromMainsl').checked = false;
      $("#doNotFeedFromMainsl").removeAttr("disabled");
      $("#doNotFeedFromMainslQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromMainslQtyAvail").removeAttr("disabled");

      $("#amazonDoNotFeed").removeAttr("disabled");
      $("#amazonRatio").removeAttr("disabled");
      $("#amazonZeroOut").removeAttr("disabled");

      $("#wayfairDoNotFeed").removeAttr("disabled");
      $("#wayfairRatio").removeAttr("disabled");
      $("#wayfairZeroOut").removeAttr("disabled");

      $("#walmartDoNotFeed").removeAttr("disabled");
      $("#walmartRatio").removeAttr("disabled");
      $("#walmartZeroOut").removeAttr("disabled");

      $("#overstockDoNotFeed").removeAttr("disabled");
      $("#overstockRatio").removeAttr("disabled");
      $("#overstockZeroOut").removeAttr("disabled");

      $("#eBayDoNotFeed").removeAttr("disabled");
      $("#eBayRatio").removeAttr("disabled");
      $("#eBayZeroOut").removeAttr("disabled");

      $("#bpmDoNotFeed").removeAttr("disabled");
      $("#bpmRatio").removeAttr("disabled");
      $("#bpmZeroOut").removeAttr("disabled");

      $("#mellowDoNotFeed").removeAttr("disabled");
      $("#mellowRatio").removeAttr("disabled");
      $("#mellowZeroOut").removeAttr("disabled");

      $("#houzzDoNotFeed").removeAttr("disabled");
      $("#houzzRatio").removeAttr("disabled");
      $("#houzzZeroOut").removeAttr("disabled");

    }
  });
});

$(function () {
  $("#doNotFeedFromBanc").click(function () {
    if ($(this).is(":checked") && (document.getElementById('doNotFeedFromMainsl').checked == false)) {
      $("#doNotFeedFromBancQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromBancQtyAvail").attr("disabled", "disabled");
    } else if ($(this).is(":checked") && (document.getElementById('doNotFeedFromMainsl').checked == true)) {
      $("#doNotFeedFromAll").click();
    } else {
      $("#doNotFeedFromBancQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromBancQtyAvail").removeAttr("disabled");
      $("#doNotFeedFromBanc").focus();
    }
  });
});

$(function () {
  $("#doNotFeedFromMainsl").click(function () {
    if ($(this).is(":checked") && (document.getElementById('doNotFeedFromBanc').checked == false)) {
      $("#doNotFeedFromMainslQtyOnHand").attr("disabled", "disabled");
      $("#doNotFeedFromMainslQtyAvail").attr("disabled", "disabled");
    } else if ($(this).is(":checked") && (document.getElementById('doNotFeedFromBanc').checked == true)) {
      $("#doNotFeedFromAll").click();
    } else {
      $("#doNotFeedFromMainslQtyOnHand").removeAttr("disabled");
      $("#doNotFeedFromMainslQtyAvail").removeAttr("disabled");
      $("#doNotFeedFromMainsl").focus();
    }
  });

  if ($("#doNotFeedFromMainsl").is(":checked") && (document.getElementById('doNotFeedFromBanc').checked == false)) {
    $("#doNotFeedFromMainslQtyOnHand").attr("disabled", "disabled");
    $("#doNotFeedFromMainslQtyAvail").attr("disabled", "disabled");
  } else if ($(this).is(":checked") && (document.getElementById('doNotFeedFromBanc').checked == true)) {
    $("#doNotFeedFromAll").click();
  } else {
    $("#doNotFeedFromMainslQtyOnHand").removeAttr("disabled");
    $("#doNotFeedFromMainslQtyAvail").removeAttr("disabled");
    $("#doNotFeedFromMainsl").focus();
  }

});



$(function () {
  $("#amzSKUSpecific").click(function () {
    if ($(this).is(":checked")) {
      $("#amazonRatio").removeAttr("disabled");
      $("#amazonZeroOut").removeAttr("disabled");
      $("#amzSKUSpecific").focus();
    } else {
      $("#amazonRatio").attr("disabled", "disabled");
      $("#amazonZeroOut").attr("disabled", "disabled");
    }
  });
});

$(function () {
  if ($("#amzSKUSpecific").is(":checked")) {
      $("#amazonRatio").removeAttr("disabled");
      $("#amazonZeroOut").removeAttr("disabled");
      $("#amzSKUSpecific").focus();
    } else {
      $("#amazonRatio").attr("disabled", "disabled");
      $("#amazonZeroOut").attr("disabled", "disabled");
    }
});

$(function () {
  $("#wyfrSKUSpecific").click(function () {
    if ($(this).is(":checked")) {
      $("#wayfairRatio").removeAttr("disabled");
      $("#wayfairZeroOut").removeAttr("disabled");
      $("#wyfrSKUSpecific").focus();
    } else {
      $("#wayfairRatio").attr("disabled", "disabled");
      $("#wayfairZeroOut").attr("disabled", "disabled");
    }
  });
});

$(function () {
  if ($("#wyfrSKUSpecific").is(":checked")) {
    $("#wayfairRatio").removeAttr("disabled");
    $("#wayfairZeroOut").removeAttr("disabled");
    $("#wyfrSKUSpecific").focus();
  } else {
    $("#wayfairRatio").attr("disabled", "disabled");
    $("#wayfairZeroOut").attr("disabled", "disabled");
  }
});

$(function () {
  $("#wlmrtSKUSpecific").click(function () {
    if ($(this).is(":checked")) {
      $("#walmartRatio").removeAttr("disabled");
      $("#walmartZeroOut").removeAttr("disabled");
      $("#wlmrtSKUSpecific").focus();
    } else {
      $("#walmartRatio").attr("disabled", "disabled");
      $("#walmartZeroOut").attr("disabled", "disabled");
    }
  });
});

$(function () {
  if ($("#wlmrtSKUSpecific").is(":checked")) {
    $("#walmartRatio").removeAttr("disabled");
    $("#walmartZeroOut").removeAttr("disabled");
    $("#wlmrtSKUSpecific").focus();
  } else {
    $("#walmartRatio").attr("disabled", "disabled");
    $("#walmartZeroOut").attr("disabled", "disabled");
  }
});

$(function () {
  $("#ostSKUSpecific").click(function () {
    if ($(this).is(":checked")) {
      $("#overstockRatio").removeAttr("disabled");
      $("#overstockZeroOut").removeAttr("disabled");
      $("#ostSKUSpecific").focus();
    } else {
      $("#overstockRatio").attr("disabled", "disabled");
      $("#overstockZeroOut").attr("disabled", "disabled");
    }
  });
});

$(function () {
  if ($("#ostSKUSpecific").is(":checked")) {
    $("#overstockRatio").removeAttr("disabled");
    $("#overstockZeroOut").removeAttr("disabled");
    $("#ostSKUSpecific").focus();
  } else {
    $("#overstockRatio").attr("disabled", "disabled");
    $("#overstockZeroOut").attr("disabled", "disabled");
  }
});

$(function () {
  $("#eBaySKUSpecific").click(function () {
    if ($(this).is(":checked")) {
      $("#eBayRatio").removeAttr("disabled");
      $("#eBayZeroOut").removeAttr("disabled");
      $("#eBaySKUSpecific").focus();
    } else {
      $("#eBayRatio").attr("disabled", "disabled");
      $("#eBayZeroOut").attr("disabled", "disabled");
    }
  });
});

$(function () {
  if ($("#eBaySKUSpecific").is(":checked")) {
    $("#eBayRatio").removeAttr("disabled");
    $("#eBayZeroOut").removeAttr("disabled");
    $("#eBaySKUSpecific").focus();
  } else {
    $("#eBayRatio").attr("disabled", "disabled");
    $("#eBayZeroOut").attr("disabled", "disabled");
  }
});

$(function () {
  $("#bpmSKUSpecific").click(function () {
    if ($(this).is(":checked")) {
      $("#bpmRatio").removeAttr("disabled");
      $("#bpmZeroOut").removeAttr("disabled");
      $("#bpmSKUSpecific").focus();
    } else {
      $("#bpmRatio").attr("disabled", "disabled");
      $("#bpmZeroOut").attr("disabled", "disabled");
    }
  });
});

$(function () {
  if ($("#bpmSKUSpecific").is(":checked")) {
    $("#bpmRatio").removeAttr("disabled");
    $("#bpmZeroOut").removeAttr("disabled");
    $("#bpmSKUSpecific").focus();
  } else {
    $("#bpmRatio").attr("disabled", "disabled");
    $("#bpmZeroOut").attr("disabled", "disabled");
  }
});

$(function () {
  $("#mellowSKUSpecific").click(function () {
    if ($(this).is(":checked")) {
      $("#mellowRatio").removeAttr("disabled");
      $("#mellowZeroOut").removeAttr("disabled");
      $("#mellowSKUSpecific").focus();
    } else {
      $("#mellowRatio").attr("disabled", "disabled");
      $("#mellowZeroOut").attr("disabled", "disabled");
    }
  });
});

$(function () {
  if ($("#mellowSKUSpecific").is(":checked")) {
    $("#mellowRatio").removeAttr("disabled");
    $("#mellowZeroOut").removeAttr("disabled");
    $("#mellowSKUSpecific").focus();
  } else {
    $("#mellowRatio").attr("disabled", "disabled");
    $("#mellowZeroOut").attr("disabled", "disabled");
  }
});

$(function () {
  $("#houzzSKUSpecific").click(function () {
    if ($(this).is(":checked")) {
      $("#houzzRatio").removeAttr("disabled");
      $("#houzzZeroOut").removeAttr("disabled");
      $("#houzzSKUSpecific").focus();
    } else {
      $("#houzzRatio").attr("disabled", "disabled");
      $("#houzzZeroOut").attr("disabled", "disabled");
    }
  });
});

$(function () {
  if ($("#houzzSKUSpecific").is(":checked")) {
    $("#houzzRatio").removeAttr("disabled");
    $("#houzzZeroOut").removeAttr("disabled");
    $("#houzzSKUSpecific").focus();
  } else {
    $("#houzzRatio").attr("disabled", "disabled");
    $("#houzzZeroOut").attr("disabled", "disabled");
  }
});


$(function () {
  $("#remarks").click(function () {
    console.log("I'm here!");
  });
});