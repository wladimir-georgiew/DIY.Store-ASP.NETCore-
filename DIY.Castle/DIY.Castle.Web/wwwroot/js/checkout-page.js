function selectDeliveryCourrier() {
    var el = document.getElementById('courrierSelect');
    var econtOfficeContainer = document.getElementById('econtOfficeContainer');
    var speedyAddressContainer = document.getElementById('speedyAddressContainer');

    var deliveryOptionsLi = document.getElementById('delivery-option');

    if (el.value === 'Econt') {
        var officesSelect = document.getElementById('officesEcont');
        if (officesSelect.length <= 0) {
            $('#officesEcont').append($('<option>', {
                value: "null",
                text: "Няма офиси за избрания град"
            }));
        }

        deliveryOptionsLi.removeAttribute('hidden');
        speedyAddressContainer.setAttribute('hidden', '');

        var selectedDeliveryOption = '';
        $(".raido-option-choice").change(function () {
            selectedDeliveryOption = $(".raido-option-choice:checked").val();

            if (selectedDeliveryOption !== undefined &&
                selectedDeliveryOption !== '') {

                if (selectedDeliveryOption === 'Office') {
                    econtOfficeContainer.removeAttribute('hidden');
                    speedyAddressContainer.setAttribute('hidden', '');
                    speedyAddressContainer.removeAttribute('required');
                }
                else if (selectedDeliveryOption === 'Address') {
                    econtOfficeContainer.setAttribute('hidden', '');
                    speedyAddressContainer.removeAttribute('hidden');
                    speedyAddressContainer.setAttribute('required', '');
                }
            }
        });





    }
    else if (el.value === 'Speedy') {
        var officesSelect = document.getElementById('speedyAddressContainer');
        speedyAddressContainer.removeAttribute('hidden');
        econtOfficeContainer.setAttribute('hidden', '');
        deliveryOptionsLi.setAttribute('hidden', '');
        speedyAddressContainer.setAttribute('required', '');
    }
}