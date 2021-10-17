//Abstract Post Data Function
async function postData(url = '', data = {}) {
    // Default options are marked with *
    const response = await fetch(url, {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: {
            'Content-Type': 'application/json'
            // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: 'follow', // manual, *follow, error
        referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
        body: JSON.stringify(data) // body data type must match "Content-Type" header
    });
    return response.json(); // parses JSON response into native JavaScript objects
};



//Filling Econt Cities

fillEcontCitiesOptions();

async function fillEcontCitiesOptions() {
    let econtCities = await getCitiesPromise();
    console.log(econtCities);
    $.each(econtCities, function (i, city) {
        $('#citiesEcont').append($('<option>', {
            value: city.id,
            text: city.name
        }));
    });
}

function getCitiesPromise() {
    let getOfficesUrl = 'https://ee.econt.com/services/Nomenclatures/NomenclaturesService.getCities.json';

    return postData(getOfficesUrl, {
        "countryCode": "BGR"
    })
        .then(data => {
            return data.cities;
        });
};


//Filling Econt Cities END


//FILLING ECONT OFFICES
function getOfficesByCityIdPromise(cityId) {
    let getOfficesUrl = 'https://ee.econt.com/services/Nomenclatures/NomenclaturesService.getOffices.json';

    return postData(getOfficesUrl, {
        "countryCode": "BGR",
        "cityID": cityId
    });
};




$('#citiesEcont').change(async function () {
    $('#officesEcont').empty();
    var cityId = $("#citiesEcont option:selected").val();
    var officesAddresses = await getOfficesByCityIdPromise(cityId)
        .then(data => { return data.offices.map(a => a.address.fullAddress) });

    console.log(officesAddresses[0]);


    $.each(officesAddresses, function (i, address) {
        $('#officesEcont').append($('<option>', {
            value: address,
            text: address
        }));
    });

});

//FILLING ECONT OFFICES END