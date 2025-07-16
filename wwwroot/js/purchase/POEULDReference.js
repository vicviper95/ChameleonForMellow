
$(document).ready(function () {



});

async function getVendorProdLeadTime() {
  let result = await $.ajax({
    type: "GET",
    url: "/Purchase/GetVendorProdLeadTimeList",
    data: "{}",
    success: function (data) {
    }
  });
  vendorProdLeadTimeList = JSON.parse(JSON.stringify(result));
  return vendorProdLeadTimeList;
}

async function getDefaultPortOrigPerVendor() {
  let result = await $.ajax({
    type: "GET",
    url: "/Purchase/GetDefaultPortOrigPerVendorList",
    contentType: "application/json charset=utf-8",
    data: { prePOHistoryId: dv.prePOHistoryId },
    success: function (data) {
    }
  });
  defaultPortOrigPerVendorList = JSON.parse(JSON.stringify(result));
  return defaultPortOrigPerVendorList;
}

async function getPortOrigToPortDestOceanSailingDays() {
  let result = await $.ajax({
    type: "GET",
    url: "/Purchase/GetPortOrigToPortDestOceanSailingDaysList",
    data: "{}",
    success: function (data) {
    }
  });
  portOrigToPortDestOceanSailingDaysList = JSON.parse(JSON.stringify(result));
  return portOrigToPortDestOceanSailingDaysList;
}

async function getPortDestToWarehouseInLandTransDays() {
  let result = await $.ajax({
    type: "GET",
    url: "/Purchase/GetPortDestToWarehouseInLandTransDaysList",
    data: "{}",
    success: function (data) {
    }
  });
  portDestToWarehouseInLandTransDays = JSON.parse(JSON.stringify(result));
  return portDestToWarehouseInLandTransDays;
}

async function getDefaultPortDestPerWarehouse() {
  let result = await $.ajax({
    type: "GET",
    url: "/Purchase/GetDefaultPortDestPerWarehouseList",
    data: "{}",
    success: function (data) {
    }
  });
  defaultPortDestPerWarehouse = JSON.parse(JSON.stringify(result));
  return defaultPortDestPerWarehouse;
}