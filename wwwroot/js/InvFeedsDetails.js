

$(document).ready(function () {
  //calculateQtyRatioBanc();
  //calculateQtyRatioBasc();
  //calculateQtyRatioMainsl();
  //calculateQtyRatioSwcaft();

  var leftoverQtyBanc = 0;
  var leftoverQtyBasc = 0;
  var leftoverQtyMainsl = 0;
  var leftoverQtySwcaft = 0;
  var leftoverQtyZinusTracy = 0;
  var leftoverQtyZinusChs = 0;
  
  var qtyAvailBanc = parseInt($('#qtyAvailBanc').val());
  var qtyAvailBasc = parseInt($('#qtyAvailBasc').val());
  var qtyAvailMainsl = parseInt($('#qtyAvailMainsl').val());
  var qtyAvailSwcaft = parseInt($('#qtyAvailSwcaft').val());
  var qtyAvailZinusTracy = parseInt($('#qtyAvailZinusTracy').val());
  var qtyAvailZinusChs = parseInt($('#qtyAvailZinusChs').val());

  var actualQtyAvailBanc = 0;
  var actualQtyAvailBasc = 0;
  var actualQtyAvailMainsl = 0;
  var actualQtyAvailSwcaft = 0;
  var actualQtyAvailZinusTracy = 0;
  var actualQtyAvailZinusChs = 0;

  var amazonQtyBanc = parseInt($('#amazonQtyBanc').val());
  var overstockQtyBanc = parseInt($('#overstockQtyBanc').val());
  var walmartQtyBanc = parseInt($('#walmartQtyBanc').val());
  var wayfairQtyBanc = parseInt($('#wayfairQtyBanc').val());
  var targetQtyBanc = parseInt($('#targetQtyBanc').val());
  var eBayQtyBanc = parseInt($('#eBayQtyBanc').val());
  //var houzzQtyBanc = parseInt($('#houzzQtyBanc').val());
  var mellowWebQtyBanc = parseInt($('#mellowWebQtyBanc').val());
  var bpmWebQtyBanc = parseInt($('#bpmWebQtyBanc').val());
  var homeDepotQtyBanc = parseInt($('#homeDepotQtyBanc').val());

  var amazonQtyBasc = parseInt($('#amazonQtyBasc').val());
  var overstockQtyBasc = parseInt($('#overstockQtyBasc').val());
  var walmartQtyBasc = parseInt($('#walmartQtyBasc').val());
  var wayfairQtyBasc = parseInt($('#wayfairQtyBasc').val());
  var targetQtyBasc = parseInt($('#targetQtyBasc').val());
  var eBayQtyBasc = parseInt($('#eBayQtyBasc').val());
  //var houzzQtyBasc = parseInt($('#houzzQtyBasc').val());
  var mellowWebQtyBasc = parseInt($('#mellowWebQtyBasc').val());
  var bpmWebQtyBasc = parseInt($('#bpmWebQtyBasc').val());
  var homeDepotQtyBasc = parseInt($('#homeDepotQtyBasc').val());

  var amazonQtyMainsl = parseInt($('#amazonQtyMainsl').val());
  var overstockQtyMainsl = parseInt($('#overstockQtyMainsl').val());
  var walmartQtyMainsl = parseInt($('#walmartQtyMainsl').val());
  var wayfairQtyMainsl = parseInt($('#wayfairQtyMainsl').val());
  var targetQtyMainsl = parseInt($('#targetQtyMainsl').val());
  var eBayQtyMainsl = parseInt($('#eBayQtyMainsl').val());
  //var houzzQtyMainsl = parseInt($('#houzzQtyMainsl').val());
  var mellowWebQtyMainsl = parseInt($('#mellowWebQtyMainsl').val());
  var bpmWebQtyMainsl = parseInt($('#bpmWebQtyMainsl').val());
  var homeDepotQtyMainsl = parseInt($('#homeDepotQtyMainsl').val());

  var amazonQtySwcaft = parseInt($('#amazonQtySwcaft').val());
  var overstockQtySwcaft = parseInt($('#overstockQtySwcaft').val());
  var walmartQtySwcaft = parseInt($('#walmartQtySwcaft').val());
  var wayfairQtySwcaft = parseInt($('#wayfairQtySwcaft').val());
  var targetQtySwcaft = parseInt($('#targetQtySwcaft').val());
  var eBayQtySwcaft = parseInt($('#eBayQtySwcaft').val());
  //var houzzQtySwcaft = parseInt($('#houzzQtySwcaft').val());
  var mellowWebQtySwcaft = parseInt($('#mellowWebQtySwcaft').val());
  var bpmWebQtySwcaft = parseInt($('#bpmWebQtySwcaft').val());
  var homeDepotQtySwcaft = parseInt($('#homeDepotQtySwcaft').val());


  var amazonQtyZinusTracy = parseInt($('#amazonQtyZinusTracy').val());
  var overstockQtyZinusTracy = parseInt($('#overstockQtyZinusTracy').val());
  var walmartQtyZinusTracy = parseInt($('#walmartQtyZinusTracy').val());
  var wayfairQtyZinusTracy = parseInt($('#wayfairQtyZinusTracy').val());
  var targetQtyZinusTracy = parseInt($('#targetQtyZinusTracy').val());
  var eBayQtyZinusTracy = parseInt($('#eBayQtyZinusTracy').val());
  //var houzzQtyZinusTracy = parseInt($('#houzzQtyZinusTracy').val());
  var mellowWebQtyZinusTracy = parseInt($('#mellowWebQtyZinusTracy').val());
  var bpmWebQtyZinusTracy = parseInt($('#bpmWebQtyZinusTracy').val());
  var homeDepotQtyZinusTracy = parseInt($('#homeDepotQtyZinusTracy').val());


  var amazonQtyZinusChs = parseInt($('#amazonQtyZinusChs').val());
  var overstockQtyZinusChs = parseInt($('#overstockQtyZinusChs').val());
  var walmartQtyZinusChs = parseInt($('#walmartQtyZinusChs').val());
  var wayfairQtyZinusChs = parseInt($('#wayfairQtyZinusChs').val());
  var targetQtyZinusChs = parseInt($('#targetQtyZinusChs').val());
  var eBayQtyZinusChs = parseInt($('#eBayQtyZinusChs').val());
  //var houzzQtyZinusChs = parseInt($('#houzzQtyZinusChs').val());
  var mellowWebQtyZinusChs = parseInt($('#mellowWebQtyZinusChs').val());
  var bpmWebQtyZinusChs = parseInt($('#bpmWebQtyZinusChs').val());
  var homeDepotQtyZinusChs = parseInt($('#homeDepotQtyZinusChs').val());

  //console.log(leftoverQtyBanc);
  leftoverQtyBanc = qtyAvailBanc - amazonQtyBanc - overstockQtyBanc - walmartQtyBanc - wayfairQtyBanc - targetQtyBanc;
  leftoverQtyBanc = leftoverQtyBanc - eBayQtyBanc - mellowWebQtyBanc - bpmWebQtyBanc - homeDepotQtyBanc; //- houzzQtyBanc
  //console.log(qtyAvailBasc, qtyAvailMainsl, qtyAvailSwcaft);
  //leftoverQtyBanc = parseInt(qtyAvailBanc-(amazonQtyBanc+overstockQtyBanc+walmartQtyBanc+wayfairQtyBanc+homeDepotQtyBanc+targetQtyBasc+eBayQtyBanc+houzzQtyBanc+bpmWebQtyBasc+mellowWebQtyBanc));
  leftoverQtyBasc = qtyAvailBasc - amazonQtyBasc - overstockQtyBasc - walmartQtyBasc - wayfairQtyBasc - homeDepotQtyBasc;
  leftoverQtyBasc = leftoverQtyBasc - targetQtyBasc - eBayQtyBasc - bpmWebQtyBasc - mellowWebQtyBasc;// - houzzQtyBasc
  leftoverQtyMainsl = qtyAvailMainsl - amazonQtyMainsl - overstockQtyMainsl - walmartQtyMainsl - wayfairQtyMainsl - homeDepotQtyMainsl;
  //console.log(leftoverQtyMainsl - targetQtyBasc);
  leftoverQtyMainsl = leftoverQtyMainsl - targetQtyMainsl - eBayQtyMainsl - bpmWebQtyMainsl - mellowWebQtyMainsl; // - houzzQtyMainsl
  leftoverQtySwcaft = qtyAvailSwcaft - amazonQtySwcaft - overstockQtySwcaft - walmartQtySwcaft - wayfairQtySwcaft - homeDepotQtySwcaft;
  //console.log(leftoverQtySwcaft);
  leftoverQtySwcaft = leftoverQtySwcaft - targetQtySwcaft - eBayQtySwcaft - bpmWebQtySwcaft - mellowWebQtySwcaft; // - houzzQtySwcaft
  //console.log(qtyAvailBasc, amazonQtyBasc,  overstockQtyBasc, walmartQtyBasc, wayfairQtyBasc, targetQtyBasc, eBayQtyBasc,houzzQtyBasc,  mellowWebQtyBasc,bpmWebQtyBasc,homeDepotQtyBasc)
  //console.log(qtyAvailMainsl, amazonQtyMainsl, overstockQtyMainsl, walmartQtyMainsl, wayfairQtyMainsl, targetQtyMainsl, eBayQtyMainsl, houzzQtyMainsl, mellowWebQtyMainsl, bpmWebQtyMainsl, homeDepotQtyMainsl)
  //console.log(qtyAvailSwcaft, amazonQtySwcaft, overstockQtySwcaft, walmartQtySwcaft, wayfairQtySwcaft, targetQtySwcaft, eBayQtySwcaft, houzzQtySwcaft, mellowWebQtySwcaft, bpmWebQtySwcaft, homeDepotQtySwcaft)
  //console.log(leftoverQtyBanc);

  leftoverQtyZinusTracy = qtyAvailZinusTracy - amazonQtyZinusTracy - overstockQtyZinusTracy - walmartQtyZinusTracy - wayfairQtyZinusTracy - targetQtyZinusTracy;
  leftoverQtyZinusTracy = leftoverQtyZinusTracy - eBayQtyZinusTracy - mellowWebQtyZinusTracy - bpmWebQtyZinusTracy - homeDepotQtyZinusTracy; //- houzzQtyZinusTracy

  leftoverQtyZinusChs = qtyAvailZinusChs - amazonQtyZinusChs - overstockQtyZinusChs - walmartQtyZinusChs - wayfairQtyZinusChs - targetQtyZinusChs;
  leftoverQtyZinusChs = leftoverQtyZinusChs - eBayQtyZinusChs - mellowWebQtyZinusChs - bpmWebQtyZinusChs - homeDepotQtyZinusChs; //- houzzQtyZinusChs



  totalStagePOQtyBanc = parseInt($('#totalStagePOQtyBanc').val());
  totalStagePOQtyBasc = parseInt($('#totalStagePOQtyBasc').val());
  totalStagePOQtyMainsl = parseInt($('#totalStagePOQtyBasc').val());
  totalStagePOQtySWCAFT = parseInt($('#totalStagePOQtySWCAFT').val());
  totalStagePOQtyZinusTracy = parseInt($('#totalStagePOQtyZinusTracy').val());
  totalStagePOQtyZinusChs = parseInt($('#totalStagePOQtyZinusChs').val());

  actualQtyAvailBanc = qtyAvailBanc - totalStagePOQtyBanc;
  actualQtyAvailBasc = qtyAvailBasc - totalStagePOQtyBasc;
  actualQtyAvailMainsl = qtyAvailMainsl - totalStagePOQtyMainsl;
  actualQtyAvailSwcaft = qtyAvailSwcaft - totalStagePOQtySWCAFT;
  actualQtyAvailZinusTracy = qtyAvailZinusTracy - totalStagePOQtyZinusTracy;
  actualQtyAvailZinusChs = qtyAvailZinusChs - totalStagePOQtyZinusChs;

  document.getElementById('leftoverQtyBanc').value = (leftoverQtyBanc - totalStagePOQtyBanc) + " (" + leftoverQtyBanc + ")";
  var lqbn = document.getElementById('leftoverQtyBanc');
  if ((leftoverQtyBanc - totalStagePOQtyBanc) < 0) {
    lqbn.style.color = "#FBC02D";
    if (leftoverQtyBanc < 0) { lqbn.style.color = "#D32F2F"; }
  } else {
    lqbn.style.color = "#000000";
  }
  document.getElementById('leftoverQtyBasc').value = (leftoverQtyBasc - totalStagePOQtyBasc) + " (" + leftoverQtyBasc + ")";
  var lqbs = document.getElementById('leftoverQtyBasc');
  if ((leftoverQtyBasc - totalStagePOQtyBasc) < 0) {
    lqbs.style.color = "#FBC02D";
    if (leftoverQtyBasc < 0) { lqbs.style.color = "#D32F2F"; }
  } else {
    lqbs.style.color = "#000000";
  }

  document.getElementById('leftoverQtyMainsl').value = (leftoverQtyMainsl - totalStagePOQtyMainsl) + " (" + leftoverQtyMainsl + ")";
  var lqm = document.getElementById('leftoverQtyMainsl');
  if ((leftoverQtyMainsl - totalStagePOQtyMainsl) < 0) {
    lqm.style.color = "#FBC02D";
    if (leftoverQtyMainsl < 0) { lqm.style.color = "#D32F2F"; }
  } else {
    lqm.style.color = "#000000";
  }
  /*
  document.getElementById('leftoverQtySwcaft').value = (leftoverQtySwcaft - totalStagePOQtySWCAFT) + " (" + leftoverQtySwcaft + ")";
  var lqs = document.getElementById('leftoverQtySwcaft');
  if ((leftoverQtySwcaft - totalStagePOQtySWCAFT) < 0) {
    lqs.style.color = "#FBC02D";
    if (leftoverQtySwcaft < 0) { lqs.style.color = "#D32F2F"; }
  } else {
    lqs.style.color = "#000000";
  }
  */
  document.getElementById('leftoverQtyZinusTracy').value = (leftoverQtyZinusTracy - totalStagePOQtyZinusTracy) + " (" + leftoverQtyZinusTracy + ")";
  var lqbn = document.getElementById('leftoverQtyZinusTracy');
  if ((leftoverQtyZinusTracy - totalStagePOQtyZinusTracy) < 0) {
    lqbn.style.color = "#FBC02D";
    if (leftoverQtyZinusTracy < 0) { lqbn.style.color = "#D32F2F"; }
  } else {
    lqbn.style.color = "#000000";
  }
  document.getElementById('leftoverQtyZinusChs').value = (leftoverQtyZinusChs - totalStagePOQtyZinusChs) + " (" + leftoverQtyZinusChs + ")";
  var lqbs = document.getElementById('leftoverQtyZinusChs');
  if ((leftoverQtyZinusChs - totalStagePOQtyZinusChs) < 0) {
    lqbs.style.color = "#FBC02D";
    if (leftoverQtyZinusChs < 0) { lqbs.style.color = "#D32F2F"; }
  } else {
    lqbs.style.color = "#000000";
  }



});

