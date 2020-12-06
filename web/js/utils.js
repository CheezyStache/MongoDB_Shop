
function formObj2Json(formArray) { //serialize data function
  var returnArray = {};
  var numberArray = ["Count", "Price"]
  for (var i = 0, len = formArray.length; i < len; i++) {
        if(numberArray.includes(formArray[i].name))
            returnArray[formArray[i].name] = parseInt(formArray[i].value);
        else
            returnArray[formArray[i].name] = formArray[i].value;
  }
  return returnArray;
}

function sendDataToAPI(uri, data, method) {
    const xhr = new XMLHttpRequest()
    xhr.open(method, uri)
    xhr.setRequestHeader('content-type', 'application/json')
    xhr.send(data) 
}