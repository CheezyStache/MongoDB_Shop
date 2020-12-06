function formObj2Json(formArray) {
  //serialize data function
  var returnArray = {};
  var numberArray = ["Count", "Price"];
  for (var i = 0, len = formArray.length; i < len; i++) {
    if (numberArray.includes(formArray[i].name))
      returnArray[formArray[i].name] = parseInt(formArray[i].value);
    else returnArray[formArray[i].name] = formArray[i].value;
  }
  return returnArray;
}

async function sendDataToAPI(uri, data, callback) {
  fetch(uri, {
    method: "POST",
    body: data,
    headers: { "content-type": "application/json" },
  }).then(() => callback());
}
