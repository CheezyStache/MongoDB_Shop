$(function () {
  var sellerId = getIdFromURL();

  fetch("https://localhost:5001/api/sellers/" + sellerId).then((result) =>
    result.json().then((json) => {
      changeInput("seller-name", json.Name);
      changeInput("seller-address", json.Address);
      changeInput("seller-active", json.IsActive);
    })
  );
});