//Banc
const amazonQtyBancInput = document.getElementById('amazonQtyBanc');
const wayfairQtyBancInput = document.getElementById('wayfairQtyBanc');
const walmartQtyBancInput = document.getElementById('walmartQtyBanc');
const eBayQtyBancInput = document.getElementById('eBayQtyBanc');
const homeDepotQtyBancInput = document.getElementById('homeDepotQtyBanc');
const targetQtyBancInput = document.getElementById('targetQtyBanc');
//const houzzQtyBancInput = document.getElementById('houzzQtyBanc');
const overstockQtyBancInput = document.getElementById('overstockQtyBanc');
const bpmWebQtyBancInput = document.getElementById('bpmWebQtyBanc');
const mellowWebQtyBancInput = document.getElementById('mellowWebQtyBanc');
const qtyAvailBancInput = document.getElementById('qtyAvailBanc');

const bancQtyRatioHandler = function (e) {
  calculateQtyRatioBanc();
}

amazonQtyBancInput.addEventListener('input', bancQtyRatioHandler);
wayfairQtyBancInput.addEventListener('input', bancQtyRatioHandler);
walmartQtyBancInput.addEventListener('input', bancQtyRatioHandler);
eBayQtyBancInput.addEventListener('input', bancQtyRatioHandler);
homeDepotQtyBancInput.addEventListener('input', bancQtyRatioHandler);
targetQtyBancInput.addEventListener('input', bancQtyRatioHandler);
//houzzQtyBancInput.addEventListener('input', bancQtyRatioHandler);
overstockQtyBancInput.addEventListener('input', bancQtyRatioHandler);
bpmWebQtyBancInput.addEventListener('input', bancQtyRatioHandler);
mellowWebQtyBancInput.addEventListener('input', bancQtyRatioHandler);
qtyAvailBancInput.addEventListener('input', bancQtyRatioHandler);


