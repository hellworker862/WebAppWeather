export async function getCurrentWeatherList() {
    var request = "/api/weathers?";

    for (const n of arguments)
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