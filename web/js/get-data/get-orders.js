function getOrders() {
  fetch("https://localhost:5001/api/orders").then((result) =>
    result.json().then((json) => {
      var itemCardsElement = document.getElementById("order-cards");
      itemCardsElement.innerHTML = "";
      json.forEach((element) => {
        itemCardsElement.innerHTML += `<div class="col-md-3 top_brand_left-1">
                                            <div class="hover14 column">
                                              <div class="agile_top_brand_left_grid">
                                                <div class="agile_top_brand_left_grid1">
                                                  <figure>
                                                    <div class="snipcart-item block">
                                                      <div class="snipcart-thumb">
                                                      <p>Date: ${new Date(
                                                        element.DateTimeStamp
                                                      ).toUTCString()}</p>
                                                      <p>IsCompleted: ${
                                                        element.IsCompleted
                                                      }</p>
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
                                                            <input type="button" name="delete" value="Delete" class="button_Delete" onClick="deleteOrder('${
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

function deleteOrder(id) {
  fetch("https://localhost:5001/api/orders/" + id, {
    method: "DELETE",
  }).then(() => {
    getOrders();
  });
}

$(function () {
  getOrders();
});