//Basc
const amazonQtyBascInput = document.getElementById('amazonQtyBasc');
const wayfairQtyBascInput = document.getElementById('wayfairQtyBasc');
const walmartQtyBascInput = document.getElementById('walmartQtyBasc');
const eBayQtyBascInput = document.getElementById('eBayQtyBasc');
const homeDepotQtyBascInput = document.getElementById('homeDepotQtyBasc');
const targetQtyBascInput = document.getElementById('targetQtyBasc');
//const houzzQtyBascInput = document.getElementById('houzzQtyBasc');
const overstockQtyBascInput = document.getElementById('overstockQtyBasc');
const bpmWebQtyBascInput = document.getElementById('bpmWebQtyBasc');
const mellowWebQtyBascInput = document.getElementById('mellowWebQtyBasc');
const qtyAvailBascInput = document.getElementById('qtyAvailBasc');

const bascQtyRatioHandler = function (e) {
  calculateQtyRatioBasc();
}

amazonQtyBascInput.addEventListener('input', bascQtyRatioHandler);
wayfairQtyBascInput.addEventListener('input', bascQtyRatioHandler);
walmartQtyBascInput.addEventListener('input', bascQtyRatioHandler);
eBayQtyBascInput.addEventListener('input', bascQtyRatioHandler);
homeDepotQtyBascInput.addEventListener('input', bascQtyRatioHandler);
targetQtyBascInput.addEventListener('input', bascQtyRatioHandler);
//houzzQtyBascInput.addEventListener('input', bascQtyRatioHandler);
overstockQtyBascInput.addEventListener('input', bascQtyRatioHandler);
bpmWebQtyBascInput.addEventListener('input', bascQtyRatioHandler);
mellowWebQtyBascInput.addEventListener('input', bascQtyRatioHandler);
qtyAvailBascInput.addEventListener('input', bascQtyRatioHandler);



//Mainsl

const amazonQtyMainslInput = document.getElementById('amazonQtyMainsl');
const wayfairQtyMainslInput = document.getElementById('wayfairQtyMainsl');
const walmartQtyMainslInput = document.getElementById('walmartQtyMainsl');
const eBayQtyMainslInput = document.getElementById('eBayQtyMainsl');
const homeDepotQtyMainslInput = document.getElementById('homeDepotQtyMainsl');
const targetQtyMainslInput = document.getElementById('targetQtyMainsl');
//const houzzQtyMainslInput = document.getElementById('houzzQtyMainsl');
const overstockQtyMainslInput = document.getElementById('overstockQtyMainsl');
const bpmWebQtyMainslInput = document.getElementById('bpmWebQtyMainsl');
const mellowWebQtyMainslInput = document.getElementById('mellowWebQtyMainsl');
const qtyAvailMainslInput = document.getElementById('qtyAvailMainsl');

const mainslQtyRatioHandler = function (e) {
  calculateQtyRatioMainsl();
}

amazonQtyMainslInput.addEventListener('input', mainslQtyRatioHandler);
wayfairQtyMainslInput.addEventListener('input', mainslQtyRatioHandler);
walmartQtyMainslInput.addEventListener('input', mainslQtyRatioHandler);
eBayQtyMainslInput.addEventListener('input', mainslQtyRatioHandler);
homeDepotQtyMainslInput.addEventListener('input', mainslQtyRatioHandler);
targetQtyMainslInput.addEventListener('input', mainslQtyRatioHandler);
//houzzQtyMainslInput.addEventListener('input', mainslQtyRatioHandler);
overstockQtyMainslInput.addEventListener('input', mainslQtyRatioHandler);
bpmWebQtyMainslInput.addEventListener('input', mainslQtyRatioHandler);
mellowWebQtyMainslInput.addEventListener('input', mainslQtyRatioHandler);
qtyAvailMainslInput.addEventListener('input', mainslQtyRatioHandler);


//Swcaft

const amazonQtySwcaftInput = document.getElementById('amazonQtySwcaft');
const wayfairQtySwcaftInput = document.getElementById('wayfairQtySwcaft');
const walmartQtySwcaftInput = document.getElementById('walmartQtySwcaft');
const eBayQtySwcaftInput = document.getElementById('eBayQtySwcaft');
const homeDepotQtySwcaftInput = document.getElementById('homeDepotQtySwcaft');
const targetQtySwcaftInput = document.getElementById('targetQtySwcaft');
//const houzzQtySwcaftInput = document.getElementById('houzzQtySwcaft');
const overstockQtySwcaftInput = document.getElementById('overstockQtySwcaft');
const bpmWebQtySwcaftInput = document.getElementById('bpmWebQtySwcaft');
const mellowWebQtySwcaftInput = document.getElementById('mellowWebQtySwcaft');
const qtyAvailSwcaftInput = document.getElementById('qtyAvailSwcaft');

