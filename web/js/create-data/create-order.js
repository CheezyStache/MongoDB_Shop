$(function () {
  fetch("https://localhost:5001/api/items").then((result) =>
    result.json().then((json) => {
      var itemElement = document.getElementById("item");
      itemElement.innerHTML = "";

      json.forEach((element) => {
        itemElement.innerHTML += `<option value="${element.Id}">${element.Name}</option>`;
      });
    })
  );
});
