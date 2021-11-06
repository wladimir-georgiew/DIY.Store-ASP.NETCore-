function selectDeliveryCourrier() {
    var el = document.getElementById('courrierSelect');
    var econtOfficeContainer = document.getElementById('econtOfficeContainer');
    var speedyAddressContainer = document.getElementById('speedyAddressContainer');

    var deliveryOptionsLi = document.getElementById('delivery-option');
    console.log(el.value)

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

                if (selectedDeliveryOption === 'office') {
                    econtOfficeContainer.removeAttribute('hidden');
                    speedyAddressContainer.setAttribute('hidden', '');
                    console.log('office')
                }
                else if (selectedDeliveryOption === 'address') {
                    econtOfficeContainer.setAttribute('hidden', '');
                    speedyAddressContainer.removeAttribute('hidden');
                    console.log('addres')
                }
            }
        });





    }
    else if (el.value === 'Speedy') {
        var officesSelect = document.getElementById('speedyAddressContainer');
        speedyAddressContainer.removeAttribute('hidden');
        econtOfficeContainer.setAttribute('hidden', '');
        deliveryOptionsLi.setAttribute('hidden', '');
    }
}