const zinusTracyQtyRatioHandler = function (e) {
  calculateQtyRatioZinusTracy();
}

//ZinusTracy

const amazonQtyZinusTracyInput = document.getElementById('amazonQtyZinusTracy');
const wayfairQtyZinusTracyInput = document.getElementById('wayfairQtyZinusTracy');
const walmartQtyZinusTracyInput = document.getElementById('walmartQtyZinusTracy');
const eBayQtyZinusTracyInput = document.getElementById('eBayQtyZinusTracy');
const homeDepotQtyZinusTracyInput = document.getElementById('homeDepotQtyZinusTracy');
const targetQtyZinusTracyInput = document.getElementById('targetQtyZinusTracy');
//const houzzQtyZinusTracyInput = document.getElementById('houzzQtyZinusTracy');
const overstockQtyZinusTracyInput = document.getElementById('overstockQtyZinusTracy');
const bpmWebQtyZinusTracyInput = document.getElementById('bpmWebQtyZinusTracy');
const mellowWebQtyZinusTracyInput = document.getElementById('mellowWebQtyZinusTracy');
const qtyAvailZinusTracyInput = document.getElementById('qtyAvailZinusTracy');



const zinusChsQtyRatioHandler = function (e) {
  calculateQtyRatioZinusChs();
}

//ZinusChs

const amazonQtyZinusChsInput = document.getElementById('amazonQtyZinusChs');
const wayfairQtyZinusChsInput = document.getElementById('wayfairQtyZinusChs');
const walmartQtyZinusChsInput = document.getElementById('walmartQtyZinusChs');
const eBayQtyZinusChsInput = document.getElementById('eBayQtyZinusChs');
const homeDepotQtyZinusChsInput = document.getElementById('homeDepotQtyZinusChs');
const targetQtyZinusChsInput = document.getElementById('targetQtyZinusChs');
//const houzzQtyZinusChsInput = document.getElementById('houzzQtyZinusChs');
const overstockQtyZinusChsInput = document.getElementById('overstockQtyZinusChs');
const bpmWebQtyZinusChsInput = document.getElementById('bpmWebQtyZinusChs');
const mellowWebQtyZinusChsInput = document.getElementById('mellowWebQtyZinusChs');
const qtyAvailZinusChsInput = document.getElementById('qtyAvailZinusChs');


/*
const swcaftQtyRatioHandler = function (e) {
  calculateQtyRatioSwcaft();
}

amazonQtySwcaftInput.addEventListener('input', swcaftQtyRatioHandler);
wayfairQtySwcaftInput.addEventListener('input', swcaftQtyRatioHandler);
walmartQtySwcaftInput.addEventListener('input', swcaftQtyRatioHandler);
eBayQtySwcaftInput.addEventListener('input', swcaftQtyRatioHandler);
homeDepotQtySwcaftInput.addEventListener('input', swcaftQtyRatioHandler);
targetQtySwcaftInput.addEventListener('input', swcaftQtyRatioHandler);
//houzzQtySwcaftInput.addEventListener('input', swcaftQtyRatioHandler);
overstockQtySwcaftInput.addEventListener('input', swcaftQtyRatioHandler);
bpmWebQtySwcaftInput.addEventListener('input', swcaftQtyRatioHandler);
mellowWebQtySwcaftInput.addEventListener('input', swcaftQtyRatioHandler);
qtyAvailSwcaftInput.addEventListener('input', swcaftQtyRatioHandler);
*/
function calculateQtyRatioBanc() {
  qtyAvailBanc = parseInt($('#qtyAvailBanc').val());

  amazonQtyBanc = parseInt($('#amazonQtyBanc').val());
  amazonBancRatio = parseInt($('#amazonBancPercentage').val());
  
  overstockQtyBanc = parseInt($('#overstockQtyBanc').val());
  overstockBancRatio = parseInt($('#overstockBancPercentage').val());

  walmartQtyBanc = parseInt($('#walmartQtyBanc').val());
  walmartBancRatio = parseInt($('#walmartBancPercentage').val());

  wayfairQtyBanc = parseInt($('#wayfairQtyBanc').val());
  wayfairBancRatio = parseInt($('#wayfairBancPercentage').val());

  targetQtyBanc = parseInt($('#targetQtyBanc').val());
  targetBancRatio = parseInt($('#targetBancPercentage').val());

  eBayQtyBanc = parseInt($('#eBayQtyBanc').val());
  eBayBancRatio = parseInt($('#eBayBancPercentage').val());

  //houzzQtyBanc = parseInt($('#houzzQtyBanc').val());
  //houzzBancRatio = parseInt($('#houzzBancPercentage').val());

  mellowWebQtyBanc = parseInt($('#mellowWebQtyBanc').val());
  mellowWebBancRatio = parseInt($('#mellowWebBancPercentage').val());

  bpmWebQtyBanc = parseInt($('#bpmWebQtyBanc').val());
  bpmWebBancRatio = parseInt($('#bpmWebBancPercentage').val());

  homeDepotQtyBanc = parseInt($('#homeDepotQtyBanc').val());
  homeDepotBancRatio = parseInt($('#homeDepotBancPercentage').val());


  //console.log(parseInt($('#qtyAvailBanc').val()));
  // Get total qty.
  leftoverQtyBanc = parseInt($('#qtyAvailBanc').val());

  totalStagePOQtyBanc = parseInt($('#totalStagePOQtyBanc').val());
  actualQtyAvailBanc = qtyAvailBanc - totalStagePOQtyBanc;
  //console.log(leftoverQtyBanc);
  // Calculate leftover qtys.
  leftoverQtyBanc = leftoverQtyBanc - amazonQtyBanc - overstockQtyBanc - walmartQtyBanc - wayfairQtyBanc - homeDepotQtyBanc;

  leftoverQtyBanc = leftoverQtyBanc - targetQtyBanc - eBayQtyBanc - bpmWebQtyBanc - mellowWebQtyBanc; // - houzzQtyBanc
  //console.log(leftoverQtyBanc);

  document.getElementById('leftoverQtyBanc').value = (leftoverQtyBanc - totalStagePOQtyBanc) + " (" + leftoverQtyBanc +")";
  var lqbn = document.getElementById('leftoverQtyBanc');
  if ((leftoverQtyBanc - totalStagePOQtyBanc) < 0)
  {
    lqbn.style.color = "#FBC02D";
    if (leftoverQtyBanc < 0) { console.log("Here"); lqbn.style.color = "#D32F2F"; }
  } else {
    lqbn.style.color = "#000000";
  }
  amazonBancRatio = Math.round((amazonQtyBanc / actualQtyAvailBanc) * 100);
  document.getElementById('amazonBancPercentage').value = amazonBancRatio;
  console.log(amazonBancRatio);

  overstockBancRatio = Math.round((overstockQtyBanc / actualQtyAvailBanc) * 100);
  document.getElementById('overstockBancPercentage').value = overstockBancRatio;

  walmartBancRatio = Math.round((walmartQtyBanc / actualQtyAvailBanc) * 100);
  document.getElementById('walmartBancPercentage').value = walmartBancRatio;

  wayfairBancRatio = Math.round((wayfairQtyBanc / actualQtyAvailBanc) * 100);
  document.getElementById('wayfairBancPercentage').value = wayfairBancRatio;

  homeDepotBancRatio = Math.round((homeDepotQtyBanc / actualQtyAvailBanc) * 100);
  document.getElementById('homeDepotBancPercentage').value = homeDepotBancRatio;

  eBayBancRatio = Math.round((eBayQtyBanc / actualQtyAvailBanc) * 100);
  document.getElementById('eBayBancPercentage').value = eBayBancRatio;

  targetBancRatio = Math.round((targetQtyBanc / actualQtyAvailBanc) * 100);
  document.getElementById('targetBancPercentage').value = targetBancRatio;

  //houzzBancRatio = Math.round((houzzQtyBanc / actualQtyAvailBanc) * 100);
  //document.getElementById('houzzBancPercentage').value = houzzBancRatio;

  bpmWebBancRatio = Math.round((bpmWebQtyBanc / actualQtyAvailBanc) * 100);
  document.getElementById('bpmWebBancPercentage').value = bpmWebBancRatio;

  mellowWebBancRatio = Math.round((mellowWebQtyBanc / actualQtyAvailBanc) * 100);
  document.getElementById('mellowWebBancPercentage').value = mellowWebBancRatio;


};

