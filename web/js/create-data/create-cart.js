$(function () {
  fetch("https://localhost:5001/api/orders").then((result) =>
    result.json().then((json) => {
      var orderElement = document.getElementById("order");
      orderElement.innerHTML = "";

      json.forEach((element) => {
        orderElement.innerHTML += `<option value="${element.Id}">${element.Id}</option>`;
      });
    })
  );
});
