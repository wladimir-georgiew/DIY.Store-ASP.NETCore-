function itemAddedNotification(itemName) {
    toastr.success(`Добавихте ${itemName} в кошницата`);
}

function deleteItem(form, itemName) {
    $(form).parentsUntil("tbody").remove();
    toastr.error(`Премахнахте ${itemName} от кошницата`);

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
            document.getElementById("cart-total-amount-foot").innerHTML = `${response.toFixed(2)} лв.`;
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