function getItems() {
  fetch("https://localhost:5001/api/items").then((result) =>
    result.json().then((json) => {
      var itemCardsElement = document.getElementById("item-cards");
      itemCardsElement.innerHTML = "";
      json.forEach((element) => {
        itemCardsElement.innerHTML += `<div class="col-md-3 top_brand_left-1">
                                          <div class="hover14 column">
                                            <div class="agile_top_brand_left_grid">
                                              <div class="agile_top_brand_left_grid1">
                                                <figure>
                                                  <div class="snipcart-item block">
                                                    <div class="snipcart-thumb">
                                                    <p>Name: ${element.Name}</p>
                                                    <p>Count: ${
                                                      element.Count
                                                    }</p>
                                                    <p>Price: ${element.Price.toFixed(
                                                      2
                                                    )}</p>
                                                    <p>Seller: ${
                                                      element.Seller.Name
                                                    }</p>
                                                    </div>
                                                    <div class="snipcart-details top_brand_home_details">
                                                      <form action="#" method="post" aligh = "write">
                                                          <input type="button" name="edit" value="Edit" class="button_Edit" onClick="location.href='edit item.html?id=${
                                                            element.Id
                                                          }';">
                                                          <input type="hidden" name="cmd" value="_cart">
                                                          <input type="submit" name="submit" value="Add to cart" class="button_Add">
                                                          <input type="button" name="delete" value="Delete" class="button_Delete" onClick="deleteItem('${
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

function deleteItem(id) {
  fetch("https://localhost:5001/api/items/" + id, {
    method: "DELETE",
  }).then(() => {
    getItems();
  });
}

$(function () {
  getItems();
});
