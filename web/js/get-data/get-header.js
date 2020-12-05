$(function () {
  fetch("https://localhost:5001/api/items").then((result) =>
    result.json().then((json) => {
      json.forEach((element) => {
        document.getElementById(
          "items-list"
        ).innerHTML += `<li><a href="">${element.Name}</a></li>`;
      });
    })
  );

  fetch("https://localhost:5001/api/customers").then((result) =>
    result.json().then((json) => {
      json.forEach((element) => {
        document.getElementById(
          "customers-list"
        ).innerHTML += `<li><a href="">${element.Name}</a></li>`;
      });
    })
  );

  fetch("https://localhost:5001/api/sellers").then((result) =>
    result.json().then((json) => {
      json.forEach((element) => {
        document.getElementById(
          "sellers-list"
        ).innerHTML += `<li><a href="">${element.Name}</a></li>`;
      });
    })
  );

  fetch("https://localhost:5001/api/orders").then((result) =>
    result.json().then((json) => {
      json.forEach((element) => {
        document.getElementById(
          "orders-list"
        ).innerHTML += `<li><a href="">Customer: ${element.Customer.Name}</a></li>`;
      });
    })
  );

  fetch("https://localhost:5001/api/carts").then((result) =>
    result.json().then((json) => {
      json.forEach((element) => {
        document.getElementById(
          "carts-list"
        ).innerHTML += `<li><a href="">Customer: ${element.Customer.Name}</a></li>`;
      });
    })
  );
});
