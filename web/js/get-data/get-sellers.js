function getSellers() {
  fetch("https://localhost:5001/api/sellers").then((result) =>
    result.json().then((json) => {
      var itemCardsElement = document.getElementById("seller-cards");
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
                                                        <p>Address: ${
                                                          element.Address
                                                        }</p>
                                                        <p>${
                                                          element.IsActive
                                                            ? "Seller is active"
                                                            : "Seller is not active"
                                                        }</p>
                                                        <p>Items:<br/>${element.Items.map(
                                                          (item) => item.Name
                                                        ).join("<br/>")}</p>
                                                        </div>
                                                        <div class="snipcart-details top_brand_home_details">
                                                          <form action="#" method="post" aligh = "write">
                                                              <input type="button" name="edit" value="Edit" class="button_Edit" onClick="location.href='edit seller.html?id=${
                                                                element.Id
                                                              }';">
                                                              <input type="hidden" name="cmd" value="_cart">
                                                              <input type="button" name="delete" value="Delete" class="button_Delete" onClick="deleteSeller('${
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
                                            There is no sellers
                                      </div>`;
    })
  );
}

function deleteSeller(id) {
  fetch("https://localhost:5001/api/sellers/" + id, {
    method: "DELETE",
  }).then(() => {
    getSellers();
    loadHeader();
  });
}

$(function () {
  getSellers();
});
