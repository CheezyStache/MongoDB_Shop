function getCustomers() {
  fetch("https://localhost:5001/api/customers").then((result) =>
    result.json().then((json) => {
      var itemCardsElement = document.getElementById("customer-cards");
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
                                                          <p>Name: ${
                                                            element.Name
                                                          }</p>
                                                          <p>Phone: ${
                                                            element.Phone
                                                          }</p>
                                                          <p>Cart: ${
                                                            element.CartId
                                                              ? "cart exists"
                                                              : "cart is empty"
                                                          }</p>
                                                          </div>
                                                          <div class="snipcart-details top_brand_home_details">
                                                            <form action="#" method="post" aligh = "write">
                                                                <input type="button" name="edit" value="Edit" class="button_Edit" onClick="location.href='edit customer.html?id=${
                                                                  element.Id
                                                                }';">
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
      else
        itemCardsElement.innerHTML += `<div style="text-align:center">
                                            There is no customers
                                      </div>`;
    })
  );
}

function deleteCustomer(id) {
  fetch("https://localhost:5001/api/customers/" + id, {
    method: "DELETE",
  }).then(() => {
    getCustomers();
    loadHeader();
  });
}

$(function () {
  getCustomers();
});
