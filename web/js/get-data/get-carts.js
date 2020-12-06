function getCarts() {
  var userId = getUserid();
  var username = getUsername();

  fetch("https://localhost:5001/api/carts?userId=" + userId).then((result) =>
    result.json().then((json) => {
      var itemCardsElement = document.getElementById("cart-cards");
      itemCardsElement.innerHTML = "";

      if (json.length !== 0)
        json.forEach((element) => {
          itemCardsElement.innerHTML += `<div class="col-md-3 top_brand_left-1">
                                                  <div class="hover14 column">
                                                    <div class="agile_top_brand_left_grid">
                                                      <div class="agile_top_brand_left_grid1">
                                                        <figure>
                                                          <div class="snipcart-item block">
                                                            <div class="snipcart-thumb">
                                                            <p>Customer: ${
                                                              element.Customer
                                                                .Name
                                                            }</p>
                                                            <p>Items:<br/>${element.Items.map(
                                                              (item) =>
                                                                item.Name
                                                            ).join("<br/>")}</p>
                                                            </div>
                                                            <div class="snipcart-details top_brand_home_details">
                                                              <form action="#" method="post" aligh = "write">
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
      else
        itemCardsElement.innerHTML += `<div style="text-align:center">
                                            ${
                                              userId.length === 0
                                                ? "There is no carts"
                                                : username +
                                                  " doesn't have a cart"
                                            }
                                      </div>`;
    })
  );
}

function deleteCart(id) {
  fetch("https://localhost:5001/api/carts/" + id, {
    method: "DELETE",
  }).then(() => {
    getCarts();
    loadHeader();
  });
}

$(function () {
  getCarts();
});
