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

  var userId = getUserid();
  if (userId.length === 0)
    document.getElementById("logout").style = "display:none";
});

function loginCookie(data) {
  var customer = JSON.parse(data.customer);

  document.cookie = "username=" + customer.Name;
  document.cookie = "userid=" + customer.Id;

  alert("You logged in as " + customer.Name);
}

function logout() {
  document.cookie = "username=";
  document.cookie = "userid=";

  alert("You logged out");
  location.reload(true);
}
