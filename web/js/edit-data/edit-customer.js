$(function () {
  var customerId = getIdFromURL();

  fetch("https://localhost:5001/api/customers/" + customerId).then((result) =>
    result.json().then((json) => {
      changeInput("customer-name", json.Name);
      changeInput("customer-phone", json.Phone);
    })
  );
});
