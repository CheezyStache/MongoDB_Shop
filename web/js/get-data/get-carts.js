function getCarts() {
  fetch("https://localhost:5001/api/carts").then((result) =>
    result.json().then((json) => {
      var itemCardsElement = document.getElementById("cart-cards");
      itemCardsElement.innerHTML = "";
      json.forEach((element) => {
        itemCardsElement.innerHTML += `<div class="col-md-3 top_brand_left-1">
                                                  <div class="hover14 column">
                                                    <div class="agile_top_brand_left_grid">
                                                      <div class="agile_top_brand_left_grid1">
                                                        <figure>
                                                          <div class="snipcart-item block">
                                                            <div class="snipcart-thumb">
                                                            <p>CustomerId: ${
                                                              element.CustomerId
                                                            }</p>
                                                            <p>ItemIds: ${element.ItemIds.map(
                                                              (itemId) =>
                                                                itemId + ",\n"
                                                            )}</p>
                                                            </div>
                                                            <div class="snipcart-details top_brand_home_details">
                                                              <form action="#" method="post" aligh = "write">
                                                                  <input type="submit" name="edit" value="Edit" class="button_Edit">
                                                                  <input type="hidden" name="cmd" value="_cart">
                                                                  <input type="button" name="delete" value="Delete" class="button_Delete" onClick="deleteCart('${
                                                                    element.Id
                                                                  }')">
                                                              </form>
                                                            </div>
                                                          </div>
                                                        </figure>
                                                      </div>
                                                    </div>
                                                  </div>
                                                </div>`;
      });
    })
  );
}

function deleteCart(id) {
  fetch("https://localhost:5001/api/carts?id=" + id, {
    method: "DELETE",
  }).then(() => {
    getCarts();
  });
}

$(function () {
  getCarts();
});