function calculateQtyRatioBasc() {
  qtyAvailBasc = parseInt($('#qtyAvailBasc').val());

  amazonQtyBasc = parseInt($('#amazonQtyBasc').val());
  amazonBascRatio = parseInt($('#amazonBascPercentage').val());

  overstockQtyBasc = parseInt($('#overstockQtyBasc').val());
  overstockBascRatio = parseInt($('#overstockBascPercentage').val());

  walmartQtyBasc = parseInt($('#walmartQtyBasc').val());
  walmartBascRatio = parseInt($('#walmartBascPercentage').val());

  homeDepotQtyBasc = parseInt($('#homeDepotQtyBasc').val());
  homeDepotBascRatio = parseInt($('#homeDepotBascPercentage').val());

  wayfairQtyBasc = parseInt($('#wayfairQtyBasc').val());
  wayfairBascRatio = parseInt($('#wayfairBascPercentage').val());

  targetQtyBasc = parseInt($('#targetQtyBasc').val());
  targetBascRatio = parseInt($('#targetBascPercentage').val());

  eBayQtyBasc = parseInt($('#eBayQtyBasc').val());
  eBayBascRatio = parseInt($('#eBayBascPercentage').val());

  //houzzQtyBasc = parseInt($('#houzzQtyBasc').val());
  //houzzBascRatio = parseInt($('#houzzBascPercentage').val());

  mellowWebQtyBasc = parseInt($('#mellowWebQtyBasc').val());
  mellowWebBascRatio = parseInt($('#mellowWebBascPercentage').val());

  bpmWebQtyBasc = parseInt($('#bpmWebQtyBasc').val());
  bpmWebBascRatio = parseInt($('#bpmWebBascPercentage').val());



  // Get total qty.
  leftoverQtyBasc = parseInt($('#qtyAvailBasc').val());
  //console.log(leftoverQtyBasc);
  totalStagePOQtyBasc = parseInt($('#totalStagePOQtyBasc').val());
  actualQtyAvailBasc = qtyAvailBasc - totalStagePOQtyBasc;

  // Calculate leftover qtys.
  leftoverQtyBasc = leftoverQtyBasc - amazonQtyBasc - overstockQtyBasc - walmartQtyBasc - wayfairQtyBasc - homeDepotQtyBasc;
  leftoverQtyBasc = leftoverQtyBasc - targetQtyBasc - eBayQtyBasc - bpmWebQtyBasc - mellowWebQtyBasc;// - houzzQtyBasc

  document.getElementById('leftoverQtyBasc').value = (leftoverQtyBasc - totalStagePOQtyBasc) + " (" + leftoverQtyBasc + ")";
  var lqbs = document.getElementById('leftoverQtyBasc');
  if ((leftoverQtyBasc - totalStagePOQtyBasc) < 0) {
    lqbs.style.color = "#FBC02D";
    if (leftoverQtyBasc < 0) { lqbs.style.color = "#D32F2F"; }
  } else {
    lqbs.style.color = "#000000";
  }
  //document.getElementById('leftoverQtyBasc').value = leftoverQtyBasc;

  amazonBascRatio = Math.round((amazonQtyBasc / actualQtyAvailBasc) * 100);
  document.getElementById('amazonBascPercentage').value = amazonBascRatio;

  overstockBascRatio = Math.round((overstockQtyBasc / actualQtyAvailBasc) * 100);
  document.getElementById('overstockBascPercentage').value = overstockBascRatio;

  walmartBascRatio = Math.round((walmartQtyBasc / actualQtyAvailBasc) * 100);
  document.getElementById('walmartBascPercentage').value = walmartBascRatio;

  wayfairBascRatio = Math.round((wayfairQtyBasc / actualQtyAvailBasc) * 100);
  document.getElementById('wayfairBascPercentage').value = wayfairBascRatio;

  homeDepotBascRatio = Math.round((homeDepotQtyBasc / actualQtyAvailBasc) * 100);
  document.getElementById('homeDepotBascPercentage').value = homeDepotBascRatio;

  eBayBascRatio = Math.round((eBayQtyBasc / actualQtyAvailBasc) * 100);
  document.getElementById('eBayBascPercentage').value = eBayBascRatio;

  targetBascRatio = Math.round((targetQtyBasc / actualQtyAvailBasc) * 100);
  document.getElementById('targetBascPercentage').value = targetBascRatio;

  //houzzBascRatio = Math.round((houzzQtyBasc / actualQtyAvailBasc) * 100);
  //document.getElementById('houzzBascPercentage').value = houzzBascRatio;

  bpmWebBascRatio = Math.round((bpmWebQtyBasc / actualQtyAvailBasc) * 100);
  document.getElementById('bpmWebBascPercentage').value = bpmWebBascRatio;

  mellowWebBascRatio = Math.round((mellowWebQtyBasc / actualQtyAvailBasc) * 100);
  document.getElementById('mellowWebBascPercentage').value = mellowWebBascRatio;



};

