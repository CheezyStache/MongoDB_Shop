$(function () {
  var userId = getUserid();

  if (userId.length === 0) {
    document.getElementById("order-form").innerHTML = "User is not logged in";
    return;
  }

  fetch("https://localhost:5001/api/customers/" + userId).then((result) =>
    result.json().then((json) => {
      if (json.CartId == null || json.CartId.length === 0) {
        document.getElementById("order-form").innerHTML =
          "User doesn't have a cart";
        return;
      }

      fetch("https://localhost:5001/api/carts/" + json.CartId).then((result) =>
        result.json().then((json) => {
          var totalPrice = 0;

          json.Items.forEach((element) => {
            document.getElementById("order-form").innerHTML += `<div>${
              element.Name
            }: ${element.Price.toFixed(0)}</div>`;
            totalPrice += parseInt(element.Price);
          });

          document.getElementById(
            "order-form"
          ).innerHTML += `<br/><div>Total: ${totalPrice}</div>`;
          document.getElementById(
            "order-form"
          ).innerHTML += `<button id="grap">Create</button>`;
        })
      );
    })
  );
});
