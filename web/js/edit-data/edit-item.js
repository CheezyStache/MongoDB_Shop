$(function () {
  fetch("https://localhost:5001/api/sellers").then((result) =>
    result.json().then((json) => {
      var sellerElement = document.getElementById("seller");
      sellerElement.innerHTML = "";

      json.forEach((element) => {
        sellerElement.innerHTML += `<option value="${element.Id}">${element.Name}</option>`;
      });
    })
  );

  var itemId = getIdFromURL();

  fetch("https://localhost:5001/api/items/" + itemId).then((result) =>
    result.json().then((json) => {
      changeInput("item-name", json.Name);
      changeInput("item-count", json.Count);
      changeInput("item-price", json.Price.toFixed(0));
      changeInput("seller", json.Seller.Id);
    })
  );
});