function calculateQtyRatioMainsl() {
  qtyAvailMainsl = parseInt($('#qtyAvailMainsl').val());
  actualQtyAvailMainsl = 

  amazonQtyMainsl = parseInt($('#amazonQtyMainsl').val());
  amazonMainslRatio = parseInt($('#amazonMainslPercentage').val());

  overstockQtyMainsl = parseInt($('#overstockQtyMainsl').val());
  overstockMainslRatio = parseInt($('#overstockMainslPercentage').val());

  walmartQtyMainsl = parseInt($('#walmartQtyMainsl').val());
  walmartMainslRatio = parseInt($('#walmartMainslPercentage').val());

  wayfairQtyMainsl = parseInt($('#wayfairQtyMainsl').val());
  wayfairMainslRatio = parseInt($('#wayfairMainslPercentage').val());

  homeDepotQtyMainsl = parseInt($('#homeDepotQtyMainsl').val());
  homeDepotMainslRatio = parseInt($('#homeDepotMainslPercentage').val());

  targetQtyMainsl = parseInt($('#targetQtyMainsl').val());
  targetMainslRatio = parseInt($('#targetMainslPercentage').val());

  eBayQtyMainsl = parseInt($('#eBayQtyMainsl').val());
  eBayMainslRatio = parseInt($('#eBayMainslPercentage').val());

  //houzzQtyMainsl = parseInt($('#houzzQtyMainsl').val());
  //houzzMainslRatio = parseInt($('#houzzMainslPercentage').val());

  mellowWebQtyMainsl = parseInt($('#mellowWebQtyMainsl').val());
  mellowWebMainslRatio = parseInt($('#mellowWebMainslPercentage').val());

  bpmWebQtyMainsl = parseInt($('#bpmWebQtyMainsl').val());
  bpmWebMainslRatio = parseInt($('#bpmWebMainslPercentage').val());
  
  
  // Get total qty.
  leftoverQtyMainsl = parseInt($('#qtyAvailMainsl').val());
  totalStagePOQtyMainsl = parseInt($('#totalStagePOQtyMainsl').val());
  actualQtyAvailMainsl = qtyAvailMainsl - totalStagePOQtyMainsl;


  // Calculate leftover qtys.
  leftoverQtyMainsl = leftoverQtyMainsl - amazonQtyMainsl - overstockQtyMainsl - walmartQtyMainsl - wayfairQtyMainsl - homeDepotQtyMainsl;
  leftoverQtyMainsl = leftoverQtyMainsl - targetQtyMainsl - eBayQtyMainsl - bpmWebQtyBasc - mellowWebQtyMainsl;// - houzzQtyMainsl

  document.getElementById('leftoverQtyMainsl').value = (leftoverQtyMainsl - totalStagePOQtyMainsl) + " (" + leftoverQtyMainsl + ")";
  var lqm = document.getElementById('leftoverQtyMainsl');
  if ((leftoverQtyMainsl - totalStagePOQtyMainsl) < 0) {
    lqm.style.color = "#FBC02D";
    if (leftoverQtyMainsl < 0) { lqm.style.color = "#D32F2F"; }
  } else {
    lqm.style.color = "#000000";
  }
//  document.getElementById('leftoverQtyMainsl').value = leftoverQtyMainsl;

  amazonMainslRatio = Math.round((amazonQtyMainsl / actualQtyAvailMainsl) * 100);
  document.getElementById('amazonMainslPercentage').value = amazonMainslRatio;

  overstockMainslRatio = Math.round((overstockQtyMainsl / actualQtyAvailMainsl) * 100);
  document.getElementById('overstockMainslPercentage').value = overstockMainslRatio;

  walmartMainslRatio = Math.round((walmartQtyMainsl / actualQtyAvailMainsl) * 100);
  document.getElementById('walmartMainslPercentage').value = walmartMainslRatio;

  wayfairMainslRatio = Math.round((wayfairQtyMainsl / actualQtyAvailMainsl) * 100);
  document.getElementById('wayfairMainslPercentage').value = wayfairMainslRatio;

  homeDepotMainslRatio = Math.round((homeDepotQtyMainsl / actualQtyAvailMainsl) * 100);
  document.getElementById('homeDepotMainslPercentage').value = homeDepotMainslRatio;

  eBayMainslRatio = Math.round((eBayQtyMainsl / actualQtyAvailMainsl) * 100);
  document.getElementById('eBayMainslPercentage').value = eBayMainslRatio;

  targetMainslRatio = Math.round((targetQtyMainsl / actualQtyAvailMainsl) * 100);
  document.getElementById('targetMainslPercentage').value = targetMainslRatio;

  //houzzMainslRatio = Math.round((houzzQtyMainsl / actualQtyAvailMainsl) * 100);
  //document.getElementById('houzzMainslPercentage').value = houzzMainslRatio;

  bpmWebMainslRatio = Math.round((bpmWebQtyMainsl / actualQtyAvailMainsl) * 100);
  document.getElementById('bpmWebMainslPercentage').value = bpmWebMainslRatio;

  mellowWebMainslRatio = Math.round((mellowWebQtyMainsl / actualQtyAvailMainsl) * 100);
  document.getElementById('mellowWebMainslPercentage').value = mellowWebMainslRatio;



};
/*
function calculateQtyRatioSwcaft() {
  qtyAvailSwcaft = parseInt($('#qtyAvailSWCAFT').val());

  amazonQtySwcaft = parseInt($('#amazonQtySwcaft').val());
  amazonSwcaftRatio = parseInt($('#amazonSWCAFTPercentage').val());

  overstockQtySwcaft = parseInt($('#overstockQtySwcaft').val());
  overstockSwcaftRatio = parseInt($('#overstockSwcaftPercentage').val());

  walmartQtySwcaft = parseInt($('#walmartQtySwcaft').val());
  walmartSwcaftRatio = parseInt($('#walmartSwcaftPercentage').val());

  homeDepotQtySwcaft = parseInt($('#homeDepotQtySwcaft').val());
  homeDepotSwcaftRatio = parseInt($('#homeDepotSwcaftPercentage').val());

  wayfairQtySwcaft = parseInt($('#wayfairQtySwcaft').val());
  wayfairSwcaftRatio = parseInt($('#wayfairSwcaftPercentage').val());

  targetQtySwcaft = parseInt($('#targetQtySwcaft').val());
  targetSwcaftRatio = parseInt($('#targetSwcaftPercentage').val());

  eBayQtySwcaft = parseInt($('#eBayQtySwcaft').val());
  eBaySwcaftRatio = parseInt($('#eBaySwcaftPercentage').val());

  //houzzQtySwcaft = parseInt($('#houzzQtySwcaft').val());
  //houzzSwcaftRatio = parseInt($('#houzzSwcaftPercentage').val());

  bpmWebQtySwcaft = parseInt($('#bpmWebQtySwcaft').val());
  bpmWebSwcaftRatio = parseInt($('#bpmWebSwcaftPercentage').val());

  mellowWebQtySwcaft = parseInt($('#mellowWebQtySwcaft').val());
  mellowWebSwcaftRatio = parseInt($('#mellowWebSwcaftPercentage').val());

   
  // Get total qty.
  leftoverQtySwcaft = parseInt($('#qtyOnAvailSWCAFT').val());

  totalStagePOQtySWCAFT = parseInt($('#totalStagePOQtySWCAFT').val());
  actualQtyAvailSwcaft = qtyAvailSwcaft - totalStagePOQtySWCAFT;

  // Calculate leftover qtys.
  leftoverQtySwcaft = leftoverQtySwcaft - amazonQtySwcaft - overstockQtySwcaft - walmartQtySwcaft - wayfairQtySwcaft - homeDepotQtySwcaft;
  leftoverQtySwcaft = leftoverQtySwcaft - targetQtySwcaft - eBayQtySwcaft - bpmWebQtyBasc - mellowWebQtySwcaft;// - houzzQtySwcaft

  document.getElementById('leftoverQtySwcaft').value = (leftoverQtySwcaft - totalStagePOQtySWCAFT) + " (" + leftoverQtySwcaft +")";
  var lqs = document.getElementById('leftoverQtySwcaft');
  if ((leftoverQtySwcaft - totalStagePOQtySWCAFT) < 0) {
    lqs.style.color = "#FBC02D";
    if (leftoverQtySwcaft < 0) { lqs.style.color = "#D32F2F"; }
  } else {
    lqs.style.color = "#000000";
  }


  amazonSwcaftRatio = Math.round((amazonQtySwcaft / actualQtyAvailSwcaft) * 100);
  document.getElementById('amazonSwcaftPercentage').value = amazonSwcaftRatio;

  overstockSwcaftRatio = Math.round((overstockQtySwcaft / actualQtyAvailSwcaft) * 100);
  document.getElementById('overstockSwcaftPercentage').value = overstockSwcaftRatio;

  walmartSwcaftRatio = Math.round((walmartQtySwcaft / actualQtyAvailSwcaft) * 100);
  document.getElementById('walmartSwcaftPercentage').value = walmartSwcaftRatio;

  wayfairSwcaftRatio = Math.round((wayfairQtySwcaft / actualQtyAvailSwcaft) * 100);
  document.getElementById('wayfairSwcaftPercentage').value = wayfairSwcaftRatio;

  homeDepotSwcaftRatio = Math.round((homeDepotQtySwcaft / actualQtyAvailSwcaft) * 100);
  document.getElementById('homeDepotSwcaftPercentage').value = homeDepotSwcaftRatio;

  eBaySwcaftRatio = Math.round((eBayQtySwcaft / actualQtyAvailSwcaft) * 100);
  document.getElementById('eBaySwcaftPercentage').value = eBaySwcaftRatio;

  targetSwcaftRatio = Math.round((targetQtySwcaft / actualQtyAvailSwcaft) * 100);
  document.getElementById('targetSwcaftPercentage').value = targetSwcaftRatio;

  //houzzSwcaftRatio = Math.round((houzzQtySwcaft / actualQtyAvailSwcaft) * 100);
  //document.getElementById('houzzSwcaftPercentage').value = houzzSwcaftRatio;

  bpmWebSwcaftRatio = Math.round((bpmWebQtySwcaft / actualQtyAvailSwcaft) * 100);
  document.getElementById('bpmWebSwcaftPercentage').value = bpmWebSwcaftRatio;

  mellowWebSwcaftRatio = Math.round((mellowWebQtySwcaft / actualQtyAvailSwcaft) * 100);
  document.getElementById('mellowWebSwcaftPercentage').value = mellowWebSwcaftRatio;


}; */


