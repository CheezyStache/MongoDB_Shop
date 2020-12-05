function getCustomers() {
  fetch("https://localhost:5001/api/customers").then((result) =>
    result.json().then((json) => {
      var itemCardsElement = document.getElementById("customer-cards");
      itemCardsElement.innerHTML = "";
      json.forEach((element) => {
        itemCardsElement.innerHTML += `<div class="col-md-3 top_brand_left-1">
                                                <div class="hover14 column">
                                                  <div class="agile_top_brand_left_grid">
                                                    <div class="agile_top_brand_left_grid1">
                                                      <figure>
                                                        <div class="snipcart-item block">
                                                          <div class="snipcart-thumb">
                                                          <p>Name: ${
                                                            element.Name
                                                          }</p>
                                                          <p>Phone: ${
                                                            element.Phone
                                                          }</p>
                                                          <p>CartId: ${
                                                            element.CartId ??
                                                            "cart is empty"
                                                          }</p>
                                                          </div>
                                                          <div class="snipcart-details top_brand_home_details">
                                                            <form action="#" method="post" aligh = "write">
                                                                <input type="submit" name="edit" value="Edit" class="button_Edit">
                                                                <input type="hidden" name="cmd" value="_cart">
                                                                <input type="button" name="delete" value="Delete" class="button_Delete" onClick="deleteCustomer('${
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

function deleteCustomer(id) {
  fetch("https://localhost:5001/api/customers?id=" + id, {
    method: "DELETE",
  }).then(() => {
    getCustomers();
  });
}

$(function () {
  getCustomers();
});