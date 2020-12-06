$(function () {
  fetch("https://localhost:5001/api/customers").then((result) =>
    result.json().then((json) => {
      var customerElement = document.getElementById("customer");
      customerElement.innerHTML = "";

      json.forEach((element) => {
        var jsonValue = JSON.stringify(element);

        customerElement.innerHTML += `<option value='${jsonValue}'>${element.Name}</option>`;
      });
    })
  );
});

function loginCookie(data) {
  var customer = JSON.parse(data.customer);

  document.cookie = "username=" + customer.Name;
  document.cookie = "userid=" + customer.Id;
}