function calculateQtyRatioZinusTracy() {
  qtyAvailZinusTracy = parseInt($('#qtyAvailZinusTracy').val());

  amazonQtyZinusTracy = parseInt($('#amazonQtyZinusTracy').val());
  amazonZinusTracyRatio = parseInt($('#amazonZinusTracyPercentage').val());

  overstockQtyZinusTracy = parseInt($('#overstockQtyZinusTracy').val());
  overstockZinusTracyRatio = parseInt($('#overstockZinusTracyPercentage').val());

  walmartQtyZinusTracy = parseInt($('#walmartQtyZinusTracy').val());
  walmartZinusTracyRatio = parseInt($('#walmartZinusTracyPercentage').val());

  homeDepotQtyZinusTracy = parseInt($('#homeDepotQtyZinusTracy').val());
  homeDepotZinusTracyRatio = parseInt($('#homeDepotZinusTracyPercentage').val());

  wayfairQtyZinusTracy = parseInt($('#wayfairQtyZinusTracy').val());
  wayfairZinusTracyRatio = parseInt($('#wayfairZinusTracyPercentage').val());

  targetQtyZinusTracy = parseInt($('#targetQtyZinusTracy').val());
  targetZinusTracyRatio = parseInt($('#targetZinusTracyPercentage').val());

  eBayQtyZinusTracy = parseInt($('#eBayQtyZinusTracy').val());
  eBayZinusTracyRatio = parseInt($('#eBayZinusTracyPercentage').val());

  //houzzQtyZinusTracy = parseInt($('#houzzQtyZinusTracy').val());
  //houzzZinusTracyRatio = parseInt($('#houzzZinusTracyPercentage').val());

  bpmWebQtyZinusTracy = parseInt($('#bpmWebQtyZinusTracy').val());
  bpmWebZinusTracyRatio = parseInt($('#bpmWebZinusTracyPercentage').val());

  mellowWebQtyZinusTracy = parseInt($('#mellowWebQtyZinusTracy').val());
  mellowWebZinusTracyRatio = parseInt($('#mellowWebZinusTracyPercentage').val());


  // Get total qty.
  leftoverQtyZinusTracy = parseInt($('#qtyOnAvailZinusTracy').val());

  totalStagePOQtyZinusTracy = parseInt($('#totalStagePOQtyZinusTracy').val());
  actualQtyAvailZinusTracy = qtyAvailZinusTracy - totalStagePOQtyZinusTracy;

  // Calculate leftover qtys.
  leftoverQtyZinusTracy = leftoverQtyZinusTracy - amazonQtyZinusTracy - overstockQtyZinusTracy - walmartQtyZinusTracy - wayfairQtyZinusTracy - homeDepotQtyZinusTracy;
  leftoverQtyZinusTracy = leftoverQtyZinusTracy - targetQtyZinusTracy - eBayQtyZinusTracy - bpmWebQtyBasc - mellowWebQtyZinusTracy;// - houzzQtyZinusTracy

  document.getElementById('leftoverQtyZinusTracy').value = (leftoverQtyZinusTracy - totalStagePOQtyZinusTracy) + " (" + leftoverQtyZinusTracy + ")";
  var lqs = document.getElementById('leftoverQtyZinusTracy');
  if ((leftoverQtyZinusTracy - totalStagePOQtyZinusTracy) < 0) {
    lqs.style.color = "#FBC02D";
    if (leftoverQtyZinusTracy < 0) { lqs.style.color = "#D32F2F"; }
  } else {
    lqs.style.color = "#000000";
  }


  amazonZinusTracyRatio = Math.round((amazonQtyZinusTracy / actualQtyAvailZinusTracy) * 100);
  document.getElementById('amazonZinusTracyPercentage').value = amazonZinusTracyRatio;

  overstockZinusTracyRatio = Math.round((overstockQtyZinusTracy / actualQtyAvailZinusTracy) * 100);
  document.getElementById('overstockZinusTracyPercentage').value = overstockZinusTracyRatio;

  walmartZinusTracyRatio = Math.round((walmartQtyZinusTracy / actualQtyAvailZinusTracy) * 100);
  document.getElementById('walmartZinusTracyPercentage').value = walmartZinusTracyRatio;

  wayfairZinusTracyRatio = Math.round((wayfairQtyZinusTracy / actualQtyAvailZinusTracy) * 100);
  document.getElementById('wayfairZinusTracyPercentage').value = wayfairZinusTracyRatio;

  homeDepotZinusTracyRatio = Math.round((homeDepotQtyZinusTracy / actualQtyAvailZinusTracy) * 100);
  document.getElementById('homeDepotZinusTracyPercentage').value = homeDepotZinusTracyRatio;

  eBayZinusTracyRatio = Math.round((eBayQtyZinusTracy / actualQtyAvailZinusTracy) * 100);
  document.getElementById('eBayZinusTracyPercentage').value = eBayZinusTracyRatio;

  targetZinusTracyRatio = Math.round((targetQtyZinusTracy / actualQtyAvailZinusTracy) * 100);
  document.getElementById('targetZinusTracyPercentage').value = targetZinusTracyRatio;

  //houzzZinusTracyRatio = Math.round((houzzQtyZinusTracy / actualQtyAvailZinusTracy) * 100);
  //document.getElementById('houzzZinusTracyPercentage').value = houzzZinusTracyRatio;

  bpmWebZinusTracyRatio = Math.round((bpmWebQtyZinusTracy / actualQtyAvailZinusTracy) * 100);
  document.getElementById('bpmWebZinusTracyPercentage').value = bpmWebZinusTracyRatio;

  mellowWebZinusTracyRatio = Math.round((mellowWebQtyZinusTracy / actualQtyAvailZinusTracy) * 100);
  document.getElementById('mellowWebZinusTracyPercentage').value = mellowWebZinusTracyRatio;


};


