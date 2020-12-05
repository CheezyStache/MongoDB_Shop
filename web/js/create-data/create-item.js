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
});
