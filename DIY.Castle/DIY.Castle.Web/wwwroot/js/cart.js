function deleteItem(form) {
    $(form).parentsUntil("tbody").remove();

    fetch('/Cart/GetTotalPrice')
        .then((data) => {
            return data.json();
        })
        .then((response) => {
            document.getElementById("cart-total-amount-foot").innerHTML = `${response.toFixed(2)}лв.`;
            document.getElementById("cart-total-amount-head").innerHTML = `${response.toFixed(2)}лв.`;
        });
}