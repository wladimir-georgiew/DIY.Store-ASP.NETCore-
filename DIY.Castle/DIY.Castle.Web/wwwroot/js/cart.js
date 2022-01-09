// Variables
var cartItemsCountSpan = document.getElementById('cart-items-count');

function itemAddedNotification(itemName) {
    toastr.success(`Добавихте ${itemName} в кошницата`);
}

function AddToBasket(quantity, id = null, name = null, price = null) {
    if (id === null && name === null && price === null) {
        var args = document.getElementById('selected-sku').value;
        var argsArr = args.split('/');
        id = argsArr[0];
        name = argsArr[1];
        price = argsArr[2];
    }


    var dynamicQuantity = document.getElementById('product-quantity')?.value;
    if (dynamicQuantity !== undefined && dynamicQuantity !== null) {
        quantity = dynamicQuantity;
    }

    fetch(`/Cart/AddToBasket/${id}/${quantity}`)
        .then((response) => {
            return response.json();
        })
        .then((response) => {
            return response.value;
        })
        .then((data) => {
            // Update the cart total products quantity
            cartItemsCountSpan.innerHTML = data.updatedTotalQuantity;
            cartItemsCountSpan.removeAttribute('hidden');
            // If item doesn't already exist => add new item
            if (data.itemAlreadyExists === false) {
                var itemsContainer = document.getElementById('cart-items');
                var li = document.createElement('li');
                li.setAttribute('id', `item-id-${id}`)
                var img = document.createElement('img');
                img.classList.add('cart-product-img');
                img.src = data.imageSource;
                var spanQty = document.createElement('span');
                spanQty.classList.add('cd-qty');
                spanQty.innerHTML = `${data.updatedQuantity}X `;
                var spanName = document.createElement('span');
                spanName.innerHTML = `${name}`;
                var div = document.createElement('div');
                div.classList.add('cd-price');
                div.innerHTML = `${price} лв.`;
                var a = document.createElement('a');
                a.className = 'cd-item-remove cd-img-replace';
                a.setAttribute('href', `/cart/Remove/${id}`);
                a.setAttribute('data-ajax', 'true');
                a.setAttribute('data-ajax-success', `deleteItem(this, '${name}')`);
                a.innerHTML = "Премахни";

                li.appendChild(img);
                li.appendChild(spanQty);
                li.appendChild(spanName);
                li.appendChild(div);
                li.appendChild(a);

                itemsContainer.appendChild(li);

                // HTML
                //<li>
                //    <img class="cart-product-img" src="@item.Product.ImagesSourcePaths[0]">
                //    <span class="cd-qty">@(item.Quantity)X</span> @item.Product.Name
                //    <div class="cd-price">@item.Product.Price</div>
                //    <a asp-controller="Cart" asp-action="Remove" asp-route-id="@item.Product.Id" data-ajax="true" data-ajax-success="deleteItem(this, '@item.Product.Name')"
                //    id = "remove-item-@item.Product.Id" class="cd-item-remove cd-img-replace" > Премахни</a >
                //</li>
            }
            // if it does => increase quantity
            else {
                var spanQty = document.querySelector(`#item-id-${id} > span.cd-qty`);
                spanQty.innerHTML = `${data.updatedQuantity}X `;
            }

            return data;
        })
        .then(data => {
            document.getElementById("total-price").innerHTML = `${data.updatedPrice} лв.`;

            return data;
        })
        .then(itemAddedNotification(name));
}

function deleteItem(form, itemName) {
    $(form).parentsUntil("ul").remove();
    toastr.error(`Премахнахте ${itemName} от кошницата`);

    var cartItemsCount = Number(cartItemsCountSpan.innerHTML);
    cartItemsCountSpan.innerHTML = cartItemsCount - 1;

    if (cartItemsCount - 1 <= 0) {
        cartItemsCountSpan.setAttribute('hidden', 'true');
    }
    

    updateTotalPrice();
}

function increaseQuantity(id) {
    document.getElementById(`quantity-item-${id}`).value++;

    updateSubTotalPrice(id);
    updateTotalPrice();
}
function decreaseQuantity(id) {
    if (document.getElementById(`quantity-item-${id}`).value > 1) {
        document.getElementById(`quantity-item-${id}`).value--;

        updateSubTotalPrice(id);
        updateTotalPrice();
    }
}

function updateTotalPrice() {
    fetch('/Cart/GetTotalPrice')
        .then((data) => {
            return data.json();
        })
        .then((response) => {
            document.getElementById("total-price").innerHTML = `${response.toFixed(2)} лв.`;
        });
}

function updateSubTotalPrice(id) {
    fetch(`/Cart/GetSubTotalPrice/${id}`)
        .then((data) => {
            return data.json();
        })
        .then((response) => {
            document.getElementById(`cart-subtotal-amount-${id}`).innerHTML = `${response.toFixed(2)} лв.`;
        });
}