function calculateQtyRatioZinusChs() {
  qtyAvailZinusChs = parseInt($('#qtyAvailZinusChs').val());

  amazonQtyZinusChs = parseInt($('#amazonQtyZinusChs').val());
  amazonZinusChsRatio = parseInt($('#amazonZinusChsPercentage').val());

  overstockQtyZinusChs = parseInt($('#overstockQtyZinusChs').val());
  overstockZinusChsRatio = parseInt($('#overstockZinusChsPercentage').val());

  walmartQtyZinusChs = parseInt($('#walmartQtyZinusChs').val());
  walmartZinusChsRatio = parseInt($('#walmartZinusChsPercentage').val());

  homeDepotQtyZinusChs = parseInt($('#homeDepotQtyZinusChs').val());
  homeDepotZinusChsRatio = parseInt($('#homeDepotZinusChsPercentage').val());

  wayfairQtyZinusChs = parseInt($('#wayfairQtyZinusChs').val());
  wayfairZinusChsRatio = parseInt($('#wayfairZinusChsPercentage').val());

  targetQtyZinusChs = parseInt($('#targetQtyZinusChs').val());
  targetZinusChsRatio = parseInt($('#targetZinusChsPercentage').val());

  eBayQtyZinusChs = parseInt($('#eBayQtyZinusChs').val());
  eBayZinusChsRatio = parseInt($('#eBayZinusChsPercentage').val());

  //houzzQtyZinusChs = parseInt($('#houzzQtyZinusChs').val());
  //houzzZinusChsRatio = parseInt($('#houzzZinusChsPercentage').val());

  bpmWebQtyZinusChs = parseInt($('#bpmWebQtyZinusChs').val());
  bpmWebZinusChsRatio = parseInt($('#bpmWebZinusChsPercentage').val());

  mellowWebQtyZinusChs = parseInt($('#mellowWebQtyZinusChs').val());
  mellowWebZinusChsRatio = parseInt($('#mellowWebZinusChsPercentage').val());


  // Get total qty.
  leftoverQtyZinusChs = parseInt($('#qtyOnAvailZinusChs').val());

  totalStagePOQtyZinusChs = parseInt($('#totalStagePOQtyZinusChs').val());
  actualQtyAvailZinusChs = qtyAvailZinusChs - totalStagePOQtyZinusChs;

  // Calculate leftover qtys.
  leftoverQtyZinusChs = leftoverQtyZinusChs - amazonQtyZinusChs - overstockQtyZinusChs - walmartQtyZinusChs - wayfairQtyZinusChs - homeDepotQtyZinusChs;
  leftoverQtyZinusChs = leftoverQtyZinusChs - targetQtyZinusChs - eBayQtyZinusChs - bpmWebQtyBasc - mellowWebQtyZinusChs;// - houzzQtyZinusChs

  document.getElementById('leftoverQtyZinusChs').value = (leftoverQtyZinusChs - totalStagePOQtyZinusChs) + " (" + leftoverQtyZinusChs + ")";
  var lqs = document.getElementById('leftoverQtyZinusChs');
  if ((leftoverQtyZinusChs - totalStagePOQtyZinusChs) < 0) {
    lqs.style.color = "#FBC02D";
    if (leftoverQtyZinusChs < 0) { lqs.style.color = "#D32F2F"; }
  } else {
    lqs.style.color = "#000000";
  }


  amazonZinusChsRatio = Math.round((amazonQtyZinusChs / actualQtyAvailZinusChs) * 100);
  document.getElementById('amazonZinusChsPercentage').value = amazonZinusChsRatio;

  overstockZinusChsRatio = Math.round((overstockQtyZinusChs / actualQtyAvailZinusChs) * 100);
  document.getElementById('overstockZinusChsPercentage').value = overstockZinusChsRatio;

  walmartZinusChsRatio = Math.round((walmartQtyZinusChs / actualQtyAvailZinusChs) * 100);
  document.getElementById('walmartZinusChsPercentage').value = walmartZinusChsRatio;

  wayfairZinusChsRatio = Math.round((wayfairQtyZinusChs / actualQtyAvailZinusChs) * 100);
  document.getElementById('wayfairZinusChsPercentage').value = wayfairZinusChsRatio;

  homeDepotZinusChsRatio = Math.round((homeDepotQtyZinusChs / actualQtyAvailZinusChs) * 100);
  document.getElementById('homeDepotZinusChsPercentage').value = homeDepotZinusChsRatio;

  eBayZinusChsRatio = Math.round((eBayQtyZinusChs / actualQtyAvailZinusChs) * 100);
  document.getElementById('eBayZinusChsPercentage').value = eBayZinusChsRatio;

  targetZinusChsRatio = Math.round((targetQtyZinusChs / actualQtyAvailZinusChs) * 100);
  document.getElementById('targetZinusChsPercentage').value = targetZinusChsRatio;

  //houzzZinusChsRatio = Math.round((houzzQtyZinusChs / actualQtyAvailZinusChs) * 100);
  //document.getElementById('houzzZinusChsPercentage').value = houzzZinusChsRatio;

  bpmWebZinusChsRatio = Math.round((bpmWebQtyZinusChs / actualQtyAvailZinusChs) * 100);
  document.getElementById('bpmWebZinusChsPercentage').value = bpmWebZinusChsRatio;

  mellowWebZinusChsRatio = Math.round((mellowWebQtyZinusChs / actualQtyAvailZinusChs) * 100);
  document.getElementById('mellowWebZinusChsPercentage').value = mellowWebZinusChsRatio;


};