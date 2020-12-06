$(function () {
  loadHeader();
});

function loadHeader() {
  fetch("https://localhost:5001/api/items").then((result) =>
    result.json().then((json) => {
      document.getElementById(
        "items-list"
      ).innerHTML = `<a href="item.html" class="acth"><h6 class="acth">All Items</h6></a>`;

      json.forEach((element) => {
        document.getElementById(
          "items-list"
        ).innerHTML += `<li><a href="">${element.Name}</a></li>`;
      });
    })
  );

  fetch("https://localhost:5001/api/customers").then((result) =>
    result.json().then((json) => {
      document.getElementById(
        "customers-list"
      ).innerHTML = `<a href="customer.html" class="acth"><h6 class="acth">All Customers</h6></a>`;

      json.forEach((element) => {
        document.getElementById(
          "customers-list"
        ).innerHTML += `<li><a href="">${element.Name}</a></li>`;
      });
    })
  );

  fetch("https://localhost:5001/api/sellers").then((result) =>
    result.json().then((json) => {
      document.getElementById(
        "sellers-list"
      ).innerHTML = `<a href="seller.html" class="acth"><h6 class="acth">All Sellers</h6></a>`;

      json.forEach((element) => {
        document.getElementById(
          "sellers-list"
        ).innerHTML += `<li><a href="">${element.Name}</a></li>`;
      });
    })
  );

  fetch("https://localhost:5001/api/orders").then((result) =>
    result.json().then((json) => {
      document.getElementById(
        "orders-list"
      ).innerHTML = `<a href="order.html" class="acth"><h6 class="acth">All Orders</h6></a>`;

      json.forEach((element) => {
        document.getElementById(
          "orders-list"
        ).innerHTML += `<li><a href="">Customer: ${element.Customer.Name}</a></li>`;
      });
    })
  );

  fetch("https://localhost:5001/api/carts").then((result) =>
    result.json().then((json) => {
      document.getElementById(
        "carts-list"
      ).innerHTML = `<a href="cart.html" class="acth"><h6 class="acth">All Carts</h6></a>`;

      json.forEach((element) => {
        document.getElementById(
          "carts-list"
        ).innerHTML += `<li><a href="">Customer: ${element.Customer.Name}</a></li>`;
      });
    })
  );

  var username = getUsername();
  if (username != null && username.length !== 0)
    document.getElementById("username").innerHTML = username;
}

function getUsername() {
  return document.cookie.replace(
    /(?:(?:^|.*;\s*)username\s*\=\s*([^;]*).*$)|^.*$/,
    "$1"
  );
}

function getUserid() {
  return document.cookie.replace(
    /(?:(?:^|.*;\s*)userid\s*\=\s*([^;]*).*$)|^.*$/,
    "$1"
  );
}
