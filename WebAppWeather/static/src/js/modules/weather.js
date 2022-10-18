export async function getCurrentWeatherList(arr) {
    var request = "/api/weathers?";

    if(arr.length > 0) {
        for (const n of arr)
        request = request + "id=" + n + '&';
    request.slice(0, -1);

    return await fetch(request, {
        method: "GET",
        headers: {
            "Accept": "application/json",
            'Content-Type': 'application/json'
        }
    }).then(response => response.json());
    }

    [];
}

export async function findWeather(id) {
    var request = "/api/weathers/" + id;

    return await fetch(request, {
        method: "GET",
        headers: {
            "Accept": "application/json",
            'Content-Type': 'application/json'
        }
    }).then(response => response.json());
}

export async function findCity(searchString) {
    var request = "/api/weathers/cities/" + searchString;

    return await fetch(request, {
        method: "GET",
        headers: {
            "Accept": "application/json",
            'Content-Type': 'application/json'
        }
    }).then(response => response.json());
}

export async function findForecast(id) {
    var request = "/api/weathers/forecast/" + id;

    return await fetch(request, {
        method: "GET",
        headers: {
            "Accept": "application/json",
            'Content-Type': 'application/json'
        }
    }).then(response => response.json());
}