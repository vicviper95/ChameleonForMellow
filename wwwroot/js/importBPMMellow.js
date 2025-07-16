function openAttachment() {
  document.getElementById('attachment').click();
}

function fileSelected(input) {
 // document.getElementById('btnAttachment').value = "File: " + input.files[0].name;
  var result = csvJSON(input.files[0].name);

}


function csvJSON(csv) {
  const lines = csv.split('\n');
  const result = [];
  const headers = lines[0].split(',');

  for (let k = 0; k < headers.length; k++) {
    headers[k] = headers[k].replace(/\s/g, '');
  }

  for (let i = 1; i < lines.length; i++) {
    if (!lines[i])
      continue;
    const obj = {};
    const currentline = lines[i].split(',');

    for (let j = 0; j < headers.length; j++) {
      obj[headers[j]] = currentline[j];
    }
    result.push(obj);
  }
  return result;
}